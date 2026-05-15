import {
  AlertDialog,
  AlertDialogContent,
} from "@/shared/components/ui/alert-dialog";
import { Wallet, Calendar, ShoppingBag, ArrowRight } from "lucide-react";
import { format } from "date-fns";
import { vi } from "date-fns/locale";

interface WalletConfirmDialogProps {
  isOpen: boolean;
  onClose: () => void;
  onConfirm: () => void;
  totalPrice: number;
  slotCount: number;
  date: Date;
  walletBalance?: number;
  isLoading?: boolean;
}

export function WalletConfirmDialog({
  isOpen,
  onClose,
  onConfirm,
  totalPrice,
  slotCount,
  date,
  walletBalance = 0,
  isLoading,
}: WalletConfirmDialogProps) {
  const isInsufficientBalance = walletBalance < totalPrice;

  return (
    <AlertDialog open={isOpen} onOpenChange={(open) => !open && onClose()}>
      <AlertDialogContent className="max-w-md bg-white rounded-3xl border-none shadow-2xl p-0 overflow-hidden">
        <div className="bg-gradient-to-br from-[#004E43] to-[#00897B] p-8 text-white relative overflow-hidden">
          {/* Decorative background elements */}
          <div className="absolute top-0 right-0 w-32 h-32 bg-white/10 rounded-full -mr-16 -mt-16 blur-2xl" />
          <div className="absolute bottom-0 left-0 w-24 h-24 bg-emerald-400/10 rounded-full -ml-12 -mb-12 blur-xl" />
          
          <div className="relative z-10 flex flex-col items-center text-center">
            <div className="w-16 h-16 bg-white/20 backdrop-blur-md rounded-2xl flex items-center justify-center mb-4 shadow-xl border border-white/30">
              <Wallet size={32} className="text-white" />
            </div>
            <h2 className="text-2xl font-black uppercase tracking-tight mb-1">Xác nhận thanh toán</h2>
            <p className="text-emerald-50/80 text-sm font-medium">Sử dụng số dư ví để thanh toán đơn đặt sân</p>
          </div>
        </div>

        <div className="p-8 space-y-6">
          <div className="space-y-4">
            <div className="flex items-center justify-between p-4 bg-gray-50 rounded-2xl border border-gray-100">
              <div className="flex items-center gap-3">
                <div className="p-2 bg-white rounded-xl shadow-sm text-emerald-600">
                  <Calendar size={18} />
                </div>
                <div className="flex flex-col">
                  <span className="text-[10px] font-black text-gray-400 uppercase tracking-widest leading-none mb-1">Ngày thi đấu</span>
                  <span className="text-sm font-bold text-[#0B2421]">{format(date, "EEEE, dd MMMM yyyy", { locale: vi })}</span>
                </div>
              </div>
            </div>

            <div className="flex items-center justify-between p-4 bg-gray-50 rounded-2xl border border-gray-100">
              <div className="flex items-center gap-3">
                <div className="p-2 bg-white rounded-xl shadow-sm text-emerald-600">
                  <ShoppingBag size={18} />
                </div>
                <div className="flex flex-col">
                  <span className="text-[10px] font-black text-gray-400 uppercase tracking-widest leading-none mb-1">Số lượng sân/giờ</span>
                  <span className="text-sm font-bold text-[#0B2421]">{slotCount} slot đã chọn</span>
                </div>
              </div>
            </div>

            <div className="pt-4 border-t border-dashed border-gray-200">
              <div className="flex items-center justify-between mb-2">
                <span className="text-sm font-medium text-gray-500">Tổng cộng</span>
                <span className="text-xl font-black text-[#0B2421]">
                  {new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(totalPrice)}
                </span>
              </div>
              <div className="flex items-center justify-between">
                <span className="text-sm font-medium text-gray-500">Số dư hiện tại</span>
                <span className={`text-sm font-bold ${isInsufficientBalance ? 'text-red-500' : 'text-emerald-600'}`}>
                  {new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(walletBalance)}
                </span>
              </div>
            </div>
          </div>

          {isInsufficientBalance && (
            <div className="p-4 bg-red-50 rounded-2xl border border-red-100 flex items-start gap-3">
              <div className="w-5 h-5 rounded-full bg-red-500 flex items-center justify-center text-white shrink-0 mt-0.5">
                <span className="text-[10px] font-bold">!</span>
              </div>
              <p className="text-xs font-bold text-red-600 leading-relaxed">
                Số dư ví không đủ để thực hiện giao dịch này. Vui lòng nạp thêm tiền hoặc chọn phương thức khác.
              </p>
            </div>
          )}

          <div className="flex flex-col gap-3 pt-2">
            <button
              onClick={onConfirm}
              disabled={isLoading || isInsufficientBalance}
              className={`h-14 w-full rounded-2xl font-black text-xs uppercase tracking-[0.2em] flex items-center justify-center gap-2 transition-all active:scale-[0.98] ${
                isInsufficientBalance 
                  ? 'bg-gray-100 text-gray-400 cursor-not-allowed' 
                  : 'bg-[#00897B] text-white hover:bg-[#00796B] shadow-lg shadow-emerald-900/10'
              }`}
            >
              {isLoading ? "Đang xử lý..." : "Xác nhận & Thanh toán"}
              {!isLoading && !isInsufficientBalance && <ArrowRight size={16} />}
            </button>
            <button
              onClick={onClose}
              disabled={isLoading}
              className="h-14 w-full rounded-2xl font-black text-[10px] uppercase tracking-[0.2em] text-gray-400 hover:text-gray-600 hover:bg-gray-50 transition-all"
            >
              Hủy bỏ
            </button>
          </div>
        </div>
      </AlertDialogContent>
    </AlertDialog>
  );
}
