import { createBrowserRouter } from "react-router-dom";

import { UserLayout } from "@/shared/layouts/UserLayout";
import { GuestRoute } from "@/shared/components/common/GuestRoute";
import { UnauthorizedPage, NotFoundPage, ComingSoonPage } from "@/shared/pages";

// ─── Feature pages ───────────────────────────────────────
import { HomePage } from "@/features/landing/pages/HomePage";
import { LoginPage } from "@/features/auth/pages/LoginPage";
import { RegisterPage } from "@/features/auth/pages/RegisterPage";
import { VerifyOtpPage } from "@/features/auth/pages/VerifyOtpPage";
import { ResetPasswordPage } from "@/features/auth/pages/ResetPasswordPage";
import { ProtectedRoute } from "@/shared/components/common";
import { FavoritesPage } from "@/features/favorites";
import { AdminLayout } from "@/shared/layouts/AdminLayout";
import { AdminDashboard, OwnerDashboard } from "@/features/dashboard";
import { CourtDetailPage, CourtSearchPage } from "@/features/courts";
import { BookingHistoryPage, BookingPage } from "@/features/bookings";
import { OwnerRequestsPage } from "@/features/admin-owner-requests";
import OwnerLayout from "@/shared/layouts/OwnerLayout";
import OwnerCourtsPage from "@/features/owner-courts/pages/OwnerCourtsPage";
import OwnerSubCourtsPage from "@/features/owner-courts/pages/OwnerSubCourtsPage";
import OwnerSubCourtCalendarPage from "@/features/owner-courts/pages/OwnerSubCourtCalendarPage";
import OwnerSubCourtSchedulePage from "@/features/owner-courts/pages/OwnerSubCourtSchedulePage";
import AdminCourtsPage from "@/features/admin-courts/pages/AdminCourtsPage";
import AdminUsersPage from "@/features/admin-users/pages/AdminUsersPage";
import { AdminWithdrawalsPage } from "@/features/admin-wallet/pages/AdminWithdrawalsPage";
import { AdminTransactionsPage } from "@/features/admin-wallet/pages/AdminTransactionsPage";
import { WalletPage, OwnerWalletPage } from "@/features/wallet";
import { ReportsPage } from "@/features/reports/pages/ReportsPage";

/**
 * React Router v6 config – createBrowserRouter (Data API).
 */
export const router = createBrowserRouter([
  // ─── Public layout (User) ───────────────────────────
  {
    element: <UserLayout />,
    children: [
      { index: true, element: <HomePage /> },
      { path: "courts", element: <CourtSearchPage /> },
      { path: "courts/:id", element: <CourtDetailPage /> },
      { path: "courts/:id/booking", element: <BookingPage /> },
      { path: "matching", element: <ComingSoonPage /> },
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
      {
        path: "wallet",
        element: (
          <ProtectedRoute>
            <WalletPage />
          </ProtectedRoute>
        ),
      },
      {
        path: "reports",
        element: (
          <ProtectedRoute>
            <ReportsPage />
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
      { path: "court-approvals", element: <AdminCourtsPage /> },
      { path: "users", element: <AdminUsersPage /> },
      { path: "withdrawals", element: <AdminWithdrawalsPage /> },
      { path: "transactions", element: <AdminTransactionsPage /> },
    ],
  },

  // ─── Owner layout (Protected, owner only) ────────────
  {
    path: "owner",
    element: (
      <ProtectedRoute allowedRoles={["Owner"]}>
        <OwnerLayout />
      </ProtectedRoute>
    ),
    children: [
      { index: true, element: <OwnerDashboard /> },
      { path: "courts", element: <OwnerCourtsPage /> },
      { path: "sub-courts", element: <OwnerSubCourtsPage /> },
      { path: "sub-courts/:id/calendar", element: <OwnerSubCourtCalendarPage /> },
      { path: "sub-courts/:id/schedule", element: <OwnerSubCourtSchedulePage /> },
      { path: "schedules", element: <OwnerSubCourtsPage /> },
      { path: "wallet", element: <OwnerWalletPage /> },
    ],
  },
]);
