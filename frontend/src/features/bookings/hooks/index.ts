import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { QUERY_KEYS } from "@/shared/constants";
import { bookingsService } from "../services";

export function useBookings(pageIndex: number = 1, pageSize: number = 10) {
  return useQuery({
    queryKey: [...QUERY_KEYS.BOOKINGS, pageIndex, pageSize],
    queryFn: () => bookingsService.getAll(pageIndex, pageSize),
    staleTime: 5 * 60 * 1000,
  });
}

export function useCheckCancel() {
  return useMutation({
    mutationFn: (bookingDetailId: string) => bookingsService.checkCancel(bookingDetailId),
  });
}

export function useCancelBooking() {
  const queryClient = useQueryClient();
  
  return useMutation({
    mutationFn: (bookingDetailId: string) => bookingsService.cancel(bookingDetailId),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.BOOKINGS });
    },
  });
}
