import { apiClient } from "@/lib/axios";

import type { SystemReport, PendingCourt, RecentWithdrawal, Transaction } from "../dashboardTypes";

export interface StatPoint {
  date: string;
  count: number;
}

export interface AdminDashboardResponse {
  totalUsers: number;
  totalCourtActive: number;
  totalAmount: number;
  totalCompletedBookingsAmount: number;
  userTimeline: StatPoint[];
  courtTimeline: StatPoint[];
  
  pendingCourtsCount: number;
  pendingPayoutsCount: number;
  pendingReportsCount: number;

  pendingCourts: PendingCourt[];
  recentWithdrawals: RecentWithdrawal[];
  recentSystemReports: SystemReport[];
  recentTransactions: Transaction[];
}

export const adminDashboardService = {
  getAdminStats: async (period: string = "Day"): Promise<AdminDashboardResponse> => {
    const response = await apiClient.get("/Dashboard/DashboardAdmin", {
      params: { period }
    });
    return response as any;
  }
};
