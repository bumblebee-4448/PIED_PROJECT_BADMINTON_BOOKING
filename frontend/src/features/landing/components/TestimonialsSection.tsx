import { Star } from "lucide-react";
import { SectionHeader } from "./SectionHeader";

export function TestimonialsSection() {
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
      <div className="container-landing">
        <SectionHeader
          badge="💬 Khách hàng nói gì"
          title={
            <>
              Được <span className="text-gradient">50,000+ người dùng</span> tin tưởng
            </>
          }
        />

        {/* Cards */}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-12">
          {testimonials.map((t, i) => (
            <div
              key={i}
              className="p-6 rounded-2xl hover-lift bg-[#fafafa]"
              style={{ border: "1px solid rgba(0,0,0,0.05)" }}
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
            className="px-8 py-3 rounded-full text-white hover-lift bg-primary-gradient"
            style={{ fontWeight: 700 }}
          >
            Viết đánh giá
          </button>
        </div>
      </div>
    </section>
  );
}
