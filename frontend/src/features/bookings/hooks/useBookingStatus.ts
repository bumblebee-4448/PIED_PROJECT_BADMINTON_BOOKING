import { useQuery } from "@tanstack/react-query";
import { bookingsService } from "../services";
import type { BookingHistoryItem } from "../types";

export const useBookingStatus = (bookingId?: string, enabled?: boolean) => {
  return useQuery({
    queryKey: ["booking-status", bookingId],
    queryFn: async (): Promise<BookingHistoryItem | null> => {
      if (!bookingId) return null;
      const response = await bookingsService.getAll({ pageIndex: 1, pageSize: 10 });
      // Handle both camelCase and PascalCase from BE
      const items = response.items || (response as any).Items || [];
      return items.find((item: any) => item.bookingId === bookingId) || null;
    },
    enabled: !!bookingId && enabled,
    refetchInterval: 3000,
    refetchIntervalInBackground: true,
  });
};
