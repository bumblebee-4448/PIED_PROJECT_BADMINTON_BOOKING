import { useState, useEffect, useCallback } from "react";
import { useCancelBooking } from "../hooks/useBookingOperations";
import { bookingsService } from "../services";
import { toast } from "sonner";
import {
  Dialog,
  DialogContent,
  DialogHeader,
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
  useEffect(() => {
    let pollingInterval: ReturnType<typeof setInterval>;

    if (isOpen && bookingResponse?.bookingId && !isSuccess) {
      const checkStatus = async () => {
        try {
          const response = await bookingsService.getAll({ pageIndex: 1, pageSize: 10 });
          const currentBooking = response.items.find(item => item.bookingId === bookingResponse.bookingId);
          
          if (currentBooking?.status === "Banked") {
            toast.success("Thanh toán thành công!");
            handleSuccess();
          }
        } catch (error) {
          console.error("Error polling booking status:", error);
        }
      };

      // Poll every 5 seconds
      pollingInterval = setInterval(checkStatus, 5000);
      
      // Initial check
      checkStatus();
    }

    return () => {
      if (pollingInterval) clearInterval(pollingInterval);
    };
  }, [isOpen, bookingResponse?.bookingId, isSuccess]);

  const handleSuccess = () => {
    setIsSuccess(true);
    onSuccess();
  };

  return (
    <Dialog open={isOpen} onOpenChange={(open) => !open && handleCancel()}>
      <DialogContent className="max-w-[60%] sm:max-w-[400px] h-[600px] overflow-y-auto p-6 bg-white rounded-3xl border-none shadow-2xl">
        <DialogHeader className="text-center mb-4">
          <div className="w-12 h-12 bg-emerald-50 rounded-2xl flex items-center justify-center mx-auto mb-3">
            <CheckCircle2 size={24} className="text-emerald-500" />
          </div>
          <DialogTitle className="text-xl font-black text-[#0B2421]">
            Đã tạo đơn thành công!
          </DialogTitle>
          <p className="text-gray-400 text-xs font-medium">
            Vui lòng quét mã QR bên dưới để thanh toán đơn hàng.
          </p>
        </DialogHeader>

        {bookingResponse ? (
          <div className="space-y-4">
            <div className="relative group">
              <div className="absolute -inset-1 bg-gradient-to-r from-emerald-500 to-teal-500 rounded-3xl blur opacity-25 group-hover:opacity-40 transition duration-1000 group-hover:duration-200" />
              <div className="relative bg-white p-4 rounded-[2rem] border border-gray-50 flex items-center justify-center">
                <img 
                  src={bookingResponse.qrCodeUrl} 
                  alt="Payment QR" 
                  className="w-full aspect-square object-contain rounded-2xl"
                />
              </div>
            </div>

            <div className="p-4 bg-emerald-50/50 border border-emerald-100 rounded-2xl space-y-2">
              <div className="flex justify-between items-center">
                <span className="text-[10px] font-black text-emerald-600/60 uppercase tracking-widest">Ngân hàng</span>
                <span className="text-xs font-black text-[#0B2421] uppercase">{bookingResponse.bankName}</span>
              </div>
              <div className="flex justify-between items-center">
                <span className="text-[10px] font-black text-emerald-600/60 uppercase tracking-widest">Số tài khoản</span>
                <span className="text-xs font-black text-[#0B2421] tracking-wider">{bookingResponse.bankAccount}</span>
              </div>
            </div>

            <div className="flex items-center justify-between p-4 bg-gray-50 rounded-2xl">
              <div className="flex items-center gap-3">
                <Timer size={18} className="text-emerald-500" />
                <span className="text-[10px] font-black text-gray-400 uppercase tracking-widest">Thời gian còn lại</span>
              </div>
              <span className="text-lg font-black text-emerald-600 tabular-nums">
                {formatTime(timeLeft)}
              </span>
            </div>

            <div className="space-y-2 border-t border-b border-gray-100 py-4">
              <div className="flex justify-between text-sm">
                <span className="text-gray-400 font-bold uppercase text-[10px] tracking-widest">Mã đơn hàng</span>
                <span className="text-[#0B2421] font-black truncate max-w-[150px]" title={bookingResponse.bookingId}>
                  #{bookingResponse.bookingId.split('-')[0].toUpperCase()}
                </span>
              </div>
              <div className="flex justify-between text-sm">
                <span className="text-gray-400 font-bold uppercase text-[10px] tracking-widest">Lịch đặt</span>
                <div className="flex flex-col items-end gap-2">
                  {bookingResponse.items.map((item, index) => (
                    <div key={index} className="flex flex-col items-end bg-gray-50/50 p-2 rounded-lg border border-gray-100 min-w-[120px]">
                      <span className="text-[8px] font-black text-emerald-600 uppercase tracking-tighter mb-0.5">{item.subCourtName}</span>
                      <span className="text-[#0B2421] font-black text-xs">
                        {item.startTime.substring(0, 5)} - {item.endTime.substring(0, 5)}
                      </span>
                    </div>
                  ))}
                </div>
              </div>
              <div className="flex justify-between text-sm">
                <span className="text-gray-400 font-bold uppercase text-[10px] tracking-widest">Trạng thái</span>
                <span className="text-amber-500 font-black flex items-center gap-2">
                  <Loader2 size={12} className="animate-spin" /> 
                  {bookingResponse.status === "Pending" ? "Chờ thanh toán" : bookingResponse.status}
                </span>
              </div>
              <div className="flex justify-between text-sm">
                <span className="text-gray-400 font-bold uppercase text-[10px] tracking-widest">Tổng thanh toán</span>
                <span className="text-[#0B2421] font-black text-base">
                  {new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(bookingResponse.totalPrice)}
                </span>
              </div>
            </div>

            <div className="pt-1 flex flex-col gap-2">
              <div className="flex items-center justify-center gap-2 py-2 px-4 bg-emerald-50 text-emerald-600 rounded-xl mb-2">
                <Loader2 size={14} className="animate-spin" />
                <span className="text-[10px] font-bold uppercase tracking-wider">Đang tự động kiểm tra thanh toán...</span>
              </div>

              {/* <Button 
                onClick={handleSuccess}
                className="w-full h-12 bg-[#0B2421] hover:bg-[#1a3a36] text-white rounded-2xl font-black text-xs uppercase tracking-widest transition-all"
              >
                Tôi đã chuyển khoản
              </Button> */}
              <Button 
                variant="ghost" 
                onClick={handleCancel}
                className="w-full h-12 text-gray-400 hover:text-gray-600 font-black text-[10px] uppercase tracking-widest"
              >
                Hủy đơn
              </Button>
            </div>
          </div>
        ) : (
          <div className="h-64 flex flex-col items-center justify-center gap-4">
            <Loader2 size={40} className="text-emerald-500 animate-spin" />
            <p className="text-gray-400 font-bold animate-pulse">Đang chuẩn bị mã QR...</p>
          </div>
        )}
      </DialogContent>
    </Dialog>
  );
}
