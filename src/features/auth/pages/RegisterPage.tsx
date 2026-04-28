import { useState } from "react";
import { Link } from "react-router-dom";
import {
  Eye,
  EyeOff,
  Lock,
  Mail,
  User,
  Phone,
} from "lucide-react";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { Separator } from "@/shared/components/ui/separator";

const GoogleIcon = () => (
  <svg width="18" height="18" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
    <path d="M22.56 12.25c0-.78-.07-1.53-.2-2.25H12v4.26h5.92c-.26 1.37-1.04 2.53-2.21 3.31v2.77h3.57c2.08-1.92 3.28-4.74 3.28-8.09z" fill="#4285F4"/>
    <path d="M12 23c2.97 0 5.46-.98 7.28-2.66l-3.57-2.77c-.98.66-2.23 1.06-3.71 1.06-2.86 0-5.29-1.93-6.16-4.53H2.18v2.84C3.99 20.53 7.7 23 12 23z" fill="#34A853"/>
    <path d="M5.84 14.09c-.22-.66-.35-1.36-.35-2.09s.13-1.43.35-2.09V7.07H2.18C1.43 8.55 1 10.22 1 12s.43 3.45 1.18 4.93l3.66-2.84z" fill="#FBBC05"/>
    <path d="M12 5.38c1.62 0 3.06.56 4.21 1.64l3.15-3.15C17.45 2.09 14.97 1 12 1 7.7 1 3.99 3.47 2.18 7.07l3.66 2.84c.87-2.6 3.3-4.53 6.16-4.53z" fill="#EA4335"/>
  </svg>
);

