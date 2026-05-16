import { useNavigate } from "react-router";
import { ChevronRight } from "lucide-react";
import type { Transaction } from "../dashboardTypes";
import { Button } from "@/shared/components/ui/button";

interface CashFlowTableProps {
  cashFlows: Transaction[];
}

export function CashFlowTable({ cashFlows }: CashFlowTableProps) {
  const navigate = useNavigate();

  return (
    <div className="bg-white rounded-2xl p-5 shadow-sm border border-gray-100 h-full">
      <div className="flex items-center justify-between mb-6">
        <h3 className="text-gray-900 font-bold text-base">Luồng tiền gần đây 💰</h3>
        <Button 
          variant="link"
          onClick={() => navigate("/admin/transactions")} 
          className="text-emerald-600 text-xs font-bold hover:no-underline flex items-center gap-1 p-0 h-auto"
        >
          Xem tất cả <ChevronRight size={12} />
        </Button>
      </div>
      <div className="overflow-x-auto">
        <table className="w-full">
          <thead>
            <tr className="border-b border-gray-50">
              {["Loại", "Chi tiết", "Số tiền", "Trạng thái", "Thời gian"].map(h => (
                <th 
                  key={h} 
                  className="pb-4 text-left text-[10px] font-black uppercase tracking-wider text-gray-400"
                >
                  {h}
                </th>
              ))}
            </tr>
          </thead>
          <tbody className="divide-y divide-gray-50">
            {cashFlows.slice(0, 7).map((cf) => {
              const typeMap: Record<string, any> = {
                Receive: { label: "Đặt sân", color: "#10b981", bg: "#ecfdf5" },
                Refund:  { label: "Hoàn tiền", color: "#f59e0b", bg: "#fffbeb" },
                Withdraw:  { label: "Payout", color: "#6366f1", bg: "#eef2ff" },
              };
              const typeConfig = typeMap[cf.type] || { label: cf.type, color: "#6b7280", bg: "#f3f4f6" };

              const statusMap: Record<string, any> = {
                Success: { label: "Hoàn thành", color: "#10b981" },
                Pending: { label: "Chờ xử lý", color: "#f59e0b" },
                Failed:  { label: "Thất bại", color: "#ef4444" },
              };
              const statusConfig = statusMap[cf.status] || { label: cf.status, color: "#6b7280" };

              return (
                <tr key={cf.id} className="hover:bg-gray-50/50 transition-colors">
                  <td className="py-4 pr-4">
                    <span 
                      className="px-2.5 py-1 rounded-lg text-[10px] font-bold" 
                      style={{ background: typeConfig.bg, color: typeConfig.color }}
                    >
                      {typeConfig.label}
                    </span>
                  </td>
                  <td className="py-4 pr-4">
                    <p className="text-xs font-bold text-gray-900 line-clamp-1">
                      {cf.description || "Giao dịch hệ thống"}
                    </p>
                    <p className="text-[10px] text-gray-400 font-medium">
                      {cf.userName || "SmashBook User"}
                    </p>
                  </td>
                  <td className="py-4 pr-4">
                    <span className="text-xs font-black text-gray-900">
                      {cf.amount.toLocaleString()}đ
                    </span>
                  </td>
                  <td className="py-4 pr-4">
                    <span className="text-[10px] font-bold" style={{ color: statusConfig.color }}>
                      {statusConfig.label}
                    </span>
                  </td>
                  <td className="py-4">
                    <span className="text-[10px] text-gray-400 font-medium whitespace-nowrap">
                      {cf.createdAt ? new Date(cf.createdAt).toLocaleString("vi-VN", { 
                        day: "2-digit", 
                        month: "2-digit", 
                        hour: "2-digit", 
                        minute: "2-digit" 
                      }) : "N/A"}
                    </span>
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
