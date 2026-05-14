import React, { useState } from "react";
import { 
  Dialog, 
  DialogContent, 
  DialogTitle,
  DialogFooter,
  DialogDescription
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import type { WalletInfo } from "../types";
import { toast } from "sonner";
import { AlertCircle } from "lucide-react";

interface WithdrawalModalProps {
  isOpen: boolean;
  onClose: () => void;
  onSubmit: (amount: number) => void;
  isLoading: boolean;
  wallet: WalletInfo;
}

export const WithdrawalModal: React.FC<WithdrawalModalProps> = ({ isOpen, onClose, onSubmit, isLoading, wallet }) => {
  const [amountStr, setAmountStr] = useState<string>("");

  const formatNumber = (val: string) => {
    const num = val.replace(/\D/g, "");
    if (!num) return "";
    return parseInt(num).toLocaleString("en-US");
  };

  const handleAmountChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setAmountStr(formatNumber(e.target.value));
  };

  const handleFormSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const numAmount = parseInt(amountStr.replace(/,/g, ""));
    
    if (isNaN(numAmount) || numAmount < 50000) {
      toast.error("Số tiền rút tối thiểu là 50,000đ");
      return;
    }
    
    if (numAmount > (wallet?.balance || 0)) {
      toast.error("Số dư ví không đủ");
      return;
    }

    onSubmit(numAmount);
    setAmountStr("");
  };

  if (!wallet) return null;

  return (
    <Dialog open={isOpen} onOpenChange={onClose}>
      <DialogContent className="sm:max-w-[400px] rounded-[1.5rem] border-none shadow-2xl p-0 overflow-hidden">
        <div className="bg-emerald-600 px-6 py-4">
          <DialogTitle className="text-lg font-bold text-white">Rút tiền về tài khoản</DialogTitle>
          <DialogDescription className="text-emerald-100 text-xs mt-1">
            Tiền sẽ được chuyển về ngân hàng đã liên kết.
          </DialogDescription>
        </div>
        
        <form onSubmit={handleFormSubmit} className="p-6 space-y-5">
          <div className="bg-slate-50 p-4 rounded-xl border border-slate-100 space-y-1">
            <p className="text-[10px] text-slate-400 uppercase font-black tracking-widest mb-2">Tài khoản thụ hưởng</p>
            <div className="flex justify-between items-center">
              <span className="text-xs font-bold text-slate-700">{wallet.bankName || "Chưa thiết lập"}</span>
              <span className="text-sm font-mono font-black text-emerald-600">{wallet.bankAccount || "---"}</span>
            </div>
            <p className="text-[11px] text-slate-500 font-medium uppercase">{wallet.bankAccountName || "---"}</p>
          </div>

          <div className="space-y-3">
            <div className="flex justify-between items-baseline px-1">
              <Label htmlFor="w-amount" className="text-[10px] font-bold text-slate-400 uppercase tracking-widest">Số tiền rút</Label>
              <span className="text-[10px] font-bold text-emerald-600 bg-emerald-50 px-2 py-0.5 rounded-full">
                Khả dụng: {wallet.balance.toLocaleString()}đ
              </span>
            </div>
            <div className="relative">
              <Input 
                id="w-amount" 
                type="text" 
                value={amountStr} 
                onChange={handleAmountChange}
                placeholder="Nhập số tiền (Tối thiểu 50.000đ)"
                className="text-lg h-12 font-bold text-slate-700 border-slate-200 focus-visible:ring-emerald-500 rounded-xl pr-10"
              />
              <span className="absolute right-3 top-1/2 -translate-y-1/2 text-sm font-bold text-slate-300">đ</span>
            </div>
          </div>

          <div className="flex items-start gap-3 p-3 bg-amber-50 rounded-xl border border-amber-100">
            <AlertCircle className="w-4 h-4 text-amber-600 mt-0.5 shrink-0" />
            <p className="text-[10px] text-amber-700 leading-relaxed font-medium">
              Yêu cầu rút tiền sẽ được Admin duyệt trong vòng 24h. Vui lòng kiểm tra kỹ thông tin ngân hàng.
            </p>
          </div>

          <DialogFooter className="pt-2 flex gap-2">
            <Button type="button" variant="ghost" onClick={onClose} className="flex-1 font-bold rounded-xl h-10 text-sm">Hủy</Button>
            <Button type="submit" disabled={isLoading || wallet.balance < 50000} className="flex-[2] bg-emerald-600 hover:bg-emerald-500 font-bold rounded-xl h-10 text-sm shadow-md">
              {isLoading ? "Đang xử lý..." : "Xác nhận rút ngay"}
            </Button>
          </DialogFooter>
        </form>
      </DialogContent>
    </Dialog>
  );
};
