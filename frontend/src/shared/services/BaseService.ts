/**
 * Type-only import: Chỉ import types, không import runtime code.
 * Giúp bundle size nhỏ hơn (Vite sẽ xoá trong production build).
 */
import type { AxiosInstance } from "axios";
import { apiClient } from "@/lib/axios";
import type { PaginatedResponse, SelectOption } from "@/shared/types";

/**
 * Base service config interface với 4 GENERIC TYPE PARAMETERS.
 *
 * Generic types: Giống như "placeholder" cho types.
 * VD: BaseServiceConfig<Ritual, CreateRitualDto, UpdateRitualDto, RitualFilter>
 * → TEntity = Ritual, TCreateDto = CreateRitualDto, ...
 *
 * Lợi ích: 1 interface dùng được cho NHIỀU entities (Ritual, User, Category, ...)
 */
export interface BaseServiceConfig<
  TEntity, // Type của entity chính (VD: Ritual, User)
  TCreateDto, // Type của data khi CREATE
  TUpdateDto, // Type của data khi UPDATE
  TFilterParams, // Type của params khi FILTER/SEARCH
> {
  endpoint: string; // Base URL path (VD: "/ritual", "/users")
  axios?: AxiosInstance; // Optional: Custom axios instance (mặc định dùng apiClient)

  /**
   * Optional method overrides: Cho phép GHI ĐÈ implementation mặc định.
   * Dấu "?" = optional property.
   *
   * Function type signature: (params) => ReturnType
   * VD: getAll?: (params?: TFilterParams) => Promise<PaginatedResponse<TEntity>>
   * ↑ Property "getAll" là 1 function nhận params, trả về Promise.
   */
  getAll?: (params?: TFilterParams) => Promise<PaginatedResponse<TEntity>>;
  getById?: (id: string | number) => Promise<TEntity>;
  create?: (data: TCreateDto) => Promise<TEntity>;
  update?: (id: string | number, data: TUpdateDto) => Promise<TEntity>;
  remove?: (id: string | number) => Promise<void>;
  getSelectOptions?: () => Promise<SelectOption[]>;
}

/**
 * Base service interface (return type của factory function).
 *
 * Khác với Config interface ở trên:
 * - Config: Tất cả methods đều OPTIONAL (?)
 * - Service: Tất cả methods đều REQUIRED (không có ?)
 *
 * Lý do: Config dùng để NHẬN input (có thể thiếu), Service là OUTPUT (đầy đủ).
 */
export interface BaseService<TEntity, TCreateDto, TUpdateDto, TFilterParams> {
  getAll: (params?: TFilterParams) => Promise<PaginatedResponse<TEntity>>;
  getById: (id: string | number) => Promise<TEntity>;
  create: (data: TCreateDto) => Promise<TEntity>;
  update: (id: string | number, data: TUpdateDto) => Promise<TEntity>;
  remove: (id: string | number) => Promise<void>;
  getSelectOptions: () => Promise<SelectOption[]>;
}

/**
 * FACTORY FUNCTION: Function tạo ra object (service).
 * Pattern này thay thế OOP class-based approach.
 *
 * Senior pattern: Functional + Composition (không dùng OOP class).
 * Lợi ích:
 * - Đơn giản hơn (không có this, new, extends)
 * - Dễ test hơn (pure functions)
 * - Tree-shaking tốt hơn
 *
 * Generic với DEFAULT VALUES:
 * TCreateDto = Partial<TEntity> → Nếu không truyền, mặc định = Partial<TEntity>
 * Partial<T>: Utility type biến TẤT CẢ properties thành optional.
 * VD: Partial<{name: string, age: number}> = {name?: string, age?: number}
 *
 * Record<string, unknown>: Object với key là string, value là bất kỳ type nào.
 * VD: { search: "test", page: 1, isActive: true }
 *
 * @example
 * ```ts
 * const ritualService = createBaseService<Ritual>({
 *   endpoint: '/ritual',
 *   remove: (id) => apiClient.patch(`/ritual/${id}/soft-remove`)
 * })
 * ```
 */
export function createBaseService<
  TEntity,
  TCreateDto = Partial<TEntity>, // Default value cho generic type
  TUpdateDto = Partial<TEntity>,
  TFilterParams = Record<string, unknown>,
