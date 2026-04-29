import { useNavigate } from "react-router";
import { ChevronRight } from "lucide-react";
import type { CashFlow } from "../types";
import { Button } from "@/shared/components/ui/button";

interface CashFlowTableProps {
  cashFlows: CashFlow[];
}

export function CashFlowTable({ cashFlows }: CashFlowTableProps) {
  const navigate = useNavigate();

  return (
    <div className="bg-white rounded-2xl p-5" style={{ border: "1px solid rgba(0,0,0,0.06)" }}>
      <div className="flex items-center justify-between mb-4">
        <h3 style={{ fontWeight: 700, color: "#1a1a2e", fontSize: "0.95rem" }}>Luồng tiền gần đây 💰</h3>
        <Button 
          variant="link"
          onClick={() => navigate("/admin/cashflow")} 
          style={{ fontSize: "0.75rem", color: "#00897B", fontWeight: 600 }} 
          className="flex items-center gap-1 p-0 h-auto hover:no-underline"
        >
          Xem tất cả <ChevronRight size={13} />
        </Button>
      </div>
      <div className="overflow-x-auto">
        <table className="w-full">
          <thead>
            <tr>
              {["Loại", "Chi tiết", "Số tiền", "Phí HT", "Trạng thái", "Thời gian"].map(h => (
                <th 
                  key={h} 
                  className="pb-3 text-left" 
                  style={{ fontSize: "0.72rem", fontWeight: 700, color: "#9ca3af", paddingRight: "12px" }}
                >
                  {h}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {cashFlows.slice(0, 5).map((cf) => {
              const typeConfig = {
                booking: { label: "Đặt sân", color: "#00897B", bg: "#f0fdf9" },
                refund:  { label: "Hoàn tiền", color: "#F59E0B", bg: "#FFF8E1" },
                payout:  { label: "Payout", color: "#6366F1", bg: "#EEF2FF" },
                fee:     { label: "Phí HT", color: "#EF4444", bg: "#FEF2F2" },
              }[cf.type];

              const statusConfig = {
                done:       { label: "Hoàn thành", color: "#10B981" },
                processing: { label: "Đang xử lý", color: "#6366F1" },
                pending:    { label: "Chờ xử lý", color: "#F59E0B" },
                failed:     { label: "Thất bại", color: "#EF4444" },
              }[cf.status];

              return (
                <tr key={cf.id} className="border-t border-gray-50">
                  <td className="py-3 pr-3">
                    <span 
                      className="px-2 py-1 rounded-lg text-xs font-semibold" 
                      style={{ background: typeConfig.bg, color: typeConfig.color }}
                    >
                      {typeConfig.label}
                    </span>
                  </td>
                  <td className="py-3 pr-3">
                    <p style={{ fontSize: "0.82rem", fontWeight: 600, color: "#1a1a2e" }} className="line-clamp-1">
                      {cf.courtName}
                    </p>
                    <p style={{ fontSize: "0.7rem", color: "#9ca3af" }}>
                      {cf.customerName || cf.ownerName}
                    </p>
                  </td>
                  <td className="py-3 pr-3">
                    <span style={{ fontSize: "0.85rem", fontWeight: 700, color: "#00897B" }}>
                      {cf.amount.toLocaleString()}đ
                    </span>
                  </td>
                  <td className="py-3 pr-3">
                    <span style={{ fontSize: "0.82rem", color: "#EF4444" }}>
                      {cf.fee ? `-${cf.fee.toLocaleString()}đ` : "—"}
                    </span>
                  </td>
                  <td className="py-3 pr-3">
                    <span style={{ fontSize: "0.75rem", fontWeight: 600, color: statusConfig.color }}>
                      {statusConfig.label}
                    </span>
                  </td>
                  <td className="py-3" style={{ fontSize: "0.72rem", color: "#9ca3af", whiteSpace: "nowrap" }}>
                    {new Date(cf.date).toLocaleString("vi-VN", { 
                      day: "2-digit", 
                      month: "2-digit", 
                      hour: "2-digit", 
                      minute: "2-digit" 
                    })}
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    </div>
  );
}
