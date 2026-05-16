import React, { useState, useEffect } from "react";
import { 
  Dialog, 
  DialogContent, 
  DialogTitle,
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { Info, Copy, Check, Timer, AlertCircle, Loader2 } from "lucide-react";
import { toast } from "sonner";
import type { DepositResponse } from "../types";
import { useWallet } from "../hooks/useWallet";

interface DepositModalProps {
  isOpen: boolean;
  onClose: () => void;
  onDeposit: (amount: number) => Promise<DepositResponse>;
  isLoading: boolean;
}

export const DepositModal: React.FC<DepositModalProps> = ({ isOpen, onClose, onDeposit, isLoading }) => {
  const [amountStr, setAmountStr] = useState<string>("");
  const [step, setStep] = useState<"input" | "qr" | "success">("input");
  const [qrData, setQrData] = useState<DepositResponse | null>(null);
  const [copied, setCopied] = useState(false);
  const [timeLeft, setTimeLeft] = useState(60);
  const [isVerifying, setIsVerifying] = useState(false);

  const { checkDepositStatusMutation } = useWallet();

  // Timer logic
  useEffect(() => {
    let timer: any;
    if (step === "qr" && timeLeft > 0) {
      timer = setInterval(() => {
        setTimeLeft((prev) => prev - 1);
      }, 1000);
    }
    return () => clearInterval(timer);
  }, [step, timeLeft]);

  // Polling logic for verification
  useEffect(() => {
    let pollInterval: any;
    if (step === "qr" && timeLeft > 0 && !isVerifying) {
      pollInterval = setInterval(() => {
        handleVerify();
      }, 5000);
    }
    return () => clearInterval(pollInterval);
  }, [step, timeLeft, isVerifying, qrData]);

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
      setQrData(result);
      setStep("qr");
      setTimeLeft(60);
    } catch (error) {
      // Error handled by mutation
    }
  };

  const handleVerify = async () => {
    if (!qrData) return;
    
    setIsVerifying(true);
    try {
      const status = await checkDepositStatusMutation.mutateAsync(qrData.transactionId);
      
      if (status === "Success") {
        setStep("success");
      } else if (status === "Expired") {
        setTimeLeft(0);
        toast.error("Giao dịch đã hết hạn");
      } else {
        toast.info("Hệ thống chưa ghi nhận được thanh toán. Vui lòng đợi trong giây lát.");
      }
    } catch (error) {
      toast.error("Không thể kiểm tra trạng thái lúc này");
    } finally {
      setIsVerifying(false);
    }
  };

  const handleClose = () => {
    setStep("input");
    setQrData(null);
    setAmountStr("");
    setTimeLeft(60);
    onClose();
  };

  const copyToClipboard = (text: string) => {
    if (typeof window !== "undefined" && window.navigator.clipboard) {
      window.navigator.clipboard.writeText(text);
      setCopied(true);
      toast.success("Đã sao chép nội dung");
      setTimeout(() => setCopied(false), 2000);
    }
  };

  return (
    <Dialog open={isOpen} onOpenChange={handleClose}>
      <DialogContent className="max-w-[420px] p-0 bg-white rounded-2xl border-none shadow-2xl overflow-hidden flex flex-col max-h-[95vh]">
        {/* Header Section */}
        {step !== "success" && (
          <div className="p-8 text-center border-b border-gray-50">
            <div className="w-16 h-16 bg-emerald-50 rounded-full flex items-center justify-center mx-auto mb-4">
              {step === "input" ? <Info size={32} className="text-emerald-500" /> : <Timer size={32} className="text-emerald-500" />}
            </div>
            <DialogTitle className="text-2xl font-bold text-gray-900 mb-1">
              {step === "input" ? "Nạp tiền vào ví" : "Thanh toán qua QR"}
            </DialogTitle>
            <p className="text-gray-400 text-xs font-medium">
              {step === "input" ? "Nhập số tiền bạn muốn nạp" : "Sử dụng ứng dụng ngân hàng để quét mã"}
            </p>
          </div>
        )}

        <div className="flex-1 overflow-y-auto custom-scrollbar">
          {step === "input" && (
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
          )}

          {step === "qr" && (
            <div className="p-8 space-y-6">
              {/* QR Section */}
              <div className="flex flex-col items-center">
                <div className={`p-4 bg-white rounded-2xl border-2 shadow-sm relative mb-4 transition-all ${timeLeft > 0 ? 'border-gray-50' : 'border-red-100 opacity-25 grayscale'}`}>
                  {qrData?.qrCodeUrl && (
                    <img src={qrData.qrCodeUrl} alt="QR Code" className="w-48 h-48 object-contain" />
                  )}
                  {timeLeft === 0 && (
                    <div className="absolute inset-0 flex flex-col items-center justify-center bg-white/60 backdrop-blur-[2px] rounded-xl">
                      <AlertCircle className="w-10 h-10 text-red-500 mb-2" />
                      <p className="text-[10px] font-bold text-red-600 uppercase tracking-widest">Đã hết hạn</p>
                    </div>
                  )}
                </div>
                
                <div className="flex items-center gap-2 px-4 py-2 bg-slate-50 rounded-full">
                  <Timer size={14} className={timeLeft <= 10 ? "text-red-500" : "text-emerald-600"} />
                  <span className={`text-xs font-black tabular-nums ${timeLeft <= 10 ? "text-red-500" : "text-emerald-600"}`}>
                    {Math.floor(timeLeft / 60)}:{(timeLeft % 60).toString().padStart(2, '0')}
                  </span>
                  <span className="text-[10px] text-slate-400 font-bold uppercase tracking-wider ml-1">còn lại</span>
                </div>
              </div>

              {/* Transaction Details */}
              <div className="space-y-3 bg-slate-50/50 p-5 rounded-xl border border-slate-100">
                <div className="flex justify-between items-center">
                  <span className="text-[10px] font-bold text-slate-400 uppercase tracking-widest">Số tiền nạp</span>
                  <span className="text-lg font-black text-emerald-600 tracking-tight">{qrData?.amount.toLocaleString()}đ</span>
                </div>
                <div className="flex justify-between items-center pt-3 border-t border-slate-200/60">
                  <span className="text-[10px] font-bold text-slate-400 uppercase tracking-widest">Nội dung chuyển khoản</span>
                  <div className="flex items-center gap-2">
                    <span className="text-xs font-bold text-gray-700 bg-white px-3 py-1.5 rounded-lg border border-slate-200">
                      WA-{qrData?.id.replace(/-/g, "").toUpperCase().substring(0, 10)}
                    </span>
                    <Button 
                      variant="ghost" 
                      size="icon" 
                      className="h-8 w-8 hover:bg-emerald-50 hover:text-emerald-600 rounded-lg" 
                      onClick={() => copyToClipboard(`WA-${qrData?.id.replace(/-/g, "").toUpperCase()}`)}
                    >
                      {copied ? <Check size={14} className="text-emerald-500" /> : <Copy size={14} className="text-slate-400" />}
                    </Button>
                  </div>
                </div>
              </div>

              {/* Verify Action */}
              <div className="space-y-4">
                <div className="flex items-center justify-center gap-2 py-3 px-4 bg-emerald-50 text-emerald-600 rounded-xl border border-emerald-100">
                  <Loader2 size={14} className="animate-spin" />
                  <span className="text-[10px] font-bold uppercase tracking-wider">Đang chờ hệ thống xác thực...</span>
                </div>

                {timeLeft === 0 && (
                  <Button variant="link" onClick={handleNext} className="w-full text-xs text-emerald-600 font-bold">Lấy mã QR mới</Button>
                )}
              </div>
            </div>
          )}

          {step === "success" && (
            <div className="p-10 flex flex-col items-center text-center space-y-6">
              <div className="w-20 h-20 bg-emerald-50 rounded-full flex items-center justify-center mb-2">
                <Check size={48} className="text-emerald-500 stroke-[3px]" />
              </div>
              
              <div className="space-y-2 pb-4">
                <h3 className="text-2xl font-bold text-gray-900">Nạp tiền thành công!</h3>
                <p className="text-sm text-slate-500 font-medium px-4">
                  Hệ thống đã xác nhận khoản nạp <span className="text-emerald-600 font-bold">{qrData?.amount.toLocaleString()}đ</span>. Số dư ví của bạn đã được cập nhật.
                </p>
              </div>

              <Button 
                onClick={handleClose} 
                className="w-full bg-emerald-600 hover:bg-emerald-700 text-white font-bold h-14 rounded-xl text-sm shadow-lg shadow-emerald-600/10 transition-all active:scale-95"
              >
                Về trang ví của tôi
              </Button>
            </div>
          )}
        </div>
      </DialogContent>
    </Dialog>
  );
};
