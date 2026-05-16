import { apiClient } from "@/lib/axios";
import type { 
  OwnerRevenueResponse, 
  RevenueFilter, 
  DashboardResponse, 
  DashboardFilter,
  GetCourtBookingsRequest,
  GetCourtBookingsResponse,
  PageResult
} from "../types";

export const ownerRevenueService = {
  // Old revenue service
  getRevenue: async (filters: RevenueFilter): Promise<OwnerRevenueResponse> => {
    const params = new URLSearchParams();
    if (filters.startDate) params.append("startDate", filters.startDate);
    if (filters.endDate) params.append("endDate", filters.endDate);
    if (filters.courtId) params.append("courtId", filters.courtId);

    const response = await apiClient.get(`/Revenue/owner?${params.toString()}`);
    return response as any; // apiClient already returns response.data.data
  },

  // New Dashboard Service
  getDashboard: async (filters: DashboardFilter): Promise<DashboardResponse> => {
    const params = new URLSearchParams();
    if (filters.courtId) params.append("CourtId", filters.courtId);
    if (filters.bookingId) params.append("BookingId", filters.bookingId);
    params.append("Period", filters.period);
    if (filters.date) params.append("Date", filters.date);

    const response = await apiClient.get(`/Owner/GetDashboard?${params.toString()}`);
    return response as any; // apiClient already returns response.data.data
  },

  // New Court Bookings Service
  getCourtBookings: async (request: GetCourtBookingsRequest): Promise<PageResult<GetCourtBookingsResponse>> => {
    const params = new URLSearchParams();
    params.append("CourtId", request.courtId);
    params.append("Period", request.period);
    if (request.date) params.append("Date", request.date);
    params.append("PageIndex", request.pageIndex.toString());
    params.append("PageSize", request.pageSize.toString());

    const response = await apiClient.get(`/Owner/GetCourtBookings?${params.toString()}`);
    return response as any; // apiClient already returns response.data.data
  }
};
