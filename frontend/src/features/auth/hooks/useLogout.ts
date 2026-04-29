import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import { authService } from "../services";
import { useAuthStore } from "../store";

export const useLogout = () => {
  const navigate = useNavigate();
  const logoutStore = useAuthStore((state) => state.logout);

  return useMutation({
    mutationFn: () => authService.logout(),
    onSuccess: () => {
      logoutStore();
      toast.success("Đã đăng xuất");
      navigate("/login");
    },
    onError: () => {
      // Still logout locally even if server call fails
      logoutStore();
      navigate("/login");
    },
  });
};
