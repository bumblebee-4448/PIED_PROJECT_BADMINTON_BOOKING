import React from "react";
import { useNavigate } from "react-router-dom";
import {
  ArrowRight,
  Play,
  Search,
  Calendar,
  Clock,
  Star,
  Shield,
  Zap,
  MapPin,
  Menu,
  X,
} from "lucide-react";
import { ImageWithFallback } from "@/shared/components/common";
import { useAuthStore } from "@/features/auth/store";

// Mock data for courts
const courts = [
  {
    id: "1",
    name: "Sân Cầu Lông Tân Bình",
    location: "Quận Tân Bình, TP.HCM",
    address: "123 Nguyễn Trãi, P.3, Q.Tân Bình",
    pricePerHour: 80000,
    rating: 4.9,
    reviews: 128,
    available: "Còn 3 sân trống",
    img: "https://images.unsplash.com/photo-1775993167284-8e6a6e56ab69?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHBiYWRtaW50b24lMjBjb3VydCUyMGluZG9vciUyMHNwb3J0c3xlbnwxfHx8fDE3NzY3MDE4Mjh8MA&ixlib=rb-4.1.0&q=80&w=1080",
    tag: "Nổi bật",
    tagColor: "#00C896",
    lat: 10.7769,
    lng: 106.7009,
  },
  {
    id: "2",
    name: "Cầu Lông Phú Mỹ Hưng",
    location: "Quận 7, TP.HCM",
    address: "456 Nguyễn Văn Linh, P.Tân Phong, Q.7",
    pricePerHour: 100000,
    rating: 4.8,
    reviews: 96,
    available: "Còn 5 sân trống",
    img: "https://images.unsplash.com/photo-1614058585449-0aceebe022cc?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxiYWRtaW50b24lMjBzaHV0dGxlY29jayUyMHNtYXNofGVufDF8fHx8MTc3NjcwMTgzMXww&ixlib=rb-4.1.0&q=80&w=1080",
    tag: "Cao cấp",
    tagColor: "#FFB300",
    lat: 10.7269,
    lng: 106.7209,
  },
  {
    id: "3",
    name: "Cầu Lông Bình Thạnh",
    location: "Quận Bình Thạnh, TP.HCM",
    address: "789 Xô Viết Nghệ Tĩnh, P.19, Q.Bình Thạnh",
    pricePerHour: 65000,
    rating: 4.7,
    reviews: 74,
    available: "Còn 2 sân trống",
    img: "https://images.unsplash.com/photo-1771909720886-a90afd1b37f5?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxpbmRvb3IlMjBzcG9ydHMlMjBmYWNpbGl0eSUyMGxpZ2h0aW5nfGVufDF8fHx8MTc3NjcwMTgzNHww&ixlib=rb-4.1.0&q=80&w=1080",
    tag: "Giá tốt",
    tagColor: "#4CAF50",
    lat: 10.8069,
    lng: 106.7109,
  },
];

