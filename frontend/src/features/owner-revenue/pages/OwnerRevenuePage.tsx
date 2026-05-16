import React, { useState, useEffect } from "react";
import { useSearchParams } from "react-router-dom";
import { 
  useOwnerDashboard, 
  useCourtBookings 
} from "../hooks/useOwnerRevenue";
import { useOwnerCourts } from "@/features/owner-courts/hooks/useOwnerCourts";
import { 
  DollarSign, 
  Calendar, 
  Search, 
  MapPin, 
  Clock, 
  User, 
  Phone, 
  Tag,
  ChevronLeft,
  ChevronRight,
  Filter,
  Download,
  CalendarDays
} from "lucide-react";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/shared/components/ui/select";
import { Badge } from "@/shared/components/ui/badge";
import { formatCurrency } from "@/lib/utils";
import { cn } from "@/lib/utils";
import { format } from "date-fns";
import { vi } from "date-fns/locale";

const PERIOD_OPTIONS = [
  { value: "Day", label: "Ngày" },
  { value: "Week", label: "Tuần" },
  { value: "Month", label: "Tháng" },
  { value: "Quarter", label: "Quý" },
  { value: "Year", label: "Năm" },
];

const OwnerRevenuePage: React.FC = () => {
  const [searchParams, setSearchParams] = useSearchParams();
  
  // State filters
  const [courtId, setCourtId] = useState<string>(searchParams.get("courtId") || "all");
  const [period, setPeriod] = useState<any>(searchParams.get("period") || "Day");
  const [date, setDate] = useState<string>(searchParams.get("date") || format(new Date(), "yyyy-MM-dd"));
  const [pageIndex, setPageIndex] = useState(1);
  const pageSize = 10;

  // Sync state with URL params
  useEffect(() => {
    const newParams = new URLSearchParams();
    if (courtId !== "all") newParams.set("courtId", courtId);
    newParams.set("period", period);
    newParams.set("date", date);
    setSearchParams(newParams);
  }, [courtId, period, date, setSearchParams]);

  // Fetch data
  const { data: courtsData } = useOwnerCourts({ pageIndex: 1, pageSize: 100 });
  
  const { data: dashboardData, isLoading: isStatsLoading } = useOwnerDashboard({
    period,
    date,
    courtId: courtId === "all" ? undefined : courtId
  });

  const { data: bookingsData, isLoading: isBookingsLoading } = useCourtBookings({
    courtId: courtId === "all" ? "" : courtId,
    period,
    date,
    pageIndex,
    pageSize
  });

  const stats = [
    {
      title: "Doanh thu kỳ này",
      value: formatCurrency(dashboardData?.currentRevenue || 0),
      icon: <DollarSign className="w-5 h-5 text-emerald-600" />,
      color: "bg-emerald-50",
      sub: `So với kỳ trước: ${formatCurrency(dashboardData?.revenueDifference || 0)}`
    },
    {
      title: "Lượt đặt sân",
      value: dashboardData?.currentBookingCount || 0,
      icon: <Calendar className="w-5 h-5 text-blue-600" />,
      color: "bg-blue-50",
      sub: `Biến động: ${dashboardData?.bookingComparisonPercentage || 0}%`
    }
  ];

  return (
    <div className="p-6 lg:p-10 space-y-10 max-w-[1600px] mx-auto animate-in fade-in duration-700">
      {/* Header */}
      <div className="flex flex-col lg:flex-row lg:items-center justify-between gap-6">
        <div className="space-y-2">
          <h1 className="text-4xl font-black text-gray-900 tracking-tight">
            Chi tiết <span className="text-emerald-500">Doanh thu</span>
          </h1>
          <p className="text-gray-500 font-medium flex items-center gap-2">
            <Filter className="w-4 h-4" /> Quản lý và tra cứu đơn đặt sân theo bộ lọc
          </p>
        </div>
        <div className="flex items-center gap-3">
          <Button variant="outline" className="h-12 px-6 rounded-2xl border-gray-200 font-bold hover:bg-gray-50 transition-all">
            <Download className="w-5 h-5 mr-2" /> Xuất báo cáo
          </Button>
        </div>
      </div>

      {/* Modern Filter Bar */}
      <div className="bg-white/70 backdrop-blur-xl p-8 rounded-[32px] border border-white shadow-2xl shadow-gray-200/40 flex flex-wrap items-end gap-6">
        <div className="space-y-2.5 flex-1 min-w-[280px]">
          <label className="text-xs font-black text-gray-400 uppercase tracking-[0.2em] flex items-center gap-2">
            <MapPin size={14} className="text-emerald-500" /> Chọn sân cơ sở
          </label>
          <Select value={courtId} onValueChange={(val) => { setCourtId(val); setPageIndex(1); }}>
            <SelectTrigger className="h-14 border-gray-100 bg-gray-50/50 rounded-2xl focus:ring-emerald-500/10 font-bold text-gray-700">
              <SelectValue placeholder="Tất cả các sân" />
            </SelectTrigger>
            <SelectContent className="rounded-2xl border-gray-100">
              <SelectItem value="all">Tất cả các sân</SelectItem>
              {courtsData?.items.map(court => (
                <SelectItem key={court.courtId} value={court.courtId}>{court.name}</SelectItem>
              ))}
            </SelectContent>
          </Select>
        </div>

        <div className="space-y-2.5 flex-1 min-w-[180px]">
          <label className="text-xs font-black text-gray-400 uppercase tracking-[0.2em] flex items-center gap-2">
            <Clock size={14} className="text-blue-500" /> Loại kỳ báo cáo
          </label>
          <Select value={period} onValueChange={(val) => { setPeriod(val); setPageIndex(1); }}>
            <SelectTrigger className="h-14 border-gray-100 bg-gray-50/50 rounded-2xl focus:ring-blue-500/10 font-bold text-gray-700">
              <SelectValue placeholder="Chọn kỳ" />
            </SelectTrigger>
            <SelectContent className="rounded-2xl border-gray-100">
              {PERIOD_OPTIONS.map(opt => (
                <SelectItem key={opt.value} value={opt.value}>{opt.label}</SelectItem>
              ))}
            </SelectContent>
          </Select>
        </div>

        <div className="space-y-2.5 flex-1 min-w-[200px]">
          <label className="text-xs font-black text-gray-400 uppercase tracking-[0.2em] flex items-center gap-2">
            <CalendarDays size={14} className="text-purple-500" /> Mốc thời gian
          </label>
          <Input 
            type="date" 
            value={date}
            onChange={(e) => { setDate(e.target.value); setPageIndex(1); }}
            className="h-14 border-gray-100 bg-gray-50/50 rounded-2xl focus:ring-purple-500/10 font-bold text-gray-700"
          />
        </div>

        <Button 
          variant="ghost" 
          className="h-14 px-8 rounded-2xl font-black text-gray-400 hover:text-emerald-600 hover:bg-emerald-50 transition-all"
          onClick={() => { setCourtId("all"); setPeriod("Day"); setDate(format(new Date(), "yyyy-MM-dd")); }}
        >
          Đặt lại
        </Button>
      </div>

      {/* Stats Quick View */}
      <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
        {stats.map((stat, i) => (
          <div key={i} className="bg-white p-8 rounded-[32px] border border-gray-50 shadow-xl shadow-gray-200/30 flex items-center gap-6">
            <div className={cn("p-5 rounded-[24px]", stat.color)}>
              {stat.icon}
            </div>
            <div>
              <p className="text-xs font-black text-gray-400 uppercase tracking-widest">{stat.title}</p>
              <h3 className="text-3xl font-black text-gray-900 mt-1">{stat.value}</h3>
              <p className="text-sm font-medium text-gray-400 mt-1.5">{stat.sub}</p>
            </div>
          </div>
        ))}
      </div>

      {/* Bookings Table */}
      <div className="bg-white rounded-[40px] border border-gray-100 shadow-2xl shadow-gray-200/40 overflow-hidden">
        <div className="p-8 border-b border-gray-50 flex items-center justify-between">
          <h3 className="text-xl font-black text-gray-900">Danh sách đơn hàng</h3>
          <Badge variant="outline" className="h-8 px-4 rounded-xl border-gray-200 text-xs font-bold text-gray-500">
            {bookingsData?.totalItems || 0} kết quả
          </Badge>
        </div>

        <div className="overflow-x-auto">
          <table className="w-full text-left border-collapse">
            <thead>
              <tr className="bg-gray-50/50">
                <th className="p-6 text-xs font-black text-gray-400 uppercase tracking-widest">Khách hàng</th>
                <th className="p-6 text-xs font-black text-gray-400 uppercase tracking-widest">Sân & Ngày đặt</th>
                <th className="p-6 text-xs font-black text-gray-400 uppercase tracking-widest">Chi tiết khung giờ</th>
                <th className="p-6 text-xs font-black text-gray-400 uppercase tracking-widest">Tổng tiền</th>
                <th className="p-6 text-xs font-black text-gray-400 uppercase tracking-widest text-center">Trạng thái</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-gray-50">
              {isBookingsLoading ? (
                [1, 2, 3].map(i => (
                  <tr key={i} className="animate-pulse">
                    <td colSpan={5} className="p-8"><div className="h-12 bg-gray-100 rounded-2xl w-full" /></td>
                  </tr>
                ))
              ) : bookingsData?.items.length === 0 ? (
                <tr>
                  <td colSpan={5} className="p-20 text-center text-gray-400 font-bold">Không tìm thấy đơn hàng nào trong khoảng thời gian này.</td>
                </tr>
              ) : (
                bookingsData?.items.map((booking) => (
                  <tr key={booking.bookingId} className="hover:bg-gray-50/50 transition-colors group">
                    <td className="p-6">
                      <div className="flex items-center gap-4">
                        <div className="w-12 h-12 rounded-2xl bg-emerald-50 flex items-center justify-center text-emerald-600">
                          <User className="w-5 h-5" />
                        </div>
                        <div>
                          <p className="font-black text-gray-900">{booking.customerName}</p>
                          <p className="text-xs font-bold text-gray-400 flex items-center gap-1 mt-1">
                            <Phone className="w-3 h-3" /> {booking.customerPhone}
                          </p>
                        </div>
                      </div>
                    </td>
                    <td className="p-6">
                      <div className="space-y-1">
                        <p className="font-bold text-gray-900 flex items-center gap-2">
                          <MapPin className="w-4 h-4 text-emerald-500" /> {booking.subCourtName}
                        </p>
                        <p className="text-xs font-bold text-gray-400 flex items-center gap-2">
                          <Calendar className="w-4 h-4" /> {format(new Date(booking.bookingDate), "dd/MM/yyyy")}
                        </p>
                      </div>
                    </td>
                    <td className="p-6">
                      <div className="flex flex-wrap gap-2">
                        {booking.slots.map((slot, idx) => (
                          <Badge key={idx} variant="secondary" className="bg-blue-50 text-blue-600 border-none rounded-lg text-[10px] font-black px-2.5 py-1">
                            {slot.startTime.substring(0, 5)} - {slot.endTime.substring(0, 5)}
                          </Badge>
                        ))}
                      </div>
                      <p className="text-[10px] text-gray-400 mt-2 font-bold uppercase tracking-wider">
                        Đã đặt lúc: {format(new Date(booking.createdAt), "HH:mm dd/MM")}
                      </p>
                    </td>
                    <td className="p-6">
                      <p className="text-lg font-black text-emerald-600">{formatCurrency(booking.totalPrice)}</p>
                    </td>
                    <td className="p-6">
                      <div className="flex justify-center">
                        <Badge className={cn(
                          "rounded-xl px-4 py-1.5 border-none font-black text-xs",
                          booking.status === "Complete" ? "bg-emerald-100 text-emerald-700" :
                          booking.status === "Banked" ? "bg-blue-100 text-blue-700" :
                          booking.status === "Cancelled" ? "bg-rose-100 text-rose-700" :
                          "bg-gray-100 text-gray-600"
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

        {/* Pagination */}
        <div className="p-8 bg-gray-50/50 flex items-center justify-between">
          <p className="text-sm font-bold text-gray-400">
            Trang <span className="text-gray-900">{pageIndex}</span> / {Math.ceil((bookingsData?.totalItems || 1) / pageSize)}
          </p>
          <div className="flex items-center gap-2">
            <Button 
              variant="outline" 
              size="icon" 
              className="rounded-xl h-11 w-11 border-gray-200"
              disabled={pageIndex <= 1}
              onClick={() => setPageIndex(p => p - 1)}
            >
              <ChevronLeft className="w-5 h-5" />
            </Button>
            <Button 
              variant="outline" 
              size="icon" 
              className="rounded-xl h-11 w-11 border-gray-200"
              disabled={pageIndex >= Math.ceil((bookingsData?.totalItems || 1) / pageSize)}
              onClick={() => setPageIndex(p => p + 1)}
            >
              <ChevronRight className="w-5 h-5" />
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default OwnerRevenuePage;
