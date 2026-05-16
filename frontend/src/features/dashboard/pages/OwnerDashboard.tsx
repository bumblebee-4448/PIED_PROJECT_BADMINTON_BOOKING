import { useState, useMemo } from "react";
import {
  AreaChart,
  Area,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
} from "recharts";
import {
  TrendingUp,
  TrendingDown,
  Minus,
  CalendarCheck,
  DollarSign,
  Users,
  Loader2,
  BarChart3,
} from "lucide-react";
import { 
  format, 
  parseISO, 
  startOfWeek, 
  endOfWeek, 
  eachDayOfInterval, 
  startOfMonth, 
  endOfMonth, 
  isSameDay,
  isSameMonth,
  startOfYear,
  endOfYear,
  eachMonthOfInterval,
  subWeeks,
  subMonths,
  subYears,
} from "date-fns";
import { cn } from "@/lib/utils";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/shared/components/ui/select";
import { useOwnerCourts } from "@/features/owner-courts/hooks/useOwnerCourts";
import { useOwnerCourtBookings, useOwnerDashboardStats } from "../hooks/useOwnerDashboard";
import type { CourtBooking } from "../services/ownerDashboardService";

// ─── Period config ────────────────────────────────────────────────────────────

const PERIODS = [
  { value: "week",    label: "Tuần này" },
  { value: "month",  label: "Tháng này" },
  { value: "quarter",label: "Quý này" },
  { value: "year",   label: "Năm này" },
];

// ─── Helpers ──────────────────────────────────────────────────────────────────

function fmtCurrency(n: number) {
  return new Intl.NumberFormat("vi-VN", { style: "currency", currency: "VND" }).format(n);
}

/**
 * Builds chart data by filling gaps and optionally adding comparison data from previous period
 */
function buildChartData(currentBookings: CourtBooking[], prevBookings: CourtBooking[], period: string) {
  const now = new Date();
  let interval: Date[] = [];
  let formatStr = "dd/MM";

  if (period === "week") {
    interval = eachDayOfInterval({ start: startOfWeek(now, { weekStartsOn: 1 }), end: endOfWeek(now, { weekStartsOn: 1 }) });
  } else if (period === "month") {
    interval = eachDayOfInterval({ start: startOfMonth(now), end: endOfMonth(now) });
  } else if (period === "year") {
    interval = eachMonthOfInterval({ start: startOfYear(now), end: endOfYear(now) });
    formatStr = "MM/yyyy";
  } else {
    // Basic fallback
    if (!currentBookings.length) return [];
    const map = new Map<string, { revenue: number }>();
    for (const b of currentBookings) {
      const d = parseISO(b.createdAt);
      const key = format(d, "dd/MM");
      map.set(key, { revenue: (map.get(key)?.revenue ?? 0) + b.totalPrice });
    }
    return Array.from(map.entries()).sort((a, b) => a[0].localeCompare(b[0])).map(([date, vals]) => ({ date, ...vals }));
  }

  return interval.map((date) => {
    const key = format(date, formatStr);
    
    // Current period value
    const dayBookings = currentBookings.filter(b => {
      const bDate = parseISO(b.createdAt);
      return period === "year" ? isSameMonth(bDate, date) : isSameDay(bDate, date);
    });
    const currentRevenue = dayBookings.reduce((s, b) => s + b.totalPrice, 0);

    // Previous period value (offset calculation)
    let prevDate: Date;
    if (period === "week") prevDate = subWeeks(date, 1);
    else if (period === "month") prevDate = subMonths(date, 1);
    else prevDate = subYears(date, 1);

    const prevDayBookings = prevBookings.filter(b => {
      const bDate = parseISO(b.createdAt);
      return period === "year" ? isSameMonth(bDate, prevDate) : isSameDay(bDate, prevDate);
    });
    const prevRevenue = prevDayBookings.reduce((s, b) => s + b.totalPrice, 0);

    return {
      date: key,
      revenue: currentRevenue,
      prevRevenue: prevRevenue,
      count: dayBookings.length,
    };
  });
}

// ─── Custom Tooltip ───────────────────────────────────────────────────────────

