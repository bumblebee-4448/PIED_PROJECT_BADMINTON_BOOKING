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
   * Customer endpoints - Quản lý sân yêu thích.
   */
  CUSTOMER: {
    GET_ALL_LIKE_LIST: "/api/Customer/GetAllLikeList",
    ADD_COURT_LIKE: "/api/Customer/AddCourtLikeList",
    DELETE_COURT_LIKE: "/api/Customer/DeleteCourtLikeList",
    GET_ALL_BOOKING: "/api/Customer/GetAllBooking",
    CHECK_CANCEL_BOOKING: "/api/Customer/CheckCancelBooking",
    CANCEL_BOOKING: "/api/Customer/CancelBooking",
  },
  /**
   * Court endpoints
   */
  COURT: {
    GET_BY_FILTERS: "/Court/GetByFilters",
    GET_BY_ID: "/Court/GetCourtDetailsById",
  },
  MAP: {
    BOXING_BOX: "/Map/boxing-box",
    RADIUS: "/Map/radius",
    TEXT: "/Map/text",
  },
} as const;

/**
 * React Query keys - Dùng cho cache invalidation và query identification.
 * Mỗi key tương ứng với 1 data entity/collection.
 */
export const QUERY_KEYS = {
  ME: ["me"] as const, // User profile hiện tại
  FAVORITES: ["favorites"] as const, // Danh sách sân yêu thích
  BOOKINGS: ["bookings"] as const, // Danh sách lịch sử đặt sân
  COURTS: (filters?: any) => ["courts", filters] as const, // Danh sách sân (với filters)
  COURT_DETAIL: (id: string) => ["court", id] as const, // Chi tiết 1 sân
  MAP_SEARCH: (filters: any) => ["map-search", filters] as const, // Tìm kiếm bản đồ
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
