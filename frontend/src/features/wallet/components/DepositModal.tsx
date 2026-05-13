import React, { useState } from "react";
import { 
  Dialog, 
  DialogContent, 
  DialogHeader, 
  DialogTitle,
  DialogFooter
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { Alert, AlertDescription } from "@/shared/components/ui/alert";
import { Info, Download, Copy, Check } from "lucide-react";
import { toast } from "sonner";
import type { DepositResponse } from "../types";

interface DepositModalProps {
  isOpen: boolean;
  onClose: () => void;
  onDeposit: (amount: number) => Promise<DepositResponse>;
  isLoading: boolean;
}

export const DepositModal: React.FC<DepositModalProps> = ({ isOpen, onClose, onDeposit, isLoading }) => {
  const [amountStr, setAmountStr] = useState<string>("50,000");
  const [step, setStep] = useState<"input" | "qr">("input");
  const [qrData, setQrData] = useState<DepositResponse | null>(null);
  const [copied, setCopied] = useState(false);

  const formatNumber = (val: string) => {
    const num = val.replace(/\D/g, "");
    if (!num) return "";
    return parseInt(num).toLocaleString("en-US");
  };

  const handleAmountChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const formatted = formatNumber(e.target.value);
    setAmountStr(formatted);
  };

  const handleNext = async () => {
    const numAmount = parseInt(amountStr.replace(/,/g, ""));
    if (isNaN(numAmount) || numAmount < 10000) {
      toast.error("Số tiền tối thiểu là 10,000đ");
      return;
    }
    
    try {
      const result = await onDeposit(numAmount);
      setQrData(result);
      setStep("qr");
    } catch (error) {
      // Error handled by mutation
    }
  };

  const handleClose = () => {
    setStep("input");
    setQrData(null);
    setAmountStr("50,000");
    onClose();
  };

  const copyToClipboard = (text: string) => {
    navigator.clipboard.writeText(text);
    setCopied(true);
    toast.success("Đã sao chép nội dung");
    setTimeout(() => setCopied(false), 2000);
  };

  return (
    <Dialog open={isOpen} onOpenChange={handleClose}>
      <DialogContent className={step === "qr" ? "sm:max-w-[450px]" : "sm:max-w-[400px] rounded-[1.5rem] border-none shadow-2xl p-0 overflow-hidden"}>
        <div className="bg-emerald-600 px-6 py-4">
          <DialogTitle className="text-lg font-bold text-white">
            {step === "input" ? "Nạp tiền vào ví" : "Quét mã QR"}
          </DialogTitle>
        </div>

        {step === "input" ? (
          <div className="p-6 space-y-5">
            <div className="space-y-3">
              <Label htmlFor="amount" className="text-[10px] font-bold text-slate-400 uppercase tracking-widest">Số tiền (VNĐ)</Label>
              <div className="relative">
                <Input 
                  id="amount" 
                  type="text" 
                  value={amountStr} 
                  onChange={handleAmountChange}
                  placeholder="Nhập số tiền"
                  className="text-xl h-12 font-bold text-emerald-600 border-slate-200 focus-visible:ring-emerald-500 rounded-xl pr-10"
                />
                <span className="absolute right-3 top-1/2 -translate-y-1/2 text-sm font-bold text-slate-300">đ</span>
              </div>
              <div className="flex justify-between items-center px-1">
                <p className="text-[10px] text-slate-400 italic">* Tối thiểu 10,000đ</p>
                <p className="text-[10px] font-bold text-emerald-600 bg-emerald-50 px-2 py-0.5 rounded-full">
                  {amountStr || "0"} đ
                </p>
              </div>
            </div>

            <div className="grid grid-cols-3 gap-2">
              {["50,000", "100,000", "200,000", "500,000", "1,000,000", "2,000,000"].map((val) => (
                <Button 
                  key={val} 
                  variant="outline" 
                  size="sm"
                  onClick={() => setAmountStr(val)}
                  className={`rounded-lg font-bold text-[11px] h-9 transition-all ${
                    amountStr === val 
                      ? "border-emerald-500 bg-emerald-50 text-emerald-600" 
                      : "hover:border-emerald-100 hover:bg-emerald-50/50 text-slate-600"
                  }`}
                >
                  {val}
                </Button>
              ))}
            </div>

            <div className="flex items-start gap-3 bg-slate-50 p-3 rounded-xl border border-slate-100">
              <Info className="h-4 w-4 text-emerald-600 mt-0.5 shrink-0" />
              <p className="text-[10px] text-slate-500 leading-relaxed">
                Tiền sẽ được cộng vào ví ngay sau khi hệ thống xác nhận giao dịch thành công (thường mất 1-3 phút).
              </p>
            </div>

            <div className="flex gap-2 pt-2">
              <Button variant="ghost" onClick={handleClose} className="flex-1 font-bold rounded-xl h-10 text-sm">Hủy</Button>
              <Button onClick={handleNext} disabled={isLoading} className="flex-[2] bg-emerald-600 hover:bg-emerald-500 font-bold rounded-xl h-10 text-sm shadow-md">
                {isLoading ? "Đang xử lý..." : "Tiếp tục"}
              </Button>
            </div>
          </div>
        ) : (
          <div className="p-6 flex flex-col items-center space-y-5 text-center">
            <div className="bg-white p-4 rounded-2xl shadow-sm border border-slate-100">
              {qrData?.qrCodeUrl && (
                <img src={qrData.qrCodeUrl} alt="QR Code" className="w-48 h-48 mx-auto" />
              )}
            </div>

            <div className="w-full bg-slate-50 p-4 rounded-xl border border-slate-100 text-left space-y-3">
              <div className="flex justify-between items-center">
                <span className="text-[11px] font-bold text-slate-400 uppercase tracking-wider">Số tiền</span>
                <span className="text-lg font-black text-emerald-600">{qrData?.amount.toLocaleString()}đ</span>
              </div>
              <div className="flex justify-between items-center border-t border-slate-200 pt-3">
                <span className="text-[11px] font-bold text-slate-400 uppercase tracking-wider">Nội dung</span>
                <div className="flex items-center gap-2">
                  <span className="text-xs font-mono font-bold text-slate-700 bg-white px-2 py-1 rounded border border-slate-200">
                    {qrData?.id.replace(/-/g, "").toUpperCase().substring(0, 10)}...
                  </span>
                  <Button 
                    variant="ghost" 
                    size="icon" 
                    className="h-7 w-7 hover:bg-emerald-50 hover:text-emerald-600" 
                    onClick={() => copyToClipboard(`WA-${qrData?.id.replace(/-/g, "").toUpperCase()}`)}
                  >
                    {copied ? <Check className="w-4 h-4 text-emerald-500" /> : <Copy className="w-4 h-4 text-slate-400" />}
                  </Button>
                </div>
              </div>
            </div>

            <Button onClick={handleClose} className="w-full bg-slate-900 hover:bg-slate-800 text-white font-bold py-5 rounded-xl text-sm shadow-lg">
              Tôi đã hoàn tất chuyển khoản
            </Button>
          </div>
        )}
      </DialogContent>
    </Dialog>
  );
};
