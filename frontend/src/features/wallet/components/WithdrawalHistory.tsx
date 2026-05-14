import React from "react";
import { 
  Table, 
  TableBody, 
  TableCell, 
  TableHead, 
  TableHeader, 
  TableRow 
} from "@/shared/components/ui/table";
import { Badge } from "@/shared/components/ui/badge";
import type { WithdrawalInfo } from "../types";
import { format } from "date-fns";
import { Clock, CheckCircle2, XCircle } from "lucide-react";
// import { 
//   Tooltip,
//   TooltipContent,
//   TooltipProvider,
//   TooltipTrigger,
// } from "@/shared/components/ui/tooltip";

import { useWallet } from "../hooks/useWallet";

interface WithdrawalHistoryProps {
  withdrawals?: WithdrawalInfo[];
  isLoading?: boolean;
}

export const WithdrawalHistory: React.FC<WithdrawalHistoryProps> = ({ 
  withdrawals: propWithdrawals, 
  isLoading: propLoading 
}) => {
  const { useMyWithdrawals } = useWallet();
  const { data: fetchedData, isLoading: fetchLoading } = useMyWithdrawals({ pageIndex: 1, pageSize: 20 });

  const withdrawals = propWithdrawals ?? fetchedData?.items ?? [];
  const isLoading = propLoading ?? fetchLoading;

  if (isLoading) return <div className="p-8 text-center text-slate-500">Đang tải lịch sử rút tiền...</div>;
  
  if (withdrawals.length === 0) {
    return (
      <div className="flex flex-col items-center justify-center py-12 text-center text-slate-500">
        <Clock className="w-12 h-12 mb-4 opacity-20" />
        <p>Chưa có yêu cầu rút tiền nào.</p>
      </div>
    );
  }

  const getStatusBadge = (status?: string) => {
    switch (status) {
      case "Approved": 
        return (
          <Badge className="bg-green-100 text-green-700 border-none flex items-center gap-1 w-fit">
            <CheckCircle2 className="w-3 h-3" /> Thành công
          </Badge>
        );
      case "Rejected": 
        return (
          <Badge variant="destructive" className="flex items-center gap-1 w-fit">
            <XCircle className="w-3 h-3" /> Đã từ chối
          </Badge>
        );
      case "Pending": 
      default:
        return (
          <Badge variant="outline" className="text-amber-600 border-amber-200 flex items-center gap-1 w-fit">
            <Clock className="w-3 h-3" /> Đang chờ duyệt
          </Badge>
        );
    }
  };

  return (
    /* <TooltipProvider> */
    <div className="rounded-xl border border-slate-100 overflow-hidden shadow-sm bg-white">
      <Table>
        <TableHeader className="bg-slate-50/80 backdrop-blur-sm">
          <TableRow className="hover:bg-transparent border-b border-slate-100">
            <TableHead className="w-[180px] font-bold text-slate-500 text-xs">Thời gian</TableHead>
            <TableHead className="font-bold text-slate-500 text-xs">Số tiền</TableHead>
            <TableHead className="font-bold text-slate-500 text-xs text-center">Trạng thái</TableHead>
            <TableHead className="font-bold text-slate-500 text-xs">Ghi chú</TableHead>
          </TableRow>
        </TableHeader>
          <TableBody>
            {withdrawals.map((w) => (
              <TableRow key={w.id} className="hover:bg-slate-50/50">
                <TableCell className="text-sm text-slate-500">
                  {format(new Date(w.createdAt), "dd/MM/yyyy HH:mm")}
                </TableCell>
                <TableCell className="font-bold text-slate-700">
                  {w.amount.toLocaleString()}đ
                </TableCell>
                <TableCell>
                  {getStatusBadge(w.status)}
                </TableCell>
                <TableCell className="max-w-[200px]">
                  {w.status === "Rejected" && w.rejectionReason && (
                    /* <Tooltip>
                      <TooltipTrigger asChild> */
                        <span className="text-xs text-red-500">
                          Lý do: {w.rejectionReason}
                        </span>
                      /* </TooltipTrigger>
                      <TooltipContent>
                        <p>{w.rejectionReason}</p>
                      </TooltipContent>
                    </Tooltip> */
                  )}
                  {w.adminNote && (
                    <p className="text-xs text-slate-400 truncate">{w.adminNote}</p>
                  )}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    /* </TooltipProvider> */
  );
};
