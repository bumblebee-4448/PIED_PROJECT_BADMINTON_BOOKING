import { useQuery } from "@tanstack/react-query";
import { ownerRevenueService } from "../services";
import type { RevenueFilter, DashboardFilter, GetCourtBookingsRequest } from "../types";

export const useOwnerRevenue = (filters: RevenueFilter) => {
  return useQuery({
    queryKey: ["owner-revenue", filters],
    queryFn: () => ownerRevenueService.getRevenue(filters),
  });
};

export const useOwnerDashboard = (filters: DashboardFilter) => {
  return useQuery({
    queryKey: ["owner-dashboard", filters],
    queryFn: () => ownerRevenueService.getDashboard(filters),
  });
};

export const useCourtBookings = (request: GetCourtBookingsRequest) => {
  return useQuery({
    queryKey: ["court-bookings", request],
    queryFn: () => ownerRevenueService.getCourtBookings(request),
    enabled: !!request.courtId && request.courtId !== "skip",
  });
};
