// ─── Pagination ──────────────────────────────────────────
export interface PaginationMeta {
  totalItems: number;
  totalPages: number;
  itemsPerPage: number;
  currentPage: number;
  hasPreviousPage: boolean;
  hasNextPage: boolean;
}

export interface PaginatedResponse<T> {
  data: T[];
  meta: PaginationMeta;
}

// ─── Base filter params ──────────────────────────────────
export interface BaseFilterParams {
  page?: number;
  limit?: number;
  sortBy?: string;
  sortOrder?: "ASC" | "DESC";
  search?: string;
}

// ─── API Error ───────────────────────────────────────────
export interface ApiError {
  statusCode: number;
  message: string;
  error?: string;
  timestamp?: string;
  path?: string;
}

// ─── Select Option ───────────────────────────────────────
export interface SelectOption {
  id: string;
  name: string;
}

// ─── User Roles ──────────────────────────────────────────
export type UserRole = "user" | "admin";
