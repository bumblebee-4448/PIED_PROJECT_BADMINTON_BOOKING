import { createBrowserRouter } from "react-router-dom";

import { UserLayout } from "@/shared/layouts/UserLayout";
import { GuestRoute } from "@/shared/components/common/GuestRoute";
import { UnauthorizedPage, NotFoundPage } from "@/shared/pages";

// ─── Feature pages ───────────────────────────────────────
import { HomePage } from "@/features/landing/pages/HomePage";
import { LoginPage } from "@/features/auth/pages/LoginPage";
import { RegisterPage } from "@/features/auth/pages/RegisterPage";
import { VerifyOtpPage } from "@/features/auth/pages/VerifyOtpPage";
import { ResetPasswordPage } from "@/features/auth/pages/ResetPasswordPage";
import { ProtectedRoute } from "@/shared/components/common";
import { ProfilePage } from "@/features/profile";
import { FavoritesPage } from "@/features/favorites";
import { AdminLayout } from "@/shared/layouts/AdminLayout";
import { AdminDashboard, OwnerDashboard } from "@/features/dashboard";
import { CourtSearchPage } from "@/features/courts";
import { BookingHistoryPage } from "@/features/bookings";
import { OwnerRequestsPage } from "@/features/admin-owner-requests";

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
      { path: "courts", element: <CourtSearchPage /> },
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
      {
        path: "reset-password",
        element: (
          <GuestRoute>
            <ResetPasswordPage />
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
      {
        path: "favorites",
        element: (
          <ProtectedRoute>
            <FavoritesPage />
          </ProtectedRoute>
        ),
      },
      {
        path: "history",
        element: (
          <ProtectedRoute>
            <BookingHistoryPage />
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
      <ProtectedRoute allowedRoles={["Admin"]}>
        <AdminLayout />
      </ProtectedRoute>
    ),
    children: [
      { index: true, element: <AdminDashboard /> },
      { path: "owner-requests", element: <OwnerRequestsPage /> },
    ],
  },

  // ─── Owner layout (Protected, admin only) ───────────
  {
    path: "owner",
    element: (
      <ProtectedRoute allowedRoles={["Owner"]}>
        <AdminLayout />
      </ProtectedRoute>
    ),
    children: [{ index: true, element: <OwnerDashboard /> }],
  },
]);
