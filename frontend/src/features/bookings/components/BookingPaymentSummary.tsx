import { Button } from "@/shared/components/ui/button";
import { Wallet } from "lucide-react";
import type { AvailableSlot } from "../types";

interface BookingPaymentSummaryProps {
  selectedSlots: AvailableSlot[];
  onBookBank: () => void;
  onBookWallet: () => void;
  isLoading?: boolean;
}

export function BookingPaymentSummary({ 
  selectedSlots, 
  onBookBank, 
  onBookWallet,
  isLoading 
}: BookingPaymentSummaryProps) {
  const totalPrice = selectedSlots.reduce((sum, s) => sum + s.price, 0);

  if (selectedSlots.length === 0) return null;

  return (
    <div className="fixed bottom-0 left-0 right-0 bg-white border-t border-gray-100 px-6 py-4 shadow-[0_-10px_40px_rgba(0,0,0,0.04)] z-40">
      <div className="max-w-7xl mx-auto flex flex-col md:flex-row items-center justify-between gap-4">
        <div className="flex items-center gap-6">
          <div className="flex flex-col">
            <span className="text-[11px] font-medium text-gray-500 mb-0.5">Sẵn sàng đặt sân</span>
            <div className="flex items-baseline gap-2">
              <span className="text-2xl font-bold text-gray-900">
                {new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(totalPrice)}
              </span>
              <span className="text-xs text-gray-400">{selectedSlots.length} sân đã chọn</span>
            </div>
          </div>
        </div>

        <div className="flex items-center gap-3 w-full md:w-auto">
          <Button
            onClick={onBookWallet}
            disabled={isLoading}
            variant="outline"
            className="flex-1 md:flex-none h-12 px-6 rounded-xl text-emerald-600 border-emerald-100 hover:bg-emerald-50 font-semibold text-sm transition-all"
          >
            <Wallet size={18} className="mr-2" /> Thanh toán ví
          </Button>
          <Button
            onClick={onBookBank}
            disabled={isLoading}
            className="flex-1 md:flex-none h-12 px-10 rounded-xl bg-emerald-600 hover:bg-emerald-700 text-white font-semibold text-sm shadow-md shadow-emerald-600/10 active:scale-[0.98] transition-all"
          >
            Tiếp tục đặt sân
          </Button>
        </div>
      </div>
    </div>
  );
}