// Navbar Component
function Navbar() {
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

// Hero Section Component
function HeroSection() {
  return (
    <section
      className="relative min-h-screen overflow-hidden"
      style={{ background: "linear-gradient(135deg, #f0fdf9 0%, #ffffff 50%)" }}
    >
      {/* Wave blobs - top right */}
      <svg
        className="absolute top-0 right-0 w-[65%] h-full"
        viewBox="0 0 700 700"
        fill="none"
        xmlns="http://www.w3.org/2000/svg"
        preserveAspectRatio="xMidYMid slice"
      >
        <path
          d="M700 0 C600 0, 450 80, 420 200 C390 320, 520 380, 480 500 C440 620, 320 680, 300 700 L700 700 Z"
          fill="url(#heroGrad1)"
          opacity="0.15"
        />
        <path
          d="M700 0 C580 20, 500 120, 530 260 C560 380, 680 420, 680 550 C680 640, 640 680, 700 700 Z"
          fill="url(#heroGrad2)"
          opacity="0.25"
        />
        <path
          d="M700 100 C640 80, 560 160, 580 280 C600 380, 700 420, 700 700 Z"
          fill="url(#heroGrad3)"
          opacity="0.4"
        />
        <defs>
          <linearGradient id="heroGrad1" x1="0%" y1="0%" x2="100%" y2="100%">
            <stop offset="0%" stopColor="#00C896" />
            <stop offset="100%" stopColor="#00897B" />
          </linearGradient>
          <linearGradient id="heroGrad2" x1="0%" y1="0%" x2="100%" y2="100%">
            <stop offset="0%" stopColor="#26D0CE" />
            <stop offset="100%" stopColor="#00C896" />
          </linearGradient>
          <linearGradient id="heroGrad3" x1="0%" y1="0%" x2="100%" y2="100%">
            <stop offset="0%" stopColor="#00897B" />
            <stop offset="100%" stopColor="#004D40" />
          </linearGradient>
        </defs>
      </svg>

      {/* Bottom wave */}
      <svg
        className="absolute bottom-0 left-0 w-full"
        viewBox="0 0 1440 160"
        fill="none"
        xmlns="http://www.w3.org/2000/svg"
        preserveAspectRatio="none"
      >
        <path
          d="M0 160 C240 80, 480 40, 720 80 C960 120, 1200 60, 1440 40 L1440 160 Z"
          fill="#00C896"
          opacity="0.12"
        />
        <path
          d="M0 160 C300 100, 600 60, 900 100 C1100 128, 1300 90, 1440 80 L1440 160 Z"
          fill="#00897B"
          opacity="0.08"
        />
      </svg>

      {/* Floating accent dots */}
      <div
        className="absolute top-32 left-10 w-3 h-3 rounded-full"
        style={{ background: "#00C896" }}
      ></div>
      <div
        className="absolute top-48 left-6 w-2 h-2 rounded-full"
        style={{ background: "#26D0CE" }}
      ></div>
      <div
        className="absolute top-64 left-14 w-4 h-4 rounded-full"
        style={{ background: "#00897B", opacity: 0.4 }}
      ></div>

      {/* Content */}
      <div className="relative max-w-7xl mx-auto px-6 pt-28 pb-20 flex flex-col lg:flex-row items-center gap-12 min-h-screen">
        {/* Left */}
        <div className="flex-1 flex flex-col gap-6 z-10">
          <div
            className="inline-flex items-center gap-2 px-4 py-2 rounded-full w-fit"
            style={{
              background: "rgba(0,200,150,0.12)",
              border: "1px solid rgba(0,200,150,0.3)",
            }}
          >
            <span
              className="w-2 h-2 rounded-full animate-pulse"
              style={{ background: "#00C896" }}
            ></span>
            <span
              style={{ color: "#00897B", fontWeight: 600, fontSize: "0.85rem" }}
            >
              🏸 Nền tảng đặt sân hàng đầu Việt Nam
            </span>
          </div>

          <div>
            <h1
              style={{
                fontSize: "clamp(2.5rem, 5vw, 4rem)",
                fontWeight: 800,
                lineHeight: 1.15,
                color: "#1a1a2e",
                letterSpacing: "-1px",
              }}
            >
              Đặt sân{" "}
              <span
                style={{
                  background: "linear-gradient(135deg, #00C896, #00897B)",
                  WebkitBackgroundClip: "text",
                  WebkitTextFillColor: "transparent",
                }}
              >
                Cầu lông
              </span>
              <br />
              chưa bao giờ{" "}
              <span style={{ color: "#1a1a2e" }}>dễ dàng hơn!</span>
            </h1>
          </div>

          <p
            style={{
              color: "#6b7280",
              fontSize: "1.05rem",
              lineHeight: 1.8,
              maxWidth: "480px",
            }}
          >
            Tìm kiếm, đặt sân cầu lông gần bạn chỉ trong vài giây. Hơn{" "}
            <strong style={{ color: "#00897B" }}>500+ sân</strong> trên toàn
            quốc đang chờ bạn khám phá.
          </p>

          <div className="flex flex-wrap gap-4">
            <button
              onClick={() => {
                if (!useAuthStore.getState().accessToken) {
                  useAuthStore.getState().setLoginPromptOpen(true);
                } else {
                  window.location.href = "#";
                }
              }}
              className="flex items-center gap-2 px-8 py-4 rounded-full text-white transition-all duration-300 hover:shadow-xl hover:scale-105"
              style={{
                background: "linear-gradient(135deg, #00C896, #00897B)",
                fontWeight: 700,
                fontSize: "1rem",
              }}
            >
              Đặt sân ngay
              <ArrowRight size={18} />
            </button>
            <button
              className="flex items-center gap-2 px-8 py-4 rounded-full transition-all duration-300 hover:bg-gray-50"
              style={{
                border: "2px solid #e5e7eb",
                color: "#374151",
                fontWeight: 600,
              }}
            >
              <div
                className="w-8 h-8 rounded-full flex items-center justify-center"
                style={{
                  background: "linear-gradient(135deg, #00C896, #00897B)",
                }}
              >
                <Play size={12} fill="white" color="white" />
              </div>
              Xem demo
            </button>
          </div>

          {/* Stats */}
          <div className="flex gap-8 mt-4">
            {[
              { value: "500+", label: "Sân cầu lông" },
              { value: "50K+", label: "Người dùng" },
              { value: "4.9★", label: "Đánh giá" },
            ].map((stat, i) => (
              <div key={i}>
                <p
                  style={{
                    fontSize: "1.6rem",
                    fontWeight: 800,
                    color: "#00897B",
                  }}
                >
                  {stat.value}
                </p>
                <p
                  style={{
                    fontSize: "0.8rem",
                    color: "#9ca3af",
                    fontWeight: 500,
                  }}
                >
                  {stat.label}
                </p>
              </div>
            ))}
          </div>
        </div>

        {/* Right - Hero image */}
        <div className="flex-1 flex justify-center items-end z-10 relative">
          {/* Glow behind image */}
          <div
            className="absolute inset-0 rounded-full blur-3xl opacity-20"
            style={{
              background: "radial-gradient(circle, #00C896, transparent)",
            }}
          ></div>
          <div className="relative">
            {/* Floating card 1 */}
            <div
              className="absolute -top-8 -left-10 bg-white rounded-2xl px-4 py-3 shadow-xl z-20 flex items-center gap-3"
              style={{ border: "1px solid rgba(0,200,150,0.2)" }}
            >
              <div
                className="w-10 h-10 rounded-xl flex items-center justify-center"
                style={{
                  background: "linear-gradient(135deg, #00C896, #00897B)",
                }}
              >
                <span style={{ fontSize: "1.2rem" }}>📅</span>
              </div>
              <div>
                <p
                  style={{
                    fontWeight: 700,
                    fontSize: "0.85rem",
                    color: "#1a1a2e",
                  }}
                >
                  Đặt sân thành công!
                </p>
                <p style={{ fontSize: "0.72rem", color: "#9ca3af" }}>
                  Sân A3 • 18:00 - 19:30
                </p>
              </div>
            </div>

            {/* Floating card 2 */}
            <div
              className="absolute -bottom-4 -right-8 bg-white rounded-2xl px-4 py-3 shadow-xl z-20 flex items-center gap-3"
              style={{ border: "1px solid rgba(0,200,150,0.2)" }}
            >
              <div
                className="w-10 h-10 rounded-xl flex items-center justify-center"
                style={{
                  background: "linear-gradient(135deg, #FFD700, #FFA500)",
                }}
              >
                <span style={{ fontSize: "1.2rem" }}>⭐</span>
              </div>
              <div>
                <p
                  style={{
                    fontWeight: 700,
                    fontSize: "0.85rem",
                    color: "#1a1a2e",
                  }}
                >
                  4.9 / 5 sao
                </p>
                <p style={{ fontSize: "0.72rem", color: "#9ca3af" }}>
                  12,345 đánh giá
                </p>
              </div>
            </div>

            <ImageWithFallback
              src="https://images.unsplash.com/photo-1761286753703-570ed91dd90e?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxiYWRtaW50b24lMjBwbGF5ZXIlMjBhY3Rpb24lMjBzaG90fGVufDF8fHx8MTc3NjcwMTgyOHww&ixlib=rb-4.1.0&q=80&w=1080"
              alt="Badminton player"
              className="w-full max-w-lg rounded-3xl object-cover shadow-2xl"
              style={{ maxHeight: "520px" }}
            />
          </div>
        </div>
      </div>

      {/* Dot indicator */}
      <div className="absolute bottom-8 left-1/2 -translate-x-1/2 flex gap-2">
        {[0, 1, 2].map((i) => (
          <div
            key={i}
            className="rounded-full transition-all"
            style={{
              width: i === 0 ? "24px" : "8px",
              height: "8px",
              background: i === 0 ? "#00897B" : "#b2dfdb",
            }}
          />
        ))}
      </div>
    </section>
  );
}

// Features Section Component
function FeaturesSection() {
  const features = [
    {
      icon: <Search size={24} />,
      title: "Tìm sân nhanh chóng",
      desc: "Tìm kiếm sân cầu lông gần bạn dễ dàng theo vị trí, giá cả, tiện nghi và thời gian phù hợp.",
      color: "#00C896",
      bg: "rgba(0,200,150,0.1)",
    },
    {
      icon: <Calendar size={24} />,
      title: "Đặt sân online 24/7",
      desc: "Đặt sân bất kỳ lúc nào, bất kỳ đâu. Không cần gọi điện, không cần chờ xác nhận lâu.",
      color: "#26D0CE",
      bg: "rgba(38,208,206,0.1)",
    },
    {
      icon: <Clock size={24} />,
      title: "Xác nhận tức thì",
      desc: "Nhận xác nhận đặt sân ngay lập tức qua ứng dụng và SMS, không lo bị nhầm lịch.",
      color: "#00897B",
      bg: "rgba(0,137,123,0.1)",
    },
    {
      icon: <Star size={24} />,
      title: "Đánh giá tin cậy",
      desc: "Xem đánh giá thực từ người chơi, chọn sân chất lượng với chứng nhận từ cộng đồng.",
      color: "#FFB300",
      bg: "rgba(255,179,0,0.1)",
    },
    {
      icon: <Shield size={24} />,
      title: "Thanh toán an toàn",
      desc: "Hỗ trợ nhiều phương thức thanh toán: VNPay, MoMo, ZaloPay, thẻ ngân hàng.",
      color: "#4CAF50",
      bg: "rgba(76,175,80,0.1)",
    },
    {
      icon: <Zap size={24} />,
      title: "Hủy sân linh hoạt",
      desc: "Thay đổi hoặc hủy lịch đặt sân dễ dàng, hoàn tiền nhanh chóng theo chính sách minh bạch.",
      color: "#FF7043",
      bg: "rgba(255,112,67,0.1)",
    },
  ];

  return (
    <section
      className="relative py-24 overflow-hidden"
      style={{ background: "#ffffff" }}
    >
      {/* Background wave top */}
      <div className="absolute top-0 left-0 right-0 h-24 overflow-hidden">
        <svg
          viewBox="0 0 1440 96"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
          preserveAspectRatio="none"
          className="w-full h-full"
        >
          <path
            d="M0 0 C360 96, 720 80, 1080 48 C1260 32, 1380 16, 1440 8 L1440 0 Z"
            fill="#f0fdf9"
          />
        </svg>
      </div>

      <div className="max-w-7xl mx-auto px-6">
        {/* Header */}
        <div className="text-center mb-16">
          <div
            className="inline-flex items-center gap-2 px-4 py-2 rounded-full mb-4"
            style={{
              background: "rgba(0,200,150,0.1)",
              border: "1px solid rgba(0,200,150,0.2)",
            }}
          >
            <span
              style={{ color: "#00897B", fontWeight: 600, fontSize: "0.85rem" }}
            >
              ✨ Tính năng nổi bật
            </span>
          </div>
          <h2
            style={{
              fontSize: "clamp(1.8rem, 3.5vw, 2.8rem)",
              fontWeight: 800,
              color: "#1a1a2e",
              lineHeight: 1.3,
            }}
          >
            Mọi thứ bạn cần để{" "}
            <span
              style={{
                background: "linear-gradient(135deg, #00C896, #00897B)",
                WebkitBackgroundClip: "text",
                WebkitTextFillColor: "transparent",
              }}
            >
              đặt sân hoàn hảo
            </span>
          </h2>
          <p
            style={{
              color: "#6b7280",
              marginTop: "12px",
              fontSize: "1.05rem",
              maxWidth: "520px",
              margin: "12px auto 0",
            }}
          >
            SmashBook cung cấp đầy đủ tính năng giúp việc đặt sân trở nên đơn
            giản và tiện lợi hơn bao giờ hết.
          </p>
        </div>

        {/* Features grid */}
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feat, i) => (
            <div
              key={i}
              className="group p-6 rounded-2xl transition-all duration-300 hover:shadow-xl hover:-translate-y-1 cursor-pointer"
              style={{
                background: "#fafafa",
                border: "1px solid rgba(0,0,0,0.05)",
              }}
            >
              <div
                className="w-12 h-12 rounded-xl flex items-center justify-center mb-4 transition-all group-hover:scale-110"
                style={{ background: feat.bg, color: feat.color }}
              >
                {feat.icon}
              </div>
              <h3
                style={{
                  fontWeight: 700,
                  fontSize: "1.1rem",
                  color: "#1a1a2e",
                  marginBottom: "8px",
                }}
              >
                {feat.title}
              </h3>
              <p
                style={{
                  color: "#6b7280",
                  lineHeight: 1.7,
                  fontSize: "0.9rem",
                }}
              >
                {feat.desc}
              </p>
            </div>
          ))}
        </div>
      </div>
    </section>
  );
}

