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

  // Nếu đã đăng nhập → redirect về trang chính
  if (accessToken) {
    const redirectTo = role === "admin" ? "/admin" : "/";
    return <Navigate to={redirectTo} replace />;
  }

  // Chưa đăng nhập → cho phép truy cập
  return <>{children}</>;
}
