import { useState } from "react";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Eye, EyeOff, Lock, Mail, User, Phone } from "lucide-react";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { Separator } from "@/shared/components/ui/separator";
import { registerSchema } from "../schema";
import type { RegisterInput } from "../types";
import { useRegister } from "../hooks/useRegister";

const GoogleIcon = () => (
  <svg width="18" height="18" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
    <path d="M22.56 12.25c0-.78-.07-1.53-.2-2.25H12v4.26h5.92c-.26 1.37-1.04 2.53-2.21 3.31v2.77h3.57c2.08-1.92 3.28-4.74 3.28-8.09z" fill="#4285F4"/>
    <path d="M12 23c2.97 0 5.46-.98 7.28-2.66l-3.57-2.77c-.98.66-2.23 1.06-3.71 1.06-2.86 0-5.29-1.93-6.16-4.53H2.18v2.84C3.99 20.53 7.7 23 12 23z" fill="#34A853"/>
    <path d="M5.84 14.09c-.22-.66-.35-1.36-.35-2.09s.13-1.43.35-2.09V7.07H2.18C1.43 8.55 1 10.22 1 12s.43 3.45 1.18 4.93l3.66-2.84z" fill="#FBBC05"/>
    <path d="M12 5.38c1.62 0 3.06.56 4.21 1.64l3.15-3.15C17.45 2.09 14.97 1 12 1 7.7 1 3.99 3.47 2.18 7.07l3.66 2.84c.87-2.6 3.3-4.53 6.16-4.53z" fill="#EA4335"/>
  </svg>
);

export const RegisterForm = () => {
  const [showPassword, setShowPassword] = useState(false);

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<RegisterInput>({
    resolver: zodResolver(registerSchema),
    defaultValues: {
      fullName: "",
      phone: "",
      email: "",
      password: "",
    },
  });

  const { mutate: registerUser, isPending } = useRegister();

  const onSubmit = (data: RegisterInput) => {
    registerUser(data);
  };

  return (
    <form className="space-y-4 md:space-y-5 w-full" onSubmit={handleSubmit(onSubmit)}>
      <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
        <div className="space-y-1.5">
          <Label htmlFor="fullName" className="text-xs md:text-sm font-bold text-[#374151] ml-1 uppercase tracking-wider">Họ và Tên</Label>
          <div className="relative group">
            <User className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 md:w-5 md:h-5 text-[#9CA3AF] group-focus-within:text-[#00CE98] transition-colors" />
            <Input 
              {...register("fullName")}
              id="fullName" 
              placeholder="Nguyễn Văn A" 
              className={`h-11 md:h-12 pl-11 md:pl-12 rounded-xl border-[#E5E7EB] bg-white focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all text-sm md:text-base shadow-sm ${
                errors.fullName ? "border-red-500 focus:border-red-500 focus:ring-red-500/20" : ""
              }`}
            />
          </div>
          {errors.fullName && <p className="text-red-500 text-xs mt-1 ml-1 font-medium">{errors.fullName.message}</p>}
        </div>

        <div className="space-y-1.5">
          <Label htmlFor="phone" className="text-xs md:text-sm font-bold text-[#374151] ml-1 uppercase tracking-wider">Số điện thoại</Label>
          <div className="relative group">
            <Phone className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 md:w-5 md:h-5 text-[#9CA3AF] group-focus-within:text-[#00CE98] transition-colors" />
            <Input 
              {...register("phone")}
              id="phone" 
              placeholder="09xx xxx xxx" 
              className={`h-11 md:h-12 pl-11 md:pl-12 rounded-xl border-[#E5E7EB] bg-white focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all text-sm md:text-base shadow-sm ${
                errors.phone ? "border-red-500 focus:border-red-500 focus:ring-red-500/20" : ""
              }`}
            />
          </div>
          {errors.phone && <p className="text-red-500 text-xs mt-1 ml-1 font-medium">{errors.phone.message}</p>}
        </div>
      </div>

      <div className="space-y-1.5">
        <Label htmlFor="email" className="text-xs md:text-sm font-bold text-[#374151] ml-1 uppercase tracking-wider">Địa chỉ Email</Label>
        <div className="relative group">
          <Mail className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 md:w-5 md:h-5 text-[#9CA3AF] group-focus-within:text-[#00CE98] transition-colors" />
          <Input 
            {...register("email")}
            id="email" 
            type="email"
            placeholder="example@rallyhub.com" 
            className={`h-11 md:h-12 pl-11 md:pl-12 rounded-xl border-[#E5E7EB] bg-white focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all text-sm md:text-base shadow-sm ${
              errors.email ? "border-red-500 focus:border-red-500 focus:ring-red-500/20" : ""
            }`}
          />
        </div>
        {errors.email && <p className="text-red-500 text-xs mt-1 ml-1 font-medium">{errors.email.message}</p>}
      </div>

      <div className="space-y-1.5">
        <Label htmlFor="password" className="text-xs md:text-sm font-bold text-[#374151] ml-1 uppercase tracking-wider">Mật khẩu</Label>
        <div className="relative group">
          <Lock className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 md:w-5 md:h-5 text-[#9CA3AF] group-focus-within:text-[#00CE98] transition-colors" />
          <Input 
            {...register("password")}
            id="password" 
            type={showPassword ? "text" : "password"} 
            placeholder="••••••••" 
            className={`h-11 md:h-12 pl-11 md:pl-12 pr-11 md:pr-12 rounded-xl border-[#E5E7EB] bg-white focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all text-sm md:text-base shadow-sm ${
              errors.password ? "border-red-500 focus:border-red-500 focus:ring-red-500/20" : ""
            }`}
          />
          <button 
            type="button"
            onClick={() => setShowPassword(!showPassword)}
            className="absolute right-4 top-1/2 -translate-y-1/2 text-[#9CA3AF] hover:text-[#374151]"
          >
            {showPassword ? <EyeOff className="w-4 h-4 md:w-5 md:h-5" /> : <Eye className="w-4 h-4 md:w-5 md:h-5" />}
          </button>
        </div>
        {errors.password && <p className="text-red-500 text-xs mt-1 ml-1 font-medium">{errors.password.message}</p>}
      </div>

      <Button 
        type="submit"
        disabled={isPending}
        className="w-full h-12 md:h-13 rounded-xl text-white font-extrabold text-base md:text-lg shadow-lg hover:shadow-[#00CE98]/40 transition-all duration-300 mt-2 active:scale-[0.98] relative overflow-hidden group"
        style={{ background: "linear-gradient(to right, #004E43, #00CE98)" }}
      >
        <span className="relative z-10">{isPending ? "Đang xử lý..." : "Đăng Ký Tài Khoản"}</span>
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
  );
};
