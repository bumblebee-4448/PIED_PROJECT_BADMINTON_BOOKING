import { useQuery } from "@tanstack/react-query";
import { bookingsService } from "../services";

export function useTransactions(pageIndex = 1, pageSize = 100) {
  return useQuery({
    queryKey: ["transactions", pageIndex, pageSize],
    queryFn: () => bookingsService.getTransactions(pageIndex, pageSize),
    staleTime: 10000,
    refetchInterval: 30000,
    refetchIntervalInBackground: true,
  });
}
