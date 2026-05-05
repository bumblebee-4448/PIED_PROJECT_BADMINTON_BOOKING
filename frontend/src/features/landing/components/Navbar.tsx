import React from "react";
import { useNavigate, useLocation } from "react-router-dom";
import {  Menu, X } from "lucide-react";
import { useAuthStore } from "@/features/auth/store";
import { cn } from "@/lib/utils";

export function Navbar() {
  const [menuOpen, setMenuOpen] = React.useState(false);
  const navigate = useNavigate();
  const location = useLocation();
  const { accessToken, setLoginPromptOpen } = useAuthStore();

  const NAV_ITEMS = [
    { label: "Trang chủ", path: "/" },
    { label: "Tìm sân", path: "/courts" },
    { label: "Yêu thích", path: "/favorites" },
    { label: "Matching", path: "/matching" },
    { label: "Lịch sử", path: "/history"},
  ];

  const handleBookingClick = () => {
    if (!accessToken) {
      setLoginPromptOpen(true);
    } else {
      navigate("/courts");
    }
  };

  const handleLoginClick = () => {
    navigate("/login");
  };

  const handleNavItemClick = (path: string) => {
    if (path.startsWith("/")) {
      navigate(path);
      setMenuOpen(false);
    }
  };

  return (
    <nav className="fixed top-0 left-0 right-0 z-50 bg-white/90 backdrop-blur-md shadow-sm">
      <div className="max-w-7xl mx-auto px-6 py-4 flex items-center justify-between">
        {/* Logo */}
        <div 
          className="flex items-center gap-2 cursor-pointer" 
          onClick={() => navigate("/")}
        >
          <div
            className="w-10 h-10 rounded-xl flex items-center justify-center"
            style={{ background: "linear-gradient(135deg, #00C896, #00897B)" }}
          >
            <svg width="22" height="22" viewBox="0 0 24 24" fill="none">
              <circle cx="12" cy="12" r="2.5" fill="white" />
              <path
                d="M12 4C7.58 4 4 7.58 4 12s3.58 8 8 8 8-3.58 8-8-3.58-8-8-8zm0 14c-3.31 0-6-2.69-6-6s2.69-6 6-6 6 2.69 6 6-2.69 6-6 6z"
                fill="white"
                opacity="0.6"
              />
              <path
                d="M8 12h8M12 8v8"
                stroke="white"
                strokeWidth="1.5"
                strokeLinecap="round"
              />
            </svg>
          </div>
          <span
            style={{
              fontSize: "1.3rem",
              fontWeight: 700,
              color: "#00897B",
              letterSpacing: "-0.5px",
            }}
          >
            RallyHub
          </span>
        </div>

        {/* Desktop Nav */}
        <div className="hidden md:flex items-center gap-8">
          {NAV_ITEMS.map((item, i) => {
            const isActive = location.pathname === item.path;
            return (
              <button
                key={i}
                onClick={() => handleNavItemClick(item.path)}
                className={cn(
                  "transition-all duration-300 text-sm font-bold relative py-2 outline-none",
                  isActive 
                    ? "text-emerald-600 after:absolute after:bottom-[-4px] after:left-0 after:right-0 after:h-0.5 after:bg-emerald-600 after:rounded-full after:animate-in after:fade-in after:slide-in-from-bottom-1" 
                    : "text-gray-600 hover:text-emerald-600"
                )}
              >
                {item.label}
              </button>
            );
          })}
        </div>

        {/* CTA */}
        <div className="hidden md:flex items-center gap-3">
              <button
                onClick={handleBookingClick}
            className="px-5 py-2 rounded-full text-white text-sm transition-all duration-200 hover:shadow-lg hover:scale-105"
                style={{
                  background: "linear-gradient(135deg, #00C896, #00897B)",
              fontWeight: 600,
                }}
              >
                Đặt sân ngay
              </button>
          {!accessToken && (
            <button
              onClick={handleLoginClick}
              className="px-5 py-2 rounded-full text-black text-sm transition-all duration-200 hover:shadow-lg hover:scale-105"
              style={{
                background: "linear-gradient(135deg, #FFFFFF 0%, #D9D9D9 100%)",
                fontWeight: 600,
              }}
            >
              Đăng nhập
            </button>
          )}
        </div>

        {/* Mobile menu toggle */}
        <button
          className="md:hidden text-gray-600"
          onClick={() => setMenuOpen(!menuOpen)}
        >
          {menuOpen ? <X size={24} /> : <Menu size={24} />}
        </button>
      </div>

      {/* Mobile Menu */}
      {menuOpen && (
        <div className="md:hidden bg-white border-t border-gray-100 px-6 py-4 flex flex-col gap-4">
          {NAV_ITEMS.map((item, i) => (
            <button
              key={i}
              onClick={() => handleNavItemClick(item.path)}
              className="text-left text-gray-600 hover:text-emerald-600 py-1 text-sm font-medium"
            >
              {item.label}
            </button>
          ))}
          <button
            onClick={handleBookingClick}
            className="px-5 py-2 rounded-full text-white text-sm w-full"
            style={{
              background: "linear-gradient(135deg, #00C896, #00897B)",
              fontWeight: 600,
            }}
          >
            Đặt sân ngay
          </button>
        </div>
      )}
    </nav>
  );
}
