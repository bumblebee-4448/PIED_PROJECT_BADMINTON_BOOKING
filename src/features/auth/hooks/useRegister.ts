import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import { RegisterInput } from "../types";

export const useRegister = () => {
  const navigate = useNavigate();

  return useMutation({
    mutationFn: async (data: RegisterInput) => {
      const response = await apiClient.post(
        API_ENDPOINTS.AUTH.REGISTER,
        data
      );
      return response;
    },
    onSuccess: () => {
      toast.success("Đăng ký thành công! Vui lòng đăng nhập.");
      navigate("/login");
    },
    onError: (error: any) => {
      const message = error.response?.data?.message || "Đăng ký thất bại";
      toast.error(message);
    },
  });
};
