import { useQuery } from "@tanstack/react-query";
import { bookingsService } from "../services";
import type { GetBookingResponse } from "../types";

export const useBookingStatus = (bookingId?: string, enabled?: boolean) => {
  return useQuery({
    queryKey: ["booking-status", bookingId],
    queryFn: async (): Promise<GetBookingResponse | null> => {
      if (!bookingId) return null;
      const response = await bookingsService.getAll({ pageIndex: 1, pageSize: 10 });
      // Handle both camelCase and PascalCase from BE
      const items = (response.items || (response as any).Items || []) as GetBookingResponse[];
      return items.find((item) => (item.bookingId || (item as any).BookingId) === bookingId) || null;
    },
    enabled: !!bookingId && enabled,
    refetchInterval: 30000,
    refetchIntervalInBackground: true,
  });
};
