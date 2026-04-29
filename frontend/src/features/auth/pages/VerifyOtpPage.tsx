import React, { useState, useEffect } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { Mail, ArrowLeft, CheckCircle2, Timer } from "lucide-react";
import { toast } from "sonner";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { authService } from "../services";
import { useAuthStore } from "../store";

const OTP_LENGTH = 6;

export function VerifyOtpPage() {
  const [otp, setOtp] = useState(new Array(OTP_LENGTH).fill(""));
  const [timer, setTimer] = useState(60);
  const [isVerifying, setIsVerifying] = useState(false);
  const navigate = useNavigate();
  const location = useLocation();
  const setAuth = useAuthStore((state) => state.setAuth);
  
  // Lấy email từ state điều hướng (được gửi từ trang Register)
  const email = location.state?.email || "";

  useEffect(() => {
    if (!email) {
      toast.error("Thiếu thông tin email xác thực");
      navigate("/register");
    }
  }, [email, navigate]);

  useEffect(() => {
    const interval = setInterval(() => {
      setTimer((prev) => (prev > 0 ? prev - 1 : 0));
    }, 1000);
    return () => clearInterval(interval);
  }, []);

  const handleChange = (index: number, value: string) => {
    const newOtp = [...otp];
    
    // Nếu nhập mới (không phải xóa)
    if (value) {
      const char = value.slice(-1).toUpperCase();
      newOtp[index] = char;
      setOtp(newOtp);

      // Tự động focus ô tiếp theo
      if (index < OTP_LENGTH - 1) {
        document.getElementById(`otp-${index + 1}`)?.focus();
      }
    } else {
      // Trường hợp xóa
      newOtp[index] = "";
      setOtp(newOtp);
    }
  };

  const handleKeyDown = (index: number, e: React.KeyboardEvent) => {
    if (e.key === "Backspace") {
      if (!otp[index] && index > 0) {
        // Nếu ô hiện tại rỗng, quay lại ô trước và xóa
        const prevInput = document.getElementById(`otp-${index - 1}`) as HTMLInputElement;
        if (prevInput) {
          prevInput.focus();
          const newOtp = [...otp];
          newOtp[index - 1] = "";
          setOtp(newOtp);
        }
      }
    }
  };

  const handlePaste = (e: React.ClipboardEvent) => {
    e.preventDefault();
    const pasteData = e.clipboardData.getData("text").slice(0, OTP_LENGTH).toUpperCase();
    const newOtp = [...otp];
    
    pasteData.split("").forEach((char, i) => {
      if (i < OTP_LENGTH) newOtp[i] = char;
    });
    
    setOtp(newOtp);
    
    // Focus vào ô cuối cùng hoặc ô sau ký tự cuối cùng đã paste
    const nextIndex = Math.min(pasteData.length, OTP_LENGTH - 1);
    document.getElementById(`otp-${nextIndex}`)?.focus();
  };

  const handleVerify = async () => {
    const otpCode = otp.join("");
    if (otpCode.length < OTP_LENGTH) {
      toast.error(`Vui lòng nhập đủ ${OTP_LENGTH} ký tự`);
      return;
    }

    setIsVerifying(true);
    try {
      await authService.verifyOtp(email, otpCode);
      toast.success("Xác thực tài khoản thành công!");
      navigate("/login");
    } catch (error: any) {
      // Lỗi đã được xử lý bởi axios interceptor
      console.error("Xác thực thất bại:", error);
    } finally {
      setIsVerifying(false);
    }
  };

  return (
    <div className="min-h-[calc(100vh-80px)] w-full flex items-center justify-center py-20 px-6 bg-[#F8FAFC] relative overflow-hidden">
      {/* Background Decor */}
      <div className="absolute inset-0 z-0">
        <div className="absolute top-[-10%] left-[-10%] w-[50%] h-[50%] bg-[#00CE98]/10 blur-[120px] rounded-full" />
        <div className="absolute bottom-[-10%] right-[-10%] w-[50%] h-[50%] bg-[#004E43]/10 blur-[120px] rounded-full" />
      </div>

      <div className="w-full max-w-md bg-white/95 backdrop-blur-2xl p-8 md:p-10 rounded-[2.5rem] shadow-[0_30px_70px_rgba(0,78,67,0.06)] border border-white relative z-10 transition-all">
        <button 
          onClick={() => navigate("/register")}
          className="flex items-center gap-2 text-[#6B7280] hover:text-[#004E43] font-bold text-sm mb-8 transition-colors group"
        >
          <ArrowLeft size={18} className="group-hover:-translate-x-1 transition-transform" />
          Quay lại đăng ký
        </button>

        <div className="text-center mb-10">
          <div className="w-20 h-20 bg-[#00CE98]/10 rounded-[1.5rem] flex items-center justify-center mx-auto mb-6 text-[#00CE98] shadow-sm animate-bounce-slow">
            <Mail size={40} />
          </div>
          <h1 className="text-3xl font-black text-[#091E1B] mb-3 tracking-tight">Xác thực Email</h1>
          <p className="text-[#6B7280] text-sm leading-relaxed">
            Chúng tôi đã gửi mã xác thực đến <br />
            <span className="font-extrabold text-[#004E43]">{email}</span>
          </p>
        </div>

        <div className="flex justify-center gap-2 md:gap-3 mb-10">
          {otp.map((digit, index) => (
            <input
              key={index}
              id={`otp-${index}`}
              type="text"
              value={digit}
              onChange={(e) => handleChange(index, e.target.value)}
              onKeyDown={(e) => handleKeyDown(index, e)}
              onPaste={handlePaste}
              className="w-12 h-14 md:w-14 md:h-16 text-center text-2xl font-black text-[#004E43] bg-white border-2 border-[#E5E7EB] rounded-2xl focus:border-[#00CE98] focus:ring-4 focus:ring-[#00CE98]/10 transition-all outline-none shadow-sm"
              maxLength={1}
            />
          ))}
        </div>

        <Button 
          onClick={handleVerify}
          disabled={isVerifying}
          className="w-full h-14 rounded-2xl text-white font-extrabold text-lg shadow-lg hover:shadow-[#00CE98]/40 transition-all duration-300 active:scale-[0.98] mb-6"
          style={{ background: "linear-gradient(to right, #004E43, #00CE98)" }}
        >
          {isVerifying ? "Đang xác thực..." : "Xác nhận ngay"}
        </Button>

        <div className="text-center">
          {timer > 0 ? (
            <p className="text-[#9CA3AF] text-sm font-medium flex items-center justify-center gap-2">
              <Timer size={16} />
              Gửi lại mã sau <span className="text-[#00CE98] font-bold">{timer}s</span>
            </p>
          ) : (
            <button className="text-[#00CE98] font-black text-sm hover:underline hover:text-[#004E43] transition-all">
              Gửi lại mã OTP
            </button>
          )}
        </div>
      </div>
    </div>
  );
}
