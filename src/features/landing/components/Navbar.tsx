import React from "react";
import { useNavigate } from "react-router-dom";
import { Search, Menu, X } from "lucide-react";
import { useAuthStore } from "@/features/auth/store";

export function Navbar() {
  const [menuOpen, setMenuOpen] = React.useState(false);
  const navigate = useNavigate();
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

  return (
    <nav className="fixed top-0 left-0 right-0 z-50 bg-white/90 backdrop-blur-md shadow-sm">
      <div className="max-w-7xl mx-auto px-6 py-4 flex items-center justify-between">
        {/* Logo */}
        <div className="flex items-center gap-2">
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
          {["Trang chủ", "Tìm sân", "Sân cầu lông", "Bảng giá", "Liên hệ"].map(
            (item, i) => (
              <a
                key={i}
                href="#"
                className="text-gray-600 hover:text-emerald-600 transition-colors duration-200"
                style={{ fontWeight: 500 }}
              >
                {item}
              </a>
            ),
          )}
        </div>

        {/* Search + CTA */}
        <div className="hidden md:flex items-center gap-3">
          <div className="flex items-center gap-2 bg-gray-100 rounded-full px-4 py-2">
            <Search size={15} className="text-gray-400" />
            <input
              type="text"
              placeholder="Tìm sân..."
              className="bg-transparent outline-none text-sm text-gray-600 w-28"
            />
          </div>
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
          {["Trang chủ", "Giới thiệu", "Sân cầu", "Bảng giá", "Liên hệ"].map(
            (item, i) => (
              <a
                key={i}
                href="#"
                className="text-gray-600 hover:text-emerald-600 py-1"
                style={{ fontWeight: 500 }}
              >
                {item}
              </a>
            ),
          )}
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
