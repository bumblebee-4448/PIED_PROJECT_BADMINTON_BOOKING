export type BookingStatus = "Pending" | "Banked" | "Cancel" | "Refund" | "Complete" | "RefundPending" | "Cancelled";

export interface BookingHistoryItem {
  id: string; // BookingDetailId
  bookingId: string; // Order ID
  courtName: string;
  courtAddress: string;
  date: string;
  startTime: string;
  endTime: string;
  subCourtName: string;
  price: number;
  status: BookingStatus;
  createdAt: string; // Order Date

  // Potential fields for UI polish
  courtImageUrl?: string;
  rating?: number;
  reviewSnippet?: string;
}

export interface BookingHistoryResponse {
  items: BookingHistoryItem[];
  totalItems: number;
  pageIndex: number;
  pageSize: number;
}

export interface CheckCancelResponse {
  success: boolean;
  message: string;
  data: boolean; // True if can cancel
}

// ─── UI-specific types ───────────────────────────────────
export type FilterStatus = "all" | "ongoing" | "completed" | "cancelled";

// ─── Constants ───────────────────────────────────────────
export const DEFAULT_PAGE_SIZE = 10;
