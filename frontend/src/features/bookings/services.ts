import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { BookingHistoryResponse, CheckCancelResponse } from "./types";

export const bookingsService = {
  getAll: async (pageIndex: number = 1, pageSize: number = 10): Promise<BookingHistoryResponse> => {
    return apiClient.get(API_ENDPOINTS.CUSTOMER.GET_ALL_BOOKING, {
      params: { pageIndex, pageSize },
    }) as any;
  },

  checkCancel: async (bookingDetailId: string): Promise<CheckCancelResponse> => {
    return apiClient.post(API_ENDPOINTS.CUSTOMER.CHECK_CANCEL_BOOKING, {
      bookingDetailId,
    }) as any;
  },

  cancel: async (bookingDetailId: string): Promise<void> => {
    return apiClient.patch(API_ENDPOINTS.CUSTOMER.CANCEL_BOOKING, {
      bookingDetailId,
    }) as any;
  },
};