export const RegisterPage = () => {
  const [showPassword, setShowPassword] = useState(false);

  return (
    <div className="min-h-screen w-full flex items-center justify-center p-4 sm:p-6 lg:p-8 relative overflow-hidden bg-[#F8FAFC]">
      
      {/* --- Dynamic Background Elements --- */}
      <div className="absolute inset-0 z-0">
        <div 
          className="absolute inset-0 opacity-30"
          style={{
            background: `
              radial-gradient(at 0% 0%, #00CE98 0px, transparent 50%),
              radial-gradient(at 100% 0%, #004E43 0px, transparent 50%),
              radial-gradient(at 100% 100%, #00CE98 0px, transparent 50%),
              radial-gradient(at 0% 100%, #004E43 0px, transparent 50%)
            `
          }}
        />
        <div className="absolute top-[-10%] right-[-10%] w-[40%] h-[40%] bg-[#00CE98]/10 blur-[120px] rounded-full animate-pulse" />
        <div className="absolute bottom-[-10%] left-[-10%] w-[40%] h-[40%] bg-[#004E43]/10 blur-[120px] rounded-full animate-pulse duration-[4000ms]" />
        <div 
          className="absolute inset-0 opacity-[0.03]" 
          style={{ backgroundImage: 'radial-gradient(#004E43 1px, transparent 1px)', backgroundSize: '40px 40px' }}
        />
      </div>

      {/* --- Main Card --- */}
      <div className="w-full max-w-[450px] md:max-w-4xl lg:max-w-5xl bg-white/95 backdrop-blur-sm rounded-[1.5rem] md:rounded-[2.5rem] shadow-[0_20px_50px_rgba(0,78,67,0.15)] overflow-hidden flex flex-col md:flex-row-reverse min-h-[600px] md:min-h-[650px] relative z-10 border border-white/20">
        
        {/* --- Right Side: Register Form --- */}
        <div className="flex-1 p-6 sm:p-10 md:p-12 lg:p-16 flex flex-col justify-center bg-white/50">
          <div className="mb-6 md:mb-8 text-center md:text-left">
            <h1 className="text-3xl md:text-4xl font-extrabold text-[#091E1B] tracking-tight">
              Đăng ký <span className="text-[#00CE98]">🚀</span>
            </h1>
            <p className="text-[#6B7280] mt-2 text-sm md:text-base">
              Gia nhập cộng đồng <span className="font-bold text-[#004E43]">RallyHub</span> ngay.
            </p>
          </div>

          <form className="space-y-4 md:space-y-5 w-full" onSubmit={(e: React.FormEvent) => e.preventDefault()}>
            <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
              <div className="space-y-1.5">
                <Label htmlFor="fullName" className="text-xs md:text-sm font-bold text-[#374151] ml-1 uppercase tracking-wider">Họ và Tên</Label>
                <div className="relative group">
                  <User className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 md:w-5 md:h-5 text-[#9CA3AF] group-focus-within:text-[#00CE98] transition-colors" />
                  <Input 
                    id="fullName" 
                    placeholder="Nguyễn Văn A" 
                    className="h-11 md:h-12 pl-11 md:pl-12 rounded-xl border-[#E5E7EB] bg-white focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all text-sm md:text-base shadow-sm"
                  />
                </div>
              </div>

              <div className="space-y-1.5">
                <Label htmlFor="phone" className="text-xs md:text-sm font-bold text-[#374151] ml-1 uppercase tracking-wider">Số điện thoại</Label>
                <div className="relative group">
                  <Phone className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 md:w-5 md:h-5 text-[#9CA3AF] group-focus-within:text-[#00CE98] transition-colors" />
                  <Input 
                    id="phone" 
                    placeholder="09xx xxx xxx" 
                    className="h-11 md:h-12 pl-11 md:pl-12 rounded-xl border-[#E5E7EB] bg-white focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all text-sm md:text-base shadow-sm"
                  />
                </div>
              </div>
            </div>

            <div className="space-y-1.5">
              <Label htmlFor="email" className="text-xs md:text-sm font-bold text-[#374151] ml-1 uppercase tracking-wider">Địa chỉ Email</Label>
              <div className="relative group">
                <Mail className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 md:w-5 md:h-5 text-[#9CA3AF] group-focus-within:text-[#00CE98] transition-colors" />
                <Input 
                  id="email" 
                  type="email"
                  placeholder="example@rallyhub.com" 
                  className="h-11 md:h-12 pl-11 md:pl-12 rounded-xl border-[#E5E7EB] bg-white focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all text-sm md:text-base shadow-sm"
                />
              </div>
            </div>

            <div className="space-y-1.5">
              <Label htmlFor="password" className="text-xs md:text-sm font-bold text-[#374151] ml-1 uppercase tracking-wider">Mật khẩu</Label>
              <div className="relative group">
                <Lock className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 md:w-5 md:h-5 text-[#9CA3AF] group-focus-within:text-[#00CE98] transition-colors" />
                <Input 
                  id="password" 
                  type={showPassword ? "text" : "password"} 
                  placeholder="••••••••" 
                  className="h-11 md:h-12 pl-11 md:pl-12 pr-11 md:pr-12 rounded-xl border-[#E5E7EB] bg-white focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all text-sm md:text-base shadow-sm"
                />
                <button 
                  type="button"
                  onClick={() => setShowPassword(!showPassword)}
                  className="absolute right-4 top-1/2 -translate-y-1/2 text-[#9CA3AF] hover:text-[#374151]"
                >
                  {showPassword ? <EyeOff className="w-4 h-4 md:w-5 md:h-5" /> : <Eye className="w-4 h-4 md:w-5 md:h-5" />}
                </button>
              </div>
            </div>

            <Button 
              className="w-full h-12 md:h-13 rounded-xl text-white font-extrabold text-base md:text-lg shadow-lg hover:shadow-[#00CE98]/40 transition-all duration-300 mt-2 active:scale-[0.98] relative overflow-hidden group"
              style={{ background: "linear-gradient(to right, #004E43, #00CE98)" }}
              id="register-submit-button"
            >
              <span className="relative z-10">Đăng Ký Tài Khoản</span>
              <div className="absolute inset-0 bg-white/20 translate-x-[-100%] group-hover:translate-x-[100%] transition-transform duration-500" />
            </Button>

            <div className="relative py-1">
              <div className="absolute inset-0 flex items-center">
                <Separator className="bg-[#E5E7EB]" />
              </div>
              <div className="relative flex justify-center text-[10px] uppercase">
                <span className="bg-white/80 backdrop-blur-sm px-4 text-[#9CA3AF] font-bold tracking-[0.2em]">Hoặc</span>
              </div>
            </div>

            <Button 
              variant="outline" 
              type="button"
              className="w-full h-11 md:h-12 rounded-xl border-[#E5E7EB] bg-white hover:bg-[#F9FAFB] shadow-sm flex items-center justify-center gap-3 transition-all duration-300"
            >
              <GoogleIcon />
              <span className="font-bold text-[#374151] text-sm md:text-base">Đăng ký với Google</span>
            </Button>
            
            <p className="text-center text-[#6B7280] font-medium text-xs md:text-sm pt-2">
              Đã có tài khoản?{" "}
              <Link to="/login" className="text-[#00CE98] font-bold hover:underline">Đăng nhập ngay</Link>
            </p>
          </form>

          <p className="mt-8 text-center md:text-left text-[#9CA3AF] text-[10px] md:text-xs font-medium">
            © 2026 RallyHub Ecosystem. All Rights Reserved.
          </p>
        </div>

        {/* --- Left Side: Visual Content --- */}
        <div 
          className="hidden md:flex flex-1 relative overflow-hidden items-center justify-center p-8 lg:p-12 text-white"
          style={{ background: "linear-gradient(to bottom left, #004E43, #00CE98)" }}
        >
          <div className="absolute inset-0 opacity-10 pointer-events-none transform -scale-x-100">
            <svg width="100%" height="100%" viewBox="0 0 1000 1000" xmlns="http://www.w3.org/2000/svg">
              <path d="M0,1000 C300,800 400,900 700,700 C1000,500 1000,0 1000,0 L0,0 Z" fill="white" />
            </svg>
          </div>

          <div className="relative z-10 w-full max-w-sm">
            <div className="space-y-4 text-center lg:text-left">
              <h2 className="text-3xl lg:text-4xl xl:text-5xl font-black leading-tight tracking-tighter">
                Gia nhập <br className="hidden xl:block" />
                <span className="text-[#FFD700]">Cộng đồng</span>
              </h2>
              <p className="text-base lg:text-lg text-white/90 font-medium italic border-l-4 border-[#FFD700] pl-4 py-1">
                "Nơi đam mê bứt phá giới hạn."
              </p>
            </div>

            <div className="mt-8 lg:mt-12 relative group">
              <div className="absolute -inset-4 bg-white/10 rounded-[2rem] blur-xl" />
              <img 
                src="/badminton_court_register_side_1777042852780.png" 
                alt="Badminton Court" 
                className="relative rounded-[1.5rem] lg:rounded-[2rem] shadow-2xl w-full object-cover transform transition-transform duration-700 group-hover:scale-[1.02]"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