function CustomTooltip({ active, payload, label }: any) {
  if (!active || !payload?.length) return null;
  return (
    <div className="bg-white border border-gray-100 rounded-xl px-4 py-3 shadow-xl text-sm min-w-[180px]">
      <p className="text-gray-400 text-[10px] font-bold uppercase tracking-widest mb-2 border-b border-gray-50 pb-2">{label}</p>
      <div className="space-y-2">
        <div>
          <p className="text-[10px] text-gray-400 font-bold uppercase">Hiện tại</p>
          <p className="font-bold text-base text-emerald-600">
            {fmtCurrency(payload[0]?.value ?? 0)}
          </p>
        </div>
        {payload[1] && (
          <div>
            <p className="text-[10px] text-gray-400 font-bold uppercase">Kỳ trước</p>
            <p className="font-bold text-sm text-gray-400 line-through decoration-gray-300">
              {fmtCurrency(payload[1]?.value ?? 0)}
            </p>
          </div>
        )}
      </div>
    </div>
  );
}

// ─── Stat Card ────────────────────────────────────────────────────────────────

function StatCard({
  label, value, sub, pct, status, icon, color,
}: {
  label: string;
  value: string;
  sub: string;
  pct: number;
  status: string;
  icon: React.ReactNode;
  color: string;
}) {
  const isUp   = status === "Increase";
  const isDown = status === "Decrease";

  return (
    <div className="bg-white rounded-2xl border border-gray-100 p-6 shadow-sm hover:shadow-md transition-all duration-300 group">
      <div className="flex items-center justify-between mb-4">
        <div
          className="w-11 h-11 rounded-xl flex items-center justify-center group-hover:scale-110 transition-transform"
          style={{ background: `${color}10` }}
        >
          {icon}
        </div>
        <div
          className={cn(
            "flex items-center gap-1 text-[11px] font-bold px-2.5 py-1 rounded-full",
            isUp   ? "bg-emerald-50 text-emerald-600" :
            isDown ? "bg-rose-50 text-rose-600" :
                     "bg-gray-50 text-gray-400"
          )}
        >
          {isUp   ? <TrendingUp  size={12} /> :
           isDown ? <TrendingDown size={12} /> :
                    <Minus size={12} />}
          {Math.abs(pct).toFixed(1)}%
        </div>
      </div>

      <div className="space-y-1">
        <p className="text-2xl font-bold text-gray-900 tracking-tight">{value}</p>
        <p className="text-[11px] text-gray-400 font-semibold uppercase tracking-wider">{label}</p>
      </div>

      <div className="mt-4 pt-4 border-t border-gray-100 flex items-center justify-between gap-2">
        <div className="flex flex-col">
          <span className="text-[10px] text-gray-400 font-bold uppercase tracking-tighter">Kỳ trước</span>
          <span className="text-[11px] text-gray-600 font-semibold">{sub.replace("Kỳ trước: ", "")}</span>
        </div>
        {pct !== 0 && (
          <div className={cn(
            "flex flex-col items-end px-2 py-1 rounded-lg",
            isUp ? "bg-emerald-50 text-emerald-600" : isDown ? "bg-rose-50 text-rose-600" : "bg-gray-50 text-gray-500"
          )}>
            <span className="text-[10px] font-black uppercase">{isUp ? "Tăng" : isDown ? "Giảm" : "—"}</span>
            <span className="text-xs font-bold leading-none">{Math.abs(pct).toFixed(1)}%</span>
          </div>
        )}
      </div>
    </div>
  );
}

// ─── Main Page ────────────────────────────────────────────────────────────────

