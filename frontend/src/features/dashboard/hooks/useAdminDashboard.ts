import { useMemo, useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { adminDashboardService } from "../services/adminDashboardService";

export const useAdminDashboard = () => {
  const [period, setPeriod] = useState("Day");

  const { data: adminStats, isLoading: isAdminStatsLoading, isError, error } = useQuery({
    queryKey: ["admin-stats", period],
    queryFn: () => adminDashboardService.getAdminStats(period)
  });

  const pendingReports = useMemo(() => 
    adminStats?.recentSystemReports || [], 
  [adminStats]);

  const pendingCourts = useMemo(() => 
    adminStats?.pendingCourts || [], 
  [adminStats]);

  const recentWithdrawals = useMemo(() => 
    adminStats?.recentWithdrawals || [], 
  [adminStats]);

  const highPriorityReports = useMemo(() => 
    pendingReports.filter(r => (r as any).priority === "high"), 
  [pendingReports]);

  return {
    adminStats,
    isAdminStatsLoading,
    pendingReports,
    pendingCourts,
    recentWithdrawals,
    highPriorityReports,
    period,
    setPeriod,
    isError,
    error
  };
};
