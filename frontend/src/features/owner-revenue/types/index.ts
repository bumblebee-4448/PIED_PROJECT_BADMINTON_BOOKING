export interface DashboardResponse {
  currentRevenue: number;
  previousRevenue: number;
  comparisonPercentage: number;
  revenueDifference: number;
  comparisonStatus: "Increase" | "Decrease" | "NoChange";
  currentBookingCount: number;
  previousBookingCount: number;
  bookingComparisonPercentage: number;
  bookingDifference: number;
  bookingComparisonStatus: "Increase" | "Decrease" | "NoChange";
  period: string;
}

export interface DashboardFilter {
  courtId?: string;
  bookingId?: string;
  period: "Day" | "Week" | "Month" | "Quarter" | "Year";
  date?: string;
}

export interface GetCourtBookingsRequest {
  courtId: string;
  period: string;
  date?: string;
  pageIndex: number;
  pageSize: number;
}

export interface BookingSlotResponse {
  startTime: string;
  endTime: string;
  price: number;
}

export interface GetCourtBookingsResponse {
  bookingId: string;
  customerName: string;
  customerPhone: string;
  subCourtName: string;
  bookingDate: string;
  totalPrice: number;
  status: string;
  createdAt: string;
  slots: BookingSlotResponse[];
}

export interface PageResult<T> {
  items: T[];
  totalItems: number;
  pageIndex: number;
  pageSize: number;
}

// Keep old types for compatibility if needed, or remove them
export interface RevenueStats {
  date: string;
  amount: number;
  bookingCount: number;
}

export interface CourtRevenue {
  courtId: string;
  courtName: string;
  totalRevenue: number;
  bookingCount: number;
}

export interface OwnerRevenueResponse {
  totalRevenue: number;
  totalBookings: number;
  courts: CourtRevenue[];
  chartData: RevenueStats[];
}

export interface RevenueFilter {
  startDate?: string;
  endDate?: string;
  courtId?: string;
}
