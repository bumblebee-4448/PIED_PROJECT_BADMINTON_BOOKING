import { useState } from "react";
import { Outlet, useNavigate, useLocation, Navigate } from "react-router-dom";
import {
  LayoutDashboard,
  Users,
  Building2,
  DollarSign,
  Menu,
  Bell,
  ShieldCheck,
  Search,
} from "lucide-react";
import { useAuthStore } from "@/features/auth/store";
import { Button } from "@/shared/components/ui/button";
import { cn } from "@/lib/utils";
import { UserProfileCard } from "@/features/auth/components/UserProfileCard";
import { useMe } from "@/features/profile/hooks/useMe";

const ADMIN_NAV_ITEMS = [
  { icon: LayoutDashboard, label: "Dashboard", path: "/admin" },
  { icon: Users, label: "Người dùng", path: "/admin/users" },
  { icon: Building2, label: "Sân cầu lông", path: "/admin/courts" },
  { icon: DollarSign, label: "Tài chính", path: "/admin/finance" },
];

const OWNER_NAV_ITEMS = [
  { icon: LayoutDashboard, label: "Dashboard", path: "/owner" },
  { icon: Building2, label: "Cơ sở của tôi", path: "/owner/courts" },
  { icon: DollarSign, label: "Doanh thu", path: "/owner/revenue" },
];

