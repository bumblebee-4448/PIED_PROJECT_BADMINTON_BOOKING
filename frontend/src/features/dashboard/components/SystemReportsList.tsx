import { useNavigate } from "react-router";
import { ChevronRight } from "lucide-react";
import type { SystemReport } from "../types";
import { Button } from "@/shared/components/ui/button";

const PRIORITY_CONFIG = {
  high:   { bg: "#FEF2F2", color: "#DC2626", label: "Khẩn cấp" },
  medium: { bg: "#FFF8E1", color: "#D97706", label: "Trung bình" },
  low:    { bg: "#f3f4f6", color: "#6b7280", label: "Thấp" },
};

interface SystemReportsListProps {
  reports: SystemReport[];
}

export function SystemReportsList({ reports }: SystemReportsListProps) {
  const navigate = useNavigate();

  return (
    <div className="bg-white rounded-2xl p-5" style={{ border: "1px solid rgba(0,0,0,0.06)" }}>
      <div className="flex items-center justify-between mb-4">
        <h3 style={{ fontWeight: 700, color: "#1a1a2e", fontSize: "0.95rem" }}>Báo cáo hệ thống</h3>
        <Button 
          variant="link"
          onClick={() => navigate("/admin/products")} 
          style={{ fontSize: "0.72rem", color: "#00897B", fontWeight: 600 }} 
          className="flex items-center gap-1 p-0 h-auto hover:no-underline"
        >
          Xem tất cả <ChevronRight size={12} />
        </Button>
      </div>
      <div className="flex flex-col gap-2.5">
        {reports.slice(0, 4).map((r) => {
          const cfg = PRIORITY_CONFIG[r.priority];
          return (
            <div key={r.id} className="p-3 rounded-xl" style={{ background: cfg.bg, border: `1px solid ${cfg.color}20` }}>
              <div className="flex items-center justify-between mb-1">
                <span 
                  className="px-2 py-0.5 rounded text-xs font-bold" 
                  style={{ background: cfg.color, color: "white" }}
                >
                  {cfg.label}
                </span>
                <span style={{ fontSize: "0.65rem", color: "#9ca3af" }}>
                  {new Date(r.createdAt).toLocaleDateString("vi-VN")}
                </span>
              </div>
              <p style={{ fontSize: "0.78rem", fontWeight: 600, color: "#1a1a2e" }} className="line-clamp-1">
                {r.courtName}
              </p>
              <p style={{ fontSize: "0.72rem", color: "#6b7280" }} className="line-clamp-1">
                {r.description}
              </p>
            </div>
          );
        })}
      </div>
    </div>
  );
}
