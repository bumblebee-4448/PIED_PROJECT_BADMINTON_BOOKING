import React from "react";
import { ImageWithFallback } from "@/shared/components/common";

export function AppMockup() {
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

      <div className="relative container-landing flex flex-col lg:flex-row items-center gap-16">
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
