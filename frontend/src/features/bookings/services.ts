import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { 
  BookingHistoryResponse, 
  SubCourt, 
  AvailableSlot, 
  CreateBookingRequest, 
  CreateBookingResponse,
  GetBookingHistoryRequest
} from "./types";

export const bookingsService = {
  // Booking Management
  getAll: async (params: GetBookingHistoryRequest = { pageIndex: 1, pageSize: 10 }): Promise<BookingHistoryResponse> => {
    return apiClient.get(API_ENDPOINTS.BOOKING.GET_ALL, {
      params: { 
        PageIndex: params.pageIndex, 
        PageSize: params.pageSize,
      },
    }) as Promise<BookingHistoryResponse>;
  },

  cancel: async (bookingId: string): Promise<void> => {
    await apiClient.patch(API_ENDPOINTS.BOOKING.CANCEL, null, {
      params: { bookingId }
    });
  },

  // New Booking Operations
  getSubCourts: async (courtId: string): Promise<SubCourt[]> => {
    return apiClient.get(API_ENDPOINTS.COURT.GET_SUB_COURTS.replace("{courtId}", courtId)) as Promise<SubCourt[]>;
  },

  getAvailableSlots: async (subCourtId: string, date: string): Promise<AvailableSlot[]> => {
    return apiClient.get(API_ENDPOINTS.OWNER.GET_AVAILABLE_SLOTS, {
      params: { SubCourtId: subCourtId, Date: date }
    }) as Promise<AvailableSlot[]>;
  },

  create: async (data: CreateBookingRequest): Promise<CreateBookingResponse> => {
    return apiClient.post(API_ENDPOINTS.BOOKING.CREATE, data) as Promise<CreateBookingResponse>;
  },

  createByWallet: async (data: CreateBookingRequest): Promise<CreateBookingResponse> => {
    return apiClient.post(API_ENDPOINTS.BOOKING.CREATE_BY_WALLET, data) as Promise<CreateBookingResponse>;
  },

  refund: async (bookingId: string): Promise<void> => {
    await apiClient.patch(API_ENDPOINTS.BOOKING.REFUND, null, {
      params: { bookingId }
    });
  },
};
