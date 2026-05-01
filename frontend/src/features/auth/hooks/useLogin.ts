import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import { jwtDecode } from "jwt-decode";
import { authService } from "../services";
import { useAuthStore } from "../store";
import type { LoginInput } from "../types";

export const useLogin = () => {
  const navigate = useNavigate();
  const setAuth = useAuthStore((state) => state.setAuth);

  return useMutation({
    mutationFn: (data: LoginInput) => authService.login(data),
    onSuccess: (response: any) => {
      const token = response.accessToken;
      if (!token) {
        toast.error("Không nhận được token từ server");
        return;
      }

      try {
        const decoded: any = jwtDecode(token);

        // Map .NET Identity claims (URL format) to friendly properties
        const user = {
          id: decoded[
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
          ],
          email:
            decoded[
              "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
            ],
          fullName:
            decoded["FullName"] ||
            decoded[
              "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
            ] ||
            "User",
          role:
            decoded["Role"] ||
            decoded[
              "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
            ] ||
            "Customer",
        };

        setAuth(token, user.role, user);
        toast.success("Đăng nhập thành công!");

        const roleRedirects: Record<string, string> = {
          Admin: "/admin",
          Owner: "/owner",
          Customer: "/",
        };

        navigate(roleRedirects[user.role] || "/");
      } catch (error) {
        console.error("Token decode error:", error);
      }
    },
  });
};
