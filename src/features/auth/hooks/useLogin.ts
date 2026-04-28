import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import { useAuthStore } from "../store";
import { LoginInput, AuthResponse } from "../types";

export const useLogin = () => {
  const navigate = useNavigate();
  const setAuth = useAuthStore((state) => state.setAuth);

  return useMutation({
    mutationFn: async (data: LoginInput) => {
      const response = await apiClient.post<AuthResponse>(
        API_ENDPOINTS.AUTH.LOGIN,
        data
      );
      // axios.ts interceptor already returns response.data or response.data.data
      return response as unknown as AuthResponse;
    },
    onSuccess: (data) => {
      setAuth(data.accessToken, data.role, data.user);
      toast.success("Đăng nhập thành công!");
      navigate("/");
    },
    onError: (error: any) => {
      const message = error.response?.data?.message || "Đăng nhập thất bại";
      toast.error(message);
    },
  });
};