>(
  config: BaseServiceConfig<TEntity, TCreateDto, TUpdateDto, TFilterParams>,
): BaseService<TEntity, TCreateDto, TUpdateDto, TFilterParams> {
  /**
   * Nullish coalescing operator (??):
   * config.axios ?? apiClient
   * → Nếu config.axios là null/undefined, dùng apiClient.
   * Khác với || : ?? chỉ check null/undefined, không check "", 0, false.
   */
  const axios = config.axios ?? apiClient;
  const endpoint = config.endpoint;

  /**
   * Return object với methods.
   * Mỗi property là 1 ARROW FUNCTION.
   *
   * Pattern: config.method ?? defaultImplementation
   * → Nếu config có override method, dùng override.
   * → Nếu không, dùng implementation mặc định.
   */
  return {
    /**
     * GETALL Method
     * async function: Trả về Promise, dùng await được.
     * params?: TFilterParams = Optional parameter (có thể không truyền).
     *
     * axios.get<PaginatedResponse<TEntity>>(...)
     * ↑ Generic type cho axios: Khai báo response data type.
     *
     * ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
     * ⚠️ TẠI SAO PHẢI DÙNG: as unknown as Promise<...>
     * ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
     *
     * VẤN ĐỀ:
     * 1. Axios types mặc định: axios.get() → Promise<AxiosResponse<T>>
     *    (có .data, .status, .headers, ...)
     *
     * 2. NHƯNG: Axios interceptor (lib/axios.ts) đã UNWRAP .data:
     *    return response.data?.data !== undefined
     *      ? response.data.data    // ← Trả về data trực tiếp
     *      : response.data;
     *
     * 3. Runtime thực tế: axios.get() → Promise<T> (đã unwrap)
     * 4. TypeScript nghĩ: axios.get() → Promise<AxiosResponse<T>>
     * 5. → MÂU THUẪN! Runtime ≠ TypeScript types
     *
     * GIẢI PHÁP:
     * "as unknown as Promise<T>" = DOUBLE TYPE ASSERTION
     * - Bước 1: "as unknown" → Ép về type universal (tương thích mọi type)
     * - Bước 2: "as Promise<T>" → Ép sang type đích
     *
     * TypeScript không cho ép trực tiếp Promise<AxiosResponse<T>> → Promise<T>
     * vì không tương thích. Phải qua "unknown" làm trung gian.
     *
     * TẠI SAO AN TOÀN?
     * Vì ta ĐÃ BIẾT chắc chắn interceptor unwrap .data → runtime = Promise<T>.
     * Chỉ cần báo TypeScript: "Tao biết tao làm gì, tin tao đi!"
     *
     * 📚 Chi tiết: code-references/type-assertion-explanation.md
     */
    getAll:
      config.getAll ??
      (async (params?: TFilterParams) => {
        return axios.get<PaginatedResponse<TEntity>>(endpoint, {
          params,
        }) as unknown as Promise<PaginatedResponse<TEntity>>;
      }),

    /**
     * GETBYID Method
     * Template literal: `${endpoint}/${id}` = "/ritual/123"
     * → Nối string động với biến.
     *
     * "as unknown as": Xem giải thích chi tiết ở getAll method ↑
     */
    getById:
      config.getById ??
      (async (id: string | number) => {
        return axios.get<TEntity>(
          `${endpoint}/${id}`,
        ) as unknown as Promise<TEntity>;
      }),

    /**
     * CREATE Method
     * axios.post(url, data) → Gửi POST request với body = dto.
     *
     * "as unknown as": Xem giải thích chi tiết ở getAll method ↑
     */
    create:
      config.create ??
      (async (dto: TCreateDto) => {
        return axios.post<TEntity>(
          endpoint,
          dto,
        ) as unknown as Promise<TEntity>;
      }),

    /**
     * UPDATE Method
     * axios.put(url, data) → Gửi PUT request (update toàn bộ entity).
     *
     * "as unknown as": Xem giải thích chi tiết ở getAll method ↑
     */
    update:
      config.update ??
      (async (id: string | number, dto: TUpdateDto) => {
        return axios.put<TEntity>(
          `${endpoint}/${id}`,
          dto,
        ) as unknown as Promise<TEntity>;
      }),

    /**
     * REMOVE Method
     * Promise<void>: Function không return gì (chỉ delete).
     * await axios.delete(...): Đợi request hoàn thành, không cần response.
     */
    remove:
      config.remove ??
      (async (id: string | number) => {
        await axios.delete(`${endpoint}/${id}`);
      }),

    /**
     * GETSELECTOPTIONS Method
     * GET /endpoint/select → Trả về [{value, label}] cho dropdown.
     *
     * "as unknown as": Xem giải thích chi tiết ở getAll method ↑
     */
    getSelectOptions:
      config.getSelectOptions ??
      (async () => {
        return axios.get<SelectOption[]>(
          `${endpoint}/select`,
        ) as unknown as Promise<SelectOption[]>;
      }),
  };
}
