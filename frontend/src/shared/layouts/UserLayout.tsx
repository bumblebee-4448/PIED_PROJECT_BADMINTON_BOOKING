import { Link, Outlet } from "react-router-dom";
import { LogOut, User, BookOpen } from "lucide-react";

import { useAuthStore, useLogout } from "@/features/auth";
import { Button } from "@/shared/components/ui/button";
import { Separator } from "@/shared/components/ui/separator";
import { ThemeToggle } from "@/shared/components/common/ThemeToggle";

export function UserLayout() {
  const { accessToken, role } = useAuthStore();
  const { mutate: logout } = useLogout();

  return (
    <div className="min-h-screen flex flex-col">
      {/* ─── Header ─────────────────────────────────────── */}
      <header className="sticky top-0 z-50 border-b bg-background/95 backdrop-blur supports-backdrop-filter:bg-background/60">
        <div className="container mx-auto flex h-16 items-center justify-between px-4">
          <Link
            to="/"
            className="flex items-center gap-2 font-bold text-xl text-primary"
          >
            <BookOpen className="h-6 w-6" />
            Thích Cúng Kiếng
          </Link>

          <nav className="flex items-center gap-4">
            <Link
              to="/"
              className="text-sm font-medium text-muted-foreground transition-colors hover:text-foreground"
            >
              Trang chủ
            </Link>
            <Link
              to="/rituals"
              className="text-sm font-medium text-muted-foreground transition-colors hover:text-foreground"
            >
              Nghi lễ
            </Link>

            <Separator orientation="vertical" className="h-6" />

            <ThemeToggle />

            {accessToken ? (
              <div className="flex items-center gap-2">
                {role === "admin" && (
                  <Button variant="ghost" size="sm" asChild>
                    <Link to="/admin/rituals">Quản trị</Link>
                  </Button>
                )}
                <Button variant="ghost" size="sm" asChild>
                  <Link to="/profile">
                    <User className="mr-1.5 h-4 w-4" />
                    Tài khoản
                  </Link>
                </Button>
                <Button variant="secondary" size="sm" onClick={() => logout()}>
                  <LogOut className="mr-1.5 h-4 w-4" />
                  Đăng xuất
                </Button>
              </div>
            ) : (
              <div className="flex items-center gap-2">
                <Button variant="outline" size="sm" asChild>
                  <Link to="/login">Đăng nhập</Link>
                </Button>
                <Button size="sm" asChild>
                  <Link to="/register">Đăng ký</Link>
                </Button>
              </div>
            )}
          </nav>
        </div>
      </header>

      {/* ─── Main Content ───────────────────────────────── */}
      <main className="flex-1">
        <Outlet />
      </main>

      {/* ─── Footer ─────────────────────────────────────── */}
      <footer className="border-t bg-muted/40">
        <div className="container mx-auto px-4 py-8 text-center text-sm text-muted-foreground">
          © 2026 Thích Cúng Kiếng. Dự án học tập ReactJS.
        </div>
      </footer>
    </div>
  );
}
