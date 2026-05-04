import { useState } from "react";
import { ChevronRight, Eye, EyeOff } from "lucide-react";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { changePasswordSchema, type ChangePasswordSchema } from "../schema";
import { Button } from "@/shared/components/ui/button";

interface PasswordSectionProps {
  onUpdate: (data: ChangePasswordSchema) => void;
  isLoading: boolean;
}

export function PasswordSection({ onUpdate, isLoading }: PasswordSectionProps) {
  const [showSection, setShowSection] = useState(false);
  const [showOldPass, setShowOldPass] = useState(false);
  const [showNewPass, setShowNewPass] = useState(false);

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<ChangePasswordSchema>({
    resolver: zodResolver(changePasswordSchema),
    defaultValues: {
      oldPassword: "",
      newPassword: "",
    },
  });

  const handleConfirm = (data: ChangePasswordSchema) => {
    onUpdate(data);
  };

  return (
    <div className="bg-white rounded-2xl overflow-hidden mb-4" style={{ border: "1px solid rgba(0,0,0,0.07)" }}>
      <Button
        variant="ghost"
        onClick={() => setShowSection(!showSection)}
        className="w-full flex items-center justify-between px-5 py-4 h-auto rounded-none hover:bg-gray-50 transition"
      >
        <div className="flex items-center gap-3">
          <div className="w-8 h-8 rounded-lg flex items-center justify-center" style={{ background: "#f0fdf9" }}>🔒</div>
          <span style={{ fontWeight: 700, fontSize: "0.9rem", color: "#1a1a2e" }}>Đổi mật khẩu</span>
        </div>
        <ChevronRight
          size={16}
          className="text-gray-400"
          style={{ transform: showSection ? "rotate(90deg)" : "none", transition: "0.2s" }}
        />
      </Button>
      {showSection && (
        <form onSubmit={handleSubmit(handleConfirm)} className="px-5 pb-5 border-t border-gray-50 pt-4">
          <div className="flex flex-col gap-3">
            <div className="relative">
              <input
                type={showOldPass ? "text" : "password"}
                {...register("oldPassword")}
                placeholder="Mật khẩu hiện tại"
                className={`w-full pr-10 px-3 py-2.5 rounded-xl outline-none text-sm transition-all ${
                  errors.oldPassword ? "ring-1 ring-red-500 border-red-500" : "border-gray-200"
                }`}
                style={{ 
                  border: errors.oldPassword ? "1.5px solid #ef4444" : "1.5px solid #e5e7eb", 
                  background: "#f9fafb" 
                }}
              />
              <Button
                type="button"
                variant="ghost"
                size="icon"
                onClick={() => setShowOldPass(!showOldPass)}
                className="absolute right-3 top-1/2 -translate-y-1/2 text-gray-400 hover:bg-transparent"
              >
                {showOldPass ? <EyeOff size={15} /> : <Eye size={15} />}
              </Button>
            </div>
            {errors.oldPassword && <p className="text-red-500 text-[11px] ml-1 -mt-1">{errors.oldPassword.message}</p>}

            <div className="relative">
              <input
                type={showNewPass ? "text" : "password"}
                {...register("newPassword")}
                placeholder="Mật khẩu mới"
                className={`w-full pr-10 px-3 py-2.5 rounded-xl outline-none text-sm transition-all ${
                  errors.newPassword ? "ring-1 ring-red-500 border-red-500" : "border-gray-200"
                }`}
                style={{ 
                  border: errors.newPassword ? "1.5px solid #ef4444" : "1.5px solid #e5e7eb", 
                  background: "#f9fafb" 
                }}
              />
              <Button
                type="button"
                variant="ghost"
                size="icon"
                onClick={() => setShowNewPass(!showNewPass)}
                className="absolute right-3 top-1/2 -translate-y-1/2 text-gray-400 hover:bg-transparent"
              >
                {showNewPass ? <EyeOff size={15} /> : <Eye size={15} />}
              </Button>
            </div>
            {errors.newPassword && <p className="text-red-500 text-[11px] ml-1 -mt-1">{errors.newPassword.message}</p>}

            <Button
              type="submit"
              disabled={isLoading}
              variant="gradient"
              className="w-full py-2.5 rounded-xl text-sm font-bold mt-2"
            >
              {isLoading ? "Đang xử lý..." : "Xác nhận đổi mật khẩu"}
            </Button>
          </div>
        </form>
      )}
    </div>
  );
}
