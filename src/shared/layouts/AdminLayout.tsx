import { Link, Outlet, useLocation } from "react-router-dom";
import {
  BookOpen,
  LayoutDashboard,
  ScrollText,
  Users,
  LogOut,
  ChevronRight,
} from "lucide-react";

import { cn } from "@/lib/utils";
import { useLogout } from "@/features/auth";
import { Button } from "@/shared/components/ui/button";
import { Separator } from "@/shared/components/ui/separator";
import { ThemeToggle } from "@/shared/components/common/ThemeToggle";

const sidebarLinks = [
  { to: "/admin", label: "Dashboard", icon: LayoutDashboard, end: true },
  { to: "/admin/rituals", label: "Quản lý nghi lễ", icon: ScrollText },
  { to: "/admin/users", label: "Quản lý người dùng", icon: Users },
];

export function AdminLayout() {
  const location = useLocation();
  const { mutate: logout } = useLogout();

  const isActive = (path: string, end?: boolean) =>
    end ? location.pathname === path : location.pathname.startsWith(path);

  return (
    <div className="flex min-h-screen">
      {/* ─── Sidebar ────────────────────────────────────── */}
      <aside className="fixed inset-y-0 left-0 z-50 w-64 border-r bg-background flex flex-col">
        <div className="flex h-16 items-center gap-2 border-b px-6">
          <BookOpen className="h-6 w-6 text-primary" />
          <span className="font-bold text-lg">Admin Panel</span>
        </div>

        <nav className="flex-1 space-y-1 p-4">
          {sidebarLinks.map((link) => (
            <Button
              key={link.to}
              variant={isActive(link.to, link.end) ? "secondary" : "ghost"}
              className={cn(
                "w-full justify-start gap-3",
                isActive(link.to, link.end) && "text-primary",
              )}
              asChild
            >
              <Link to={link.to}>
                <link.icon className="h-4 w-4" />
                {link.label}
                {isActive(link.to, link.end) && (
                  <ChevronRight className="ml-auto h-4 w-4" />
                )}
              </Link>
            </Button>
          ))}
        </nav>

        <Separator />

        <div className="space-y-1 p-4">
          <div className="flex items-center justify-between px-3 py-2">
            <span className="text-xs text-muted-foreground">Giao diện</span>
            <ThemeToggle />
          </div>

          <Button
            variant="ghost"
            className="w-full justify-start gap-3"
            asChild
          >
            <Link to="/">← Về trang chính</Link>
          </Button>

          <Button
            variant="ghost"
            className="w-full justify-start gap-3 text-destructive hover:text-destructive"
            onClick={() => logout()}
          >
            <LogOut className="h-4 w-4" />
            Đăng xuất
          </Button>
        </div>
      </aside>

      {/* ─── Main Content ───────────────────────────────── */}
      <div className="flex-1 pl-64">
        <header className="sticky top-0 z-40 flex h-16 items-center border-b bg-background px-6">
          <h1 className="text-lg font-semibold">
            {sidebarLinks.find((l) => isActive(l.to, l.end))?.label ?? "Admin"}
          </h1>
        </header>
        <main className="p-6">
          <Outlet />
        </main>
      </div>
    </div>
  );
}

export default AdminLayout;
