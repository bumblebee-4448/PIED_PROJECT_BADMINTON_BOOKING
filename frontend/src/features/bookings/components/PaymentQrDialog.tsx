import { useState, useEffect, useCallback } from "react";
import { useCancelBooking, useBookingStatus } from "../hooks";
import { toast } from "sonner";
import {
  Dialog,
  DialogContent,
  DialogTitle,
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { Loader2, Timer, CheckCircle2 } from "lucide-react";
import type { CreateBookingResponse } from "../types";

interface PaymentQrDialogProps {
  bookingResponse: CreateBookingResponse | null;
  isOpen: boolean;
  onClose: () => void;
  onSuccess: () => void;
}

export function PaymentQrDialog({ 
  bookingResponse, 
  isOpen, 
  onClose,
  onSuccess
}: PaymentQrDialogProps) {
  const [timeLeft, setTimeLeft] = useState<number>(0);
  const [isSuccess, setIsSuccess] = useState(false);
  const cancelBooking = useCancelBooking();

  const formatTime = (seconds: number) => {
    const mins = Math.floor(seconds / 60);
    const secs = seconds % 60;
    return `${mins}:${secs.toString().padStart(2, '0')}`;
  };

  const handleSuccess = useCallback(() => {
    setIsSuccess(true);
    onSuccess();
  }, [onSuccess]);

  const handleCancel = useCallback(() => {
    if (bookingResponse?.bookingId && !isSuccess) {
      cancelBooking.mutate(bookingResponse.bookingId);
    }
    onClose();
  }, [bookingResponse?.bookingId, isSuccess, cancelBooking, onClose]);

  // Reset success state when dialog opens
  useEffect(() => {
    if (isOpen) {
      setIsSuccess(false);
    }
  }, [isOpen]);

  useEffect(() => {
    if (isOpen && bookingResponse?.expiredAt) {
      const expiry = new Date(bookingResponse.expiredAt).getTime();
      
      const checkExpiry = () => {
        const now = new Date().getTime();
        const diff = Math.max(0, Math.floor((expiry - now) / 1000));
        setTimeLeft(diff);
        
        if (diff <= 0) {
          if (!isSuccess) {
            toast.error("Mã thanh toán đã hết hạn!");
            handleCancel();
          }
          return true;
        }
        return false;
      };

      // Check immediately
      if (checkExpiry()) return;

      const interval = setInterval(() => {
        if (checkExpiry()) {
          clearInterval(interval);
        }
      }, 1000);
      
      return () => clearInterval(interval);
    }
  }, [isOpen, bookingResponse, isSuccess, handleCancel]);

  // ─── Polling Logic for Payment Status ───────────────────
  const { data: currentBooking } = useBookingStatus(
    bookingResponse?.bookingId,
    isOpen && !isSuccess
  );

  useEffect(() => {
    if (currentBooking?.status === "Banked") {
      toast.success("Thanh toán thành công!");
      handleSuccess();
    }
  }, [currentBooking?.status, handleSuccess]);

  return (
    <Dialog open={isOpen} onOpenChange={(open) => !open && handleCancel()}>
      <DialogContent className="max-w-[420px] p-0 bg-white rounded-2xl border-none shadow-2xl overflow-hidden flex flex-col max-h-[95vh]">
        {/* Header Section (Simplified) */}
        <div className="p-8 text-center border-b border-gray-50">
          <div className="w-16 h-16 bg-emerald-50 rounded-full flex items-center justify-center mx-auto mb-4">
            <CheckCircle2 size={32} className="text-emerald-500" />
          </div>
          <DialogTitle className="text-2xl font-bold text-gray-900 mb-1">
            Đặt sân thành công!
          </DialogTitle>
          <p className="text-gray-400 text-xs font-medium">
            Mã QR của bạn đã sẵn sàng để thanh toán
          </p>
        </div>

        {bookingResponse ? (
        <div className="flex-1 overflow-y-auto p-8 space-y-6 custom-scrollbar">
            {/* QR Section */}
            <div className="flex flex-col items-center">
              <div className="p-4 bg-white rounded-2xl border-2 border-gray-50 shadow-sm relative mb-4">
                <img 
                  src={bookingResponse.qrCodeUrl} 
                  alt="Payment QR" 
                  className="w-48 h-48 object-contain"
                />
              </div>
              <div className="flex items-center gap-2 px-4 py-2 bg-slate-50 rounded-full">
                <Timer size={14} className="text-emerald-600" />
                <span className="text-xs font-black text-emerald-600 tabular-nums">
                  {formatTime(timeLeft)}
                </span>
                <span className="text-[10px] text-slate-400 font-bold uppercase tracking-wider ml-1">còn lại</span>
              </div>
            </div>

            {/* Account Details */}
            <div className="grid grid-cols-2 gap-3">
              <div className="p-3 bg-slate-50 rounded-xl border border-slate-100">
                <p className="text-[9px] font-black text-slate-400 uppercase tracking-widest mb-1">Ngân hàng</p>
                <p className="text-xs font-black text-slate-700">{bookingResponse.bankName}</p>
              </div>
              <div className="p-3 bg-slate-50 rounded-xl border border-slate-100">
                <p className="text-[9px] font-black text-slate-400 uppercase tracking-widest mb-1">Số tài khoản</p>
                <p className="text-xs font-black text-slate-700 tracking-wider">{bookingResponse.bankAccount}</p>
              </div>
            </div>

            {/* Booking Summary */}
            <div className="space-y-3 bg-slate-50/50 p-4 rounded-xl border border-slate-100">
              <div className="flex justify-between items-center">
                <span className="text-[10px] font-black text-slate-400 uppercase tracking-widest">Mã đơn hàng</span>
                <span className="text-xs font-black text-slate-700">#{bookingResponse.bookingId.split('-')[0].toUpperCase()}</span>
              </div>
              
              <div className="flex justify-between items-start">
                <span className="text-[10px] font-black text-slate-400 uppercase tracking-widest pt-1">Chi tiết sân</span>
                <div className="flex flex-col items-end gap-1">
                  {bookingResponse.items.map((item, index) => (
                    <div key={index} className="flex items-center gap-2 text-[11px] font-bold text-slate-600">
                      <span>{item.subCourtName}</span>
                      <span className="text-slate-300">|</span>
                      <span>{(item.startTime || "").substring(0, 5)} - {(item.endTime || "").substring(0, 5)}</span>
                    </div>
                  ))}
                </div>
              </div>

              <div className="pt-2 mt-2 border-t border-slate-200/60 flex justify-between items-center">
                <span className="text-[10px] font-black text-slate-400 uppercase tracking-widest">Tổng tiền</span>
                <span className="text-lg font-black text-[#0B2421]">
                  {new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(bookingResponse.totalPrice)}
                </span>
              </div>
            </div>

            {/* Actions */}
            <div className="space-y-3">
              <div className="flex items-center justify-center gap-2 py-3 px-4 bg-emerald-50 text-emerald-600 rounded-xl border border-emerald-100">
                <Loader2 size={14} className="animate-spin" />
                <span className="text-[10px] font-bold uppercase tracking-wider">Hệ thống đang tự động xác thực...</span>
              </div>
              
              <Button 
                variant="ghost" 
                onClick={handleCancel}
                className="w-full h-10 text-slate-400 hover:text-rose-500 font-bold text-[10px] uppercase tracking-[0.2em] transition-colors"
              >
                Hủy đơn đặt sân
              </Button>
            </div>
          </div>
        ) : (
          <div className="h-96 flex flex-col items-center justify-center gap-4">
            <Loader2 size={40} className="text-emerald-500 animate-spin" />
            <p className="text-gray-400 font-bold animate-pulse uppercase text-[10px] tracking-widest">Đang chuẩn bị mã QR...</p>
          </div>
        )}
      </DialogContent>
    </Dialog>
  );
}
