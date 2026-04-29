import { useMemo } from "react";
import { SYSTEM_REPORTS, PENDING_COURTS, CASH_FLOW } from "../data/mockData";

export const useAdminDashboard = () => {
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
    pendingReports,
    pendingCourts,
    pendingPayouts,
    highPriorityReports
  };
};
