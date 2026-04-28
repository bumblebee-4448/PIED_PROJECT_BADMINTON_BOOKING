import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import { authService } from "../services";
import { useAuthStore } from "../store";
import type { LoginInput, RegisterInput } from "../types";

export const useLogin = () => {
  const navigate = useNavigate();
  const setAuth = useAuthStore((state) => state.setAuth);

  return useMutation({
    mutationFn: (data: LoginInput) => authService.login(data),
    onSuccess: (response) => {
      setAuth(response.accessToken, response.role, response.user);
      toast.success("Đăng nhập thành công!");
      navigate("/");
    },
    onError: (error: any) => {
      const message = error.response?.data?.message || "Đăng nhập thất bại";
      toast.error(message);
    },
  });
};

export const useRegister = () => {
  const navigate = useNavigate();

  return useMutation({
    mutationFn: (data: RegisterInput) => authService.register(data),
    onSuccess: (message) => {
      toast.success(message || "Đăng ký thành công! Vui lòng kiểm tra email để lấy mã OTP.");
      // Thường sẽ chuyển đến trang verify OTP hoặc hiện modal
      // navigate("/verify-otp"); 
    },
    onError: (error: any) => {
      const message = error.response?.data?.message || "Đăng ký thất bại";
      toast.error(message);
    },
  });
};

export const useLogout = () => {
  const navigate = useNavigate();
  const clearAuth = useAuthStore((state) => state.logout);

  return useMutation({
    mutationFn: () => authService.logout(),
    onSuccess: () => {
      clearAuth();
      toast.success("Đã đăng xuất");
      navigate("/login");
    },
    onError: () => {
      clearAuth(); // Vẫn clear local state nếu server lỗi
      navigate("/login");
    },
  });
};
