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
import type { TransactionInfo } from "../types";
import { format } from "date-fns";
import { ArrowUpRight, ArrowDownLeft, RefreshCcw } from "lucide-react";

import { useWallet } from "../hooks/useWallet";

interface TransactionHistoryProps {
  transactions?: TransactionInfo[];
  isLoading?: boolean;
}

export const TransactionHistory: React.FC<TransactionHistoryProps> = ({ 
  transactions: propTransactions, 
  isLoading: propLoading 
}) => {
  const { useMyTransactions } = useWallet();
  const { data: fetchedData, isLoading: fetchLoading } = useMyTransactions({ pageIndex: 1, pageSize: 20 });

  const transactions = propTransactions ?? fetchedData?.items ?? [];
  const isLoading = propLoading ?? fetchLoading;

  if (isLoading) return <div className="p-8 text-center text-slate-500">Đang tải lịch sử giao dịch...</div>;
  
  if (transactions.length === 0) {
    return (
      <div className="flex flex-col items-center justify-center py-12 text-center text-slate-500">
        <RefreshCcw className="w-12 h-12 mb-4 opacity-20" />
        <p>Chưa có giao dịch nào được thực hiện.</p>
      </div>
    );
  }

  const getTypeIcon = (type: string) => {
    switch (type) {
      case "Deposit":
      case "Refund":
      case "AdminUp":
      case "Receive":
        return <ArrowDownLeft className="w-4 h-4 text-green-500" />;
      default:
        return <ArrowUpRight className="w-4 h-4 text-red-500" />;
    }
  };

  const getTypeName = (type: string) => {
    switch (type) {
      case "Deposit": return "Nạp tiền";
      case "Refund": return "Hoàn tiền";
      case "AdminUp": return "Cộng tiền Admin";
      case "Payment": return "Thanh toán";
      case "Withdrawal": return "Rút tiền";
      case "AdminDeduct": return "Trừ tiền Admin";
      default: return type;
    }
  };

  const getStatusBadge = (status: string) => {
    switch (status) {
      case "Success": return <Badge className="bg-green-100 text-green-700 border-none">Thành công</Badge>;
      case "Pending": return <Badge variant="outline" className="text-amber-600 border-amber-200">Đang xử lý</Badge>;
      case "Failed": return <Badge variant="destructive">Thất bại</Badge>;
      default: return <Badge variant="secondary">{status}</Badge>;
    }
  };

  return (
    <div className="rounded-xl border border-slate-100 overflow-hidden shadow-sm bg-white">
      <Table>
        <TableHeader className="bg-slate-50/80 backdrop-blur-sm">
          <TableRow className="hover:bg-transparent border-b border-slate-100">
            <TableHead className="w-[180px] font-bold text-slate-500 text-xs">Thời gian</TableHead>
            <TableHead className="font-bold text-slate-500 text-xs">Loại giao dịch</TableHead>
            <TableHead className="font-bold text-slate-500 text-xs text-right">Số tiền</TableHead>
            <TableHead className="font-bold text-slate-500 text-xs text-center">Trạng thái</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {transactions.map((tx) => (
            <TableRow key={tx.id} className="hover:bg-slate-50/50 transition-colors border-b border-slate-50 last:border-0">
              <TableCell className="text-xs font-medium text-slate-400">
                {tx.createdAt ? format(new Date(tx.createdAt), "dd/MM/yyyy HH:mm") : "N/A"}
              </TableCell>
              <TableCell>
                <div className="flex items-center gap-3">
                  <div className={`p-2 rounded-xl ${
                    ["Deposit", "Refund", "AdminUp", "Receive"].includes(tx.type) 
                      ? "bg-emerald-50 text-emerald-600" 
                      : "bg-rose-50 text-rose-600"
                  }`}>
                    {getTypeIcon(tx.type)}
                  </div>
                  <span className="font-bold text-slate-700 text-sm">{getTypeName(tx.type)}</span>
                </div>
              </TableCell>
              <TableCell className={`font-black text-right text-base ${
                ["Deposit", "Refund", "AdminUp", "Receive"].includes(tx.type) 
                  ? "text-emerald-600" 
                  : "text-rose-600"
              }`}>
                {["Deposit", "Refund", "AdminUp", "Receive"].includes(tx.type) ? "+" : "-"}
                {Math.abs(tx.amount).toLocaleString()}
                <span className="text-[10px] ml-1 uppercase opacity-70">đ</span>
              </TableCell>
              <TableCell className="text-center">
                {getStatusBadge(tx.status)}
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  );
};
