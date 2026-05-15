import { useQuery } from "@tanstack/react-query";
import { QUERY_KEYS } from "@/shared/constants";
import { bookingsService } from "../services";
import { DEFAULT_PAGE_SIZE, type BookingHistoryResponse } from "../types";

export function useBookings(pageIndex: number = 1, pageSize: number = DEFAULT_PAGE_SIZE) {
  return useQuery({
    queryKey: [...QUERY_KEYS.BOOKINGS, pageIndex, pageSize],
    queryFn: async () => {
      const response = await bookingsService.getAll({ pageIndex, pageSize });
      // Normalize response from BE (handle PascalCase)
      return {
        items: response.items || (response as any).Items || [],
        totalItems: response.totalItems ?? (response as any).TotalItems ?? 0,
        pageIndex: response.pageIndex ?? (response as any).PageIndex ?? pageIndex,
        pageSize: response.pageSize ?? (response as any).PageSize ?? pageSize,
      } as BookingHistoryResponse;
    },
    staleTime: 0,
    refetchInterval: 3000,
    refetchIntervalInBackground: true,
  });
}