export function OwnerDashboard() {
  const [selectedCourtId, setSelectedCourtId] = useState<string>("");
  const [period, setPeriod]                   = useState<string>("month");

  // Fetch courts list
  const { data: courtsData, isLoading: isCourtsLoading } = useOwnerCourts({
    pageIndex: 1,
    pageSize: 100,
  });

  const courts = courtsData?.items ?? [];
  const effectiveCourtId = selectedCourtId || courts[0]?.courtId || "";
  const periodLabel = PERIODS.find(p => p.value === period)?.label ?? "";

  // Fetch current period bookings
  const { data: currentBookingsData, isLoading: isCurrentLoading } = useOwnerCourtBookings({
    courtId: effectiveCourtId,
    period,
    pageSize: 500,
  });

  // Calculate previous period date
  const now = new Date();
  let prevDateStr = "";
  if (period === "week") prevDateStr = format(subWeeks(now, 1), "yyyy-MM-dd");
  else if (period === "month") prevDateStr = format(subMonths(now, 1), "yyyy-MM-dd");
  else if (period === "year") prevDateStr = format(subYears(now, 1), "yyyy-MM-dd");

  // Fetch previous period bookings for comparison chart
  const { data: prevBookingsData, isLoading: isPrevLoading } = useOwnerCourtBookings({
    courtId: effectiveCourtId,
    period,
    date: prevDateStr,
    pageSize: 500,
  });

  // Fetch comparison stats
  const { data: stats } = useOwnerDashboardStats({
    courtId: effectiveCourtId,
    period,
  });

  const currentBookings = currentBookingsData?.items ?? [];
  const prevBookings    = prevBookingsData?.items ?? [];
  const chartData       = useMemo(() => buildChartData(currentBookings, prevBookings, period), [currentBookings, prevBookings, period]);

  const paidCount = currentBookings.filter(b => ["Paid", "Completed", "Banked"].includes(b.status)).length;
  const isLoading = isCourtsLoading || isCurrentLoading || isPrevLoading;

  return (
    <div className="p-5 sm:p-7 max-w-[1400px] mx-auto space-y-8 animate-in fade-in duration-500">

      {/* Header */}
      <div className="flex flex-col sm:flex-row sm:items-center justify-between gap-6">
        <div>
          <h1 className="text-xl font-bold text-gray-900 tracking-tight flex items-center gap-2">
            <div className="w-9 h-9 rounded-xl bg-emerald-600 flex items-center justify-center shadow-md">
              <BarChart3 size={20} className="text-white" />
            </div>
            Tổng quan kinh doanh
          </h1>
          <p className="text-sm text-gray-500 mt-1 font-medium">
            Phân tích hiệu quả kinh doanh và so sánh với kỳ trước
          </p>
        </div>

        <div className="flex items-center gap-3">
          {!isCourtsLoading && courts.length > 0 && (
            <Select value={effectiveCourtId} onValueChange={setSelectedCourtId}>
              <SelectTrigger className="h-10 min-w-[200px] rounded-xl border-gray-200 bg-white shadow-sm font-semibold text-sm text-gray-700">
                <SelectValue placeholder="Chọn cơ sở" />
              </SelectTrigger>
              <SelectContent className="rounded-xl border-gray-100 shadow-xl">
                {courts.map(c => (
                  <SelectItem key={c.courtId} value={c.courtId} className="font-medium">
                    {c.name}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>
          )}

          <Select value={period} onValueChange={setPeriod}>
            <SelectTrigger className="h-10 w-[140px] rounded-xl border-gray-200 bg-white shadow-sm font-semibold text-sm text-gray-700">
              <SelectValue />
            </SelectTrigger>
            <SelectContent className="rounded-xl border-gray-100 shadow-xl">
              {PERIODS.map(p => (
                <SelectItem key={p.value} value={p.value} className="font-medium">
                  {p.label}
                </SelectItem>
              ))}
            </SelectContent>
          </Select>
        </div>
      </div>

      {/* Stat cards */}
      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        <StatCard
          label={`Doanh thu ${periodLabel.toLowerCase()}`}
          value={fmtCurrency(stats?.currentRevenue ?? 0)}
          sub={`Kỳ trước: ${fmtCurrency(stats?.previousRevenue ?? 0)}`}
          pct={stats?.comparisonPercentage ?? 0}
          status={stats?.comparisonStatus ?? "NoChange"}
          icon={<DollarSign size={20} className="text-emerald-600" />}
          color="#10b981"
        />
        <StatCard
          label={`Lượt đặt ${periodLabel.toLowerCase()}`}
          value={(stats?.currentBookingCount ?? currentBookings.length).toLocaleString()}
          sub={`Kỳ trước: ${stats?.previousBookingCount ?? 0} lượt`}
          pct={stats?.bookingComparisonPercentage ?? 0}
          status={stats?.bookingComparisonStatus ?? "NoChange"}
          icon={<CalendarCheck size={20} className="text-indigo-600" />}
          color="#6366f1"
        />
        <StatCard
          label={`Tỷ lệ hoàn tất`}
          value={currentBookings.length ? `${((paidCount / currentBookings.length) * 100).toFixed(0)}%` : "0%"}
          sub={`Trên tổng ${currentBookings.length} đơn`}
          pct={0}
          status="NoChange"
          icon={<Users size={20} className="text-amber-600" />}
          color="#f59e0b"
        />
      </div>

      {/* Comparison Chart */}
      <div className="bg-white rounded-3xl border border-gray-100 shadow-sm p-8">
        <div className="flex items-center justify-between mb-8">
          <div className="flex items-center gap-4">
            <div className="w-10 h-10 rounded-xl bg-emerald-50 flex items-center justify-center">
              <TrendingUp size={20} className="text-emerald-500" />
            </div>
            <div>
              <h2 className="text-lg font-bold text-gray-900 tracking-tight">Biểu đồ so sánh doanh thu</h2>
              <p className="text-[11px] text-gray-400 font-bold uppercase tracking-widest mt-1">
                Kỳ này vs Kỳ trước · {periodLabel}
              </p>
            </div>
          </div>
          {isLoading && <Loader2 size={20} className="animate-spin text-emerald-300" />}
        </div>

        {isLoading ? (
          <div className="h-[350px] flex items-center justify-center">
            <Loader2 size={32} className="animate-spin text-emerald-500/10" />
          </div>
        ) : chartData.length === 0 ? (
          <div className="h-[350px] flex flex-col items-center justify-center text-gray-200 gap-4">
            <BarChart3 size={64} strokeWidth={1} />
            <p className="text-sm font-semibold text-gray-400">Không có dữ liệu thống kê cho kỳ này</p>
          </div>
        ) : (
          <ResponsiveContainer width="100%" height={350}>
            <AreaChart data={chartData} margin={{ top: 10, right: 10, left: 10, bottom: 0 }}>
              <defs>
                <linearGradient id="gradCurrent" x1="0" y1="0" x2="0" y2="1">
                  <stop offset="5%"  stopColor="#10b981" stopOpacity={0.15} />
                  <stop offset="95%" stopColor="#10b981" stopOpacity={0} />
                </linearGradient>
              </defs>

              <CartesianGrid strokeDasharray="3 3" stroke="#f8fafc" vertical={false} />
              <XAxis
                dataKey="date"
                tick={{ fontSize: 9, fontWeight: 700, fill: "#94a3b8" }}
                axisLine={false}
                tickLine={false}
                dy={10}
                interval={period === "month" ? 2 : 0}
              />
              <YAxis
                tickFormatter={v => `${(v / 1000).toFixed(0)}k`}
                tick={{ fontSize: 10, fontWeight: 600, fill: "#94a3b8" }}
                axisLine={false}
                tickLine={false}
                width={45}
              />
              <Tooltip content={<CustomTooltip />} cursor={{ stroke: "#f1f5f9", strokeWidth: 2 }} />

              {/* Previous Period Line */}
              <Area
                type="monotone"
                dataKey="prevRevenue"
                stroke="#cbd5e1"
                strokeWidth={2}
                fill="transparent"
                strokeDasharray="5 5"
                dot={false}
                activeDot={false}
              />

              {/* Current Period Area */}
              <Area
                type="monotone"
                dataKey="revenue"
                stroke="#10b981"
                strokeWidth={3}
                fill="url(#gradCurrent)"
                dot={false}
                activeDot={{ r: 6, fill: "#10b981", stroke: "#fff", strokeWidth: 2 }}
              />
            </AreaChart>
          </ResponsiveContainer>
        )}

        <div className="flex items-center gap-6 mt-8 justify-center border-t border-gray-50 pt-6">
          <div className="flex items-center gap-2">
            <div className="w-8 h-1 bg-emerald-500 rounded-full" />
            <span className="text-[10px] font-bold text-gray-500 uppercase tracking-widest">Kỳ này (VNĐ)</span>
          </div>
          <div className="flex items-center gap-2">
            <div className="w-8 h-1 bg-gray-300 rounded-full border-t border-dashed" />
            <span className="text-[10px] font-bold text-gray-500 uppercase tracking-widest">Kỳ trước (VNĐ)</span>
          </div>
        </div>
      </div>
    </div>
  );
}
