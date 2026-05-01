import { useState } from "react";
import { useNavigate } from "react-router";
import {
  TrendingUp, Calendar, Star,

  Clock, ChevronRight, AlertCircle
} from "lucide-react";
import {
  AreaChart, Area, XAxis, YAxis,
  Tooltip, ResponsiveContainer, CartesianGrid
} from "recharts";
import {
  OWNER_COURTS, REVENUE_MONTHLY, REVENUE_WEEKLY,
  PEAK_HOURS, OWNER_REVIEWS
} from "../data/mockData";
import { StatCard } from "../components/StatCard";
import { Button } from "@/shared/components/ui/button";

const PERIOD_OPTS = ["Tuần", "Tháng"];

const CustomTooltip = ({ active, payload, label }: any) => {
  if (!active || !payload?.length) return null;
  return (
    <div className="bg-white rounded-xl px-3 py-2 shadow-lg" style={{ border: "1px solid #e5e7eb" }}>
      <p style={{ fontSize: "0.75rem", fontWeight: 700, color: "#1a1a2e", marginBottom: "4px" }}>{label}</p>
      {payload.map((p: any) => (
        <p key={p.name} style={{ fontSize: "0.72rem", color: p.color }}>
          {p.name}: <strong>{typeof p.value === "number" && p.value > 1000 ? (p.value / 1000000).toFixed(1) + "M" : p.value}</strong>
        </p>
      ))}
    </div>
  );
};

