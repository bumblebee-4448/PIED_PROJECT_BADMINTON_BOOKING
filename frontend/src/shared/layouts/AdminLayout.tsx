import { useState } from "react";
import { Outlet, useNavigate, useLocation, Navigate } from "react-router-dom";
import {
  LayoutDashboard, Users, Building2, DollarSign,
  LogOut, Menu, X, ChevronRight, Bell, ShieldCheck
} from "lucide-react";
import { useAuthStore } from "@/features/auth/store";
import { Button } from "@/shared/components/ui/button";
import { cn } from "@/lib/utils";

const NAV_ITEMS = [
  { icon: LayoutDashboard, label: "Dashboard", path: "/admin" },
  { icon: Users, label: "Quản lý User", path: "/admin/users" },
  { icon: Building2, label: "Quản lý Sản phẩm", path: "/admin/products" },
  { icon: DollarSign, label: "Luồng tiền", path: "/admin/cashflow" },
];

export function AdminLayout() {
  const { user, logout, role } = useAuthStore();
  const navigate = useNavigate();
  const location = useLocation();
  const [sidebarOpen, setSidebarOpen] = useState(false);

  // Kiểm tra quyền admin
  if (!user || role !== "admin") {
    return <Navigate to="/login" replace />;
  }

  const isActive = (path: string) => {
    if (path === "/admin") {
      return location.pathname === "/admin";
    }
    return location.pathname.startsWith(path);
  };

  return (
    <div className="flex h-screen overflow-hidden" style={{ background: "#f0f2f5" }}>
      {/* Sidebar Overlay for Mobile */}
      {sidebarOpen && (
        <div 
          className="fixed inset-0 z-30 bg-black/50 lg:hidden" 
          onClick={() => setSidebarOpen(false)} 
        />
      )}

      {/* Sidebar */}
      <aside
        className={cn(
          "fixed lg:static inset-y-0 left-0 z-40 flex flex-col transition-transform duration-300",
          sidebarOpen ? "translate-x-0" : "-translate-x-full lg:translate-x-0"
        )}
        style={{ 
          width: "240px", 
          background: "linear-gradient(180deg, #0D1B2A 0%, #1B2838 60%, #243447 100%)", 
          flexShrink: 0 
        }}
      >
        {/* Logo */}
        <div className="flex items-center gap-3 px-5 py-5 border-b border-white/10">
          <div 
            className="w-9 h-9 rounded-xl flex items-center justify-center" 
            style={{ background: "linear-gradient(135deg,#00C896,#00897B)" }}
          >
            <ShieldCheck size={18} color="white" />
          </div>
          <div>
            <p className="text-white font-extrabold text-base leading-tight">SmashBook</p>
            <p className="text-white/50 text-[0.68rem]">Admin Panel</p>
          </div>
          <Button 
            variant="ghost" 
            size="icon" 
            className="ml-auto lg:hidden text-white hover:bg-white/10" 
            onClick={() => setSidebarOpen(false)}
          >
            <X size={18} />
          </Button>
        </div>

        {/* Admin info */}
        <div className="px-5 py-4 border-b border-white/10">
          <div className="flex items-center gap-3">
            <div 
              className="w-10 h-10 rounded-xl flex items-center justify-center font-bold text-white text-sm"
              style={{ background: "linear-gradient(135deg,#00C896,#00897B)" }}
            >
              AD
            </div>
            <div>
              <p className="text-white font-bold text-[0.85rem]">{user.fullName || user.name || "Admin"}</p>
              <div className="flex items-center gap-1">
                <ShieldCheck size={10} className="text-[#00C896]" />
                <span className="text-white/50 text-[0.68rem]">Super Admin</span>
              </div>
            </div>
          </div>
        </div>

        {/* Nav */}
        <nav className="flex-1 px-3 py-4 flex flex-col gap-1">
          {NAV_ITEMS.map(({ icon: Icon, label, path }) => (
            <Button
              key={path}
              variant="ghost"
              onClick={() => { navigate(path); setSidebarOpen(false); }}
              className={cn(
                "justify-start gap-3 px-3 py-2.5 h-auto rounded-xl transition-all border-l-[3px]",
                isActive(path) 
                  ? "bg-[#00C896]/15 text-[#00C896] font-bold border-[#00C896] hover:bg-[#00C896]/20 hover:text-[#00C896]" 
                  : "text-white/55 border-transparent hover:bg-white/5 hover:text-white"
              )}
            >
              <Icon size={17} />
              {label}
              {isActive(path) && <ChevronRight size={14} className="ml-auto" />}
            </Button>
          ))}
        </nav>

        {/* Logout */}
        <div className="px-3 pb-5">
          <Button
            variant="ghost"
            onClick={() => { logout(); navigate("/login"); }}
            className="w-full justify-start gap-3 px-3 py-2.5 h-auto rounded-xl text-white/50 hover:bg-white/10 hover:text-white"
          >
            <LogOut size={16} /> Đăng xuất
          </Button>
        </div>
      </aside>

      {/* Main Content Area */}
      <div className="flex-1 flex flex-col min-w-0 overflow-hidden">
        <header className="bg-white border-b border-gray-100 px-4 sm:px-6 py-3 flex items-center gap-3 flex-shrink-0">
          <Button 
            variant="secondary" 
            size="icon"
            onClick={() => setSidebarOpen(true)} 
            className="lg:hidden rounded-xl bg-[#f3f4f6]"
          >
            <Menu size={18} />
          </Button>
          <div className="flex-1">
            <p className="text-[0.78rem] text-[#9ca3af]">
              Admin Panel • {new Date().toLocaleDateString("vi-VN", { weekday: "long", year: "numeric", month: "long", day: "numeric" })}
            </p>
          </div>
          <Button 
            variant="secondary" 
            size="icon"
            className="relative rounded-xl bg-[#f3f4f6]"
          >
            <Bell size={16} className="text-gray-500" />
            <span className="absolute top-2 right-2 w-2 h-2 rounded-full bg-red-500" />
          </Button>
        </header>

        <main className="flex-1 overflow-y-auto">
          <Outlet />
        </main>
      </div>
    </div>
  );
}

export default AdminLayout;
