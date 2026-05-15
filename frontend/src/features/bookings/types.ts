export type BookingStatus = "Pending" | "Banked" | "Cancel" | "Refund" | "Completed" | "RefundPending" | "Cancelled";

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
  bookingDetailId?: string;
}

export interface SlotRequest {
  startTime: string;
  endTime: string;
}

export interface CreateBookingItemRequest {
  subCourtId: string;
  slots: SlotRequest[];
}

export interface CreateBookingRequest {
  date: string; // yyyy-MM-dd
  code?: string;
  campaignId?: string;
  items: CreateBookingItemRequest[];
}

export interface BookingDetailItem {
  bookingDetailId: string;
  subCourtId: string;
  subCourtName: string;
  startTime: string;
  endTime: string;
  price: number;
  createdAt: string;
}

export interface CreateBookingResponse {
  bookingId: string;
  bankName: string;
  bankAccount: string;
  totalPrice: number;
  expiredAt: string;
  status: string;
  items: BookingDetailItem[];
  qrCodeUrl: string;
  totalSlots: number;
  createdAt: string;
}

export interface GetBookingHistoryRequest {
  pageIndex?: number;
  pageSize?: number;
  date?: string;
}

// ─── Transaction Types ─────────────────────────────────────
export interface TransactionItem {
  id: string;
  type: string;
  amount: number;
  status: string;
  createdAt: string;
  updatedAt: string;
  bankRefCode?: string;
  bankAccountNumber?: string;
  bookingId?: string;
}

export interface TransactionResponse {
  items: TransactionItem[];
  totalItems: number;
  pageSize: number;
  pageIndex: number;
}

// ─── Constants ───────────────────────────────────────────
export const DEFAULT_PAGE_SIZE = 10;
