import { Navigate, useLocation } from "react-router-dom";

import { useAuthStore } from "@/features/auth/store";
import type { UserRole } from "@/shared/types";

interface ProtectedRouteProps {
  children: React.ReactNode;
  allowedRoles?: UserRole[];
}

/**
 * Guard component – kiểm tra đăng nhập & role trước khi render.
 * Nếu chưa login → redirect /login (lưu lại vị trí hiện tại).
 * Nếu không đủ role → redirect /unauthorized.
 */
export function ProtectedRoute({
  children,
  allowedRoles,
}: ProtectedRouteProps) {
  const location = useLocation();
  const { accessToken, role } = useAuthStore();

  if (!accessToken) {
    return <Navigate to="/login" state={{ from: location }} replace />;
  }

  if (allowedRoles && role && !allowedRoles.includes(role)) {
    return <Navigate to="/unauthorized" replace />;
  }

  return <>{children}</>;
}
