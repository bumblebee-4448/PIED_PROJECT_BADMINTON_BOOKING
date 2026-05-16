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
  // Lọc bỏ hoàn toàn Cancel/Cancelled để đồng nhất dữ liệu hiển thị và số lượng (counts)
  const baseItems = useMemo(() => {
    if (!data?.items) return [];
    return data.items.filter((item) => !["Cancel", "Cancelled"].includes(item.status));
  }, [data]);

  const filteredItems = useMemo(() => {
    switch (activeStatus) {
      case "ongoing":
        return baseItems.filter((item) => ["Pending", "Banked"].includes(item.status));
      case "completed":
        return baseItems.filter((item) => ["Complete", "Completed"].includes(item.status));
      case "cancelled":
        return baseItems.filter((item) =>
          ["Refund", "RefundPending"].includes(item.status),
        );
      default:
        return baseItems;
    }
  }, [baseItems, activeStatus]);

  const counts = useMemo(() => {
    return {
      all: baseItems.length,
      ongoing: baseItems.filter((i) => ["Pending", "Banked"].includes(i.status)).length,
      completed: baseItems.filter((i) => ["Complete", "Completed"].includes(i.status)).length,
      cancelled: baseItems.filter((i) =>
        ["Refund", "RefundPending"].includes(i.status),
      ).length,
    };
  }, [baseItems]);

  return { filteredItems, counts };
}
