import React from "react";
import { useNavigate, Link, useLocation } from "react-router-dom";
import { Search, Menu, X, Home, MapPin, Heart, Users, History } from "lucide-react";
import { useAuthStore } from "@/features/auth/store";
import { cn } from "@/lib/utils";
import { Button } from "@/shared/components/ui/button";

export function Navbar() {
  const [menuOpen, setMenuOpen] = React.useState(false);
  const navigate = useNavigate();
  const location = useLocation();
  const { accessToken, setLoginPromptOpen } = useAuthStore();

  const handleBookingClick = () => {
    if (!accessToken) {
      setLoginPromptOpen(true);
    } else {
      navigate("/search");
    }
  };

  const handleLoginClick = () => {
    navigate("/login");
  };

  const navItems = [
    { name: "Trang chủ", path: "/", icon: Home },
    { name: "Tìm sân", path: "/search", icon: MapPin },
    { name: "Yêu thích", path: "/favorites", icon: Heart },
    { name: "Matching", path: "/matching", icon: Users },
    { name: "Lịch sử", path: "/history", icon: History },
  ];

  return (
    <nav className="fixed top-0 left-0 right-0 z-50 bg-white/90 backdrop-blur-md border-b border-gray-100">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 py-3 flex items-center justify-between">
        {/* Logo */}
        <Link to="/" className="flex items-center gap-2">
          <div
            className="w-9 h-9 rounded-xl flex items-center justify-center"
            style={{ background: "linear-gradient(135deg, #00C896, #00897B)" }}
          >
            <span className="text-lg">🏸</span>
          </div>
          <span className="text-xl font-black text-[#00897B] tracking-tight">
            SmashBook
          </span>
        </Link>

        {/* Desktop Nav */}
        <div className="hidden lg:flex items-center gap-1">
          {navItems.map((item) => {
            const isActive = location.pathname === item.path;
            const Icon = item.icon;
            return (
              <Link
                key={item.path}
                to={item.path}
                className={cn(
                  "flex items-center gap-2 px-4 py-2 rounded-full text-sm font-bold transition-all duration-200",
                  isActive
                    ? "bg-[#00CE98]/10 text-[#00897B]"
                    : "text-gray-500 hover:text-[#00CE98] hover:bg-gray-50"
                )}
              >
                <Icon size={16} />
                {item.name}
              </Link>
            );
          })}
        </div>

        {/* Auth & CTA */}
        <div className="hidden md:flex items-center gap-4">
          {!accessToken ? (
            <>
              <button
                onClick={handleLoginClick}
                className="text-sm font-bold text-gray-600 hover:text-[#00897B] transition-colors"
              >
                Đăng nhập
              </button>
              <button
                onClick={() => navigate("/register")}
                className="px-6 py-2.5 rounded-full bg-[#00CE98] text-white text-sm font-bold shadow-md shadow-[#00CE98]/20 hover:bg-[#00B589] transition-all active:scale-95"
              >
                Đăng ký
              </button>
            </>
          ) : (
            <button
              onClick={handleBookingClick}
              className="px-6 py-2.5 rounded-full bg-[#00CE98] text-white text-sm font-bold shadow-md shadow-[#00CE98]/20 hover:bg-[#00B589] transition-all active:scale-95"
            >
              Đặt sân ngay
            </button>
          )}
        </div>

        {/* Mobile menu toggle */}
        <button
          className="lg:hidden p-2 text-gray-600"
          onClick={() => setMenuOpen(!menuOpen)}
        >
          {menuOpen ? <X size={24} /> : <Menu size={24} />}
        </button>
      </div>

      {/* Mobile Menu */}
      {menuOpen && (
        <div className="lg:hidden bg-white border-t border-gray-100 px-6 py-6 flex flex-col gap-4 animate-in slide-in-from-top duration-300">
          {navItems.map((item) => (
            <Link
              key={item.path}
              to={item.path}
              onClick={() => setMenuOpen(false)}
              className={cn(
                "flex items-center gap-3 py-2 text-base font-bold transition-colors",
                location.pathname === item.path ? "text-[#00897B]" : "text-gray-500"
              )}
            >
              <item.icon size={20} />
              {item.name}
            </Link>
          ))}
          <div className="pt-4 border-t border-gray-50 flex flex-col gap-3">
             {!accessToken ? (
               <>
                 <Button variant="outline" onClick={handleLoginClick} className="w-full rounded-full font-bold">
                   Đăng nhập
                 </Button>
                 <Button variant="gradient" onClick={() => navigate("/register")} className="w-full rounded-full font-bold">
                   Đăng ký
                 </Button>
               </>
             ) : (
               <Button variant="gradient" onClick={handleBookingClick} className="w-full rounded-full font-bold">
                 Đặt sân ngay
               </Button>
             )}
          </div>
        </div>
      )}
    </nav>
  );
}
