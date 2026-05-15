import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { 
  CourtDetail, 
  CourtFilters, 
  CourtFeedback,
  CourtFeedbackListResponse,
  CourtListResponse, 
  BoundingBoxRequest, 
  MapSearchResponse, 
  RadiusRequest, 
  TextSearchRequest 
} from "./types";

export const courtService = {
  // Lấy danh sách sân kèm theo bộ lọc (Search theo tên, địa chỉ, phân trang)
  getCourts: async (filters: CourtFilters): Promise<CourtListResponse> => {
    return apiClient.get(API_ENDPOINTS.COURT.GET_BY_FILTERS, {
      params: {
        // Tham số Keyword sẽ được Server dùng để lọc theo Tên hoặc Địa chỉ sân
        Keyword: filters.search || undefined, 
        PageIndex: filters.page || 1,
        PageSize: filters.limit || 10,
      },
    });
  },

  // Lấy thông tin chi tiết của một sân cụ thể bằng ID
  getCourtById: async (id: string): Promise<CourtDetail> => {
    return apiClient.get(API_ENDPOINTS.COURT.GET_BY_ID.replace("{courtId}", id));
  },

  getCourtFeedbacks: async (
    courtId: string,
    pageIndex = 1,
    pageSize = 10
  ): Promise<CourtFeedbackListResponse> => {
    const response = (await apiClient.get(API_ENDPOINTS.FEEDBACK.GET_BY_COURT, {
      params: {
        CourtId: courtId,
        PageIndex: pageIndex,
        PageSize: pageSize,
      },
      skipToast: true,
    })) as unknown as CourtFeedbackListResponse & {
      Items?: unknown[];
      TotalItems?: number;
      PageSize?: number;
      PageIndex?: number;
    };

    const rawItems = response.items || response.Items || [];
    const items = rawItems.map((item: any): CourtFeedback => ({
      nameCustomer: item.nameCustomer || item.NameCustomer || "Khách hàng",
      comment: item.comment ?? item.Comment ?? null,
      rating: item.rating ?? item.Rating ?? 0,
      createdAt: item.createdAt || item.CreatedAt,
    }));

    return {
      items,
      totalItems: response.totalItems ?? response.TotalItems ?? items.length,
      pageSize: response.pageSize ?? response.PageSize ?? pageSize,
      pageIndex: response.pageIndex ?? response.PageIndex ?? pageIndex,
    };
  },

  // Map Search APIs
  searchByBoundingBox: async (request: BoundingBoxRequest): Promise<MapSearchResponse> => {
    return apiClient.get(API_ENDPOINTS.MAP.BOXING_BOX, { params: request });
  },

  searchByRadius: async (request: RadiusRequest): Promise<MapSearchResponse> => {
    return apiClient.get(API_ENDPOINTS.MAP.RADIUS, { params: request });
  },

  searchByText: async (request: TextSearchRequest): Promise<MapSearchResponse> => {
    return apiClient.get(API_ENDPOINTS.MAP.TEXT, { params: request });
  },
};
