import { useNavigate } from "react-router";
import { Users, Building2, TrendingUp, Flag } from "lucide-react";
import {
  ADMIN_STATS,
  VISITOR_DATA,
  SYSTEM_REPORTS,
  CASH_FLOW,
} from "../data/mockData";
import { useAdminDashboard } from "../hooks/useAdminDashboard";
import { StatCard } from "../components/StatCard";
import { DashboardAlerts } from "../components/DashboardAlerts";
import { VisitorChart } from "../components/VisitorChart";
import { SystemReportsList } from "../components/SystemReportsList";
import { CashFlowTable } from "../components/CashFlowTable";
import { formatCurrency } from "@/lib/utils";

export function AdminDashboard() {
  const navigate = useNavigate();
  const { adminStats, isAdminStatsLoading, pendingCourts, pendingPayouts, highPriorityReports, pendingReports } =
    useAdminDashboard();

  if (isAdminStatsLoading) {
    return (
      <div className="p-8 flex items-center justify-center min-h-[400px]">
        <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-emerald-600"></div>
      </div>
    );
  }

  return (
    <div className="p-4 sm:p-6 max-w-7xl mx-auto">
      <div className="mb-6">
        <h1 style={{ fontWeight: 800, fontSize: "1.4rem", color: "#1a1a2e" }}>
          Admin Dashboard 🛡️
        </h1>
        <p style={{ color: "#9ca3af", fontSize: "0.85rem" }}>
          Tổng quan hệ thống SmashBook
        </p>
      </div>

      {/* Alerts */}
      <DashboardAlerts
        highPriorityReports={highPriorityReports}
        pendingCourts={pendingCourts}
        pendingPayouts={pendingPayouts}
      />

      {/* Stats grid */}
      <div className="grid grid-cols-2 lg:grid-cols-4 gap-4 mb-6">
        <StatCard
          label="Tổng Users"
          value={(adminStats?.totalUsers || 0).toLocaleString()}
          icon={<Users size={18} style={{ color: "#6366F1" }} />}
          color="#6366F1"
          sub="Đang hoạt động"
          onClick={() => navigate("/admin/users")}
        />
        <StatCard
          label="Sân đang hoạt động"
          value={adminStats?.totalCourtActive || 0}
          icon={<Building2 size={18} style={{ color: "#00897B" }} />}
          color="#00897B"
          sub={`${pendingCourts.length} chờ duyệt`}
          onClick={() => navigate("/admin/court-approvals")}
        />
        <StatCard
          label="Doanh thu tháng"
          value={formatCurrency(adminStats?.totalAmount || 0)}
          icon={<TrendingUp size={18} style={{ color: "#F59E0B" }} />}
          color="#F59E0B"
          sub="Tổng doanh thu hệ thống"
          onClick={() => navigate("/admin/transactions")}
        />
        <StatCard
          label="Báo cáo chờ xử lý"
          value={pendingReports.length}
          icon={<Flag size={18} style={{ color: "#EF4444" }} />}
          color="#EF4444"
          sub="Cần xử lý khẩn"
          onClick={() => navigate("/admin/court-approvals")}
        />
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-5 mb-5">
        {/* Visitor chart */}
        <VisitorChart
          data={VISITOR_DATA}
          visitorsToday={ADMIN_STATS.visitorsToday}
          visitorsThisWeek={ADMIN_STATS.visitorsThisWeek}
        />

        {/* Reports */}
        <SystemReportsList reports={SYSTEM_REPORTS} />
      </div>

      {/* Recent cash flow */}
      <CashFlowTable cashFlows={CASH_FLOW} />
    </div>
  );
}
