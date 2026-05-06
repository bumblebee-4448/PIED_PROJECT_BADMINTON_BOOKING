import { 
  Dialog, 
  DialogContent, 
  DialogHeader, 
  DialogTitle, 
  DialogDescription, 
  DialogFooter 
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { AlertCircle, CheckCircle2, Loader2 } from "lucide-react";
import { useCheckCancel } from "../hooks/useCheckCancel";
import { useCancelBooking } from "../hooks/useCancelBooking";
import { toast } from "sonner";
import { cn } from "@/lib/utils";

interface CancelBookingDialogProps {
  bookingId: string | null;
  isOpen: boolean;
  onClose: () => void;
}

export function CancelBookingDialog({ bookingId, isOpen, onClose }: CancelBookingDialogProps) {
  // useCheckCancel giờ là query — tự động fetch khi bookingId có giá trị
  // Không cần useEffect nữa
  const { data: checkData, isLoading: isChecking } = useCheckCancel(isOpen ? bookingId : null);
  const { mutate: cancelBooking, isPending: isCancelling } = useCancelBooking();

  const handleConfirm = () => {
    if (!bookingId) return;
    
    cancelBooking(bookingId, {
      onSuccess: () => {
        toast.success("Hủy đặt sân thành công");
        onClose();
      },
    });
  };

  const canCancel = checkData?.data === true;
  const message = checkData?.message || "";

  return (
    <Dialog open={isOpen} onOpenChange={(open) => !open && onClose()}>
      <DialogContent className="max-w-md rounded-3xl p-8 border-none shadow-2xl">
        <DialogHeader className="items-center text-center">
          <div className="w-16 h-16 rounded-full bg-red-50 flex items-center justify-center text-red-500 mb-4">
            <AlertCircle size={32} />
          </div>
          <DialogTitle className="text-2xl font-black text-gray-900">
            Xác nhận hủy đặt sân
          </DialogTitle>
          <DialogDescription className="text-gray-500 font-medium pt-2">
            Bạn có chắc chắn muốn hủy đơn đặt sân này không?
          </DialogDescription>
        </DialogHeader>

        <div className="py-6">
          {isChecking ? (
            <div className="flex flex-col items-center justify-center py-4 gap-3 text-gray-400">
              <Loader2 className="animate-spin" />
              <span className="text-xs font-bold uppercase tracking-widest">Đang kiểm tra điều kiện...</span>
            </div>
          ) : (
            <div className={cn(
              "p-4 rounded-2xl flex gap-3 items-start border",
              canCancel ? "bg-emerald-50 border-emerald-100 text-emerald-700" : "bg-orange-50 border-orange-100 text-orange-700"
            )}>
              {canCancel ? <CheckCircle2 size={18} className="shrink-0 mt-0.5" /> : <AlertCircle size={18} className="shrink-0 mt-0.5" />}
              <div className="text-sm font-bold leading-relaxed">
                {message || (canCancel ? "Bạn đủ điều kiện để hủy sân và được hoàn tiền." : "Không thể hủy sân vào lúc này.")}
              </div>
            </div>
          )}
        </div>

        <DialogFooter className="sm:flex-col gap-3">
          <Button
            onClick={handleConfirm}
            disabled={!canCancel || isCancelling || isChecking}
            className="w-full bg-red-500 hover:bg-red-600 text-white rounded-2xl h-12 font-bold text-base shadow-lg shadow-red-200"
          >
            {isCancelling ? (
              <>
                <Loader2 className="mr-2 h-4 w-4 animate-spin" />
                Đang xử lý...
              </>
            ) : "Xác nhận hủy sân"}
          </Button>
          <Button
            variant="ghost"
            onClick={onClose}
            className="w-full rounded-2xl h-12 font-bold text-gray-500 hover:bg-gray-100"
          >
            Quay lại
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}
