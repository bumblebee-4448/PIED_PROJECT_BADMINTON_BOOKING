import { useMemo } from "react";
import { useQuery } from "@tanstack/react-query";
import { SYSTEM_REPORTS, PENDING_COURTS, CASH_FLOW } from "../data/mockData";
import { adminDashboardService } from "../services/adminDashboardService";

export const useAdminDashboard = () => {
  const { data: adminStats, isLoading: isAdminStatsLoading } = useQuery({
    queryKey: ["admin-stats"],
    queryFn: () => adminDashboardService.getAdminStats()
  });

  const pendingReports = useMemo(() => 
    SYSTEM_REPORTS.filter(r => r.status === "pending"), 
  []);

  const pendingCourts = useMemo(() => 
    PENDING_COURTS.filter(c => c.status === "pending"), 
  []);

  const pendingPayouts = useMemo(() => 
    CASH_FLOW.filter(c => c.type === "payout" && c.status === "pending"), 
  []);

  const highPriorityReports = useMemo(() => 
    pendingReports.filter(r => r.priority === "high"), 
  [pendingReports]);

  return {
    adminStats,
    isAdminStatsLoading,
    pendingReports,
    pendingCourts,
    pendingPayouts,
    highPriorityReports
  };
};
