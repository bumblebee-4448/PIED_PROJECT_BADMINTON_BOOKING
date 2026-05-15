import { useMemo } from "react";
import type { GetBookingResponse, BookingHistoryResponse, FilterStatus } from "../types";

interface FilteredBookingsResult {
  filteredItems: GetBookingResponse[];
  counts: {
    all: number;
    ongoing: number;
    completed: number;
    cancelled: number;
  };
}

/**
 * Extract filter & count logic ra khỏi page component.
 * Giữ page gọn, dễ test, dễ reuse.
 */
export function useFilteredBookings(
  data: BookingHistoryResponse | undefined,
  activeStatus: FilterStatus,
): FilteredBookingsResult {
  const filteredItems = useMemo(() => {
    if (!data?.items) return [];

    switch (activeStatus) {
      case "ongoing":
        return data.items.filter((item) => ["Pending", "Banked"].includes(item.status));
      case "completed":
        return data.items.filter((item) => item.status === "Completed");
      case "cancelled":
        return data.items.filter((item) =>
          ["Cancel", "Cancelled", "Refund", "RefundPending"].includes(item.status),
        );
      default:
        return data.items;
    }
  }, [data, activeStatus]);

  const counts = useMemo(() => {
    if (!data?.items) return { all: 0, ongoing: 0, completed: 0, cancelled: 0 };

    return {
      all: data.items.length,
      ongoing: data.items.filter((i) => ["Pending", "Banked"].includes(i.status)).length,
      completed: data.items.filter((i) => ["Complete", "Completed"].includes(i.status)).length,
      cancelled: data.items.filter((i) =>
        ["Cancel", "Cancelled", "Refund", "RefundPending"].includes(i.status),
      ).length,
    };
  }, [data]);

  return { filteredItems, counts };
}
