import { ArrowRight, Play } from "lucide-react";
import { useNavigate } from "react-router-dom";
import { useAuthStore } from "@/features/auth/store";
import { ImageWithFallback } from "@/shared/components/common";

export function HeroSection() {
  const navigate = useNavigate();
  const { setLoginPromptOpen, accessToken } = useAuthStore();

  return (
    <section
      className="relative min-h-screen overflow-hidden"
      style={{ background: "linear-gradient(135deg, #f0fdf9 0%, #ffffff 50%)" }}
    >
      {/* Wave blobs - top right */}
      {/* ... SVG content ... */}
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
      {/* ... SVG content ... */}
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
              <span className="text-gradient">Cầu lông</span>
              <br />
              chưa bao giờ <span style={{ color: "#1a1a2e" }}>dễ dàng hơn!</span>
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
                if (!accessToken) {
                  setLoginPromptOpen(true);
                } else {
                  navigate("/courts");
                }
              }}
              className="flex items-center gap-2 px-8 py-4 rounded-full text-white hover-lift bg-primary-gradient"
              style={{
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
                className="w-10 h-10 rounded-xl flex items-center justify-center bg-primary-gradient"
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
