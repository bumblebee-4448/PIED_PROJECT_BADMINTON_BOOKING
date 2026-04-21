import { lazy, Suspense, type ReactNode } from "react";
import { createBrowserRouter } from "react-router-dom";

import { UserLayout } from "@/shared/layouts/UserLayout";
import { ProtectedRoute } from "@/shared/components/common/ProtectedRoute";
import { GuestRoute } from "@/shared/components/common/GuestRoute";
import { UnauthorizedPage, NotFoundPage } from "@/shared/pages";

// ─── Feature pages ───────────────────────────────────────
import { HomePage } from "@/features/landing";
import { LoginPage, RegisterPage } from "@/features/auth";
import { RitualCatalog, RitualDetail } from "@/features/rituals";
import { ProfilePage } from "@/features/users";
import { LoadingSpinner } from "@/shared/components/common";

const AdminLayout = lazy(() => import("@/shared/layouts/AdminLayout"));
const DashboardPage = lazy(
  () => import("@/features/dashboard/pages/DashboardPage"),
);
const ManageRitualList = lazy(
  () => import("@/features/rituals/pages/ManageRitualList"),
);
const ManageRitualCreate = lazy(
  () => import("@/features/rituals/pages/ManageRitualCreate"),
);
const ManageRitualEdit = lazy(
  () => import("@/features/rituals/pages/ManageRitualEdit"),
);
const UserManagementPage = lazy(
  () => import("@/features/users/pages/UserManagementPage"),
);

const withSuspense = (children: ReactNode) => (
  <Suspense fallback={<LoadingSpinner className="py-20" size="lg" />}>
    {children}
  </Suspense>
);

/**
 * React Router v6 config – createBrowserRouter (Data API).
 *
 * Public routes: /, /rituals, /rituals/:id, /login, /register
 * Protected (user/admin): /profile
 * Protected (admin only): /admin/*
 */
export const router = createBrowserRouter([
  // ─── Public layout (User) ───────────────────────────
  {
    element: <UserLayout />,
    children: [
      { index: true, element: <HomePage /> },
      { path: "rituals", element: <RitualCatalog /> },
      { path: "rituals/:id", element: <RitualDetail /> },
      {
        path: "login",
        element: (
          <GuestRoute>
            <LoginPage />
          </GuestRoute>
        ),
      },
      {
        path: "register",
        element: (
          <GuestRoute>
            <RegisterPage />
          </GuestRoute>
        ),
      },
      { path: "unauthorized", element: <UnauthorizedPage /> },

      // Protected: cần đăng nhập
      {
        path: "profile",
        element: (
          <ProtectedRoute>
            <ProfilePage />
          </ProtectedRoute>
        ),
      },

      // 404 fallback cho user layout
      { path: "*", element: <NotFoundPage /> },
    ],
  },

  // ─── Admin layout (Protected, admin only) ───────────
  {
    path: "admin",
    element: (
      <ProtectedRoute allowedRoles={["admin"]}>
        {withSuspense(<AdminLayout />)}
      </ProtectedRoute>
    ),
    children: [
      { index: true, element: withSuspense(<DashboardPage />) },
      { path: "rituals", element: withSuspense(<ManageRitualList />) },
      { path: "rituals/create", element: withSuspense(<ManageRitualCreate />) },
      { path: "rituals/:id/edit", element: withSuspense(<ManageRitualEdit />) },
      { path: "users", element: withSuspense(<UserManagementPage />) },
    ],
  },
]);
