import { useQuery } from "@tanstack/react-query";
import { ownerRevenueService } from "../services";
import type { RevenueFilter } from "../types";

export const useOwnerRevenue = (filters: RevenueFilter) => {
  return useQuery({
    queryKey: ["owner-revenue", filters],
    queryFn: () => ownerRevenueService.getRevenue(filters),
  });
};
