export interface AdminStats {
  totalUsers: number;
  totalOwners: number;
  totalCourts: number;
  revenueThisMonth: number;
  totalBookingsToday: number;
  visitorsToday: number;
  visitorsThisWeek: number;
}

export interface VisitorData {
  day: string;
  visitors: number;
}

export type ReportPriority = "high" | "medium" | "low";
export type ReportStatus = "pending" | "resolved" | "dismissed";

export interface SystemReport {
  id: string;
  status: ReportStatus;
  priority: ReportPriority;
  courtName: string;
  description: string;
  createdAt: string;
}

export interface PendingCourt {
  id: string;
  status: "pending" | "approved" | "rejected";
  courtName: string;
}

export type CashFlowType = "booking" | "refund" | "payout" | "fee";
export type CashFlowStatus = "done" | "processing" | "pending" | "failed";

export interface CashFlow {
  id: string;
  type: CashFlowType;
  status: CashFlowStatus;
  courtName: string;
  customerName?: string;
  ownerName?: string;
  amount: number;
  fee?: number;
  date: string;
}
