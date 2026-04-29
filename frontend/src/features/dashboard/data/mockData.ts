import type { AdminStats, VisitorData, SystemReport, PendingCourt, CashFlow } from "../types";

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

export const REVENUE_WEEKLY = [
  { label: "T2", revenue: 1500000 },
  { label: "T3", revenue: 1800000 },
  { label: "T4", revenue: 2100000 },
  { label: "T5", revenue: 1900000 },
  { label: "T6", revenue: 3200000 },
  { label: "T7", revenue: 5500000 },
  { label: "CN", revenue: 4800000 },
];

export const REVENUE_MONTHLY = [
  { label: "Tuần 1", revenue: 15000000 },
  { label: "Tuần 2", revenue: 18000000 },
  { label: "Tuần 3", revenue: 21000000 },
  { label: "Tuần 4", revenue: 19000000 },
];

export const PEAK_HOURS = [
  { time: "17:00", bookingRate: 95 },
  { time: "18:00", bookingRate: 100 },
  { time: "19:00", bookingRate: 90 },
  { time: "20:00", bookingRate: 85 },
  { time: "06:00", bookingRate: 75 },
  { time: "07:00", bookingRate: 65 },
  { time: "16:00", bookingRate: 50 },
  { time: "21:00", bookingRate: 40 },
];

export const OWNER_COURTS = [
  {
    id: "c1",
    name: "Sân Cầu Lông A1",
    district: "Quận 1",
    rating: 4.8,
    totalRevenue: 25000000,
    totalBookings: 150,
    subCourts: [
      { id: "sc1", todayBookings: [{ status: "booked" }, { status: "banked" }] },
      { id: "sc2", todayBookings: [{ status: "complete" }] }
    ]
  },
  {
    id: "c2",
    name: "Sân Cầu Lông A2",
    district: "Quận 3",
    rating: 4.5,
    totalRevenue: 18000000,
    totalBookings: 120,
    subCourts: [
      { id: "sc3", todayBookings: [{ status: "booked" }] },
      { id: "sc4", todayBookings: [] }
    ]
  }
];

export const OWNER_REVIEWS = [
  { id: "r1", avatar: "A", customerName: "Nguyễn Văn A", rating: 5, comment: "Sân rất đẹp và sạch sẽ", courtName: "Sân A1", date: "Hôm nay" },
  { id: "r2", avatar: "B", customerName: "Trần Thị B", rating: 4, comment: "Giá hơi cao nhưng chất lượng tốt", courtName: "Sân A2", date: "Hôm qua" }
];
