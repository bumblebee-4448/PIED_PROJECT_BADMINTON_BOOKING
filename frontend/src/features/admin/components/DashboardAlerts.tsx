import { useNavigate } from "react-router";
import { AlertTriangle, Clock, Bell } from "lucide-react";
import type { SystemReport, PendingCourt, CashFlow } from "../types";

interface DashboardAlertsProps {
  highPriorityReports: SystemReport[];
  pendingCourts: PendingCourt[];
  pendingPayouts: CashFlow[];
}

export function DashboardAlerts({ highPriorityReports, pendingCourts, pendingPayouts }: DashboardAlertsProps) {
  const navigate = useNavigate();

  const hasAlerts = highPriorityReports.length > 0 || pendingCourts.length > 0 || pendingPayouts.length > 0;

  if (!hasAlerts) return null;

  return (
    <div className="flex flex-col gap-2 mb-6">
      {highPriorityReports.map((r) => (
        <div 
          key={r.id} 
          className="flex items-center gap-3 px-4 py-3 rounded-xl"
          style={{ background: "#FEF2F2", border: "1px solid #FECACA" }}
        >
          <AlertTriangle size={16} style={{ color: "#DC2626", flexShrink: 0 }} />
          <p style={{ fontSize: "0.82rem", color: "#DC2626", flex: 1 }}>
            🚨 <strong>Báo cáo khẩn:</strong> {r.courtName} — {r.description.slice(0, 60)}...
          </p>
          <button 
            onClick={() => navigate("/admin/products")} 
            className="text-xs font-bold" 
            style={{ color: "#DC2626" }}
          >
            Xem →
          </button>
        </div>
      ))}

      {pendingCourts.length > 0 && (
        <div 
          className="flex items-center gap-3 px-4 py-3 rounded-xl"
          style={{ background: "#FFF8E1", border: "1px solid #FDE68A" }}
        >
          <Clock size={16} style={{ color: "#D97706", flexShrink: 0 }} />
          <p style={{ fontSize: "0.82rem", color: "#92400E", flex: 1 }}>
            ⏳ Có <strong>{pendingCourts.length} sân đang chờ duyệt</strong>
          </p>
          <button 
            onClick={() => navigate("/admin/products")} 
            className="text-xs font-bold" 
            style={{ color: "#D97706" }}
          >
            Duyệt ngay →
          </button>
        </div>
      )}

      {pendingPayouts.length > 0 && (
        <div 
          className="flex items-center gap-3 px-4 py-3 rounded-xl"
          style={{ background: "#f0fdf9", border: "1px solid rgba(0,200,150,0.3)" }}
        >
          <Bell size={16} style={{ color: "#00897B", flexShrink: 0 }} />
          <p style={{ fontSize: "0.82rem", color: "#00897B", flex: 1 }}>
            💸 Có <strong>{pendingPayouts.length} payout chờ xử lý</strong> cho owner
          </p>
          <button 
            onClick={() => navigate("/admin/cashflow")} 
            className="text-xs font-bold" 
            style={{ color: "#00897B" }}
          >
            Xử lý →
          </button>
        </div>
      )}
    </div>
  );
}
