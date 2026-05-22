import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { 
  Dialog, 
  DialogContent, 
  DialogTitle,
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { Info, Loader2 } from "lucide-react";
import { toast } from "sonner";
import type { DepositResponse } from "../types";

interface DepositModalProps {
  isOpen: boolean;
  onClose: () => void;
  onDeposit: (amount: number) => Promise<DepositResponse>;
  isLoading: boolean;
}

export const DepositModal: React.FC<DepositModalProps> = ({ isOpen, onClose, onDeposit, isLoading }) => {
  const [amountStr, setAmountStr] = useState<string>("");
  const navigate = useNavigate();

  // Reset state
  useEffect(() => {
    if (isOpen) {
      setAmountStr("");
    }
  }, [isOpen]);

  const formatNumber = (val: string) => {
    const num = val.replace(/\D/g, "");
    if (!num) return "";
    return parseInt(num).toLocaleString("vi-VN");
  };

  const handleAmountChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const formatted = formatNumber(e.target.value);
    setAmountStr(formatted);
  };

  const handleNext = async () => {
    const numAmount = parseInt(amountStr.replace(/\./g, ""));
    if (isNaN(numAmount) || numAmount < 10000) {
      toast.error("Số tiền tối thiểu là 10,000đ");
      return;
    }
    
    try {
      const result = await onDeposit(numAmount);
      onClose();
      navigate("/payment", {
        state: {
          qrCodeUrl: result.qrCodeUrl,
          amount: result.amount,
          transactionId: result.transactionId || result.id, // Ensure we use the correct ID for polling
          transactionCode: `#${(result.transactionId || result.id).split('-')[0].toUpperCase()}`,
          content: "Nạp tiền vào ví",
          type: "wallet",
          expiredAt: new Date(Date.now() + 5 * 60000).toISOString(),
        }
      });
    } catch (error) {
      // Error handled by mutation
    }
  };

  const handleClose = () => {
    setAmountStr("");
    onClose();
  };

  return (
    <Dialog open={isOpen} onOpenChange={handleClose}>
      <DialogContent className="max-w-[420px] p-0 bg-white rounded-2xl border-none shadow-2xl overflow-hidden flex flex-col max-h-[95vh]">
        <div className="p-8 text-center border-b border-gray-50">
          <div className="w-16 h-16 bg-emerald-50 rounded-full flex items-center justify-center mx-auto mb-4">
            <Info size={32} className="text-emerald-500" />
          </div>
          <DialogTitle className="text-2xl font-bold text-gray-900 mb-1">
            Nạp tiền vào ví
          </DialogTitle>
          <p className="text-gray-400 text-xs font-medium">
            Nhập số tiền bạn muốn nạp
          </p>
        </div>

        <div className="flex-1 overflow-y-auto custom-scrollbar">
            <div className="p-8 space-y-6">
              <div className="space-y-4">
                <Label htmlFor="amount" className="text-xs font-semibold text-gray-500">Số tiền nạp (VNĐ)</Label>
                <div className="relative">
                  <Input 
                    id="amount" 
                    type="text" 
                    value={amountStr} 
                    onChange={handleAmountChange}
                    placeholder="Ví dụ: 100.000"
                    className="text-2xl h-14 font-bold text-gray-900 border-gray-100 bg-slate-50/50 focus-visible:ring-emerald-500 rounded-xl pr-12 transition-all"
                  />
                  <span className="absolute right-4 top-1/2 -translate-y-1/2 text-lg font-bold text-gray-300">đ</span>
                </div>
              </div>

              <div className="grid grid-cols-3 gap-2">
                {["50.000", "100.000", "200.000", "500.000", "1.000.000", "2.000.000"].map((val) => (
                  <Button 
                    key={val} 
                    variant="outline" 
                    size="sm"
                    onClick={() => setAmountStr(val)}
                    className={`rounded-xl font-semibold text-xs h-10 transition-all ${
                      amountStr === val 
                        ? "border-emerald-500 bg-emerald-50 text-emerald-600" 
                        : "border-gray-100 hover:border-emerald-100 hover:bg-emerald-50/50 text-gray-600"
                    }`}
                  >
                    {val}
                  </Button>
                ))}
              </div>

              <div className="flex items-start gap-3 bg-slate-50 p-4 rounded-xl border border-slate-100">
                <Info className="h-4 w-4 text-emerald-600 mt-0.5 shrink-0" />
                <p className="text-[11px] text-slate-500 leading-relaxed font-medium">
                  Tiền sẽ được cộng vào ví ngay sau khi hệ thống xác nhận giao dịch thành công.
                </p>
              </div>

              <div className="flex gap-3 pt-4">
                <Button variant="ghost" onClick={handleClose} className="flex-1 font-semibold rounded-xl h-12 text-sm text-gray-400">Hủy</Button>
                <Button onClick={handleNext} disabled={isLoading} className="flex-[2] bg-emerald-600 hover:bg-emerald-700 text-white font-semibold rounded-xl h-12 text-sm shadow-lg shadow-emerald-600/10 transition-all">
                  {isLoading ? <Loader2 className="animate-spin mr-2" size={18} /> : null}
                  Tiếp tục nạp tiền
                </Button>
              </div>
            </div>
        </div>
      </DialogContent>
    </Dialog>
  );
};
