import { Search, Calendar, Clock, Star, Shield, Zap } from "lucide-react";
import { SectionHeader } from "./SectionHeader";

export function FeaturesSection() {
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
    <section className="relative py-24 overflow-hidden bg-white">
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

      <div className="container-landing">
        <SectionHeader
          badge="✨ Tính năng nổi bật"
          title={
            <>
              Mọi thứ bạn cần để <span className="text-gradient">đặt sân hoàn hảo</span>
            </>
          }
          subtitle="SmashBook cung cấp đầy đủ tính năng giúp việc đặt sân trở nên đơn giản và tiện lợi hơn bao giờ hết."
        />

        {/* Features grid */}
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
          {features.map((feat, i) => (
            <div
              key={i}
              className="group p-6 rounded-2xl transition-all duration-300 hover:shadow-xl hover:-translate-y-1 cursor-pointer bg-[#fafafa]"
              style={{ border: "1px solid rgba(0,0,0,0.05)" }}
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
