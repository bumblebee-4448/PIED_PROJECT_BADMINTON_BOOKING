import type { AdminStats, VisitorData, SystemReport, PendingCourt, CashFlow } from "./types";

export const ADMIN_STATS: AdminStats = {
  totalUsers: 1250,
  totalOwners: 45,
  totalCourts: 120,
  revenueThisMonth: 4500000000, // 4.5B
  totalBookingsToday: 85,
  visitorsToday: 1200,
  visitorsThisWeek: 8500,
};

export const VISITOR_DATA: VisitorData[] = [
  { day: "T2", visitors: 800 },
  { day: "T3", visitors: 950 },
  { day: "T4", visitors: 1100 },
  { day: "T5", visitors: 1050 },
  { day: "T6", visitors: 1300 },
  { day: "T7", visitors: 1600 },
  { day: "CN", visitors: 1400 },
];

export const SYSTEM_REPORTS: SystemReport[] = [
  {
    id: "1",
    status: "pending",
    priority: "high",
    courtName: "Sân Cầu Lông Bình Minh",
    description: "Khách hàng báo cáo sân bị dột nước khi trời mưa to.",
    createdAt: new Date().toISOString(),
  },
  {
    id: "2",
    status: "pending",
    priority: "medium",
    courtName: "Sân Cầu Lông Ngôi Sao",
    description: "Yêu cầu thay đổi thông tin giờ hoạt động nhưng chưa được duyệt.",
    createdAt: new Date().toISOString(),
  },
];

export const PENDING_COURTS: PendingCourt[] = [
  {
    id: "1",
    status: "pending",
    courtName: "Sân Cầu Lông Hải Yến",
  },
  {
    id: "2",
    status: "pending",
    courtName: "Sân Cầu Lông Trường Sơn",
  },
];

export const CASH_FLOW: CashFlow[] = [
  {
    id: "1",
    type: "booking",
    status: "done",
    courtName: "Sân Cầu Lông Bình Minh",
    customerName: "Nguyễn Văn A",
    amount: 200000,
    fee: 20000,
    date: new Date().toISOString(),
  },
  {
    id: "2",
    type: "payout",
    status: "pending",
    courtName: "Sân Cầu Lông Ngôi Sao",
    ownerName: "Trần Thị B",
    amount: 1500000,
    date: new Date().toISOString(),
  },
];
