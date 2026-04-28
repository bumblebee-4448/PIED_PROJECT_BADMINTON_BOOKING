import React from "react";

export function CTASection() {
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
