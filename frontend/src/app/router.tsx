import { createBrowserRouter } from "react-router-dom";

import { UserLayout } from "@/shared/layouts/UserLayout";
import { GuestRoute } from "@/shared/components/common/GuestRoute";
import { UnauthorizedPage, NotFoundPage } from "@/shared/pages";

// ─── Feature pages ───────────────────────────────────────
import { HomePage } from "@/features/landing/pages/HomePage";
import { LoginPage } from "@/features/auth/pages/LoginPage";
import { RegisterPage } from "@/features/auth/pages/RegisterPage";
import { VerifyOtpPage } from "@/features/auth/pages/VerifyOtpPage";
import { ProtectedRoute } from "@/shared/components/common";
import { ProfilePage } from "@/features/profile";

/**
 * React Router v6 config – createBrowserRouter (Data API).
 *
 * Active routes: /, /login, /register, /unauthorized, /* (404)
 * Commented routes: /rituals, /rituals/:id, /profile, /admin/*
 */
export const router = createBrowserRouter([
  // ─── Public layout (User) ───────────────────────────
  {
    element: <UserLayout />,
    children: [
      { index: true, element: <HomePage /> },
      // { path: "rituals", element: <RitualCatalog /> },
      // { path: "rituals/:id", element: <RitualDetail /> },
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
      {
        path: "verify-otp",
        element: (
          <GuestRoute>
            <VerifyOtpPage />
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
  // {
  //   path: "admin",
  //   element: (
  //     <ProtectedRoute allowedRoles={["admin"]}>
  //       {withSuspense(<AdminLayout />)}
  //     </ProtectedRoute>
  //   ),
  //   children: [
  //     { index: true, element: withSuspense(<DashboardPage />) },
  //     { path: "rituals", element: withSuspense(<ManageRitualList />) },
  //     { path: "rituals/create", element: withSuspense(<ManageRitualCreate />) },
  //     { path: "rituals/:id/edit", element: withSuspense(<ManageRitualEdit />) },
  //     { path: "users", element: withSuspense(<UserManagementPage />) },
  //   ],
  // },
]);
