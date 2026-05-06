import { Building2 } from "lucide-react";
import { useAuthStore } from "@/features/auth/store";
import { useOwnerRegistrationStore } from "../store";
import { Button } from "@/shared/components/ui/button";

interface OwnerRegistrationButtonProps {
  variant?: "header" | "default";
  className?: string;
}

export function OwnerRegistrationButton({
  variant = "default",
  className = "",
}: OwnerRegistrationButtonProps) {
  const { accessToken, setLoginPromptOpen } = useAuthStore();
  const { setDialogOpen } = useOwnerRegistrationStore();

  const handleClick = () => {
    if (!accessToken) {
      setLoginPromptOpen(true);
      return;
    }
    setDialogOpen(true);
  };

  if (variant === "header") {
    return (
      <button
        onClick={handleClick}
        className="flex items-center gap-2 px-4 py-2 rounded-full text-sm font-medium transition-all duration-200 hover:shadow-lg hover:scale-105 bg-emerald-50 text-emerald-700 hover:bg-emerald-100 border border-emerald-200"
      >
        <Building2 size={16} />
        <span>Đăng ký chủ sân</span>
      </button>
    );
  }

  return (
    <Button
      onClick={handleClick}
      variant="outline"
      className={`w-full rounded-xl py-3 h-auto flex items-center gap-3 justify-start ${className}`}
    >
      <div className="w-8 h-8 rounded-lg flex items-center justify-center bg-emerald-50">
        <Building2 size={16} className="text-emerald-600" />
      </div>
      <div className="text-left">
        <span className="font-bold text-sm text-gray-900">Đăng ký chủ sân</span>
        <p className="text-xs text-gray-500">
          Quản lý sân và nhận tiền định kỳ
        </p>
      </div>
    </Button>
  );
}
