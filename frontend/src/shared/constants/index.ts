export const API_ENDPOINTS = {
  /**
   * Auth endpoints - Dùng trong auth/services.ts và axios.ts (interceptor).
   * - LOGIN: POST /auth/login (authService.login)
   * - REGISTER: POST /auth/register (authService.register)
   * - LOGOUT: POST /auth/logout (authService.logout)
   * - REFRESH: POST /auth/refresh (axios interceptor - refresh token flow)
   */
  AUTH: {
    LOGIN: "/User/Login",
    REGISTER: "/User/Register",
    LOGOUT: "/User/Logout",
    VERIFY_OTP: "/User/VerifyOtp",
    FORGOT_PASSWORD: "/User/ForgotPassword",
    RESET_PASSWORD: "/User/ResetPassword",
    REFRESH: "/User/Refresh", // Placeholder if backend adds it later
  },
  /**
   * User endpoints - Không dùng BaseService (custom logic phức tạp).
   * - ME: Lấy thông tin user hiện tại (từ JWT)
   * - PROFILE: Update profile user hiện tại
   */
  USER: {
    ME: "/User/GetMe",
    PROFILE: "/User/UpdateProfile",
    CHANGE_PASSWORD: "/User/ChangePassword",
  },
  /**
   * Ritual endpoints - Dùng với BaseService (rituals/services.ts).
   * BaseService tự động xử lý tất cả CRUD operations:
   * - getAll() → GET /ritual
   * - getById(id) → GET /ritual/:id
   * - create() → POST /ritual
   * - update(id) → PUT /ritual/:id
   * - remove(id) → PATCH /ritual/:id/soft-remove (custom override)
   * - getSelectOptions() → GET /ritual/select
   */
  RITUAL: {
    BASE: "/ritual",
  },
  /**
   * Ritual Category endpoints - Dùng với BaseService (rituals/services.ts).
   * BaseService tự động xử lý, giống như RITUAL.
   */
  RITUAL_CATEGORY: {
    BASE: "/ritual-category",
  },
  /**
   * Customer endpoints - Quản lý sân yêu thích.
   */
  CUSTOMER: {
    GET_ALL_LIKE_LIST: "/api/Customer/GetAllLikeList",
    ADD_COURT_LIKE: "/api/Customer/AddCourtLikeList",
    DELETE_COURT_LIKE: "/api/Customer/DeleteCourtLikeList",
  },
} as const;

/**
 * React Query keys - Dùng cho cache invalidation và query identification.
 * Mỗi key tương ứng với 1 data entity/collection.
 */
export const QUERY_KEYS = {
  ME: ["me"] as const, // User profile hiện tại
  RITUALS: ["rituals"] as const, // Danh sách rituals (với filters)
  RITUAL_DETAIL: (id: string) => ["ritual", id] as const, // Chi tiết 1 ritual
  RITUAL_CATEGORIES: ["ritual-categories"] as const, // Danh sách categories
  FAVORITES: ["favorites"] as const, // Danh sách sân yêu thích
} as const;

/**
 * Difficulty levels cho rituals - Dùng trong filters và forms.
 * RitualCatalog, ManageRitualList, RitualForm
 */
export const DIFFICULTY_LEVELS = [
  { value: "dễ", label: "Dễ" },
  { value: "trung bình", label: "Trung bình" },
  { value: "khó", label: "Khó" },
  { value: "rất khó", label: "Rất khó" },
] as const;