// Courts Section Component
function CourtsSection() {
  return (
    <section className="py-24 bg-white">
      <div className="max-w-7xl mx-auto px-6">
        {/* Header */}
        <div className="flex flex-col md:flex-row md:items-end md:justify-between gap-4 mb-12">
          <div>
            <div
              className="inline-flex items-center gap-2 px-4 py-2 rounded-full mb-4"
              style={{
                background: "rgba(0,200,150,0.1)",
                border: "1px solid rgba(0,200,150,0.2)",
              }}
            >
              <span
                style={{
                  color: "#00897B",
                  fontWeight: 600,
                  fontSize: "0.85rem",
                }}
              >
                📍 Sân nổi bật
              </span>
            </div>
            <h2
              style={{
                fontSize: "clamp(1.8rem, 3.5vw, 2.8rem)",
                fontWeight: 800,
                color: "#1a1a2e",
                lineHeight: 1.3,
              }}
            >
              Sân cầu lông{" "}
              <span
                style={{
                  background: "linear-gradient(135deg, #00C896, #00897B)",
                  WebkitBackgroundClip: "text",
                  WebkitTextFillColor: "transparent",
                }}
              >
                được yêu thích nhất
              </span>
            </h2>
          </div>
          <button
            className="text-sm px-6 py-3 rounded-full transition-all hover:shadow-md"
            style={{
              border: "2px solid #00C896",
              color: "#00897B",
              fontWeight: 600,
            }}
          >
            Xem tất cả sân →
          </button>
        </div>

        {/* Courts grid */}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
          {courts.map((court, i) => (
            <div
              key={i}
              className="group rounded-2xl overflow-hidden transition-all duration-300 hover:shadow-2xl hover:-translate-y-2 cursor-pointer"
              style={{ border: "1px solid rgba(0,0,0,0.06)" }}
            >
              {/* Image */}
              <div
                className="relative overflow-hidden"
                style={{ height: "200px" }}
              >
                <ImageWithFallback
                  src={court.img}
                  alt={court.name}
                  className="w-full h-full object-cover transition-transform duration-500 group-hover:scale-110"
                />
                <div
                  className="absolute inset-0"
                  style={{
                    background:
                      "linear-gradient(to bottom, transparent 50%, rgba(0,0,0,0.4))",
                  }}
                />
                <span
                  className="absolute top-3 left-3 px-3 py-1 rounded-full text-white text-xs"
                  style={{ background: court.tagColor, fontWeight: 700 }}
                >
                  {court.tag}
                </span>
              </div>

              {/* Info */}
              <div className="p-5">
                <h3
                  style={{
                    fontWeight: 700,
                    fontSize: "1.05rem",
                    color: "#1a1a2e",
                    marginBottom: "6px",
                  }}
                >
                  {court.name}
                </h3>

                <div
                  className="flex items-center gap-1 mb-2"
                  style={{ color: "#9ca3af", fontSize: "0.85rem" }}
                >
                  <MapPin size={13} />
                  <span>{court.location}</span>
                </div>

                <div className="flex items-center justify-between mb-4">
                  <div className="flex items-center gap-1">
                    <Star size={14} fill="#FFB300" color="#FFB300" />
                    <span
                      style={{
                        fontWeight: 700,
                        color: "#1a1a2e",
                        fontSize: "0.9rem",
                      }}
                    >
                      {court.rating}
                    </span>
                    <span style={{ color: "#9ca3af", fontSize: "0.8rem" }}>
                      ({court.reviews})
                    </span>
                  </div>
                  <div
                    className="flex items-center gap-1"
                    style={{ color: "#00897B", fontSize: "0.8rem" }}
                  >
                    <Clock size={13} />
                    <span style={{ fontWeight: 600 }}>{court.available}</span>
                  </div>
                </div>

                <div className="flex items-center justify-between">
                  <div>
                    <span
                      style={{
                        fontWeight: 800,
                        fontSize: "1.1rem",
                        color: "#00897B",
                      }}
                    >
                      {court.pricePerHour.toLocaleString()}đ/giờ
                    </span>
                  </div>
                  <button
                    onClick={() => {
                      if (!useAuthStore.getState().accessToken) {
                        useAuthStore.getState().setLoginPromptOpen(true);
                      } else {
                        // Handle booking logic
                      }
                    }}
                    className="px-5 py-2 rounded-full text-white text-sm transition-all hover:shadow-lg hover:scale-105"
                    style={{
                      background: "linear-gradient(135deg, #00C896, #00897B)",
                      fontWeight: 600,
                    }}
                  >
                    Đặt ngay
                  </button>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </section>
  );
}

// Testimonials Section Component
function TestimonialsSection() {
  const testimonials = [
    {
      name: "Nguyễn Minh Tuấn",
      role: "Vận động viên nghiệp dư",
      review:
        "Ứng dụng tuyệt vời! Tôi đặt sân chỉ trong 2 phút. Không còn phải gọi điện hỏi trước nữa. Rất tiện lợi cho người bận rộn như tôi.",
      rating: 5,
      avatar: "🏸",
      color: "#00C896",
    },
    {
      name: "Trần Thị Lan Anh",
      role: "Giáo viên thể dục",
      review:
        "SmashBook giúp tôi quản lý lịch dạy cầu lông rất tốt. Tìm được sân chất lượng cao với giá hợp lý. Tôi giới thiệu cho tất cả học viên.",
      rating: 5,
      avatar: "🎯",
      color: "#26D0CE",
    },
    {
      name: "Lê Quang Hùng",
      role: "Dân văn phòng yêu thể thao",
      review:
        "Đặt sân vào buổi tối rất dễ dàng. Tính năng nhắc lịch rất hay, không bao giờ bị quên lịch chơi nữa. 5 sao xứng đáng!",
      rating: 5,
      avatar: "💪",
      color: "#00897B",
    },
  ];

  return (
    <section className="py-24 bg-white">
      <div className="max-w-7xl mx-auto px-6">
        {/* Header */}
        <div className="text-center mb-16">
          <div
            className="inline-flex items-center gap-2 px-4 py-2 rounded-full mb-4"
            style={{
              background: "rgba(0,200,150,0.1)",
              border: "1px solid rgba(0,200,150,0.2)",
            }}
          >
            <span
              style={{ color: "#00897B", fontWeight: 600, fontSize: "0.85rem" }}
            >
              💬 Khách hàng nói gì
            </span>
          </div>
          <h2
            style={{
              fontSize: "clamp(1.8rem, 3.5vw, 2.8rem)",
              fontWeight: 800,
              color: "#1a1a2e",
              lineHeight: 1.3,
            }}
          >
            Được{" "}
            <span
              style={{
                background: "linear-gradient(135deg, #00C896, #00897B)",
                WebkitBackgroundClip: "text",
                WebkitTextFillColor: "transparent",
              }}
            >
              50,000+ người dùng
            </span>{" "}
            tin tưởng
          </h2>
        </div>

        {/* Cards */}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-12">
          {testimonials.map((t, i) => (
            <div
              key={i}
              className="p-6 rounded-2xl transition-all duration-300 hover:shadow-xl hover:-translate-y-1"
              style={{
                background: "#fafafa",
                border: "1px solid rgba(0,0,0,0.05)",
              }}
            >
              {/* Stars */}
              <div className="flex gap-1 mb-4">
                {Array.from({ length: t.rating }).map((_, j) => (
                  <Star key={j} size={16} fill="#FFB300" color="#FFB300" />
                ))}
              </div>

              <p
                style={{
                  color: "#374151",
                  lineHeight: 1.8,
                  fontSize: "0.95rem",
                  marginBottom: "20px",
                }}
              >
                "{t.review}"
              </p>

              <div className="flex items-center gap-3">
                <div
                  className="w-12 h-12 rounded-xl flex items-center justify-center text-xl"
                  style={{ background: `${t.color}18` }}
                >
                  {t.avatar}
                </div>
                <div>
                  <p
                    style={{
                      fontWeight: 700,
                      color: "#1a1a2e",
                      fontSize: "0.9rem",
                    }}
                  >
                    {t.name}
                  </p>
                  <p style={{ color: "#9ca3af", fontSize: "0.78rem" }}>
                    {t.role}
                  </p>
                </div>
              </div>
            </div>
          ))}
        </div>

        {/* Overall rating banner */}
        <div
          className="rounded-2xl p-8 flex flex-col md:flex-row items-center justify-between gap-6"
          style={{
            background: "linear-gradient(135deg, #f0fdf9, #e6f7f2)",
            border: "1px solid rgba(0,200,150,0.2)",
          }}
        >
          <div className="text-center md:text-left">
            <p
              style={{
                fontSize: "3.5rem",
                fontWeight: 900,
                color: "#00897B",
                lineHeight: 1,
              }}
            >
              4.9
            </p>
            <div className="flex gap-1 justify-center md:justify-start mt-1">
              {Array.from({ length: 5 }).map((_, i) => (
                <Star key={i} size={18} fill="#FFB300" color="#FFB300" />
              ))}
            </div>
            <p
              style={{ color: "#6b7280", marginTop: "4px", fontSize: "0.9rem" }}
            >
              Điểm trung bình toàn quốc
            </p>
          </div>

          <div className="flex gap-12 text-center">
            {[
              { val: "50K+", label: "Người dùng" },
              { val: "12K+", label: "Đánh giá" },
              { val: "98%", label: "Hài lòng" },
            ].map((s, i) => (
              <div key={i}>
                <p
                  style={{
                    fontSize: "1.8rem",
                    fontWeight: 800,
                    color: "#00897B",
                  }}
                >
                  {s.val}
                </p>
                <p style={{ color: "#6b7280", fontSize: "0.85rem" }}>
                  {s.label}
                </p>
              </div>
            ))}
          </div>

          <button
            className="px-8 py-3 rounded-full text-white transition-all hover:shadow-lg hover:scale-105"
            style={{
              background: "linear-gradient(135deg, #00C896, #00897B)",
              fontWeight: 700,
            }}
          >
            Viết đánh giá
          </button>
        </div>
      </div>
    </section>
  );
}

// How It Works Component
function HowItWorks() {
  const steps = [
    {
      step: "01",
      title: "Tải ứng dụng",
      desc: "Tải SmashBook miễn phí trên App Store hoặc Google Play. Đăng ký tài khoản trong 30 giây.",
      icon: "📱",
    },
    {
      step: "02",
      title: "Tìm sân phù hợp",
      desc: "Tìm kiếm sân cầu lông theo vị trí, thời gian, giá cả và đọc đánh giá từ người chơi.",
      icon: "🔍",
    },
    {
      step: "03",
      title: "Đặt & Thanh toán",
      desc: "Chọn khung giờ, xác nhận đặt sân và thanh toán an toàn qua nhiều phương thức.",
      icon: "💳",
    },
    {
      step: "04",
      title: "Ra sân thi đấu!",
      desc: "Đến sân và trình mã QR xác nhận. Tận hưởng trận đấu cầu lông tuyệt vời!",
      icon: "🏸",
    },
  ];

  return (
    <section
      className="relative py-24 overflow-hidden"
      style={{ background: "linear-gradient(135deg, #f0fdf9, #e6f7f2)" }}
    >
      {/* Decorative blobs */}
      <div
        className="absolute top-0 right-0 w-80 h-80 rounded-full opacity-20 blur-3xl"
        style={{ background: "radial-gradient(circle, #00C896, transparent)" }}
      />
      <div
        className="absolute bottom-0 left-0 w-64 h-64 rounded-full opacity-15 blur-3xl"
        style={{ background: "radial-gradient(circle, #26D0CE, transparent)" }}
      />

      <div className="relative max-w-7xl mx-auto px-6">
        {/* Header */}
        <div className="text-center mb-16">
          <div
            className="inline-flex items-center gap-2 px-4 py-2 rounded-full mb-4"
            style={{
              background: "rgba(0,200,150,0.15)",
              border: "1px solid rgba(0,200,150,0.3)",
            }}
          >
            <span
              style={{ color: "#00897B", fontWeight: 600, fontSize: "0.85rem" }}
            >
              🚀 Bắt đầu dễ dàng
            </span>
          </div>
          <h2
            style={{
              fontSize: "clamp(1.8rem, 3.5vw, 2.8rem)",
              fontWeight: 800,
              color: "#1a1a2e",
              lineHeight: 1.3,
            }}
          >
            Chỉ{" "}
            <span
              style={{
                background: "linear-gradient(135deg, #00C896, #00897B)",
                WebkitBackgroundClip: "text",
                WebkitTextFillColor: "transparent",
              }}
            >
              4 bước đơn giản
            </span>{" "}
            để đặt sân
          </h2>
          <p
            style={{ color: "#6b7280", marginTop: "12px", fontSize: "1.05rem" }}
          >
            Quy trình đặt sân nhanh gọn, tiện lợi — không phức tạp, không mất
            thời gian.
          </p>
        </div>

        {/* Steps */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6 relative">
          {/* Connector line */}
          <div
            className="hidden lg:block absolute top-10 left-1/4 right-1/4"
            style={{
              height: "2px",
              background: "linear-gradient(90deg, #00C896, #26D0CE)",
              top: "40px",
              left: "calc(12.5% + 24px)",
              right: "calc(12.5% + 24px)",
              zIndex: 0,
            }}
          />

          {steps.map((s, i) => (
            <div
              key={i}
              className="relative z-10 flex flex-col items-center text-center"
            >
              {/* Icon circle */}
              <div
                className="w-20 h-20 rounded-2xl flex items-center justify-center mb-5 shadow-lg"
                style={{
                  background: "linear-gradient(135deg, #00C896, #00897B)",
                  fontSize: "2rem",
                }}
              >
                {s.icon}
              </div>

              {/* Step number */}
              <div
                className="absolute -top-2 -right-2 lg:static lg:hidden w-7 h-7 rounded-full flex items-center justify-center text-white"
                style={{
                  background: "#00897B",
                  fontSize: "0.75rem",
                  fontWeight: 700,
                }}
              >
                {s.step}
              </div>

              <span
                className="text-xs font-bold mb-2 hidden lg:block"
                style={{ color: "#00C896", letterSpacing: "2px" }}
              >
                BƯỚC {s.step}
              </span>
              <h3
                style={{
                  fontWeight: 700,
                  fontSize: "1.1rem",
                  color: "#1a1a2e",
                  marginBottom: "10px",
                }}
              >
                {s.title}
              </h3>
              <p
                style={{
                  color: "#6b7280",
                  lineHeight: 1.7,
                  fontSize: "0.9rem",
                }}
              >
                {s.desc}
              </p>
            </div>
          ))}
        </div>
      </div>
    </section>
  );
}

// App Mockup Component
function AppMockup() {
  return (
    <section
      className="relative py-24 overflow-hidden"
      style={{
        background:
          "linear-gradient(135deg, #004D40 0%, #00695C 40%, #00897B 100%)",
      }}
    >
      {/* Decorative wave */}
      <svg
        className="absolute top-0 left-0 right-0 w-full"
        viewBox="0 0 1440 80"
        fill="none"
        preserveAspectRatio="none"
        style={{ height: "80px" }}
      >
        <path
          d="M0 80 C360 0, 720 40, 1080 10 C1260 -5, 1380 20, 1440 0 L1440 80 Z"
          fill="white"
        />
      </svg>
      <svg
        className="absolute bottom-0 left-0 right-0 w-full"
        viewBox="0 0 1440 80"
        fill="none"
        preserveAspectRatio="none"
        style={{ height: "80px" }}
      >
        <path
          d="M0 0 C360 80, 720 40, 1080 70 C1260 85, 1380 60, 1440 80 L1440 0 Z"
          fill="white"
        />
      </svg>

      {/* Blob decorations */}
      <div
        className="absolute top-20 left-10 w-64 h-64 rounded-full opacity-10"
        style={{ background: "#00C896", filter: "blur(60px)" }}
      />
      <div
        className="absolute bottom-20 right-10 w-80 h-80 rounded-full opacity-10"
        style={{ background: "#26D0CE", filter: "blur(80px)" }}
      />

      <div className="relative max-w-7xl mx-auto px-6 flex flex-col lg:flex-row items-center gap-16">
        {/* Left: Text */}
        <div className="flex-1 text-white">
          <div
            className="inline-flex items-center gap-2 px-4 py-2 rounded-full mb-6"
            style={{
              background: "rgba(255,255,255,0.15)",
              border: "1px solid rgba(255,255,255,0.25)",
            }}
          >
            <span style={{ fontWeight: 600, fontSize: "0.85rem" }}>
              📲 Ứng dụng di động
            </span>
          </div>

          <h2
            style={{
              fontSize: "clamp(1.8rem, 3.5vw, 2.8rem)",
              fontWeight: 800,
              lineHeight: 1.3,
              marginBottom: "16px",
            }}
          >
            Đặt sân mọi lúc, mọi nơi
            <br />
            <span style={{ color: "#80DEEA" }}>ngay trên điện thoại!</span>
          </h2>

          <p
            style={{
              color: "rgba(255,255,255,0.8)",
              lineHeight: 1.8,
              fontSize: "1.05rem",
              maxWidth: "440px",
              marginBottom: "32px",
            }}
          >
            Ứng dụng SmashBook giúp bạn đặt sân cầu lông siêu nhanh, quản lý
            lịch chơi và kết nối với cộng đồng cầu lông trên toàn quốc.
          </p>

          <ul className="flex flex-col gap-4 mb-10">
            {[
              "Giao diện trực quan, dễ sử dụng",
              "Thông báo nhắc lịch chơi tự động",
              "Lưu sân yêu thích, đặt lại 1 chạm",
              "Ví điện tử tích hợp, nạp tiền nhanh",
            ].map((item, i) => (
              <li key={i} className="flex items-center gap-3">
                <div
                  className="w-6 h-6 rounded-full flex items-center justify-center shrink-0"
                  style={{ background: "#00C896" }}
                >
                  <svg width="12" height="12" viewBox="0 0 12 12" fill="none">
                    <path
                      d="M2 6L5 9L10 3"
                      stroke="white"
                      strokeWidth="2"
                      strokeLinecap="round"
                      strokeLinejoin="round"
                    />
                  </svg>
                </div>
                <span
                  style={{ color: "rgba(255,255,255,0.9)", fontWeight: 500 }}
                >
                  {item}
                </span>
              </li>
            ))}
          </ul>

          {/* Store buttons */}
          <div className="flex flex-wrap gap-4">
            <button
              className="flex items-center gap-3 px-6 py-3 rounded-2xl transition-all hover:scale-105"
              style={{
                background: "rgba(255,255,255,0.15)",
                border: "1px solid rgba(255,255,255,0.3)",
                backdropFilter: "blur(10px)",
              }}
            >
              <span style={{ fontSize: "1.8rem" }}>🍎</span>
              <div className="text-left">
                <p
                  style={{ fontSize: "0.7rem", color: "rgba(255,255,255,0.7)" }}
                >
                  Tải về trên
                </p>
                <p style={{ fontWeight: 700, color: "white" }}>App Store</p>
              </div>
            </button>
            <button
              className="flex items-center gap-3 px-6 py-3 rounded-2xl transition-all hover:scale-105"
              style={{
                background: "rgba(255,255,255,0.15)",
                border: "1px solid rgba(255,255,255,0.3)",
                backdropFilter: "blur(10px)",
              }}
            >
              <span style={{ fontSize: "1.8rem" }}>🤖</span>
              <div className="text-left">
                <p
                  style={{ fontSize: "0.7rem", color: "rgba(255,255,255,0.7)" }}
                >
                  Tải về trên
                </p>
                <p style={{ fontWeight: 700, color: "white" }}>Google Play</p>
              </div>
            </button>
          </div>
        </div>

        {/* Right: Phone mockup */}
        <div className="flex-1 flex justify-center relative">
          {/* Glow */}
          <div
            className="absolute inset-0 rounded-full"
            style={{
              background:
                "radial-gradient(circle at center, rgba(0,200,150,0.3), transparent 70%)",
              filter: "blur(30px)",
            }}
          />

          {/* Phone frame */}
          <div className="relative z-10" style={{ width: "280px" }}>
            <div
              className="relative rounded-[3rem] overflow-hidden shadow-2xl"
              style={{
                border: "10px solid rgba(255,255,255,0.2)",
                background: "#fff",
              }}
            >
              {/* Status bar */}
              <div
                style={{
                  background: "#00897B",
                  padding: "12px 20px",
                  display: "flex",
                  justifyContent: "space-between",
                  alignItems: "center",
                }}
              >
                <span
                  style={{
                    color: "white",
                    fontSize: "0.75rem",
                    fontWeight: 600,
                  }}
                >
                  9:41
                </span>
                <div className="flex gap-1">
                  <div className="w-1 h-3 rounded-sm bg-white/80" />
                  <div className="w-1 h-3 rounded-sm bg-white/60" />
                  <div className="w-1 h-3 rounded-sm bg-white/40" />
                </div>
              </div>

              {/* App UI */}
              <div
                style={{
                  background: "#f8fffe",
                  minHeight: "480px",
                  padding: "16px",
                  position: "relative",
                }}
              >
                {/* App header */}
                <div className="flex items-center justify-between mb-4">
                  <div>
                    <p style={{ fontSize: "0.7rem", color: "#9ca3af" }}>
                      Xin chào, Minh Tuấn 👋
                    </p>
                    <p
                      style={{
                        fontWeight: 700,
                        fontSize: "0.95rem",
                        color: "#1a1a2e",
                      }}
                    >
                      Đặt sân hôm nay?
                    </p>
                  </div>
                  <div
                    className="w-8 h-8 rounded-full overflow-hidden"
                    style={{ border: "2px solid #00C896" }}
                  >
                    <ImageWithFallback
                      src="https://images.unsplash.com/photo-1659081463572-4c5903a309e6?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&w=100"
                      alt="avatar"
                      className="w-full h-full object-cover"
                    />
                  </div>
                </div>

                {/* Search bar */}
                <div
                  className="flex items-center gap-2 px-3 py-2 rounded-xl mb-4"
                  style={{ background: "white", border: "1px solid #e5e7eb" }}
                >
                  <svg
                    width="14"
                    height="14"
                    viewBox="0 0 24 24"
                    fill="none"
                    stroke="#9ca3af"
                    strokeWidth="2"
                  >
                    <circle cx="11" cy="11" r="8" />
                    <path d="M21 21l-4.35-4.35" />
                  </svg>
                  <span style={{ color: "#9ca3af", fontSize: "0.75rem" }}>
                    Tìm sân gần bạn...
                  </span>
                </div>

                {/* Categories */}
                <div className="flex gap-2 mb-4">
                  {["Tất cả", "Gần tôi", "Giá tốt"].map((cat, i) => (
                    <span
                      key={i}
                      className="px-3 py-1 rounded-full text-xs"
                      style={{
                        background:
                          i === 0
                            ? "linear-gradient(135deg, #00C896, #00897B)"
                            : "#f3f4f6",
                        color: i === 0 ? "white" : "#6b7280",
                        fontWeight: 600,
                      }}
                    >
                      {cat}
                    </span>
                  ))}
                </div>

                {/* Court cards */}
                {[
                  {
                    name: "Sân Tân Bình",
                    price: "80K/giờ",
                    rating: "4.9",
                    color: "#00C896",
                  },
                  {
                    name: "Sân Phú Mỹ Hưng",
                    price: "100K/giờ",
                    rating: "4.8",
                    color: "#26D0CE",
                  },
                ].map((court, i) => (
                  <div
                    key={i}
                    className="mb-3 p-3 rounded-xl"
                    style={{
                      background: "white",
                      border: "1px solid rgba(0,0,0,0.06)",
                    }}
                  >
                    <div className="flex items-center gap-3">
                      <div
                        className="w-12 h-12 rounded-xl flex items-center justify-center"
                        style={{
                          background: `${court.color}20`,
                          fontSize: "1.4rem",
                        }}
                      >
                        🏸
                      </div>
                      <div className="flex-1">
                        <p
                          style={{
                            fontWeight: 700,
                            fontSize: "0.8rem",
                            color: "#1a1a2e",
                          }}
                        >
                          {court.name}
                        </p>
                        <p
                          style={{
                            fontSize: "0.7rem",
                            color: court.color,
                            fontWeight: 600,
                          }}
                        >
                          {court.price}
                        </p>
                      </div>
                      <div className="text-center">
                        <p
                          style={{
                            fontSize: "0.7rem",
                            fontWeight: 700,
                            color: "#1a1a2e",
                          }}
                        >
                          ⭐ {court.rating}
                        </p>
                      </div>
                    </div>
                  </div>
                ))}

                {/* Bottom nav */}
                <div
                  className="absolute bottom-0 left-0 right-0 flex justify-around py-3 px-4"
                  style={{
                    background: "white",
                    borderTop: "1px solid #f3f4f6",
                  }}
                >
                  {["🏠", "🔍", "📅", "👤"].map((icon, i) => (
                    <div key={i} className="flex flex-col items-center">
                      <span style={{ fontSize: "1.1rem" }}>{icon}</span>
                      {i === 0 && (
                        <div
                          className="w-1 h-1 rounded-full mt-1"
                          style={{ background: "#00C896" }}
                        />
                      )}
                    </div>
                  ))}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}

// CTA Section Component
function CTASection() {
  return (
    <section className="relative py-24 overflow-hidden">
      {/* Background */}
      <div
        className="absolute inset-0"
        style={{
          background:
            "linear-gradient(135deg, #00C896 0%, #00897B 50%, #004D40 100%)",
        }}
      />

      {/* Wave decorations */}
      <svg
        className="absolute top-0 left-0 right-0 w-full"
        viewBox="0 0 1440 80"
        fill="none"
        preserveAspectRatio="none"
        style={{ height: "80px" }}
      >
        <path
          d="M0 80 C360 0, 720 40, 1080 20 C1260 8, 1380 30, 1440 0 L1440 80 Z"
          fill="white"
        />
      </svg>

      {/* Floating orbs */}
      <div
        className="absolute top-10 left-10 w-40 h-40 rounded-full"
        style={{ background: "rgba(255,255,255,0.05)", filter: "blur(20px)" }}
      />
      <div
        className="absolute bottom-10 right-20 w-64 h-64 rounded-full"
        style={{ background: "rgba(0,0,0,0.1)", filter: "blur(40px)" }}
      />

      {/* Shuttlecock pattern */}
      {[
        "top-6 right-1/4",
        "bottom-8 left-1/3",
        "top-1/2 left-10",
        "bottom-20 right-10",
      ].map((pos, i) => (
        <div
          key={i}
          className={`absolute ${pos} text-4xl opacity-10`}
          style={{ transform: `rotate(${i * 45}deg)` }}
        >
          🏸
        </div>
      ))}

      <div className="relative max-w-4xl mx-auto px-6 text-center text-white">
        <div
          className="inline-flex items-center gap-2 px-4 py-2 rounded-full mb-6"
          style={{
            background: "rgba(255,255,255,0.15)",
            border: "1px solid rgba(255,255,255,0.25)",
          }}
        >
          <span className="animate-bounce">🎉</span>
          <span style={{ fontWeight: 600, fontSize: "0.85rem" }}>
            Ưu đãi đặc biệt — Miễn phí 1 tháng đầu!
          </span>
        </div>

        <h2
          style={{
            fontSize: "clamp(2rem, 4vw, 3.2rem)",
            fontWeight: 900,
            lineHeight: 1.2,
            marginBottom: "16px",
          }}
        >
          Sẵn sàng chinh phục
          <br />
          <span style={{ color: "#80DEEA" }}>sân cầu lông chưa? 🏸</span>
        </h2>

        <p
          style={{
            color: "rgba(255,255,255,0.85)",
            fontSize: "1.1rem",
            lineHeight: 1.8,
            maxWidth: "540px",
            margin: "0 auto 40px",
          }}
        >
          Tham gia ngay hôm nay và nhận ngay <strong>100.000đ</strong> vào ví
          SmashBook cho lần đặt sân đầu tiên của bạn!
        </p>

        <div className="flex flex-col sm:flex-row gap-4 justify-center">
          <button
            className="px-10 py-4 rounded-full transition-all duration-300 hover:shadow-2xl hover:scale-105"
            style={{
              background: "white",
              color: "#00897B",
              fontWeight: 800,
              fontSize: "1.05rem",
            }}
          >
            🚀 Đăng ký miễn phí
          </button>
          <button
            className="px-10 py-4 rounded-full transition-all duration-300 hover:scale-105"
            style={{
              background: "rgba(255,255,255,0.15)",
              border: "2px solid rgba(255,255,255,0.5)",
              color: "white",
              fontWeight: 700,
              fontSize: "1.05rem",
            }}
          >
            Xem tất cả sân
          </button>
        </div>

        <p
          style={{
            color: "rgba(255,255,255,0.6)",
            fontSize: "0.82rem",
            marginTop: "20px",
          }}
        >
          Không cần thẻ tín dụng • Hủy bất cứ lúc nào • Hỗ trợ 24/7
        </p>
      </div>
    </section>
  );
}

// Export individual components
export {
  Navbar,
  HeroSection,
  FeaturesSection,
  CourtsSection,
  TestimonialsSection,
  HowItWorks,
  AppMockup,
  CTASection,
};

// Main HomePage Component
export const HomePage = () => {
  return (
    <div className="min-h-screen">
      <HeroSection />
      <FeaturesSection />
      <CourtsSection />
      <TestimonialsSection />
      <HowItWorks />
      <AppMockup />
      <CTASection />
    </div>
  );
};