export function AdminLayout() {
  const { user, role, accessToken } = useAuthStore();
  const navigate = useNavigate();
  const location = useLocation();
  const [sidebarOpen, setSidebarOpen] = useState(false);

  // Sử dụng React Query tối ưu thay cho useEffect
  const { isLoading: isProfileLoading } = useMe();

  const normalizedRole = role ? (role.charAt(0).toUpperCase() + role.slice(1).toLowerCase()) : "";

  // Kiểm tra quyền truy cập (Admin hoặc Owner)
  if (!accessToken || !user || (normalizedRole !== "Admin" && normalizedRole !== "Owner")) {
    return <Navigate to="/login" replace />;
  }

  // Hiển thị loading nếu đang lấy thông tin lần đầu (tránh flash dữ liệu trống)
  if (isProfileLoading && !user) {
    return (
      <div className="h-screen w-screen flex items-center justify-center bg-[#F1F5F9]">
        <div className="flex flex-col items-center gap-4">
          <div className="w-12 h-12 border-4 border-emerald-500/20 border-t-emerald-500 rounded-full animate-spin" />
          <p className="text-emerald-900/40 font-bold text-xs uppercase tracking-[0.2em]">Đang đồng bộ dữ liệu...</p>
        </div>
      </div>
    );
  }

  const isActive = (path: string) => {
    if (path === "/admin" || path === "/owner") {
      return location.pathname === path;
    }
    return location.pathname.startsWith(path);
  };

  return (
    <div className="flex h-screen overflow-hidden bg-[#F1F5F9]">
      <UserProfileCard />
      
      {/* Sidebar Overlay for Mobile */}
      {sidebarOpen && (
        <div 
          className="fixed inset-0 z-30 bg-[#091E1B]/20 backdrop-blur-sm lg:hidden" 
          onClick={() => setSidebarOpen(false)} 
        />
      )}

      {/* Sidebar */}
      <aside
        className={cn(
          "fixed lg:static inset-y-0 left-0 z-40 flex flex-col transition-all duration-300 bg-[#0B2421] text-white shadow-xl",
          sidebarOpen ? "translate-x-0" : "-translate-x-full lg:translate-x-0"
        )}
        style={{ width: "260px" }}
      >
        {/* 1. TOP: Logo & Brand */}
        <div className="px-6 py-10">
          <div className="flex items-center gap-3.5">
            <div className="w-11 h-11 rounded-2xl bg-[#00CE98] flex items-center justify-center shadow-lg shadow-emerald-500/20 rotate-3 group hover:rotate-0 transition-transform duration-300">
              <ShieldCheck size={24} className="text-[#0B2421]" />
            </div>
            <div>
              <h1 className="font-black text-xl leading-tight tracking-tight uppercase italic text-white">Rally<span className="text-[#00CE98]">Hub</span></h1>
              <p className="text-[9px] text-gray-500 font-bold tracking-[0.2em] uppercase">Badminton CMS</p>
            </div>
          </div>
        </div>

        {/* 2. MIDDLE: Navigation */}
        <nav className="flex-1 px-4 space-y-1.5 overflow-y-auto custom-scrollbar">
          <p className="px-4 text-[10px] font-black text-gray-600 uppercase tracking-[0.2em] mb-4 opacity-70">Main Content</p>
          {(normalizedRole === "Admin" ? ADMIN_NAV_ITEMS : OWNER_NAV_ITEMS).map(({ icon: Icon, label, path }) => (
            <button
              key={path}
              onClick={() => { navigate(path); setSidebarOpen(false); }}
              className={cn(
                "w-full flex items-center gap-3.5 px-4 py-3 rounded-2xl transition-all duration-300 group relative",
                isActive(path) 
                  ? "bg-[#00CE98]/10 text-[#00CE98]" 
                  : "text-gray-400 hover:bg-white/5 hover:text-white"
              )}
            >
              <Icon size={19} className={cn("transition-colors", isActive(path) ? "text-[#00CE98]" : "group-hover:text-white")} />
              <span className="text-[13px] font-bold tracking-wide">{label}</span>
              {isActive(path) && (
                <div className="absolute right-4 w-1.5 h-1.5 rounded-full bg-[#00CE98] shadow-[0_0_12px_#00CE98]" />
              )}
            </button>
          ))}
        </nav>

        {/* 3. BOTTOM: Session Section (Simplified) */}
        <div className="p-8 mt-auto">
          <div className="flex justify-center">
            <div className="inline-flex items-center justify-center px-4 py-2 bg-emerald-500/5 rounded-full border border-emerald-500/10">
              <span className="text-[10px] font-black text-emerald-500/60 uppercase tracking-[0.3em] leading-none">
                {normalizedRole} Session
              </span>
            </div>
          </div>
        </div>
      </aside>

      {/* Main Content Area */}
      <div className="flex-1 flex flex-col min-w-0 overflow-hidden">
        {/* Header */}
        <header className="bg-white/80 backdrop-blur-md border-b border-gray-100 px-8 py-4 flex items-center justify-between sticky top-0 z-20">
          <div className="flex items-center gap-4">
            <Button 
              variant="ghost" 
              size="icon"
              onClick={() => setSidebarOpen(true)} 
              className="lg:hidden rounded-xl hover:bg-gray-100"
            >
              <Menu size={20} />
            </Button>
            <h2 className="text-xl font-extrabold text-[#0B2421] tracking-tight">{normalizedRole} Portal</h2>
          </div>

          <div className="hidden md:flex items-center gap-4 flex-1 max-w-md mx-8">
            <div className="relative w-full group">
              <Search size={16} className="absolute left-4 top-1/2 -translate-y-1/2 text-gray-400 group-focus-within:text-emerald-500 transition-colors pointer-events-none" />
              <input 
                type="text" 
                placeholder="Tìm kiếm tác vụ..." 
                className="w-full bg-gray-100 border-transparent focus:bg-white focus:border-emerald-500/50 focus:ring-4 focus:ring-emerald-500/5 h-11 pl-11 pr-4 rounded-2xl text-sm transition-all outline-none font-medium"
              />
            </div>
          </div>

          <div className="flex items-center gap-4">
            <Button variant="ghost" size="icon" className="relative rounded-2xl text-gray-400 hover:bg-gray-100 h-11 w-11 transition-all">
              <Bell size={20} />
              <span className="absolute top-3 right-3 w-2 h-2 rounded-full bg-red-500 border-2 border-white" />
            </Button>
          </div>
        </header>

        <main className="flex-1 overflow-y-auto p-8 custom-scrollbar">
          <div className="max-w-7xl mx-auto">
            <Outlet />
          </div>
        </main>
      </div>
    </div>
  );
}

export default AdminLayout;
