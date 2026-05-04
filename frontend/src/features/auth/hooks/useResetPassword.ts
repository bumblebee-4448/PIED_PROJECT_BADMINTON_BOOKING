import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import { authService } from "../services";
import type { ResetPasswordInput } from "../types";

export const useResetPassword = () => {
  const navigate = useNavigate();

  return useMutation({
    mutationFn: (data: ResetPasswordInput) => authService.resetPassword(data),
    onSuccess: () => {
      toast.success("Mật khẩu của bạn đã được đặt lại thành công. Vui lòng đăng nhập lại.");
      navigate("/login");
    },
    onError: (error: any) => {
      const message = error.response?.data?.message || "Đặt lại mật khẩu thất bại. Vui lòng thử lại.";
      toast.error(message);
    },
  });
};
