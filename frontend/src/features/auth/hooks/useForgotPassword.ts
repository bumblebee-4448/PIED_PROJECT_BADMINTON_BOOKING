import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import { authService } from "../services";
import type { ForgotPasswordInput } from "../types";

export const useForgotPassword = () => {
  const navigate = useNavigate();

  return useMutation({
    mutationFn: (data: ForgotPasswordInput) => authService.forgotPassword(data),
    onSuccess: (_, variables) => {
      toast.success("Mã OTP đã được gửi tới email của bạn.");
      // Redirect to reset-password page, passing email in state
      navigate("/reset-password", { state: { email: variables.email } });
    },
  });
};
