import { Navigate } from "react-router-dom";

import { useAuthStore } from "@/features/auth/store";

interface GuestRouteProps {
  children: React.ReactNode;
}

/**
 * Guard component cho trang chỉ dành cho guest (chưa đăng nhập).
 * VD: Login, Register.
 *
 * Nếu đã login → redirect về trang chính dựa theo role:
 * - Admin → /admin
 * - User → /
 */
export function GuestRoute({ children }: GuestRouteProps) {
  const { accessToken, role } = useAuthStore();

  // Nếu đã đăng nhập → redirect về trang chính dựa theo Role
  if (accessToken && role) {
    const roleRedirects: Record<string, string> = {
      Admin: "/admin",
      Owner: "/owner",
      Customer: "/",
    };

    const redirectTo = roleRedirects[role] || "/";
    return <Navigate to={redirectTo} replace />;
  }

  // Chưa đăng nhập → cho phép truy cập
  return <>{children}</>;
}
