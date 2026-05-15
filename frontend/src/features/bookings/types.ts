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

export interface SlotsResponse {
  slotId: string;
  startTime: string;
  endTime: string;
  price: number;
  date: string;
}

export interface GetBookingResponse {
  bookingId: string;
  finalPrice: number;
  status: string;
  courtName: string;
  address: string;
  slotsResponses: SlotsResponse[];
  phoneNumber: string;
  urlMap: string;
  date?: string; 
}

export interface BookingHistoryResponse {
  items: GetBookingResponse[];
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

// ─── API Types ───────────────────────────────────────────

export interface SubCourt {
  subCourtId: string;
  courtId: string;
  name: string;
}

export interface AvailableSlot {
  startTime: string; // HH:mm:ss
  endTime: string;   // HH:mm:ss
  price: number;
  isAvailable: boolean;
  type?: "Default" | "Booked" | "Blocked" | "Override" | string;
  reason?: string;
}

export interface SlotRequest {
  startTime: string;
  endTime: string;
}

export interface CreateBookingRequest {
  subCourtId: string;
  date: string; // yyyy-MM-dd
  code?: string;
  campaignId?: string;
  slots: SlotRequest[];
}

export interface BookingDetailItem {
  bookingDetailId: string;
  startTime: string;
  endTime: string;
  price: number;
}

export interface CreateBookingResponse {
  bookingId: string;
  totalPrice: number;
  expiredAt: string;
  status: string;
  slots: BookingDetailItem[];
  qrCodeUrl: string;
}

export interface GetBookingHistoryRequest {
  pageIndex?: number;
  pageSize?: number;
  date?: string;
}

// ─── Constants ───────────────────────────────────────────
export const DEFAULT_PAGE_SIZE = 10;
