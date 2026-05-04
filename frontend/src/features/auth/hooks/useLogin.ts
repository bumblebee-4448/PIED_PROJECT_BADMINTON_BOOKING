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
      // The response might be just the 'data' object from axios interceptor
      const accessToken = response.accessToken;
      
      if (!accessToken) {
        toast.error("Không nhận được token từ server");
        return;
      }

      let role = response.role;
      let user = response.user;

      // If role or user info is missing in response, decode it from JWT
      if (!role || !user) {
        try {
          const decoded: any = jwtDecode(accessToken);
          
          role = role || 
                 decoded["Role"] || 
                 decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || 
                 "Customer";

          const decodedUser = {
            id: decoded["UserId"] || 
                decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],
            email: decoded["Email"] || 
                   decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
            firstName: decoded["FirstName"] || "",
            lastName: decoded["LastName"] || "",
          };

          user = { ...decodedUser, ...user };
        } catch (error) {
          console.error("Token decode error:", error);
        }
      }

      setAuth(accessToken, role, user);
      toast.success("Đăng nhập thành công!");

      const roleRedirects: Record<string, string> = {
        Admin: "/admin",
        Owner: "/owner",
        Customer: "/",
      };

      navigate(roleRedirects[role] || "/");
    },
  });
};
