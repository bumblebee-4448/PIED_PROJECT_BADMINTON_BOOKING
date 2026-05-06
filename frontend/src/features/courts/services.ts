import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { 
  CourtDetail, 
  CourtFilters, 
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
    return apiClient.get(API_ENDPOINTS.COURT.GET_BY_ID, {
      params: { courtId: id },
    });
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
