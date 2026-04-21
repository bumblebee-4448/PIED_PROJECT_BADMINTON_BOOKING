export const API_ENDPOINTS = {
  /**
   * Auth endpoints - Dùng trong auth/services.ts và axios.ts (interceptor).
   * - LOGIN: POST /auth/login (authService.login)
   * - REGISTER: POST /auth/register (authService.register)
   * - LOGOUT: POST /auth/logout (authService.logout)
   * - REFRESH: POST /auth/refresh (axios interceptor - refresh token flow)
   */
  AUTH: {
    LOGIN: "/auth/login",
    REGISTER: "/auth/register",
    LOGOUT: "/auth/logout",
    REFRESH: "/auth/refresh",
  },
  /**
   * User endpoints - Không dùng BaseService (custom logic phức tạp).
   * - ME: Lấy thông tin user hiện tại (từ JWT)
   * - PROFILE: Update profile user hiện tại
   */
  USER: {
    ME: "/user/me",
    PROFILE: "/user/profile",
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
