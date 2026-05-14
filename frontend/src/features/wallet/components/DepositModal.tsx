import React, { useState, useEffect } from "react";
import { 
  Dialog, 
  DialogContent, 
  DialogTitle,
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { Info, Copy, Check, Timer, AlertCircle, Loader2, Trophy } from "lucide-react";
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
      <DialogContent className={step === "qr" ? "sm:max-w-[450px] p-0 overflow-hidden border-none rounded-[2rem] shadow-2xl" : "sm:max-w-[400px] rounded-[1.5rem] border-none shadow-2xl p-0 overflow-hidden"}>
        {step !== "success" && (
          <div className="bg-emerald-600 px-6 py-5">
            <DialogTitle className="text-xl font-black text-white tracking-tight">
              {step === "input" ? "Nạp tiền vào ví" : "Thanh toán qua QR"}
            </DialogTitle>
          </div>
        )}

        {step === "input" && (
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
                Tiền sẽ được cộng vào ví ngay sau khi hệ thống xác nhận giao dịch thành công.
              </p>
            </div>

            <div className="flex gap-2 pt-2">
              <Button variant="ghost" onClick={handleClose} className="flex-1 font-bold rounded-xl h-10 text-sm">Hủy</Button>
              <Button onClick={handleNext} disabled={isLoading} className="flex-[2] bg-emerald-600 hover:bg-emerald-500 font-bold rounded-xl h-10 text-sm shadow-md">
                {isLoading ? "Đang xử lý..." : "Tiếp tục"}
              </Button>
            </div>
          </div>
        )}

        {step === "qr" && (
          <div className="p-6 flex flex-col items-center space-y-6 text-center">
            {/* QR Section */}
            <div className="relative w-full flex flex-col items-center">
              <div className={`bg-white p-5 rounded-[2.5rem] shadow-2xl border-2 transition-all duration-700 relative z-10 ${timeLeft > 0 ? 'border-emerald-50' : 'border-red-100 opacity-40 grayscale'}`}>
                {qrData?.qrCodeUrl && (
                  <img src={qrData.qrCodeUrl} alt="QR Code" className="w-52 h-52 mx-auto" />
                )}
              </div>
              
              {/* Progress Bar Container */}
              <div className="w-52 h-1.5 bg-slate-100 rounded-full mt-6 overflow-hidden relative">
                <div 
                  className={`absolute left-0 top-0 h-full transition-all duration-1000 ease-linear rounded-full ${
                    timeLeft > 20 ? 'bg-emerald-500' : timeLeft > 10 ? 'bg-amber-500' : 'bg-red-500 animate-pulse'
                  }`}
                  style={{ width: `${(timeLeft / 60) * 100}%` }}
                />
              </div>

              {timeLeft === 0 && (
                <div className="absolute inset-0 z-20 flex flex-col items-center justify-center bg-white/60 rounded-[2.5rem] backdrop-blur-[2px]">
                  <AlertCircle className="w-12 h-12 text-red-500 mb-2" />
                  <p className="text-sm font-black text-red-600 uppercase tracking-tighter">Mã QR hết hạn</p>
                  <Button variant="link" onClick={handleNext} className="text-xs text-emerald-600 font-bold mt-2">Lấy mã mới</Button>
                </div>
              )}
            </div>

            <div className="w-full bg-slate-50 p-5 rounded-[1.5rem] border border-slate-100 text-left space-y-4">
              <div className="flex justify-between items-center">
                <span className="text-[10px] font-black text-slate-400 uppercase tracking-widest">Số tiền</span>
                <span className="text-xl font-black text-emerald-600 tracking-tight">{qrData?.amount.toLocaleString()}đ</span>
              </div>
              <div className="flex justify-between items-center border-t border-slate-200 pt-4">
                <span className="text-[10px] font-black text-slate-400 uppercase tracking-widest">Nội dung</span>
                <div className="flex items-center gap-2">
                  <span className="text-xs font-mono font-bold text-slate-700 bg-white px-3 py-1.5 rounded-lg border border-slate-200">
                    WA-{qrData?.id.replace(/-/g, "").toUpperCase().substring(0, 10)}
                  </span>
                  <Button 
                    variant="ghost" 
                    size="icon" 
                    className="h-8 w-8 hover:bg-emerald-50 hover:text-emerald-600 rounded-lg transition-colors" 
                    onClick={() => copyToClipboard(`WA-${qrData?.id.replace(/-/g, "").toUpperCase()}`)}
                  >
                    {copied ? <Check className="w-4 h-4 text-emerald-500" /> : <Copy className="w-4 h-4 text-slate-400" />}
                  </Button>
                </div>
              </div>
            </div>

            <div className="w-full space-y-4">
              {/* New Timer Display */}
              <div className="flex items-center justify-center gap-2 py-1">
                <Timer className={`w-4 h-4 ${timeLeft <= 10 ? 'text-red-500 animate-bounce' : 'text-slate-400'}`} />
                <span className={`text-sm font-bold tracking-tighter ${timeLeft <= 10 ? 'text-red-600' : 'text-slate-600'}`}>
                  {timeLeft > 0 ? (
                    <>Mã hết hạn sau: <span className="font-black underline decoration-2 decoration-emerald-200 underline-offset-4">{Math.floor(timeLeft / 60)}:{(timeLeft % 60).toString().padStart(2, '0')}</span></>
                  ) : (
                    "Phiên giao dịch đã kết thúc"
                  )}
                </span>
              </div>

              <Button 
                onClick={handleVerify} 
                disabled={isVerifying || timeLeft === 0}
                className="w-full bg-slate-900 hover:bg-slate-800 text-white font-bold py-7 rounded-2xl text-sm shadow-xl transition-all active:scale-95 disabled:opacity-50 flex items-center justify-center gap-3 group"
              >
                {isVerifying ? (
                  <>
                    <Loader2 className="w-4 h-4 animate-spin" />
                    Đang xác thực giao dịch...
                  </>
                ) : (
                  <>
                    Tôi đã hoàn tất chuyển khoản
                    <div className="w-1.5 h-1.5 rounded-full bg-emerald-400 group-hover:scale-150 transition-transform" />
                  </>
                )}
              </Button>
              <p className="text-[10px] text-slate-400 font-medium italic">
                * Vui lòng giữ màn hình này cho đến khi tiền vào ví thành công.
              </p>
            </div>
          </div>
        )}

        {step === "success" && (
          <div className="p-8 flex flex-col items-center text-center space-y-6 animate-in zoom-in-95 duration-300">
            <div className="relative">
              <div className="absolute inset-0 bg-emerald-500/20 blur-3xl rounded-full scale-150 animate-pulse" />
              <div className="bg-emerald-100 p-6 rounded-full relative">
                <div className="bg-emerald-500 p-4 rounded-full shadow-lg shadow-emerald-200">
                  <Check className="w-12 h-12 text-white stroke-[3px]" />
                </div>
              </div>
            </div>
            
            <div className="space-y-2">
              <h3 className="text-2xl font-black text-slate-800 tracking-tight">Thành công rực rỡ!</h3>
              <p className="text-sm text-slate-500 font-medium px-4">
                Hệ thống đã xác nhận khoản nạp <span className="text-emerald-600 font-bold">{qrData?.amount.toLocaleString()}đ</span>. Số dư đã được cập nhật ngay lập tức.
              </p>
            </div>

            <div className="bg-slate-50 w-full p-4 rounded-2xl border border-slate-100 flex items-center gap-4 text-left">
              <div className="bg-amber-100 p-2.5 rounded-xl text-amber-600">
                <Trophy className="w-5 h-5" />
              </div>
              <div>
                <p className="text-[10px] text-slate-400 font-bold uppercase tracking-widest mb-0.5">Phần thưởng</p>
                <p className="text-xs font-bold text-slate-700 leading-tight">Giao dịch này giúp bạn tích lũy thêm điểm hội viên!</p>
              </div>
            </div>

            <Button 
              onClick={handleClose} 
              className="w-full bg-emerald-600 hover:bg-emerald-500 text-white font-bold py-6 rounded-2xl text-sm shadow-xl shadow-emerald-100 transition-all active:scale-95"
            >
              Tiếp tục sử dụng ví
            </Button>
          </div>
        )}
      </DialogContent>
    </Dialog>
  );
};
