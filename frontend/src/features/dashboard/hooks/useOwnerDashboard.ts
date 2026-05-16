import { useQuery } from "@tanstack/react-query";
import { ownerDashboardService, type CourtBookingsParams } from "../services/ownerDashboardService";

export function useOwnerCourtBookings(params: CourtBookingsParams) {
  return useQuery({
    queryKey: ["owner-court-bookings", params],
    queryFn: () => ownerDashboardService.getCourtBookings(params),
    enabled: !!params.courtId,
  });
}

export function useOwnerDashboardStats(params: { courtId?: string; period?: string; date?: string }) {
  return useQuery({
    queryKey: ["owner-dashboard-stats", params],
    queryFn: () => ownerDashboardService.getDashboard(params),
    enabled: !!params.courtId,
  });
}
