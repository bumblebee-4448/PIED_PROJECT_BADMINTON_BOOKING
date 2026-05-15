import { apiClient } from "@/lib/axios";
import type { OwnerRevenueResponse, RevenueFilter } from "../types";

export const ownerRevenueService = {
  getRevenue: async (filters: RevenueFilter): Promise<OwnerRevenueResponse> => {
    const params = new URLSearchParams();
    if (filters.startDate) params.append("startDate", filters.startDate);
    if (filters.endDate) params.append("endDate", filters.endDate);
    if (filters.courtId) params.append("courtId", filters.courtId);

    const response = await apiClient.get(`/Revenue/owner?${params.toString()}`);
    return response.data.data;
  },
};
