export type ReportStatus = "Pending" | "Confirmed" | "Completed";

// Booking Report
export interface CreateReportBookingRequest {
  reason: string;
  bookingId: string;
}

export interface ReportBookingResponse {
  reportBookingId: string;
  reason: string;
  customerId: string;
  bookingId: string;
  courtId: string;
  status: ReportStatus;
}

export interface GetReportBookingsRequest {
  reportBookingId?: string;
  reason?: string;
  customerId?: string;
  bookingId?: string;
  courtId?: string;
  status?: string;
  pageIndex?: number;
  pageSize?: number;
}

// System Report
export interface CreateSystemReportRequest {
  title: string;
  reason: string;
}

export interface SystemReportResponse {
  id: string;
  title: string;
  reason: string;
  status: ReportStatus;
}

export interface GetSystemReportRequest {
  pageIndex?: number;
  pageSize?: number;
}

export interface SubmitReportReplyRequest {
  id: string;
}