export function OwnerDashboard() {
  const navigate = useNavigate();
  const [period, setPeriod] = useState("Tháng");
  const revenueData = period === "Tuần" ? REVENUE_WEEKLY : REVENUE_MONTHLY;

  const totalRevenue = OWNER_COURTS.reduce((s, c) => s + c.totalRevenue, 0);
  const totalBookings = OWNER_COURTS.reduce((s, c) => s + c.totalBookings, 0);
  const avgRating = (OWNER_COURTS.reduce((s, c) => s + c.rating, 0) / OWNER_COURTS.length).toFixed(1);
  const todayBookings = OWNER_COURTS.flatMap(c => c.subCourts.flatMap(sc => sc.todayBookings.filter(b => b.status === "banked" || b.status === "booked")));

  return (
    <div className="p-4 sm:p-6 max-w-7xl mx-auto">
      {/* Header */}
      <div className="mb-6">
        <h1 style={{ fontWeight: 800, fontSize: "1.4rem", color: "#1a1a2e" }}>Dashboard 📊</h1>
        <p style={{ color: "#9ca3af", fontSize: "0.85rem" }}>
          Tổng quan hoạt động • {new Date().toLocaleDateString("vi-VN", { weekday: "long", day: "numeric", month: "long" })}
        </p>
      </div>

      {/* Stat cards */}
      <div className="grid grid-cols-2 lg:grid-cols-4 gap-4 mb-6">
        <StatCard label="Tổng doanh thu" value={`${(totalRevenue / 1000000).toFixed(1)}M đ`} sub="+12% so với tháng trước" trend={true} icon={<TrendingUp size={18} style={{ color: "#00897B" }} />} color="#00897B" />
        <StatCard label="Tổng lượt đặt" value={totalBookings} sub="+8% so với tuần trước" trend={true} icon={<Calendar size={18} style={{ color: "#6366F1" }} />} color="#6366F1" />
        <StatCard label="Lượt đặt hôm nay" value={todayBookings.length} sub="Đang diễn ra" icon={<Clock size={18} style={{ color: "#F59E0B" }} />} color="#F59E0B" />
        <StatCard label="Đánh giá TB" value={`${avgRating} ⭐`} sub={`Từ ${OWNER_REVIEWS.length} đánh giá`} icon={<Star size={18} style={{ color: "#EF4444" }} />} color="#EF4444" />
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-4 mb-6">
        {/* Revenue chart */}
        <div className="lg:col-span-2 bg-white rounded-2xl p-5" style={{ border: "1px solid rgba(0,0,0,0.06)" }}>
          <div className="flex items-center justify-between mb-4">
            <div>
              <h3 style={{ fontWeight: 700, color: "#1a1a2e", fontSize: "0.95rem" }}>Doanh thu</h3>
              <p style={{ fontSize: "0.75rem", color: "#9ca3af" }}>Theo {period.toLowerCase()}</p>
            </div>
            <div className="flex gap-1 bg-gray-100 p-1 rounded-xl">
              {PERIOD_OPTS.map((p) => (
                <Button key={p} variant="ghost" onClick={() => setPeriod(p)}
                  className="px-3 py-1 rounded-lg text-xs font-semibold transition h-auto hover:bg-transparent"
                  style={{ background: period === p ? "white" : "transparent", color: period === p ? "#00897B" : "#6b7280", boxShadow: period === p ? "0 1px 3px rgba(0,0,0,0.1)" : "none" }}>
                  {p}
                </Button>
              ))}
            </div>
          </div>
          <ResponsiveContainer width="100%" height={220}>
            <AreaChart data={revenueData}>
              <defs>
                <linearGradient id="revGrad" x1="0" y1="0" x2="0" y2="1">
                  <stop offset="5%" stopColor="#00C896" stopOpacity={0.2} />
                  <stop offset="95%" stopColor="#00C896" stopOpacity={0} />
                </linearGradient>
              </defs>
              <CartesianGrid strokeDasharray="3 3" stroke="#f3f4f6" />
              <XAxis dataKey="label" tick={{ fontSize: 11, fill: "#9ca3af" }} axisLine={false} tickLine={false} />
              <YAxis tick={{ fontSize: 11, fill: "#9ca3af" }} axisLine={false} tickLine={false} tickFormatter={(v) => `${v / 1000000}M`} />
              <Tooltip content={<CustomTooltip />} />
              <Area type="monotone" dataKey="revenue" name="Doanh thu" stroke="#00C896" strokeWidth={2.5} fill="url(#revGrad)" />
            </AreaChart>
          </ResponsiveContainer>
        </div>

        {/* Peak hours */}
        <div className="bg-white rounded-2xl p-5" style={{ border: "1px solid rgba(0,0,0,0.06)" }}>
          <h3 style={{ fontWeight: 700, color: "#1a1a2e", fontSize: "0.95rem", marginBottom: "4px" }}>Khung giờ cao điểm 🔥</h3>
          <p style={{ fontSize: "0.72rem", color: "#9ca3af", marginBottom: "14px" }}>Tỷ lệ đặt sân theo giờ</p>
          <div className="flex flex-col gap-2 overflow-y-auto" style={{ maxHeight: "200px" }}>
            {PEAK_HOURS.sort((a, b) => b.bookingRate - a.bookingRate).slice(0, 8).map((h) => (
              <div key={h.time} className="flex items-center gap-2">
                <span style={{ fontSize: "0.72rem", color: "#6b7280", width: "36px", flexShrink: 0 }}>{h.time}</span>
                <div className="flex-1 h-2 bg-gray-100 rounded-full overflow-hidden">
                  <div className="h-full rounded-full transition-all" style={{
                    width: `${h.bookingRate}%`,
                    background: h.bookingRate >= 85 ? "linear-gradient(90deg,#EF4444,#FF6B35)" : h.bookingRate >= 65 ? "linear-gradient(90deg,#F59E0B,#FFB300)" : "linear-gradient(90deg,#00C896,#00897B)"
                  }} />
                </div>
                <span style={{ fontSize: "0.72rem", fontWeight: 700, color: "#1a1a2e", width: "28px", textAlign: "right" }}>{h.bookingRate}%</span>
              </div>
            ))}
          </div>
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-4">
        {/* Court status today */}
        <div className="bg-white rounded-2xl p-5" style={{ border: "1px solid rgba(0,0,0,0.06)" }}>
          <div className="flex items-center justify-between mb-4">
            <h3 style={{ fontWeight: 700, color: "#1a1a2e", fontSize: "0.95rem" }}>Trạng thái sân hôm nay</h3>
            <Button variant="link" onClick={() => navigate("/owner/courts")} style={{ fontSize: "0.75rem", color: "#00897B", fontWeight: 600 }} className="flex items-center gap-1 p-0 h-auto">
              Xem tất cả <ChevronRight size={13} />
            </Button>
          </div>
          <div className="flex flex-col gap-3">
            {OWNER_COURTS.map((court) => {
              const allSlots = court.subCourts.flatMap(sc => sc.todayBookings);
              const booked = allSlots.filter(s => ["booked", "banked", "complete"].includes(s.status)).length;
              const total = allSlots.filter(s => s.status !== "blocked").length;
              const rate = total ? Math.round(booked / total * 100) : 0;
              return (
                <div key={court.id} onClick={() => navigate("/owner/courts")}
                  className="flex items-center gap-3 p-3 rounded-xl cursor-pointer hover:bg-gray-50 transition">
                  <div className="w-2.5 h-2.5 rounded-full flex-shrink-0" style={{ background: rate >= 70 ? "#EF4444" : rate >= 40 ? "#F59E0B" : "#00C896" }} />
                  <div className="flex-1 min-w-0">
                    <p style={{ fontWeight: 600, fontSize: "0.85rem", color: "#1a1a2e" }} className="line-clamp-1">{court.name}</p>
                    <p style={{ fontSize: "0.72rem", color: "#9ca3af" }}>{court.subCourts.length} sân con • {court.district}</p>
                  </div>
                  <div className="text-right flex-shrink-0">
                    <p style={{ fontWeight: 700, fontSize: "0.85rem", color: "#1a1a2e" }}>{rate}%</p>
                    <p style={{ fontSize: "0.68rem", color: "#9ca3af" }}>lấp đầy</p>
                  </div>
                </div>
              );
            })}
          </div>
        </div>

        {/* Latest reviews */}
        <div className="bg-white rounded-2xl p-5" style={{ border: "1px solid rgba(0,0,0,0.06)" }}>
          <div className="flex items-center justify-between mb-4">
            <h3 style={{ fontWeight: 700, color: "#1a1a2e", fontSize: "0.95rem" }}>Đánh giá gần đây ⭐</h3>
            <Button variant="link" onClick={() => navigate("/owner/feedback")} style={{ fontSize: "0.75rem", color: "#00897B", fontWeight: 600 }} className="flex items-center gap-1 p-0 h-auto">
              Xem tất cả <ChevronRight size={13} />
            </Button>
          </div>
          <div className="flex flex-col gap-3">
            {OWNER_REVIEWS.slice(0, 4).map((r) => (
              <div key={r.id} className="flex gap-3">
                <div className="w-8 h-8 rounded-full flex items-center justify-center text-white text-xs font-bold flex-shrink-0"
                  style={{ background: `hsl(${r.avatar.charCodeAt(0) * 40}, 60%, 50%)` }}>
                  {r.avatar}
                </div>
                <div className="flex-1 min-w-0">
                  <div className="flex items-center gap-2 mb-0.5">
                    <span style={{ fontWeight: 600, fontSize: "0.82rem", color: "#1a1a2e" }}>{r.customerName}</span>
                    <div className="flex gap-0.5">
                      {Array.from({ length: r.rating }).map((_, i) => (
                        <span key={i} style={{ fontSize: "0.6rem", color: "#FFB300" }}>★</span>
                      ))}
                    </div>
                  </div>
                  <p style={{ fontSize: "0.75rem", color: "#6b7280" }} className="line-clamp-1">"{r.comment}"</p>
                  <p style={{ fontSize: "0.65rem", color: "#9ca3af" }}>{r.courtName} • {r.date}</p>
                </div>
              </div>
            ))}
          </div>
        </div>
      </div>

      {/* Alert */}
      <div className="mt-4 flex items-start gap-3 p-4 rounded-2xl" style={{ background: "#FFF8E1", border: "1px solid #FDE68A" }}>
        <AlertCircle size={16} style={{ color: "#F59E0B", flexShrink: 0, marginTop: "1px" }} />
        <div>
          <p style={{ fontWeight: 700, fontSize: "0.85rem", color: "#92400E" }}>Sân A4 đang tắt hoạt động</p>
          <p style={{ fontSize: "0.78rem", color: "#78350F" }}>Sân A4 hiện đang ở trạng thái inactive. Bật lại để nhận thêm đơn đặt sân.</p>
        </div>
        <Button onClick={() => navigate("/owner/courts")} className="ml-auto flex-shrink-0 px-3 py-1.5 rounded-lg text-xs font-bold h-auto"
          style={{ background: "#F59E0B", color: "white" }}>
          Xem sân
        </Button>
      </div>
    </div>
  );
}
