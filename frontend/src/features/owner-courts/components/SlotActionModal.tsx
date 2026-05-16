import { useState, useEffect } from "react";
import { 
  Dialog, 
  DialogContent, 
  DialogHeader, 
  DialogTitle,
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { cn } from "@/lib/utils";
import { Loader2, Unlock } from "lucide-react";
import { useUnlockException, useRemoveOverrideSlot, useUpdateConfigSlotPrice } from "../hooks/useOwnerSlots";

interface SlotActionModalProps {
  slot: any;
  isOpen: boolean;
  onOpenChange: (open: boolean) => void;
}

export function SlotActionModal({
  slot,
  isOpen,
  onOpenChange
}: SlotActionModalProps) {
  const unlockMutation = useUnlockException();
  const removeOverrideMutation = useRemoveOverrideSlot();
  const updatePriceMutation = useUpdateConfigSlotPrice();
  const [newPrice, setNewPrice] = useState("");

  const formatVND = (val: string) => {
    const num = val.replace(/\D/g, "");
    if (!num) return "";
    return parseInt(num).toLocaleString("vi-VN");
  };

  useEffect(() => {
    if (slot?.price) {
      setNewPrice(formatVND(slot.price.toString()));
    }
  }, [slot]);

  if (!slot) return null;

  const handleAction = async () => {
    try {
      if (slot.type === "Blocked" && slot.exceptionId) {
        await unlockMutation.mutateAsync(slot.exceptionId);
      } else if (slot.type === "Override" && slot.overrideSlotId) {
        await removeOverrideMutation.mutateAsync(slot.overrideSlotId);
      } else if (slot.configSlotId) {
        await updatePriceMutation.mutateAsync({
          configSlotId: slot.configSlotId,
          newPrice: Number(newPrice.replace(/\./g, ""))
        });
      }
      onOpenChange(false);
    } catch (error) {}
  };

  const isPending = unlockMutation.isPending || removeOverrideMutation.isPending || updatePriceMutation.isPending;

  const getTheme = () => {
    switch (slot.type) {
      case "Blocked":
        return {
          title: "Mở khóa slot",
          actionLabel: "Xác nhận mở khóa",
          confirmColor: "bg-rose-600 hover:bg-rose-700 shadow-rose-600/20",
          description: "Khung giờ này đang bị khóa. Bạn có chắc chắn muốn mở khóa để khách hàng có thể đặt sân không?"
        };
      case "Override":
        return {
          title: "Gỡ gộp slot",
          actionLabel: "Xác nhận gỡ gộp",
          confirmColor: "bg-violet-600 hover:bg-violet-700 shadow-violet-600/20",
          description: "Khung giờ này đã được gộp. Bạn có chắc chắn muốn gỡ gộp để khung giờ trở về trạng thái mặc định không?"
        };
      default:
        return {
          title: "Cập nhật giá slot",
          actionLabel: "Cập nhật ngay",
          confirmColor: "bg-emerald-600 hover:bg-emerald-700 shadow-emerald-600/20",
          description: "Thay đổi giá tiền cho khung giờ này."
        };
    }
  };

  const theme = getTheme();

  return (
    <Dialog open={isOpen} onOpenChange={onOpenChange}>
      <DialogContent className="sm:max-w-[420px] rounded-[32px] p-0 overflow-hidden border-none shadow-2xl">
        <div className="relative p-8 space-y-6 bg-white">
          {/* Header Section */}
          <div className="flex flex-col items-center text-center space-y-3 pt-4">
            <div className="space-y-2">
              <DialogHeader>
                <DialogTitle className="text-2xl font-black text-gray-900 tracking-tight">
                  {theme.title}
                </DialogTitle>
              </DialogHeader>
              <div className="inline-flex items-center gap-2 px-3 py-1 bg-gray-100 rounded-full text-[11px] font-bold text-gray-500 uppercase tracking-wider">
                <Unlock size={12} className="opacity-60" />
                {slot.startTime.substring(0, 5)} — {slot.endTime.substring(0, 5)}
              </div>
            </div>
          </div>

          {/* Content Section */}
          <div className="space-y-5">
            {slot.type === "Blocked" || slot.type === "Override" ? (
              <div className="text-center px-2">
                <p className="text-sm font-medium text-gray-600 leading-relaxed">
                  {theme.description}
                </p>
              </div>
            ) : (
              <div className="space-y-3">
                <Label className="text-[10px] font-black uppercase tracking-[0.15em] text-gray-400 ml-1">
                  Giá tiền mới (VNĐ)
                </Label>
                <div className="relative group">
                  <div className="absolute left-4 top-1/2 -translate-y-1/2 text-emerald-500 font-black text-lg">₫</div>
                  <Input 
                    type="text" 
                    value={newPrice}
                    onChange={(e) => setNewPrice(formatVND(e.target.value))}
                    className="pl-10 h-14 rounded-2xl bg-gray-50 border-gray-100 focus:bg-white focus:ring-4 focus:ring-emerald-500/5 transition-all font-bold text-lg text-gray-900"
                    placeholder="0"
                  />
                </div>
                <p className="text-[10px] text-gray-400 font-medium ml-1">
                  * Giá này sẽ được áp dụng cho slot hiện tại.
                </p>
              </div>
            )}
          </div>

          {/* Footer Section */}
          <div className="flex flex-col sm:flex-row gap-3 pt-2">
            <Button 
              variant="ghost" 
              onClick={() => onOpenChange(false)} 
              className="flex-1 h-14 rounded-2xl font-bold text-gray-500 hover:bg-gray-50"
            >
              Hủy
            </Button>
            <Button 
              onClick={handleAction}
              disabled={isPending}
              className={cn(
                "flex-[1.5] h-14 rounded-2xl font-black text-white shadow-lg transition-all active:scale-95",
                theme.confirmColor
              )}
            >
              {isPending ? (
                <div className="flex items-center gap-2">
                  <Loader2 className="animate-spin" size={20} />
                  <span>Đang xử lý</span>
                </div>
              ) : (
                theme.actionLabel
              )}
            </Button>
          </div>
        </div>
      </DialogContent>
    </Dialog>
  );
}
