import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { LikeListResponse } from "./types";
import type { AddCourtLikeInput } from "./schema";

export const favoritesService = {
  getAll: async (pageIndex: number = 1, pageSize: number = 10): Promise<LikeListResponse> => {
    return apiClient.get(API_ENDPOINTS.CUSTOMER.GET_ALL_LIKE_LIST, {
      params: { pageIndex, pageSize },
    }) as any;
  },

  add: async (data: AddCourtLikeInput): Promise<void> => {
    return apiClient.post(API_ENDPOINTS.CUSTOMER.ADD_COURT_LIKE, data) as any;
  },

  remove: async (courtId: string): Promise<void> => {
    return apiClient.delete(API_ENDPOINTS.CUSTOMER.DELETE_COURT_LIKE, {
      data: { courtId },
    }) as any;
  },
};
