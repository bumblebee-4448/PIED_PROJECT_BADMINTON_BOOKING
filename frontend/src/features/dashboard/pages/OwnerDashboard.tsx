import { useState, useEffect } from "react";
import { 
  TrendingUp, 
  Calendar, 
  DollarSign, 
  Users, 
  ArrowUpRight, 
  ArrowDownRight, 
  Filter,
  BarChart3,
  CalendarDays,
  LayoutGrid,
  MapPin,
  ChevronRight,
  User,
  Phone,
  ChevronLeft,
  Clock,
  Activity,
  ArrowLeft
} from "lucide-react";
import { 
  BarChart, 
  Bar, 
  XAxis, 
  YAxis, 
  CartesianGrid, 
  Tooltip, 
  ResponsiveContainer, 
  Cell 
} from "recharts";
import { 
  useOwnerDashboard, 
  useCourtBookings 
} from "@/features/owner-revenue/hooks/useOwnerRevenue";
import { useOwnerCourts } from "@/features/owner-courts/hooks/useOwnerCourts";
import { format } from "date-fns";
import { vi } from "date-fns/locale";
import { formatCurrency } from "@/lib/utils";
import { Button } from "@/shared/components/ui/button";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/shared/components/ui/select";
import { Input } from "@/shared/components/ui/input";
import { Card, CardContent, CardHeader, CardTitle, CardDescription } from "@/shared/components/ui/card";
import { Badge } from "@/shared/components/ui/badge";
import { cn } from "@/lib/utils";

const PERIOD_OPTIONS = [
  { value: "Day", label: "Ngày" },
  { value: "Week", label: "Tuần" },
  { value: "Month", label: "Tháng" },
  { value: "Quarter", label: "Quý" },
  { value: "Year", label: "Năm" },
];

type ViewMode = "Overview" | "Detail";

