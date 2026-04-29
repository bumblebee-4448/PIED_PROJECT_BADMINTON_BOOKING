import { useEffect } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { Mail, ArrowLeft } from "lucide-react";
import { toast } from "sonner";
import { VerifyOtpForm } from "../components/VerifyOtpForm";

export function VerifyOtpPage() {
  const navigate = useNavigate();
  const location = useLocation();
  
  // Lấy email từ state điều hướng (được gửi từ trang Register)
  const email = location.state?.email || "";

  useEffect(() => {
    if (!email) {
      toast.error("Thiếu thông tin email xác thực");
      navigate("/register");
    }
  }, [email, navigate]);

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

        <VerifyOtpForm email={email} />
      </div>
    </div>
  );
}
