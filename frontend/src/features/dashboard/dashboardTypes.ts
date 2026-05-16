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

export interface SystemReport {
  id: string;
  title: string;
  reason: string;
  status: string;
  createdAt: string;
}

export interface PendingCourt {
  courtId: string;
  name: string;
  address: string;
  status: string;
  pictureUrl: string;
}

export interface RecentWithdrawal {
  id: string;
  userId: string;
  email: string;
  firstName: string;
  lastName: string;
  amount: number;
  status: string;
  createdAt: string;
}

export interface Transaction {
  id: string;
  type: string;
  amount: number;
  status: string;
  description?: string;
  createdAt: string;
  userName?: string;
}
