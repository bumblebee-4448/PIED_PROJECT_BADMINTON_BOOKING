import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import { authService } from "../services";

export const useVerifyOtp = () => {
  const navigate = useNavigate();

  return useMutation({
    mutationFn: ({ email, otp }: { email: string; otp: string }) => 
      authService.verifyOtp(email, otp),
    onSuccess: () => {
      toast.success("Xác thực tài khoản thành công!");
      navigate("/login");
    },
    onError: (error: any) => {
      // Error handling is usually done in axios interceptors, 
      // but we can add specific logic here if needed.
      console.error("Xác thực thất bại:", error);
    }
  });
};
