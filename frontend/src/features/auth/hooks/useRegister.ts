import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import { authService } from "../services";
import type { RegisterInput } from "../types";

export const useRegister = () => {
  const navigate = useNavigate();

  return useMutation({
    mutationFn: (data: RegisterInput) => authService.register(data),
    onSuccess: (_, variables) => {
      toast.success("Đăng ký thành công! Vui lòng kiểm tra email để lấy mã OTP.");
      // Chuyển hướng sang trang nhập OTP và truyền email qua state
      navigate("/verify-otp", { state: { email: variables.email } });
    },
  });
};
