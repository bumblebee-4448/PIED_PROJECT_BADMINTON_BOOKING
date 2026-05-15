import React from "react";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter,
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { 
  CreditCard, 
  Calendar, 
  Hash, 
  Wallet, 
  Info,
  CheckCircle2,
  XCircle,
  Clock
} from "lucide-react";
import { format, parseISO } from "date-fns";
import type { TransactionItem } from "../types";
import { cn } from "@/lib/utils";

interface TransactionDetailDialogProps {
  isOpen: boolean;
  onClose: () => void;
  transaction: TransactionItem | null;
}

export function TransactionDetailDialog({ isOpen, onClose, transaction }: TransactionDetailDialogProps) {
  if (!transaction) return null;

  const getStatusConfig = (status: string) => {
    switch (status) {
      case "Success":
        return {
          label: "Thành công",
          icon: <CheckCircle2 size={16} className="text-emerald-500" />,
          className: "text-emerald-600 bg-emerald-50 border-emerald-100"
        };
      case "Failed":
        return {
          label: "Thất bại",
          icon: <XCircle size={16} className="text-red-500" />,
          className: "text-red-600 bg-red-50 border-red-100"
        };
      default:
        return {
          label: status,
          icon: <Clock size={16} className="text-amber-500" />,
          className: "text-amber-600 bg-amber-50 border-amber-100"
        };
    }
  };

  const statusConfig = getStatusConfig(transaction.status);
  const formattedDate = format(parseISO(transaction.createdAt), "HH:mm:ss - dd/MM/yyyy");

  return (
    <Dialog open={isOpen} onOpenChange={(open) => !open && onClose()}>
      <DialogContent className="sm:max-w-[460px] rounded-[32px] p-0 overflow-hidden border-none shadow-2xl">
        <DialogHeader className="p-8 pb-4 bg-gradient-to-br from-[#00897B] to-[#00695C] text-white">
          <div className="w-14 h-14 bg-white/20 backdrop-blur-md rounded-2xl flex items-center justify-center mb-4">
            <CreditCard size={28} />
          </div>
          <DialogTitle className="text-2xl font-black tracking-tight">Chi tiết thanh toán</DialogTitle>
          <p className="text-white/70 text-sm font-medium">Thông tin giao dịch từ hệ thống ngân hàng</p>
        </DialogHeader>

        <div className="p-8 space-y-6">
          {/* Amount Card */}
          <div className="bg-gray-50 rounded-3xl p-6 text-center border border-gray-100">
            <p className="text-[10px] uppercase tracking-[0.2em] font-black text-gray-400 mb-2">Số tiền giao dịch</p>
            <h3 className={cn(
              "text-3xl font-black",
              transaction.amount >= 0 ? "text-emerald-600" : "text-red-600"
            )}>
              {transaction.amount >= 0 ? "+" : ""}{transaction.amount.toLocaleString()}đ
            </h3>
          </div>

          {/* Details Grid */}
          <div className="space-y-4">
            <DetailItem 
              icon={<Info size={16} />} 
              label="Loại giao dịch" 
              value={transaction.type === "Payment" ? "Thanh toán đặt sân" : transaction.type} 
            />
            
            <DetailItem 
              icon={<Calendar size={16} />} 
              label="Thời gian" 
              value={formattedDate} 
            />

            <DetailItem 
              icon={<div className={cn("w-2 h-2 rounded-full", transaction.status === "Success" ? "bg-emerald-500" : "bg-amber-500")} />} 
              label="Trạng thái" 
              value={
                <div className={cn("px-3 py-1 rounded-full text-xs font-bold border", statusConfig.className)}>
                  {statusConfig.label}
                </div>
              } 
            />

            {transaction.bankRefCode && (
              <DetailItem 
                icon={<Hash size={16} />} 
                label="Mã tham chiếu" 
                value={transaction.bankRefCode} 
                isCode
              />
            )}

            {transaction.bankAccountNumber && (
              <DetailItem 
                icon={<Wallet size={16} />} 
                label="Số tài khoản" 
                value={transaction.bankAccountNumber} 
              />
            )}
            
            <DetailItem 
              icon={<Hash size={16} />} 
              label="ID Giao dịch" 
              value={transaction.id} 
              isCode
            />
          </div>
        </div>

        <DialogFooter className="p-8 pt-0">
          <Button 
            onClick={onClose}
            className="w-full bg-gray-900 hover:bg-black text-white rounded-2xl h-14 font-bold text-base transition-all active:scale-[0.98]"
          >
            Đóng cửa sổ
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}

function DetailItem({ icon, label, value, isCode = false }: { icon: React.ReactNode, label: string, value: React.ReactNode, isCode?: boolean }) {
  return (
    <div className="flex items-center justify-between group">
      <div className="flex items-center gap-3">
        <div className="w-8 h-8 rounded-xl bg-gray-50 flex items-center justify-center text-gray-400 group-hover:bg-emerald-50 group-hover:text-emerald-500 transition-colors">
          {icon}
        </div>
        <span className="text-sm font-bold text-gray-500">{label}</span>
      </div>
      <div className={cn(
        "text-sm font-black text-gray-900",
        isCode && "font-mono bg-gray-50 px-2 py-1 rounded text-xs"
      )}>
        {value}
      </div>
    </div>
  );
}
