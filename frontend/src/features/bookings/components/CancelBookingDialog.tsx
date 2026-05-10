import { 
  Dialog, 
  DialogContent, 
  DialogHeader, 
  DialogTitle, 
  DialogDescription, 
  DialogFooter 
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { AlertCircle, Loader2, Info } from "lucide-react";
import { useCancelBooking, useRefundBooking } from "../hooks";
import { toast } from "sonner";

interface CancelBookingDialogProps {
  bookingId: string | null;
  status: string | null;
  isOpen: boolean;
  onClose: () => void;
}

export function CancelBookingDialog({ bookingId, status, isOpen, onClose }: CancelBookingDialogProps) {
  const { mutate: cancelBooking, isPending: isCancelling } = useCancelBooking();
  const { mutate: refundBooking, isPending: isRefunding } = useRefundBooking();

  const isPending = status === "Pending";
  const isBanked = status === "Banked";
  
  const isProcessing = isCancelling || isRefunding;

  const handleConfirm = () => {
    if (!bookingId) return;
    
    if (isPending) {
      cancelBooking(bookingId, {
        onSuccess: () => {
          toast.success("Hủy đặt sân thành công");
          onClose();
        },
      });
    } else if (isBanked) {
      refundBooking(bookingId, {
        onSuccess: () => {
          toast.success("Yêu cầu hoàn tiền đã được gửi thành công");
          onClose();
        },
      });
    } else {
      toast.error("Không thể xử lý yêu cầu cho trạng thái này");
    }
  };

  const getDialogContent = () => {
    if (isBanked) {
      return {
        title: "Xác nhận hoàn tiền",
        description: "Bạn đã thanh toán cho đơn này. Hệ thống sẽ thực hiện hoàn tiền theo chính sách của sân.",
        confirmText: "Yêu cầu hoàn tiền",
        icon: <Info size={32} className="text-blue-500" />,
        iconBg: "bg-blue-50",
      };
    }
    return {
      title: "Xác nhận hủy đặt sân",
      description: "Bạn có chắc chắn muốn hủy đơn đặt sân này không?",
      confirmText: "Xác nhận hủy sân",
      icon: <AlertCircle size={32} className="text-red-500" />,
      iconBg: "bg-red-50",
    };
  };

  const content = getDialogContent();

  return (
    <Dialog open={isOpen} onOpenChange={(open) => !open && onClose()}>
      <DialogContent className="max-w-md rounded-3xl p-8 border-none shadow-2xl">
        <DialogHeader className="items-center text-center">
          <div className={`w-16 h-16 rounded-full ${content.iconBg} flex items-center justify-center mb-4`}>
            {content.icon}
          </div>
          <DialogTitle className="text-2xl font-black text-gray-900">
            {content.title}
          </DialogTitle>
          <DialogDescription className="text-gray-500 font-medium pt-2">
            {content.description}
          </DialogDescription>
        </DialogHeader>

        <DialogFooter className="sm:flex-col gap-3 mt-8">
          <Button
            onClick={handleConfirm}
            disabled={isProcessing}
            className={`w-full ${isBanked ? 'bg-blue-500 hover:bg-blue-600 shadow-blue-200' : 'bg-red-500 hover:bg-red-600 shadow-red-200'} text-white rounded-2xl h-12 font-bold text-base shadow-lg`}
          >
            {isProcessing ? (
              <>
                <Loader2 className="mr-2 h-4 w-4 animate-spin" />
                Đang xử lý...
              </>
            ) : content.confirmText}
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
