import React from "react";
import { SectionHeader } from "./SectionHeader";

export function HowItWorks() {
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

      <div className="relative container-landing">
        <SectionHeader
          badge="🚀 Bắt đầu dễ dàng"
          title={
            <>
              Chỉ <span className="text-gradient">4 bước đơn giản</span> để đặt sân
            </>
          }
          subtitle="Quy trình đặt sân nhanh gọn, tiện lợi — không phức tạp, không mất thời gian."
        />

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
                className="w-20 h-20 rounded-2xl flex items-center justify-center mb-5 shadow-lg bg-primary-gradient"
                style={{ fontSize: "2rem" }}
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
