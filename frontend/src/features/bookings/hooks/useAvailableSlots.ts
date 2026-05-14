import { useQueries } from "@tanstack/react-query";
import { format } from "date-fns";
import { bookingsService } from "../services";
import type { SubCourt } from "../types";

export function useAvailableSlots(subCourts: SubCourt[], selectedDate: Date) {
  const dateStr = format(selectedDate, "yyyy-MM-dd");

  return useQueries({
    queries: subCourts.map((sub) => ({
      queryKey: ["available-slots", sub.subCourtId, dateStr],
      queryFn: async () => {
        const response = await bookingsService.getAvailableSlots(sub.subCourtId, dateStr);
        // Handle nested data property from API response
        const rawData = (response as any).data || response;
        if (!rawData || !Array.isArray(rawData)) return [];
        
        return rawData.map((s: any) => ({
          startTime: s.startTime || s.StartTime,
          endTime: s.endTime || s.EndTime,
          price: s.price ?? s.Price ?? 0,
          isAvailable: s.isAvailable !== undefined ? s.isAvailable : s.IsAvailable,
          subCourtId: sub.subCourtId
        }));
      },
      enabled: !!sub.subCourtId && !!dateStr,
      refetchInterval: 5000,
      staleTime: 0,
    })),
  });
}
