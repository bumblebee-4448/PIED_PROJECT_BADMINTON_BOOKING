import { useQuery } from "@tanstack/react-query";
import { QUERY_KEYS } from "@/shared/constants";
import { bookingsService } from "../services";
import { DEFAULT_PAGE_SIZE } from "../types";

export function useBookings(pageIndex: number = 1, pageSize: number = DEFAULT_PAGE_SIZE) {
  return useQuery({
    queryKey: [...QUERY_KEYS.BOOKINGS, pageIndex, pageSize],
    queryFn: () => bookingsService.getAll(pageIndex, pageSize),
    staleTime: 5 * 60 * 1000,
  });
}