export function OwnerDashboard() {
  const [viewMode, setViewMode] = useState<ViewMode>("Overview");
  const [period, setPeriod] = useState<"Day" | "Week" | "Month" | "Quarter" | "Year">("Day");
  const [date, setDate] = useState<string>(format(new Date(), "yyyy-MM-dd"));
  const [courtId, setCourtId] = useState<string>("");
  const [pageIndex, setPageIndex] = useState(1);
  const pageSize = 10;
  
  const { data: courtsListData } = useOwnerCourts({ pageIndex: 1, pageSize: 100 });

  useEffect(() => {
    if (viewMode === "Detail" && !courtId && courtsListData?.items.length) {
      setCourtId(courtsListData.items[0].courtId);
    }
  }, [viewMode, courtsListData, courtId]);

  const { data: dashboardData, isLoading: isStatsLoading, refetch: refetchStats } = useOwnerDashboard({
    period,
    date,
    courtId: viewMode === "Overview" ? undefined : courtId
  });

  const { data: bookingsData, isLoading: isBookingsLoading, refetch: refetchBookings } = useCourtBookings({
    courtId: viewMode === "Detail" ? courtId : "skip",
    period,
    date,
    pageIndex,
    pageSize
  });

  useEffect(() => {
    refetchStats();
    if (viewMode === "Detail" && courtId) {
      refetchBookings();
    }
  }, [period, date, courtId, pageIndex, viewMode, refetchStats, refetchBookings]);

  const stats = [
    {
      title: "Doanh thu",
      current: dashboardData?.currentRevenue || 0,
      previous: dashboardData?.previousRevenue || 0,
      diff: dashboardData?.revenueDifference || 0,
      percent: dashboardData?.comparisonPercentage || 0,
      status: dashboardData?.comparisonStatus || "NoChange",
      icon: <DollarSign className="w-4 h-4 text-emerald-500" />,
      isCurrency: true,
      color: "emerald"
    },
    {
      title: "Lượt đặt sân",
      current: dashboardData?.currentBookingCount || 0,
      previous: dashboardData?.previousBookingCount || 0,
      diff: dashboardData?.bookingDifference || 0,
      percent: dashboardData?.bookingComparisonPercentage || 0,
      status: dashboardData?.bookingComparisonStatus || "NoChange",
      icon: <Calendar className="w-4 h-4 text-blue-500" />,
      isCurrency: false,
      color: "blue"
    }
  ];

  const chartData = [
    { name: "Kỳ trước", value: stats[0].previous },
    { name: "Kỳ này", value: stats[0].current }
  ];

  const bookingChartData = [
    { name: "Kỳ trước", value: stats[1].previous },
    { name: "Kỳ này", value: stats[1].current }
  ];

  return (
    <div className="p-4 lg:p-6 max-w-6xl mx-auto space-y-6 animate-in fade-in duration-700 pb-12">
      
      {/* Header & Filter Bar */}
      <div className="flex flex-col xl:flex-row xl:items-center justify-between gap-4 bg-white/70 backdrop-blur-xl p-5 rounded-[24px] border border-white shadow-xl shadow-gray-200/40">
        <div className="space-y-0.5">
          <h1 className="text-2xl font-black text-gray-900 tracking-tight flex items-center gap-2">
            {viewMode === "Overview" ? (
              <>Dashboard <span className="text-emerald-500 font-bold">Tổng</span></>
            ) : (
              <div className="flex items-center gap-2">
                <Button 
                  variant="ghost" 
                  size="icon" 
                  onClick={() => setViewMode("Overview")}
                  className="w-8 h-8 rounded-lg hover:bg-gray-100"
                >
                  <ArrowLeft className="w-5 h-5 text-gray-400" />
                </Button>
                <span>Báo cáo <span className="text-blue-500 font-bold">Chi tiết</span></span>
              </div>
            )}
          </h1>
          <p className="text-xs font-bold text-gray-400 uppercase tracking-wider">
            {viewMode === "Overview" ? "Hệ thống tổng hợp" : `Sân: ${courtsListData?.items.find(c => c.courtId === courtId)?.name || "..."}`}
          </p>
        </div>

        <div className="flex flex-wrap items-center gap-3">
           {viewMode === "Detail" && (
             <div className="flex items-center gap-2 bg-white p-0.5 rounded-xl border border-gray-100 shadow-sm min-w-[160px]">
                <MapPin className="ml-2 w-3.5 h-3.5 text-blue-500" />
                <Select value={courtId} onValueChange={(val) => { setCourtId(val); setPageIndex(1); }}>
                  <SelectTrigger className="border-none bg-transparent focus:ring-0 font-bold text-gray-700 h-8 text-xs">
                    <SelectValue placeholder="Chọn sân" />
                  </SelectTrigger>
                  <SelectContent className="rounded-xl border-gray-100">
                    {courtsListData?.items.map(court => (
                      <SelectItem key={court.courtId} value={court.courtId} className="text-xs">{court.name}</SelectItem>
                    ))}
                  </SelectContent>
                </Select>
             </div>
           )}

           <div className="flex items-center gap-0.5 bg-gray-100/80 p-1 rounded-xl border border-gray-200">
             {PERIOD_OPTIONS.map((opt) => (
               <Button
                 key={opt.value}
                 variant="ghost"
                 size="sm"
                 onClick={() => { setPeriod(opt.value as any); setPageIndex(1); }}
                 className={cn(
                   "h-8 px-3 rounded-lg text-[10px] font-black transition-all",
                   period === opt.value 
                     ? "bg-white text-emerald-600 shadow-sm" 
                     : "text-gray-500 hover:text-gray-900"
                 )}
               >
                 {opt.label}
               </Button>
             ))}
           </div>
           
           {/* Date Picker */}
           <div className="flex items-center gap-2 bg-white px-3 h-10 rounded-xl border border-gray-100 shadow-sm transition-all hover:border-emerald-200 group">
             <CalendarDays className="w-3.5 h-3.5 text-emerald-500 shrink-0" />
             <input 
               type="date"
               value={date}
               onChange={(e) => {
                 const newDate = e.target.value;
                 if (newDate) {
                   setDate(newDate);
                   setPageIndex(1);
                 }
               }}
               onClick={(e) => e.currentTarget.showPicker?.()}
               className="bg-transparent border-none focus:ring-0 font-bold text-gray-700 text-[10px] cursor-pointer w-[110px] outline-none"
             />
           </div>
        </div>
      </div>

      {/* Stats Cards */}
      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        {stats.map((stat, i) => (
          <Card key={i} className="overflow-hidden border-none shadow-xl shadow-gray-200/40 rounded-[28px] group transition-all hover:-translate-y-0.5">
            <CardContent className="p-6 space-y-4">
              <div className="flex items-center justify-between">
                <div className="flex items-center gap-4">
                  <div className={cn("p-3 rounded-xl", stat.color === "emerald" ? "bg-emerald-50 text-emerald-600" : "bg-blue-50 text-blue-600")}>
                    {stat.icon}
                  </div>
                  <div>
                    <p className="text-[10px] font-black text-gray-400 uppercase tracking-widest">{stat.title}</p>
                    <h3 className="text-2xl font-black text-gray-900 mt-0.5 tracking-tight">
                      {stat.isCurrency ? formatCurrency(stat.current) : stat.current}
                    </h3>
                  </div>
                </div>
                <Badge className={cn(
                  "h-8 px-3 rounded-lg border-none font-black text-[10px] shadow-sm",
                  stat.status === "Increase" ? "bg-emerald-100 text-emerald-600" : 
                  stat.status === "Decrease" ? "bg-rose-100 text-rose-600" : 
                  "bg-gray-100 text-gray-400"
                )}>
                  {stat.status === "Increase" && <ArrowUpRight className="w-3 h-3 mr-1 stroke-[4]" />}
                  {stat.status === "Decrease" && <ArrowDownRight className="w-3 h-3 mr-1 stroke-[4]" />}
                  {stat.percent}%
                </Badge>
              </div>

              <div className="pt-4 border-t border-gray-50 flex items-center justify-between">
                <div className="space-y-0.5">
                  <p className="text-[9px] font-black text-gray-300 uppercase tracking-widest">Kỳ trước</p>
                  <p className="text-sm font-bold text-gray-400">
                    {stat.isCurrency ? formatCurrency(stat.previous) : stat.previous}
                  </p>
                </div>
                <div className="text-right space-y-0.5">
                  <p className="text-[9px] font-black text-gray-300 uppercase tracking-widest">Chênh lệch</p>
                  <p className={cn(
                    "text-sm font-black",
                    stat.diff >= 0 ? "text-emerald-500" : "text-rose-500"
                  )}>
                    {stat.diff >= 0 ? "+" : ""}{stat.isCurrency ? formatCurrency(stat.diff) : stat.diff}
                  </p>
                </div>
              </div>
            </CardContent>
          </Card>
        ))}
      </div>

      {/* Comparison Charts */}
      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        {[
          { title: "Doanh thu", data: chartData, icon: <BarChart3 className="w-4 h-4 text-emerald-500" />, unit: "Revenue" },
          { title: "Lượt đặt", data: bookingChartData, icon: <Users className="w-4 h-4 text-blue-500" />, unit: "Bookings" }
        ].map((c, i) => (
          <Card key={i} className="border-none shadow-xl shadow-gray-200/40 rounded-[28px] p-6 bg-white">
            <CardHeader className="p-0 mb-6">
              <CardTitle className="text-lg font-black text-gray-900 flex items-center gap-2">
                {c.icon} {c.title}
              </CardTitle>
            </CardHeader>
            <div className="h-[200px] w-full">
              <ResponsiveContainer width="100%" height="100%">
                <BarChart data={c.data} margin={{ top: 0, right: 0, left: -20, bottom: 0 }}>
                  <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="#f1f5f9" />
                  <XAxis dataKey="name" axisLine={false} tickLine={false} tick={{ fontSize: 10, fontWeight: 800, fill: '#64748b' }} dy={8} />
                  <YAxis axisLine={false} tickLine={false} tick={{ fontSize: 9, fontWeight: 700, fill: '#cbd5e1' }} tickFormatter={(v) => c.unit === "Revenue" ? `${v/1000}k` : v} />
                  <Tooltip cursor={{ fill: '#f8fafc' }} contentStyle={{ borderRadius: '12px', border: 'none', padding: '10px', fontSize: '11px' }} />
                  <Bar dataKey="value" radius={[8, 8, 8, 8]} barSize={40}>
                    {c.data.map((_, idx) => (
                      <Cell key={`cell-${idx}`} fill={idx === 1 ? (i === 0 ? '#10b981' : '#3b82f6') : '#f1f5f9'} />
                    ))}
                  </Bar>
                </BarChart>
              </ResponsiveContainer>
            </div>
          </Card>
        ))}
      </div>

      {/* Main Action Button (Only in Overview) */}
      {viewMode === "Overview" && (
        <div className="flex flex-col items-center py-6">
          <Button 
            size="lg"
            onClick={() => setViewMode("Detail")}
            className="bg-gray-900 text-white hover:bg-emerald-600 px-10 h-14 rounded-[20px] font-black text-lg shadow-xl transition-all hover:scale-105 active:scale-95 flex items-center gap-3 group"
          >
            <Activity className="w-6 h-6 text-emerald-400" />
            Xem chi tiết từng sân
            <ChevronRight className="w-6 h-6 group-hover:translate-x-1.5 transition-transform" />
          </Button>
        </div>
      )}

      {/* Detail Mode - Booking Table */}
      {viewMode === "Detail" && (
        <Card className="border-none shadow-xl shadow-gray-200/40 rounded-[28px] overflow-hidden bg-white animate-in slide-in-from-bottom-6 duration-500">
          <div className="p-6 border-b border-gray-50 flex items-center justify-between">
            <div className="space-y-0.5">
              <h3 className="text-lg font-black text-gray-900 flex items-center gap-2">
                <LayoutGrid className="text-purple-500 w-5 h-5" /> Đơn đặt sân
              </h3>
            </div>
            <Badge className="bg-purple-50 text-purple-600 border-none h-8 px-4 rounded-lg font-black text-[10px]">
              {bookingsData?.totalItems || 0} Đơn
            </Badge>
          </div>

          <div className="overflow-x-auto">
            <table className="w-full text-left border-collapse">
              <thead>
                <tr className="bg-gray-50/50">
                  <th className="p-4 text-[9px] font-black text-gray-300 uppercase tracking-widest">Khách hàng</th>
                  <th className="p-4 text-[9px] font-black text-gray-300 uppercase tracking-widest">Sân & Ngày</th>
                  <th className="p-4 text-[9px] font-black text-gray-300 uppercase tracking-widest">Khung giờ</th>
                  <th className="p-4 text-[9px] font-black text-gray-300 uppercase tracking-widest">Tổng tiền</th>
                  <th className="p-4 text-[9px] font-black text-gray-300 uppercase tracking-widest text-center">Trạng thái</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-gray-50">
                {isBookingsLoading ? (
                  [1, 2].map(i => (
                    <tr key={i} className="animate-pulse">
                      <td colSpan={5} className="p-6"><div className="h-10 bg-gray-100 rounded-xl w-full" /></td>
                    </tr>
                  ))
                ) : !bookingsData || bookingsData.items.length === 0 ? (
                  <tr>
                    <td colSpan={5} className="p-20 text-center text-gray-300 font-black text-sm">Trống rỗng...</td>
                  </tr>
                ) : (
                  bookingsData.items.map((booking) => (
                    <tr key={booking.bookingId} className="hover:bg-gray-50/30 transition-all group">
                      <td className="p-4">
                        <div className="flex items-center gap-3">
                          <div className="w-9 h-9 rounded-xl bg-emerald-50 flex items-center justify-center text-emerald-600 font-black text-sm shadow-inner">
                            {booking.customerName.charAt(0)}
                          </div>
                          <div>
                            <p className="font-black text-gray-900 text-sm">{booking.customerName}</p>
                            <p className="text-[9px] font-bold text-gray-400 flex items-center gap-1 mt-0.5">
                              <Phone className="w-2.5 h-2.5" /> {booking.customerPhone}
                            </p>
                          </div>
                        </div>
                      </td>
                      <td className="p-4">
                        <div className="space-y-0.5">
                          <p className="font-bold text-gray-800 text-xs flex items-center gap-1.5">
                            <MapPin className="w-3 h-3 text-emerald-500" /> {booking.subCourtName}
                          </p>
                          <p className="text-[9px] font-bold text-gray-400 flex items-center gap-1.5">
                            <Calendar className="w-3 h-3" /> {format(new Date(booking.bookingDate), "dd/MM/yyyy")}
                          </p>
                        </div>
                      </td>
                      <td className="p-4">
                        <div className="flex flex-wrap gap-1 max-w-[150px]">
                          {booking.slots.map((slot, idx) => (
                            <Badge key={idx} variant="secondary" className="bg-blue-50/50 text-blue-600 border-none rounded-md text-[8px] font-black px-1.5 py-0.5">
                              {slot.startTime.substring(0, 5)}
                            </Badge>
                          ))}
                        </div>
                      </td>
                      <td className="p-4">
                        <p className="text-lg font-black text-emerald-600 tracking-tight">{formatCurrency(booking.totalPrice)}</p>
                      </td>
                      <td className="p-4">
                        <div className="flex justify-center">
                          <Badge className={cn(
                            "rounded-lg px-3 py-1 border-none font-black text-[9px] shadow-sm",
                            booking.status === "Complete" ? "bg-emerald-100 text-emerald-700" :
                            booking.status === "Banked" ? "bg-blue-100 text-blue-700" :
                            booking.status === "Cancelled" ? "bg-rose-100 text-rose-700" :
                            "bg-gray-100 text-gray-500"
                          )}>
                            {booking.status}
                          </Badge>
                        </div>
                      </td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>

          {/* Compact Pagination */}
          <div className="p-6 bg-gray-50/30 flex items-center justify-between">
            <div className="flex items-center gap-2">
               <span className="text-[10px] font-black text-gray-400">Trang {pageIndex}</span>
            </div>
            <div className="flex items-center gap-2">
              <Button 
                variant="outline" 
                className="rounded-xl h-9 px-4 border-gray-200 font-black text-xs gap-1 hover:bg-white transition-all disabled:opacity-30"
                disabled={pageIndex <= 1}
                onClick={() => setPageIndex(p => p - 1)}
              >
                <ChevronLeft className="w-4 h-4" />
              </Button>
              <Button 
                variant="outline" 
                className="rounded-xl h-9 px-4 border-gray-200 font-black text-xs gap-1 hover:bg-white transition-all disabled:opacity-30"
                disabled={pageIndex >= Math.ceil((bookingsData?.totalItems || 1) / pageSize)}
                onClick={() => setPageIndex(p => p + 1)}
              >
                Sau <ChevronRight className="w-4 h-4" />
              </Button>
            </div>
          </div>
        </Card>
      )}
    </div>
  );
}
