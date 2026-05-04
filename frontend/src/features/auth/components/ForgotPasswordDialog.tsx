import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Mail, Send } from "lucide-react";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { forgotPasswordSchema } from "../schema";
import type { ForgotPasswordInput } from "../types";
import { useForgotPassword } from "../hooks/useForgotPassword";
import { useState } from "react";

export const ForgotPasswordDialog = () => {
  const [isOpen, setIsOpen] = useState(false);
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm<ForgotPasswordInput>({
    resolver: zodResolver(forgotPasswordSchema),
    defaultValues: {
      email: "",
    },
  });

  const { mutate: forgotPassword, isPending } = useForgotPassword();

  const onSubmit = (data: ForgotPasswordInput) => {
    forgotPassword(data, {
      onSuccess: () => {
        setIsOpen(false);
        reset();
      },
    });
  };

  return (
    <Dialog open={isOpen} onOpenChange={setIsOpen}>
      <DialogTrigger asChild>
        <button
          type="button"
          className="text-xs md:text-sm font-bold text-[#00CE98] hover:text-[#004E43] transition-colors"
        >
          Quên mật khẩu?
        </button>
      </DialogTrigger>
      <DialogContent className="sm:max-w-[425px] rounded-[1.5rem] md:rounded-[2rem] border-white/20 bg-white/95 backdrop-blur-md shadow-2xl">
        <DialogHeader className="space-y-3">
          <div className="w-12 h-12 bg-[#00CE98]/10 rounded-2xl flex items-center justify-center mb-2">
            <Mail className="w-6 h-6 text-[#00CE98]" />
          </div>
          <DialogTitle className="text-2xl font-black text-[#091E1B]">
            Quên mật khẩu?
          </DialogTitle>
          <DialogDescription className="text-[#6B7280] font-medium">
            Đừng lo lắng! Nhập email của bạn và chúng tôi sẽ gửi mã OTP để đặt lại mật khẩu.
          </DialogDescription>
        </DialogHeader>

        <form 
          onSubmit={(e) => {
            e.stopPropagation();
            handleSubmit(onSubmit)(e);
          }} 
          className="space-y-6 mt-4"
        >
          <div className="space-y-2">
            <Label
              htmlFor="forgot-email"
              className="text-xs font-bold text-[#374151] ml-1 uppercase tracking-wider"
            >
              Địa chỉ Email
            </Label>
            <div className="relative group">
              <Mail className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 text-[#9CA3AF] group-focus-within:text-[#00CE98] transition-colors" />
              <Input
                {...register("email")}
                id="forgot-email"
                type="email"
                placeholder="example@rallyhub.com"
                className={`h-12 pl-11 rounded-xl border-[#E5E7EB] bg-white focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all text-sm shadow-sm ${
                  errors.email ? "border-red-500 focus:border-red-500 focus:ring-red-500/20" : ""
                }`}
              />
            </div>
            {errors.email && (
              <p className="text-red-500 text-xs mt-1 ml-1 font-medium">
                {errors.email.message}
              </p>
            )}
          </div>

          <Button
            type="submit"
            disabled={isPending}
            className="w-full h-12 rounded-xl text-white font-extrabold text-base shadow-lg hover:shadow-[#00CE98]/40 transition-all duration-300 active:scale-[0.98] relative overflow-hidden group"
            style={{ background: "linear-gradient(to right, #004E43, #00CE98)" }}
          >
            <span className="relative z-10 flex items-center justify-center gap-2">
              {isPending ? (
                "Đang xử lý..."
              ) : (
                <>
                  Gửi mã OTP <Send className="w-4 h-4" />
                </>
              )}
            </span>
            <div className="absolute inset-0 bg-white/20 translate-x-[-100%] group-hover:translate-x-[100%] transition-transform duration-500" />
          </Button>
        </form>
      </DialogContent>
    </Dialog>
  );
};
