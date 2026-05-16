import { apiClient } from "@/lib/axios";

export interface BookingSlot {
  startTime: string;
  endTime: string;
  price: number;
}

export interface CourtBooking {
  bookingId: string;
  customerName: string;
  customerPhone: string;
  courtName: string;
  bookingDate: string;
  totalPrice: number;
  status: string;
  slots: BookingSlot[];
  createdAt: string;
}

export interface PageResult<T> {
  items: T[];
  totalItems: number;
  pageIndex: number;
  pageSize: number;
}

export interface CourtBookingsParams {
  courtId: string;
  period?: string;
  date?: string;
  pageIndex?: number;
  pageSize?: number;
}

export interface OwnerDashboardStats {
  currentRevenue: number;
  previousRevenue: number;
  comparisonPercentage: number;
  revenueDifference: number;
  comparisonStatus: string;
  currentBookingCount: number;
  previousBookingCount: number;
  bookingComparisonPercentage: number;
  bookingDifference: number;
  bookingComparisonStatus: string;
  period: string;
}

// NOTE: axios interceptor ở lib/axios.ts đã tự unwrap response.data.data
// nên các hàm này chỉ cần return `response` trực tiếp (không `.data.data`)

export const ownerDashboardService = {
  getCourtBookings: async (params: CourtBookingsParams): Promise<PageResult<CourtBooking>> => {
    const response = await apiClient.get("/Owner/GetCourtBookings", {
      params: {
        courtId: params.courtId,
        period: params.period ?? "month",
        date: params.date,
        pageIndex: params.pageIndex ?? 1,
        pageSize: params.pageSize ?? 50,
      },
    });
    // Interceptor đã unwrap data.data → response là PageResult trực tiếp
    return response as unknown as PageResult<CourtBooking>;
  },

  getDashboard: async (params: { courtId?: string; period?: string; date?: string }): Promise<OwnerDashboardStats> => {
    const response = await apiClient.get("/Owner/GetDashboard", { params });
    return response as unknown as OwnerDashboardStats;
  },
};
