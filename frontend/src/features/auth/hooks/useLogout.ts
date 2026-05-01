import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import { useAuthStore } from "../store";

export const useLogout = () => {
  const navigate = useNavigate();
  const logoutStore = useAuthStore((state) => state.logout);

  const handleLogout = () => {
    logoutStore();
    toast.success("Đã đăng xuất");
    navigate("/login");
  };

  return { mutate: handleLogout, isLoading: false };
};
