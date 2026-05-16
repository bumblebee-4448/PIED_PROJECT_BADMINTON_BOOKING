import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { 
  CreateFeedbackRequest, 
  DeleteFeedbackRequest, 
  Feedback, 
  FeedbackListResponse, 
  UpdateFeedbackRequest 
} from "./types";

type RawFeedback = {
  id?: string;
  Id?: string;
  feedbackId?: string;
  FeedbackId?: string;
  bookingId?: string;
  BookingId?: string;
  customerId?: string;
  CustomerId?: string;
  nameCustomer?: string;
  NameCustomer?: string;
  comment?: string | null;
  Comment?: string | null;
  rating?: number;
  Rating?: number;
  createdAt?: string;
  CreatedAt?: string;
};

export const feedbackService = {
  getByCourt: async (
    courtId: string,
    pageIndex = 1,
    pageSize = 10
  ): Promise<FeedbackListResponse> => {
    const response = (await apiClient.get(API_ENDPOINTS.FEEDBACK.GET_BY_COURT, {
      params: {
        CourtId: courtId,
        PageIndex: pageIndex,
        PageSize: pageSize,
      },
      skipToast: true,
    })) as unknown as FeedbackListResponse & {
      Items?: unknown[];
      TotalItems?: number;
      PageSize?: number;
      PageIndex?: number;
    };

    const rawItems = (response.items || response.Items || []) as RawFeedback[];
    const items = rawItems.map((item: RawFeedback): Feedback => ({
      id: (item.id || item.Id || "").toString(),
      feedbackId: (item.feedbackId || item.FeedbackId || item.id || item.Id || "").toString(),
      bookingId: (item.bookingId || item.BookingId || "").toString(),
      customerId: (item.customerId || item.CustomerId || "").toString(),
      nameCustomer: item.nameCustomer || item.NameCustomer || "Khách hàng",
      comment: item.comment ?? item.Comment ?? null,
      rating: item.rating ?? item.Rating ?? 0,
      createdAt: item.createdAt || item.CreatedAt || new Date().toISOString(),
    }));

    return {
      items,
      totalItems: response.totalItems ?? response.TotalItems ?? items.length,
      pageSize: response.pageSize ?? response.PageSize ?? pageSize,
      pageIndex: response.pageIndex ?? response.PageIndex ?? pageIndex,
    };
  },
  
  getByBookingId: async (bookingId: string): Promise<Feedback | null> => {
    try {
      const response = (await apiClient.get(
        API_ENDPOINTS.FEEDBACK.GET_BY_BOOKING,
        { 
          params: { bookingId },
          skipToast: true 
        }
      )) as unknown as RawFeedback;

      if (!response || (!response.id && !response.Id)) return null;

      return {
        id: (response.id || response.Id || "").toString(),
        feedbackId: (response.feedbackId || response.FeedbackId || response.id || response.Id || "").toString(),
        bookingId: (response.bookingId || response.BookingId || bookingId).toString(),
        customerId: (response.customerId || response.CustomerId || "").toString(),
        nameCustomer: response.nameCustomer || response.NameCustomer || "Khách hàng",
        comment: response.comment ?? response.Comment ?? null,
        rating: response.rating ?? response.Rating ?? 0,
        createdAt: response.createdAt || response.CreatedAt || new Date().toISOString(),
      };
    } catch (error) {
      // 404 is expected if the booking has no feedback yet
      return null;
    }
  },

  create: async (data: CreateFeedbackRequest): Promise<void> => {
    await apiClient.post(API_ENDPOINTS.FEEDBACK.CREATE, data, {
      skipToast: true,
    });
  },

  update: async (data: UpdateFeedbackRequest): Promise<void> => {
    await apiClient.patch(API_ENDPOINTS.FEEDBACK.UPDATE, data, {
      skipToast: true,
    });
  },

  delete: async (data: DeleteFeedbackRequest): Promise<void> => {
    await apiClient.delete(API_ENDPOINTS.FEEDBACK.DELETE, {
      data: {
        id: data.id,
        Id: data.id,
      },
      params: {
        id: data.id,
        Id: data.id,
      },
    });
  },
};
