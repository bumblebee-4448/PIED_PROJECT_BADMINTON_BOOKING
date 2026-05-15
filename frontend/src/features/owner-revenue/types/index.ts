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
