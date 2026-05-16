import { useQuery } from "@tanstack/react-query";
import { QUERY_KEYS } from "@/shared/constants";
import { bookingsService } from "../services";
import { DEFAULT_PAGE_SIZE, type BookingHistoryResponse, type GetBookingResponse } from "../types";

type RawBookingResponse = GetBookingResponse & {
  BookingId?: string;
  FinalPrice?: number;
  Status?: string;
  CourtName?: string;
  Address?: string;
  SlotsResponses?: GetBookingResponse["slotsResponses"];
  PhoneNumber?: string;
  UrlMap?: string;
  Date?: string;
  CourtId?: string;
  FeedbackId?: string;
  Rating?: number;
  Comment?: string | null;
  feedback?: {
    id?: string;
    Id?: string;
    feedbackId?: string;
    FeedbackId?: string;
    rating?: number;
    Rating?: number;
    comment?: string | null;
    Comment?: string | null;
  };
  Feedback?: {
    id?: string;
    Id?: string;
    feedbackId?: string;
    FeedbackId?: string;
    rating?: number;
    Rating?: number;
    comment?: string | null;
    Comment?: string | null;
  };
};

type RawBookingHistoryResponse = BookingHistoryResponse & {
  Items?: RawBookingResponse[];
  TotalItems?: number;
  PageIndex?: number;
  PageSize?: number;
};

function normalizeBooking(item: RawBookingResponse): GetBookingResponse {
  const feedback = item.feedback || item.Feedback;

  return {
    bookingId: item.bookingId || item.BookingId || "",
    finalPrice: item.finalPrice ?? item.FinalPrice ?? 0,
    status: item.status || item.Status || "Pending",
    courtName: item.courtName || item.CourtName || "Đơn hàng",
    address: item.address || item.Address || "Thông tin địa chỉ đang cập nhật",
    slotsResponses: item.slotsResponses || item.SlotsResponses || [],
    phoneNumber: item.phoneNumber || item.PhoneNumber || "N/A",
    urlMap: item.urlMap || item.UrlMap || "",
    date: item.date || item.Date,
    courtId: item.courtId || item.CourtId,
    feedbackId:
      item.feedbackId ||
      item.FeedbackId ||
      feedback?.feedbackId ||
      feedback?.FeedbackId ||
      feedback?.id ||
      feedback?.Id,
    rating: item.rating ?? item.Rating ?? feedback?.rating ?? feedback?.Rating,
    comment: item.comment ?? item.Comment ?? feedback?.comment ?? feedback?.Comment,
  };
}

export function useBookings(pageIndex: number = 1, pageSize: number = DEFAULT_PAGE_SIZE) {
  return useQuery({
    queryKey: [...QUERY_KEYS.BOOKINGS, pageIndex, pageSize],
    queryFn: async () => {
      const response = (await bookingsService.getAll({
        pageIndex,
        pageSize,
      })) as RawBookingHistoryResponse;
      // Normalize response from BE (handle PascalCase)
      return {
        items: (response.items || response.Items || []).map(normalizeBooking),
        totalItems: response.totalItems ?? response.TotalItems ?? 0,
        pageIndex: response.pageIndex ?? response.PageIndex ?? pageIndex,
        pageSize: response.pageSize ?? response.PageSize ?? pageSize,
      } as BookingHistoryResponse;
    },
    staleTime: 10000,
    refetchInterval: 3000,
    refetchIntervalInBackground: true,
  });
}
