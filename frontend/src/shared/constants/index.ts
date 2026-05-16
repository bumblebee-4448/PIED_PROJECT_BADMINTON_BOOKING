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
    ME: "/User/Me",
    PROFILE: "/User/UpdateProfile",
    CHANGE_PASSWORD: "/User/ChangePassword",
  },
  OWNER: {
    GET_AVAILABLE_SLOTS: "/Owner/GetAvailableSlots",
    GET_ALL_BOOKING: "/Owner/GetAvailableSlots",
  },
  /**
   * Customer endpoints - Quản lý sân yêu thích.
   */
  CUSTOMER: {
    GET_ALL_LIKE_LIST: "/Customer/GetAllLikeList",
    ADD_COURT_LIKE: "/Customer/AddCourtLikeList",
    DELETE_COURT_LIKE: "/Customer/DeleteCourtLikeList",
    CHECK_CANCEL_BOOKING: "/Customer/CheckCancelBooking",
    CANCEL_BOOKING: "/Customer/CancelBooking",
  },
  /**
   * Court endpoints
   */
  COURT: {
    GET_BY_FILTERS: "/Court/CustomerSearchCourtByFilters",
    GET_BY_ID: "/Court/CustomerGetCourtDetailsById{courtId}",
    GET_SUB_COURTS: "/Court/CustomerGetSubCourtByCourtId{courtId}",
  },
  FEEDBACK: {
    GET_BY_COURT: "/Feedback",
    GET_BY_BOOKING: "/Feedback/byBookingId",
    CREATE: "/Feedback",
    UPDATE: "/Feedback",
    DELETE: "/Feedback",
  },
  /**
   * Booking endpoints
   */
  BOOKING: {
    CREATE: "/Booking/CreateBooking",
    CREATE_BY_WALLET: "/Booking/CreateBookingByWallet",
    CANCEL: "/Booking/CancelBooking",
    REFUND: "/Booking/BookingRefund",
    GET_ALL: "/Booking/GetBooking",
  },
  MAP: {
    BOXING_BOX: "/Map/boxing_ox",
    RADIUS: "/Map/SearchByRadius",
    TEXT: "/Map/SeachByText",
  },
  /**
   * Wallet endpoints
   */
  WALLET: {
    GET_INFO: "/Wallet/GetInforWallet",
    ADD_INFO: "/Wallet/AddInforWallet",
    REMOVE_BANK: "/Wallet/RemoveBankWallet",
    ADD_BALANCE: "/Wallet/AddBalanceToWalletFromPayment",
    CHECK_STATUS: "/Wallet/CheckDepositStatus/{transactionId}",
  },
  /**
   * Withdrawal endpoints
   */
  WITHDRAWAL: {
    CREATE: "/Withdrawal/WithdrawalRequest",
    GET_MY: "/Withdrawal/GetWithdrawalRequest",
    ADMIN_GET: "/Withdrawal/AdminGetWithdrawalRequest",
    ADMIN_APPROVE: "/Withdrawal/AdminApprovedWithdrawalRequest",
    ADMIN_REJECT: "/Withdrawal/AdminRejectWithdrawalRequest",
  },
  /**
   * Transaction endpoints
   */
  TRANSACTION: {
    GET_MY: "/Transaction/GetTransaction",
    ADMIN_GET: "/Transaction/AdminGetTransaction",
  },
  /**
   * Report endpoints
   */
  REPORT: {
    CREATE_BOOKING: "/Report/CreateReportBookings",
    GET_BOOKING: "/Report/GetReportBookings",
    CONFIRM_BOOKING: "/Report/ConfirmReport",
  },
  SYSTEM_REPORT: {
    CREATE: "/SystemReport/CreateSystemReport",
    GET_ALL: "/SystemReport/GetSystemReport",
    REPLY: "/SystemReport/SubmitReportReply",
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
  COURTS: (filters?: unknown) => ["courts", filters] as const, // Danh sách sân (với filters)
  COURT_DETAIL: (id: string) => ["court", id] as const, // Chi tiết 1 sân
  COURT_FEEDBACKS: (courtId: string, pageIndex = 1, pageSize = 10) =>
    ["court-feedbacks", courtId, pageIndex, pageSize] as const,
  FEEDBACK_LOOKUP: (bookingId: string) => ["feedback-lookup", bookingId] as const,
  MAP_SEARCH: (filters: unknown) => ["map-search", filters] as const, // Tìm kiếm bản đồ
  WALLET_INFO: ["wallet-info"] as const, // Thông tin ví
  NOTIFICATIONS: (params?: any) => ["notifications", params] as const, // Thông báo
  UNREAD_COUNT: ["unread-count"] as const, // Số thông báo chưa đọc
  REPORTS_BOOKING: ["reports-booking"] as const, // Danh sách báo cáo đặt sân
  REPORTS_SYSTEM: ["reports-system"] as const, // Danh sách báo cáo hệ thống
} as const;

/**
 * Difficulty levels cho rituals - Dùng trong filters và forms.
 * RitualCatalog, ManageRitualList, RitualForm
 */
// export const DIFFICULTY_LEVELS = [
//   { value: "dễ", label: "Dễ" },
//   { value: "trung bình", label: "Trung bình" },
//   { value: "khó", label: "Khó" },
//   { value: "rất khó", label: "Rất khó" },
// ] as const;
