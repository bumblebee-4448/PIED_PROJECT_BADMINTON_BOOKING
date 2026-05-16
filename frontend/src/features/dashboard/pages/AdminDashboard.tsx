import { useNavigate } from "react-router";
import { Users, Building2, Clock, Bell } from "lucide-react";
import { useAdminDashboard } from "../hooks/useAdminDashboard";
import { StatCard } from "../components/StatCard";
import { DashboardAlerts } from "../components/DashboardAlerts";
import { AdminTimelineChart } from "../components/AdminTimelineChart";
import { SystemReportsList } from "../components/SystemReportsList";
import { CashFlowTable } from "../components/CashFlowTable";
import { cn } from "@/lib/utils";

export function AdminDashboard() {
  const navigate = useNavigate();
  const { 
    adminStats, 
    isAdminStatsLoading, 
    pendingCourts, 
    recentWithdrawals, 
    highPriorityReports, 
    period,
    setPeriod,
    isError,
    error
  } = useAdminDashboard();

  if (isAdminStatsLoading) {
    return (
      <div className="p-8 flex items-center justify-center min-h-[400px]">
        <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-emerald-600"></div>
      </div>
    );
  }

  if (isError) {
    return (
      <div className="p-8 flex flex-col items-center justify-center min-h-[400px] text-center">
        <div className="bg-rose-50 p-6 rounded-2xl border border-rose-100 max-w-md">
          <h2 className="text-rose-600 font-bold mb-2">Lỗi tải dữ liệu</h2>
          <p className="text-rose-500 text-sm">{(error as any)?.message || "Không thể kết nối tới máy chủ API"}</p>
          <button 
            onClick={() => window.location.reload()}
            className="mt-4 px-4 py-2 bg-rose-600 text-white rounded-lg text-xs font-bold hover:bg-rose-700 transition-colors"
          >
            Thử lại
          </button>
        </div>
      </div>
    );
  }

  const periods = [
    { value: "Day", label: "Ngày" },
    { value: "Month", label: "Tháng" },
    { value: "Year", label: "Năm" },
  ];

  return (
    <div className="p-6 sm:p-8 max-w-[1600px] mx-auto animate-in fade-in duration-700">
      <div className="mb-8 flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-3xl font-black text-gray-900 tracking-tight">
            Admin <span className="text-emerald-500">Dashboard</span> 🛡️
          </h1>
          <p className="text-gray-400 font-medium text-sm mt-1">
            Tổng quan hệ thống SmashBook
          </p>
        </div>

        {/* Period Selector */}
        <div className="flex bg-gray-100/80 p-1 rounded-xl w-fit border border-gray-200/50">
          {periods.map((p) => (
            <button
              key={p.value}
              onClick={() => setPeriod(p.value)}
              className={cn(
                "px-4 py-1.5 rounded-lg text-xs font-bold transition-all",
                period === p.value 
                  ? "bg-white text-emerald-600 shadow-sm ring-1 ring-black/5" 
                  : "text-gray-500 hover:text-gray-800"
              )}
            >
              {p.label}
            </button>
          ))}
        </div>
      </div>

      {/* Alerts */}
      <DashboardAlerts
        highPriorityReports={highPriorityReports}
        pendingCourts={pendingCourts}
        pendingPayouts={recentWithdrawals}
      />

      {/* Stats grid */}
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
        <StatCard
          label="Tổng Users"
          value={(adminStats?.totalUsers || 0).toLocaleString()}
          icon={<Users size={20} className="text-indigo-500" />}
          color="#6366F1"
          sub="Đang hoạt động"
          onClick={() => navigate("/admin/users")}
        />
        <StatCard
          label="Sân đang hoạt động"
          value={adminStats?.totalCourtActive || 0}
          icon={<Building2 size={20} className="text-emerald-500" />}
          color="#10b981"
          sub={`${adminStats?.pendingCourtsCount || 0} chờ duyệt`}
          onClick={() => navigate("/admin/courts")}
        />
        <StatCard
          label="Yêu cầu chờ duyệt"
          value={(adminStats?.pendingCourtsCount || 0) + (adminStats?.pendingPayoutsCount || 0)}
          icon={<Clock size={20} className="text-amber-500" />}
          color="#f59e0b"
          sub="Cần phê duyệt"
          onClick={() => navigate("/admin/court-approvals")}
        />
        <StatCard
          label="Thông báo chờ xử lý"
          value={adminStats?.pendingReportsCount || 0}
          icon={<Bell size={20} className="text-rose-500" />}
          color="#f43f5e"
          sub="Cần xử lý khẩn"
          onClick={() => navigate("/admin/reports")}
        />
      </div>

      {/* Charts Section */}
      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6 mb-8">
        <AdminTimelineChart 
          title="Tổng người dùng"
          data={adminStats?.userTimeline || []}
          color="#6366F1"
          gradientId="userGrad"
          currentTotal={adminStats?.totalUsers || 0}
        />
        <AdminTimelineChart 
          title="Sân hoạt động"
          data={adminStats?.courtTimeline || []}
          color="#10b981"
          gradientId="courtGrad"
          currentTotal={adminStats?.totalCourtActive || 0}
        />
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-6 mb-8">
        {/* Reports */}
        <div className="lg:col-span-1 h-full">
           <SystemReportsList reports={adminStats?.recentSystemReports || []} />
        </div>

        {/* Recent cash flow */}
        <div className="lg:col-span-2 h-full">
          <CashFlowTable cashFlows={adminStats?.recentTransactions || []} />
        </div>
      </div>
    </div>
  );
}
