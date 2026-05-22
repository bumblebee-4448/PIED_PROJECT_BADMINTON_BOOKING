import { useState, useEffect, useCallback, useRef } from "react";
import { useLocation, useNavigate, Navigate } from "react-router-dom";
import { useBookingStatus, useCancelBooking } from "@/features/bookings/hooks";
import { useWallet } from "@/features/wallet/hooks/useWallet";
import { toast } from "sonner";
import { Button } from "@/shared/components/ui/button";
import { 
  Loader2, 
  Timer, 
  Copy, 
  Check, 
  X,
  Calendar,
  Wallet,
  AlertCircle
} from "lucide-react";

interface PaymentState {
  qrCodeUrl: string;
  amount: number;
  transactionId: string;
  transactionCode: string;
  content: string;
  bankName?: string;
  bankAccount?: string; // Account Owner Name
  expiredAt: string;
  type: "booking" | "wallet";
  items?: { subCourtName: string; startTime: string; endTime: string }[];
}

export function PaymentPage() {
  const location = useLocation();
  const navigate = useNavigate();

  // Try to load state from navigation state or localStorage cache
  const [paymentState] = useState<PaymentState | null>(() => {
    if (location.state) {
      // Save to cache
      localStorage.setItem("rallyhub_pending_payment", JSON.stringify(location.state));
      return location.state as PaymentState;
    }
    
    // Check localStorage cache
    const cached = localStorage.getItem("rallyhub_pending_payment");
    if (cached) {
      try {
        const parsed = JSON.parse(cached);
        // Ensure it's not expired yet
        if (parsed.expiredAt && new Date(parsed.expiredAt).getTime() > Date.now()) {
          return parsed as PaymentState;
        } else {
          localStorage.removeItem("rallyhub_pending_payment");
        }
      } catch {}
    }
    return null;
  });

  // State to manage Success/Failure screen redirects
  const [status, setStatus] = useState<"pending" | "success" | "failed">("pending");
  const [failReason, setFailReason] = useState<string>("");
  const [timeLeft, setTimeLeft] = useState<number>(0);
  const [isSuccess, setIsSuccess] = useState(false);
  const [copiedField, setCopiedField] = useState<string | null>(null);
  
  // Ref to prevent double-toast/multiple action triggers on timeout
  const hasTriggeredEnd = useRef(false);

  const cancelBooking = useCancelBooking();
  const { useDepositStatus } = useWallet();

  // Redirect if no valid payment state
  if (!paymentState) {
    return <Navigate to="/history" replace />;
  }

  const {
    qrCodeUrl,
    amount,
    transactionId,
    transactionCode,
    content,
    bankName = "Ngân hàng đối tác",
    bankAccount = "RallyHub",
    expiredAt,
    type,
    items = []
  } = paymentState;

  // Handles failure transitions beautifully
  const triggerFailure = useCallback((reason: string) => {
    if (hasTriggeredEnd.current) return;
    hasTriggeredEnd.current = true;
    
    setFailReason(reason);
    setStatus("failed");
    toast.error(reason);

    if (type === "booking" && transactionId) {
      cancelBooking.mutate(transactionId);
    }
    localStorage.removeItem("rallyhub_pending_payment");

    // Automatically navigate back after 3 seconds
    setTimeout(() => {
      navigate(-1);
    }, 3000);
  }, [type, transactionId, cancelBooking, navigate]);

  // Cancel transaction handler on manual cancel click
  const handleCancel = useCallback(() => {
    triggerFailure("Giao dịch đã bị hủy bởi người dùng");
  }, [triggerFailure]);

  // Timer countdown logic
  useEffect(() => {
    if (expiredAt && status === "pending") {
      const expiry = new Date(expiredAt).getTime();
      
      const checkExpiry = () => {
        const now = Date.now();
        const diff = Math.max(0, Math.floor((expiry - now) / 1000));
        setTimeLeft(diff);
        
        if (diff <= 0) {
          if (!isSuccess && !hasTriggeredEnd.current) {
            triggerFailure("Mã thanh toán đã hết hạn!");
          }
          return true;
        }
        return false;
      };

      if (checkExpiry()) return;

      const interval = setInterval(() => {
        if (checkExpiry()) {
          clearInterval(interval);
        }
      }, 1000);
      
      return () => clearInterval(interval);
    }
  }, [expiredAt, isSuccess, status, triggerFailure]);

  // ─── Polling Logic for Booking Payment ───────────────────
  const { data: currentBooking, refetch: refetchBooking } = useBookingStatus(
    type === "booking" ? transactionId : undefined,
    type === "booking" && status === "pending"
  );

  // Poll booking every 3 seconds
  useEffect(() => {
    if (type === "booking" && status === "pending" && transactionId) {
      const interval = setInterval(() => {
        refetchBooking();
      }, 3000);
      return () => clearInterval(interval);
    }
  }, [type, status, transactionId, refetchBooking]);

  useEffect(() => {
    if (type === "booking" && currentBooking?.status === "Banked" && status === "pending") {
      setIsSuccess(true);
      setStatus("success");
      localStorage.removeItem("rallyhub_pending_payment");
      toast.success("Thanh toán đặt sân thành công!");
      
      setTimeout(() => {
        navigate("/history");
      }, 3000);
    }
  }, [type, currentBooking?.status, status, navigate]);

  // ─── Polling Logic for Wallet Payment ───────────────────
  const { data: currentDepositStatus, refetch: refetchDepositStatus } = useDepositStatus(
    type === "wallet" ? transactionId : undefined,
    type === "wallet" && status === "pending"
  );

  useEffect(() => {
    if (type === "wallet" && status === "pending" && transactionId) {
      const interval = setInterval(() => {
        refetchDepositStatus();
      }, 3000);
      return () => clearInterval(interval);
    }
  }, [type, status, transactionId, refetchDepositStatus]);

  useEffect(() => {
    if (type === "wallet" && currentDepositStatus === "Success" && status === "pending") {
      setIsSuccess(true);
      setStatus("success");
      localStorage.removeItem("rallyhub_pending_payment");
      toast.success("Nạp tiền vào ví thành công!");
      
      setTimeout(() => {
        navigate("/wallet");
      }, 3000);
    } else if (type === "wallet" && (currentDepositStatus === "Expired" || currentDepositStatus === "Failed") && status === "pending") {
      triggerFailure("Giao dịch nạp tiền đã hết hạn hoặc thất bại!");
    }
  }, [type, currentDepositStatus, status, navigate, triggerFailure]);

  // Helper to extract bank account number from VietQR URL
  const getAccountNoFromQr = (url?: string) => {
    if (!url) return "";
    try {
      const parts = url.split("/");
      const filename = parts[parts.length - 1];
      const cleanFilename = filename.split("?")[0];
      const subParts = cleanFilename.split("-");
      if (subParts.length >= 2) {
        return subParts[1];
      }
    } catch (e) {
      console.error("Failed to parse bank account from QR URL:", e);
    }
    return "";
  };

  const bankAccountNo = getAccountNoFromQr(qrCodeUrl) || "0934983284";

  const copyToClipboard = (text: string, field: string) => {
    if (navigator.clipboard) {
      navigator.clipboard.writeText(text);
      setCopiedField(field);
      toast.success("Đã sao chép vào bộ nhớ tạm");
      setTimeout(() => setCopiedField(null), 2000);
    }
  };

  const formatTime = (seconds: number) => {
    const mins = Math.floor(seconds / 60);
    const secs = seconds % 60;
    return `${mins}:${secs.toString().padStart(2, "0")}`;
  };

  // ─── Render View: Success Screen ─────────────────────────
  if (status === "success") {
    return (
      <div className="min-h-screen bg-[#F8FAFC] flex items-center justify-center p-6 font-sans">
        <div className="max-w-md w-full bg-white rounded-3xl shadow-[0_20px_60px_rgba(15,23,42,0.06)] p-8 text-center space-y-6 animate-in zoom-in-95 duration-300 border border-slate-100">
          <div className="w-20 h-20 bg-emerald-50 rounded-full flex items-center justify-center mx-auto relative">
            <div className="absolute inset-0 bg-emerald-500/10 rounded-full animate-ping" />
            <Check size={40} className="text-emerald-500 relative z-10" />
          </div>
          
          <div className="space-y-2">
            <h1 className="text-2xl font-black text-slate-800 tracking-tight">
              Thanh toán thành công!
            </h1>
            <p className="text-sm text-slate-500 font-medium leading-relaxed">
              Hệ thống RallyHub đã ghi nhận giao dịch của bạn.
            </p>
          </div>

          <div className="bg-[#F8FAFC] border border-slate-100 rounded-2xl p-5 text-left space-y-3.5 shadow-sm">
            <div className="flex justify-between items-center text-xs font-bold text-slate-400">
              <span>SỐ TIỀN THANH TOÁN</span>
              <span className="text-base font-black text-[#0068FF]">
                {new Intl.NumberFormat("vi-VN", { style: "currency", currency: "VND" }).format(amount)}
              </span>
            </div>
            <div className="h-[1px] bg-slate-100" />
            <div className="flex justify-between items-center text-xs font-bold text-slate-400">
              <span>MÃ GIAO DỊCH</span>
              <span className="font-mono text-slate-700 font-black">{transactionCode}</span>
            </div>
          </div>

          <div className="space-y-3 pt-2">
            <p className="text-xs text-slate-400 font-bold uppercase tracking-widest animate-pulse">
              Đang tự động chuyển hướng...
            </p>
            <Button
              onClick={() => navigate(type === "booking" ? "/history" : "/wallet")}
              className="w-full bg-[#0068FF] hover:bg-blue-700 text-white font-bold h-11 rounded-xl shadow-md transition-all active:scale-95 text-xs"
            >
              Tiếp tục
            </Button>
          </div>
        </div>
      </div>
    );
  }

  // ─── Render View: Failure Screen ─────────────────────────
  if (status === "failed") {
    return (
      <div className="min-h-screen bg-[#F8FAFC] flex items-center justify-center p-6 font-sans">
        <div className="max-w-md w-full bg-white rounded-3xl shadow-[0_20px_60px_rgba(15,23,42,0.06)] p-8 text-center space-y-6 animate-in zoom-in-95 duration-300 border border-slate-100">
          <div className="w-20 h-20 bg-rose-50 rounded-full flex items-center justify-center mx-auto relative">
            <div className="absolute inset-0 bg-rose-500/10 rounded-full animate-ping" />
            <AlertCircle size={40} className="text-rose-500 relative z-10" />
          </div>
          
          <div className="space-y-2">
            <h1 className="text-2xl font-black text-rose-600 tracking-tight">
              Thanh toán thất bại!
            </h1>
            <p className="text-sm text-slate-500 font-medium">
              Không thể hoàn tất giao dịch thanh toán.
            </p>
          </div>

          <div className="bg-rose-50/55 border border-rose-100 rounded-2xl p-4 inline-block w-full">
            <span className="text-xs font-bold text-rose-700 block mb-0.5">Lý do thất bại:</span>
            <p className="text-xs font-semibold text-rose-800 leading-relaxed">{failReason}</p>
          </div>

          <div className="space-y-3 pt-2">
            <p className="text-xs text-slate-400 font-bold uppercase tracking-widest">
              Tự động quay lại trang trước trong 3 giây...
            </p>
            <Button
              onClick={() => navigate(-1)}
              className="w-full bg-slate-100 hover:bg-slate-200 text-slate-700 font-bold h-11 rounded-xl shadow-sm transition-all active:scale-95 text-xs"
            >
              Quay lại ngay
            </Button>
          </div>
        </div>
      </div>
    );
  }

  // ─── Render View: Pending/Awaiting Screen (VietQR Scanner Layout) ─
  return (
    <div className="min-h-screen bg-[#F4F6F9] flex items-center justify-center p-4 md:p-8 font-sans">
      <div className="w-full max-w-5xl bg-white rounded-[2rem] shadow-[0_15px_50px_rgba(15,23,42,0.08)] overflow-hidden flex flex-col md:flex-row p-6 md:p-10 gap-8 md:gap-12 min-h-[600px] relative">
        
        {/* Absolute Cancel Button */}
        <button 
          onClick={handleCancel} 
          className="absolute top-6 right-6 text-gray-400 hover:text-rose-500 transition-all p-2 rounded-full hover:bg-slate-50 active:scale-95 z-20"
          title="Hủy giao dịch"
        >
          <X size={22} />
        </button>

        {/* Left Column: Order Detail Card (Floating layout style) */}
        <div className="w-full md:w-[360px] flex-shrink-0 flex flex-col justify-between">
          <div className="bg-[#F8FAFC] border border-[#E2E8F0] rounded-2xl p-6 flex-1 flex flex-col justify-between shadow-sm">
            
            <div className="space-y-6">
              {/* Header / Title */}
              <h2 className="text-xl font-extrabold text-[#0F172A] tracking-tight">
                Thông tin đơn hàng
              </h2>

              {/* Service details brand logo */}
              <div className="flex items-center gap-3">
                <div className="w-10 h-10 bg-emerald-50 text-emerald-600 rounded-xl flex items-center justify-center shadow-sm">
                  {type === "booking" ? <Calendar size={18} /> : <Wallet size={18} />}
                </div>
                <div>
                  <h3 className="text-sm font-black text-slate-800 leading-tight">
                    {type === "booking" ? "Đặt sân RallyHub" : "Nạp tiền ví RallyHub"}
                  </h3>
                  <p className="text-[10px] text-slate-400 font-semibold uppercase tracking-wider">
                    Dịch vụ RallyHub
                  </p>
                </div>
              </div>

              <div className="h-[1px] bg-slate-200/80 my-4" />

              {/* Price Details */}
              <div className="space-y-3.5">
                <div className="flex justify-between items-center text-sm">
                  <span className="font-semibold text-slate-400">Giá trị đơn hàng</span>
                  <span className="font-bold text-slate-700">
                    {new Intl.NumberFormat("vi-VN", { style: "currency", currency: "VND" }).format(amount)}
                  </span>
                </div>
                <div className="flex justify-between items-center text-sm">
                  <span className="font-semibold text-slate-400">Số tiền thanh toán</span>
                  <span className="text-lg font-black text-[#0068FF] tracking-tight">
                    {new Intl.NumberFormat("vi-VN", { style: "currency", currency: "VND" }).format(amount)}
                  </span>
                </div>
              </div>

              <div className="h-[1px] bg-slate-200/80 my-4" />

              {/* Booking Codes with reduced border strength (softened borders) */}
              <div className="space-y-4">
                <div>
                  <span className="text-[11px] font-bold text-slate-400 uppercase tracking-wider block mb-1">
                    Mã giao dịch
                  </span>
                  <span className="text-sm font-extrabold text-slate-800 font-mono tracking-wide">
                    {transactionCode}
                  </span>
                </div>
                
                <div>
                  <span className="text-[11px] font-bold text-slate-400 uppercase tracking-wider block mb-1">
                    Nội dung
                  </span>
                  <span className="text-sm font-black text-emerald-800 font-mono bg-emerald-50/80 px-2.5 py-1 rounded select-all tracking-wider break-all">
                    {content}
                  </span>
                </div>

                {/* Subcourts List (if booking) */}
                {type === "booking" && items.length > 0 && (
                  <div className="pt-2">
                    <span className="text-[11px] font-bold text-slate-400 uppercase tracking-wider block mb-2">
                      Chi tiết sân đặt
                    </span>
                    <div className="space-y-1.5 max-h-[140px] overflow-y-auto pr-1 custom-scrollbar">
                      {items.map((item, idx) => (
                        <div key={idx} className="flex justify-between items-center text-xs font-bold text-slate-600 bg-white p-2.5 rounded-xl border border-slate-100/30 shadow-sm animate-fade-in">
                          <span>{item.subCourtName}</span>
                          <span className="text-slate-400 text-[10px] bg-slate-50 px-2 py-0.5 rounded-lg border border-slate-100/20">
                            {(item.startTime || "").substring(0, 5)} - {(item.endTime || "").substring(0, 5)}
                          </span>
                        </div>
                      ))}
                    </div>
                  </div>
                )}
              </div>
            </div>

            {/* Countdown card */}
            <div className="bg-[#FFFBEB] border border-[#FEF3C7] rounded-xl p-4 mt-6 flex justify-between items-center text-xs font-bold text-amber-800">
              <div className="flex items-center gap-1.5">
                <Timer size={14} className="text-amber-600" />
                <span>Giao dịch kết thúc trong</span>
              </div>
              <span className={`bg-white px-2 py-1 rounded shadow-sm text-sm font-black tracking-widest font-mono tabular-nums ${timeLeft <= 30 ? "text-rose-600 animate-pulse" : "text-amber-700"}`}>
                {formatTime(timeLeft)}
              </span>
            </div>

          </div>
        </div>

        {/* Right Column: Scan & QR details */}
        <div className="flex-1 flex flex-col items-center justify-center space-y-6 pt-4 md:pt-0">
          {/* Main Title */}
          <h1 className="text-2xl font-extrabold text-[#0F172A] tracking-tight">
            Quét QR để thanh toán
          </h1>

          {/* QR Code with scan corners */}
          <div className="relative p-6 bg-white rounded-3xl border border-slate-100 shadow-lg transition-transform hover:scale-[1.01]">
            <div className="absolute top-4 left-4 w-6 h-6 border-t-[4px] border-l-[4px] border-[#0068FF] rounded-tl-lg pointer-events-none" />
            <div className="absolute top-4 right-4 w-6 h-6 border-t-[4px] border-r-[4px] border-[#0068FF] rounded-tr-lg pointer-events-none" />
            <div className="absolute bottom-4 left-4 w-6 h-6 border-b-[4px] border-l-[4px] border-[#0068FF] rounded-bl-lg pointer-events-none" />
            <div className="absolute bottom-4 right-4 w-6 h-6 border-b-[4px] border-r-[4px] border-[#0068FF] rounded-br-lg pointer-events-none" />
            
            {qrCodeUrl ? (
              <img 
                src={qrCodeUrl} 
                alt="VietQR Payment Code" 
                className="w-52 h-52 object-contain relative z-10 p-2"
              />
            ) : (
              <div className="w-52 h-52 flex items-center justify-center relative z-10">
                <Loader2 size={32} className="text-[#0068FF] animate-spin" />
              </div>
            )}
          </div>

          {/* Bank details card with reduced border thickness (softened borders) */}
          <div className="w-full max-w-md bg-[#F4F8FF] border border-[#D0E2FF]/20 rounded-2xl p-5 space-y-3 shadow-sm">
            <div className="flex justify-between items-center text-xs font-semibold pb-1.5 border-b border-slate-200/20">
              <span className="text-slate-400 uppercase tracking-wider">Ngân hàng</span>
              <span className="text-slate-800 font-bold text-right">{bankName}</span>
            </div>
            
            <div className="flex justify-between items-center text-xs font-semibold pb-1.5 border-b border-slate-200/20">
              <span className="text-slate-400 uppercase tracking-wider">Chủ tài khoản</span>
              <span className="text-slate-800 font-extrabold">{bankAccount}</span>
            </div>

            <div className="flex justify-between items-center text-xs font-semibold">
              <span className="text-slate-400 uppercase tracking-wider">Số tài khoản</span>
              <div className="flex items-center gap-2">
                <span className="font-mono font-black text-slate-800 bg-white px-2.5 py-1 rounded border border-slate-200/10 tracking-wider">
                  {bankAccountNo}
                </span>
                <Button
                  variant="ghost"
                  size="icon"
                  className="h-8 w-8 hover:bg-[#D0E2FF] hover:text-[#0068FF] rounded-lg transition-all"
                  onClick={() => copyToClipboard(bankAccountNo, "acc")}
                >
                  {copiedField === "acc" ? <Check size={14} className="text-[#0068FF]" /> : <Copy size={14} className="text-slate-400" />}
                </Button>
              </div>
            </div>
          </div>

          {/* Footer guides & High-fidelity bank logos in rectangular format */}
          <div className="w-full text-center space-y-4 pt-2">
            <p className="text-xs font-bold text-slate-400 uppercase tracking-wider">
              Mở ứng dụng hỗ trợ VietQR để quét mã thanh toán
            </p>
            
            {/* Standard high-fidelity bank brand logos formatted as rectangular boxes matching the form style */}
            <div className="flex items-center justify-center gap-2 pt-1">
              
              {/* ZaloPay Box */}
              <div className="w-[48px] h-7 bg-white border border-slate-200/20 rounded-lg flex flex-col items-center justify-center shadow-sm hover:scale-105 transition-all p-0.5" title="ZaloPay">
                <span className="text-[8.5px] font-black text-[#0068FF] tracking-tighter leading-none">Zalo</span>
                <span className="text-[7.5px] font-extrabold text-[#00E5A3] tracking-tight leading-none mt-0.5">pay</span>
              </div>

              {/* Vietcombank Box */}
              <div className="w-[48px] h-7 bg-white border border-slate-200/20 rounded-lg flex items-center justify-center shadow-sm hover:scale-105 transition-all p-0.5" title="Vietcombank">
                <span className="text-[8.5px] font-black text-[#5C933C] tracking-tighter">VCB</span>
                <span className="text-emerald-600 text-[8.5px] ml-0.5">🍃</span>
              </div>

              {/* MBBank Box */}
              <div className="w-[48px] h-7 bg-white border border-slate-200/20 rounded-lg flex items-center justify-center shadow-sm hover:scale-105 transition-all p-0.5" title="MBBank">
                <span className="text-rose-500 text-[8px] font-extrabold mr-0.5">★</span>
                <span className="text-[8.5px] font-black text-blue-900 tracking-tighter">MB</span>
              </div>

              {/* Plus More Box */}
              <div className="w-[48px] h-7 bg-[#E0F2FE] border border-[#BAE6FD]/20 rounded-lg flex items-center justify-center shadow-sm text-[8.5px] font-black text-slate-600 hover:scale-105 transition-all" title="Hỗ trợ hơn 34 đối tác VietQR">
                +34
              </div>

            </div>
          </div>

        </div>

      </div>
    </div>
  );
}
