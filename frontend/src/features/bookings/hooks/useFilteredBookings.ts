import { useMemo } from "react";
import type { BookingHistoryItem, BookingHistoryResponse, FilterStatus } from "../types";

interface FilteredBookingsResult {
  filteredItems: BookingHistoryItem[];
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
        return data.items.filter((item) => item.status === "Banked");
      case "completed":
        return data.items.filter((item) => item.status === "Complete");
      case "cancelled":
        return data.items.filter((item) =>
          ["Cancel", "Cancelled", "RefundPending"].includes(item.status),
        );
      default:
        return data.items;
    }
  }, [data, activeStatus]);

  const counts = useMemo(() => {
    if (!data?.items) return { all: 0, ongoing: 0, completed: 0, cancelled: 0 };

    return {
      all: data.totalItems,
      ongoing: data.items.filter((i) => i.status === "Banked").length,
      completed: data.items.filter((i) => i.status === "Complete").length,
      cancelled: data.items.filter((i) =>
        ["Cancel", "Cancelled", "RefundPending"].includes(i.status),
      ).length,
    };
  }, [data]);

  return { filteredItems, counts };
}
