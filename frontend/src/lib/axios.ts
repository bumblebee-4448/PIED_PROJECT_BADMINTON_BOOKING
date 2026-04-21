import axios from "axios";
import { toast } from "sonner";

import { env } from "@/lib/env";
import { useAuthStore } from "@/features/auth/store";
import { API_ENDPOINTS } from "@/shared/constants";

// ─── Axios Instance ──────────────────────────────────────
export const apiClient = axios.create({
  baseURL: env.API_URL,
  timeout: 15_000,
  headers: { "Content-Type": "application/json" },
  withCredentials: true, // gửi cookie refreshToken
});

// ─── Request Interceptor: đính kèm JWT ──────────────────
apiClient.interceptors.request.use((config) => {
  const token = useAuthStore.getState().accessToken;
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

// ─── Response Interceptor: refresh token + normalize ─────

/**
 * ⚠️ REFRESH TOKEN QUEUE PATTERN
 *
 * 🎯 Mục đích:
 * Khi có NHIỀU requests cùng lúc bị 401 (token expired), chỉ gọi
 * /auth/refresh MỘT LẦN duy nhất, các requests khác đợi trong hàng đợi.
 *
 * 🐛 Vấn đề nếu không dùng queue:
 * - User mở app, có 5 requests GET /rituals, /profile, /notifications...
 * - Cùng lúc token expired → cả 5 requests nhận 401
 * - Cả 5 requests đều gọi /auth/refresh cùng lúc
 * - Backend nhận refresh request đầu → tạo token mới, INVALIDATE token cũ
 * - 4 requests sau dùng token cũ (đã invalid) → fail!
 *
 * ✅ Giải pháp với queue:
 * - Request đầu tiên: set isRefreshing = true, gọi /auth/refresh
 * - Các requests sau: thấy isRefreshing = true → vào queue, đợi
 * - Khi refresh xong: processQueue() → retry tất cả requests với token mới
 *
 * 📚 Học thêm: https://www.rfc-editor.org/rfc/rfc6749#section-6
 */
let isRefreshing = false;
let failedQueue: Array<{
  resolve: (token: string) => void;
  reject: (error: unknown) => void;
}> = [];

/**
 * Xử lý hàng đợi requests đang chờ refresh token
 * @param error - Lỗi nếu refresh fail
 * @param token - Token mới nếu refresh success
 */
const processQueue = (error: unknown, token: string | null) => {
  failedQueue.forEach((p) => {
    if (token) p.resolve(token);
    else p.reject(error);
  });
  failedQueue = [];
};

apiClient.interceptors.response.use(
  (response) => {
    // BE wraps: { statusCode, message, data, timestamp }
    // → trả về data bên trong
    return response.data?.data !== undefined
      ? response.data.data
      : response.data;
  },
  async (error) => {
    const originalRequest = error.config;

    /**
     * ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
     * 🔐 REFRESH TOKEN LOGIC - Xử lý khi token hết hạn
     * ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
     *
     * ⚠️ QUAN TRỌNG: Chỉ refresh khi:
     * 1. Response status = 401 (Unauthorized)
     * 2. Request KHÔNG PHẢI là /auth/* endpoints
     * 3. Chưa retry lần nào (_retry flag)
     *
     * ❌ KHÔNG refresh khi:
     * - POST /auth/login → 401 (sai mật khẩu)
     * - POST /auth/register → 401
     * - POST /auth/logout → 401
     * - POST /auth/refresh → 401 (refresh token expired)
     */
    const notAuthReqs = !originalRequest.url?.includes("/auth/");
    const is401 = error.response?.status === 401;
    const notRetriedYet = !originalRequest._retry;

    if (is401 && notAuthReqs && notRetriedYet) {
      // ─────────────────────────────────────────────────────────
      // CASE 1: Đang có request khác đang refresh → vào queue chờ
      // ─────────────────────────────────────────────────────────
      if (isRefreshing) {
        return new Promise((resolve, reject) => {
          // Lưu resolve/reject vào queue để chờ
          failedQueue.push({ resolve, reject });

          // Promise này sẽ "treo" cho đến khi:
          // - processQueue(null, newToken) gọi resolve(newToken)
          // - hoặc processQueue(error, null) gọi reject(error)
        }).then((token) => {
          // ← token này đến từ: processQueue(null, newToken)
          //   gọi resolve(newToken)
          //   → Promise resolve với value = newToken
          //   → .then((token) => ...) nhận được newToken

          // Khi refresh xong, retry request này với token mới
          originalRequest.headers.Authorization = `Bearer ${token}`;
          return apiClient(originalRequest);
        });
      }

      // ─────────────────────────────────────────────────────────
      // CASE 2: Request đầu tiên → thực hiện refresh
      // ─────────────────────────────────────────────────────────
      originalRequest._retry = true;
      isRefreshing = true;

      try {
        // ─────────────────────────────────────────────────────
        // Gọi API refresh token
        // ─────────────────────────────────────────────────────
        // ⚠️ CRITICAL: Dùng axios THUẦN, KHÔNG dùng apiClient
        // Lý do: apiClient sẽ đi qua interceptor này → risk infinite loop
        // withCredentials: true → Gửi httpOnly cookie chứa refreshToken
        const res = await axios.post(
          `${env.API_URL}${API_ENDPOINTS.AUTH.REFRESH}`,
          {},
          { withCredentials: true },
        );

        // Backend có thể trả về format khác nhau:
        // Option 1: { data: { accessToken: "..." } }
        // Option 2: { accessToken: "..." }
        const newToken: string =
          res.data?.data?.accessToken ?? res.data?.accessToken;

        // ─────────────────────────────────────────────────────
        // Lưu token mới vào store (giữ nguyên role)
        // ─────────────────────────────────────────────────────
        useAuthStore.getState().setAuth({
          accessToken: newToken,
          role: useAuthStore.getState().role,
        });

        // ─────────────────────────────────────────────────────
        // Xử lý hàng đợi: Cho các requests đang chờ retry với token mới
        // ─────────────────────────────────────────────────────
        processQueue(null, newToken);

        // ─────────────────────────────────────────────────────
        // Retry request hiện tại với token mới
        // ─────────────────────────────────────────────────────
        originalRequest.headers.Authorization = `Bearer ${newToken}`;
        return apiClient(originalRequest);
      } catch (refreshError) {
        // ═════════════════════════════════════════════════════
        // ❌ REFRESH FAILED → User phải login lại
        // ═════════════════════════════════════════════════════
        // Lý do có thể:
        // - RefreshToken đã expire (quá 7 ngày không dùng app)
        // - RefreshToken bị revoke (logout từ device khác)
        // - Server có issues
        processQueue(refreshError, null); // Reject tất cả requests trong queue
        useAuthStore.getState().clearAuth();
        toast.error("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.");
        window.location.href = "/login";
        return Promise.reject(refreshError);
      } finally {
        // Luôn reset flag cho lần sau
        isRefreshing = false;
      }
    }

    // ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    // 🔴 XỬ LÝ LỖI CHUNG (400, 403, 404, 500...)
    // ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    // Normalize error message từ server
    const message =
      error.response?.data?.message ?? error.message ?? "Đã có lỗi xảy ra";

    // Toast error cho user TRỪ KHI là logout endpoint (useLogout hook tự toast)
    const isLogoutEndpoint = originalRequest.url?.includes("/auth/logout");

    if (!isLogoutEndpoint) {
      toast.error(message);
    }

    return Promise.reject(error);
  },
);
