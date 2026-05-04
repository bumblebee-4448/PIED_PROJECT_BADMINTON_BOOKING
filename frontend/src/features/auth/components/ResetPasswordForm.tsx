import { useState } from "react";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Eye, EyeOff, Lock, Mail, KeyRound } from "lucide-react";
import { useLocation } from "react-router-dom";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { resetPasswordSchema } from "../schema";
import type { ResetPasswordInput } from "../types";
import { useResetPassword } from "../hooks/useResetPassword";

export const ResetPasswordForm = () => {
  const [showPassword, setShowPassword] = useState(false);
  const location = useLocation();
  const initialEmail = location.state?.email || "";

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<ResetPasswordInput>({
    resolver: zodResolver(resetPasswordSchema),
    defaultValues: {
      email: initialEmail,
      otpCode: "",
      newPassword: "",
    },
  });

  const { mutate: resetPassword, isPending } = useResetPassword();

  const onSubmit = (data: ResetPasswordInput) => {
    resetPassword(data);
  };

  return (
    <form className="space-y-4 md:space-y-5 w-full" onSubmit={handleSubmit(onSubmit)}>
      <div className="space-y-4">
        {/* Email Field */}
        <div className="space-y-1.5">
          <Label 
            htmlFor="email" 
            className="text-xs md:text-sm font-bold text-[#374151] ml-1 uppercase tracking-wider"
          >
            Địa chỉ Email
          </Label>
          <div className="relative group">
            <Mail className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 md:w-5 md:h-5 text-[#9CA3AF] group-focus-within:text-[#00CE98] transition-colors" />
            <Input 
              {...register("email")}
              id="email" 
              type="email"
              placeholder="example@rallyhub.com" 
              readOnly={!!initialEmail}
              className={`h-11 md:h-12 pl-11 md:pl-12 rounded-xl border-[#E5E7EB] bg-white focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all text-sm md:text-base shadow-sm ${
                errors.email ? "border-red-500 focus:border-red-500 focus:ring-red-500/20" : ""
              } ${initialEmail ? "bg-gray-50 cursor-not-allowed" : ""}`}
            />
          </div>
          {errors.email && (
            <p className="text-red-500 text-xs mt-1 ml-1 font-medium">{errors.email.message}</p>
          )}
        </div>

        {/* OTP Code Field */}
        <div className="space-y-1.5">
          <Label 
            htmlFor="otpCode" 
            className="text-xs md:text-sm font-bold text-[#374151] ml-1 uppercase tracking-wider"
          >
            Mã OTP
          </Label>
          <div className="relative group">
            <KeyRound className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 md:w-5 md:h-5 text-[#9CA3AF] group-focus-within:text-[#00CE98] transition-colors" />
            <Input 
              {...register("otpCode")}
              id="otpCode" 
              type="text"
              placeholder="Nhập 6 số OTP" 
              maxLength={6}
              className={`h-11 md:h-12 pl-11 md:pl-12 rounded-xl border-[#E5E7EB] bg-white focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all text-sm md:text-base shadow-sm ${
                errors.otpCode ? "border-red-500 focus:border-red-500 focus:ring-red-500/20" : ""
              }`}
            />
          </div>
          {errors.otpCode && (
            <p className="text-red-500 text-xs mt-1 ml-1 font-medium">{errors.otpCode.message}</p>
          )}
        </div>

        {/* New Password Field */}
        <div className="space-y-1.5">
          <Label 
            htmlFor="newPassword" 
            className="text-xs md:text-sm font-bold text-[#374151] ml-1 uppercase tracking-wider"
          >
            Mật khẩu mới
          </Label>
          <div className="relative group">
            <Lock className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 md:w-5 md:h-5 text-[#9CA3AF] group-focus-within:text-[#00CE98] transition-colors" />
            <Input 
              {...register("newPassword")}
              id="newPassword" 
              type={showPassword ? "text" : "password"} 
              placeholder="••••••••" 
              className={`h-11 md:h-12 pl-11 md:pl-12 pr-11 md:pr-12 rounded-xl border-[#E5E7EB] bg-white focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all text-sm md:text-base shadow-sm ${
                errors.newPassword ? "border-red-500 focus:border-red-500 focus:ring-red-500/20" : ""
              }`}
            />
            <Button 
              variant="ghost"
              size="icon"
              type="button"
              onClick={() => setShowPassword(!showPassword)}
              className="absolute right-4 top-1/2 -translate-y-1/2 text-[#9CA3AF] hover:text-[#374151] hover:bg-transparent"
            >
              {showPassword ? <EyeOff className="w-4 h-4 md:w-5 md:h-5" /> : <Eye className="w-4 h-4 md:w-5 md:h-5" />}
            </Button>
          </div>
          {errors.newPassword && (
            <p className="text-red-500 text-xs mt-1 ml-1 font-medium">{errors.newPassword.message}</p>
          )}
        </div>
      </div>

      <Button 
        type="submit"
        disabled={isPending}
        className="w-full h-12 md:h-13 rounded-xl text-white font-extrabold text-base md:text-lg shadow-lg hover:shadow-[#00CE98]/40 transition-all duration-300 active:scale-[0.98] relative overflow-hidden group"
        style={{ background: "linear-gradient(to right, #004E43, #00CE98)" }}
      >
        <span className="relative z-10">{isPending ? "Đang xử lý..." : "Đặt lại mật khẩu"}</span>
        <div className="absolute inset-0 bg-white/20 translate-x-[-100%] group-hover:translate-x-[100%] transition-transform duration-500" />
      </Button>
    </form>
  );
};
