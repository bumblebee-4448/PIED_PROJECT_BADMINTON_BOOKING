import React, { useState } from "react";
import { useOwnerRevenue } from "../hooks/useOwnerRevenue";
import { useOwnerCourts } from "@/features/owner-courts/hooks/useOwnerCourts";
import { 
  XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer, 
  AreaChart, Area 
} from "recharts";
import { 
  TrendingUp, DollarSign, Calendar, 
  Download, ChevronRight, Activity,
  LayoutDashboard, MapPin
} from "lucide-react";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/shared/components/ui/select";
import { Badge } from "@/shared/components/ui/badge";
import { formatCurrency } from "@/lib/utils";
import { cn } from "@/lib/utils";
import { format } from "date-fns";
import { vi } from "date-fns/locale";

const OwnerRevenuePage: React.FC = () => {
  const [filters, setFilters] = useState({
    startDate: format(new Date(new Date().getFullYear(), new Date().getMonth(), 1), "yyyy-MM-dd"),
    endDate: format(new Date(), "yyyy-MM-dd"),
    courtId: "all"
  });

  const { data: revenueData, isLoading } = useOwnerRevenue({
    ...filters,
    courtId: filters.courtId === "all" ? undefined : filters.courtId
  });

  const { data: courtsData } = useOwnerCourts({ pageIndex: 1, pageSize: 100 });

  const stats = [
    {
      title: "Tổng doanh thu",
      value: formatCurrency(revenueData?.totalRevenue || 0),
      icon: <DollarSign className="w-5 h-5 text-emerald-600" />,
      color: "bg-emerald-50",
      trend: "+12.5%",
      isPositive: true
    },
    {
      title: "Tổng lượt đặt sân",
      value: revenueData?.totalBookings || 0,
      icon: <Calendar className="w-5 h-5 text-blue-600" />,
      color: "bg-blue-50",
      trend: "+5.2%",
      isPositive: true
    },
    {
      title: "Trung bình/Đơn",
      value: formatCurrency((revenueData?.totalRevenue || 0) / (revenueData?.totalBookings || 1)),
      icon: <Activity className="w-5 h-5 text-purple-600" />,
      color: "bg-purple-50",
      trend: "-2.1%",
      isPositive: false
    },
    {
      title: "Sân hoạt động",
      value: revenueData?.courts.length || 0,
      icon: <LayoutDashboard className="w-5 h-5 text-amber-600" />,
      color: "bg-amber-50",
      trend: "Ổn định",
      isPositive: true
    }
  ];

  if (isLoading) {
    return (
      <div className="p-8 flex items-center justify-center min-h-[400px]">
        <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-emerald-600"></div>
      </div>
    );
  }

  return (
    <div className="p-6 space-y-8 max-w-[1600px] mx-auto animate-in fade-in duration-500">
      {/* Header */}
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-gray-900 flex items-center gap-2">
            <TrendingUp className="text-emerald-600 w-7 h-7" />
            Quản lý doanh thu
          </h1>
          <p className="text-sm text-gray-500 mt-1">
            Theo dõi hiệu quả kinh doanh và báo cáo chi tiết các sân của bạn
          </p>
        </div>
        <div className="flex items-center gap-3">
          <Button variant="outline" className="rounded-xl border-gray-200 h-10 gap-2">
            <Download size={16} /> Xuất báo cáo
          </Button>
          <Button className="bg-emerald-600 hover:bg-emerald-700 rounded-xl h-10 shadow-lg shadow-emerald-100">
            Cập nhật dữ liệu
          </Button>
        </div>
      </div>

      {/* Filters */}
      <div className="bg-white p-5 rounded-2xl border border-gray-100 shadow-sm flex flex-wrap items-end gap-4">
        <div className="space-y-1.5 flex-1 min-w-[200px]">
          <label className="text-xs font-bold text-gray-400 uppercase tracking-wider flex items-center gap-1.5">
            <Calendar size={12} /> Từ ngày
          </label>
          <Input 
            type="date" 
            className="h-10 border-gray-100 bg-gray-50/50 rounded-xl focus:ring-emerald-500/20"
            value={filters.startDate}
            onChange={(e) => setFilters(prev => ({ ...prev, startDate: e.target.value }))}
          />
        </div>
        <div className="space-y-1.5 flex-1 min-w-[200px]">
          <label className="text-xs font-bold text-gray-400 uppercase tracking-wider flex items-center gap-1.5">
            <Calendar size={12} /> Đến ngày
          </label>
          <Input 
            type="date" 
            className="h-10 border-gray-100 bg-gray-50/50 rounded-xl focus:ring-emerald-500/20"
            value={filters.endDate}
            onChange={(e) => setFilters(prev => ({ ...prev, endDate: e.target.value }))}
          />
        </div>
        <div className="space-y-1.5 flex-1 min-w-[240px]">
          <label className="text-xs font-bold text-gray-400 uppercase tracking-wider flex items-center gap-1.5">
            <MapPin size={12} /> Chọn sân
          </label>
          <Select 
            value={filters.courtId} 
            onValueChange={(val) => setFilters(prev => ({ ...prev, courtId: val }))}
          >
            <SelectTrigger className="h-10 border-gray-100 bg-gray-50/50 rounded-xl focus:ring-emerald-500/20">
              <SelectValue placeholder="Tất cả các sân" />
            </SelectTrigger>
            <SelectContent className="rounded-xl border-gray-100">
              <SelectItem value="all">Tất cả các sân</SelectItem>
              {courtsData?.items.map(court => (
                <SelectItem key={court.courtId} value={court.courtId}>
                  {court.name}
                </SelectItem>
              ))}
            </SelectContent>
          </Select>
        </div>
        <Button variant="ghost" className="h-10 text-gray-500 hover:text-emerald-600 px-4 rounded-xl">
          Làm mới
        </Button>
      </div>

      {/* Stats Grid */}
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6">
        {stats.map((stat, i) => (
          <div key={i} className="bg-white p-6 rounded-2xl border border-gray-100 shadow-sm hover:shadow-md transition-all duration-300 group">
            <div className="flex items-center justify-between mb-4">
              <div className={cn("p-3 rounded-xl transition-transform group-hover:scale-110", stat.color)}>
                {stat.icon}
              </div>
              <Badge className={cn(
                "border-none shadow-none text-[10px] font-bold px-2",
                stat.isPositive ? "bg-emerald-50 text-emerald-600" : "bg-rose-50 text-rose-600"
              )}>
                {stat.trend}
              </Badge>
            </div>
            <p className="text-sm font-semibold text-gray-400">{stat.title}</p>
            <h3 className="text-2xl font-bold text-gray-900 mt-1">{stat.value}</h3>
          </div>
        ))}
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
        {/* Chart */}
        <div className="lg:col-span-2 bg-white p-6 rounded-2xl border border-gray-100 shadow-sm space-y-6">
          <div className="flex items-center justify-between">
            <h3 className="font-bold text-gray-900 text-lg flex items-center gap-2">
              <Activity className="text-emerald-600 w-5 h-5" />
              Biểu đồ tăng trưởng doanh thu
            </h3>
            <div className="flex gap-2">
              <Button size="sm" variant="ghost" className="text-[10px] font-bold h-7 px-2 rounded-lg bg-emerald-50 text-emerald-600">NGÀY</Button>
              <Button size="sm" variant="ghost" className="text-[10px] font-bold h-7 px-2 rounded-lg text-gray-400">THÁNG</Button>
            </div>
          </div>
          <div className="h-[400px] w-full">
            <ResponsiveContainer width="100%" height="100%">
              <AreaChart data={revenueData?.chartData || []}>
                <defs>
                  <linearGradient id="colorAmount" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="5%" stopColor="#10b981" stopOpacity={0.1}/>
                    <stop offset="95%" stopColor="#10b981" stopOpacity={0}/>
                  </linearGradient>
                </defs>
                <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="#f3f4f6" />
                <XAxis 
                  dataKey="date" 
                  axisLine={false} 
                  tickLine={false} 
                  tick={{ fontSize: 11, fill: '#9ca3af', fontWeight: 600 }}
                  dy={10}
                  tickFormatter={(val) => format(new Date(val), "dd/MM", { locale: vi })}
                />
                <YAxis 
                  axisLine={false} 
                  tickLine={false} 
                  tick={{ fontSize: 11, fill: '#9ca3af', fontWeight: 600 }}
                  dx={-10}
                  tickFormatter={(val) => `${val/1000}k`}
                />
                <Tooltip 
                  contentStyle={{ borderRadius: '12px', border: 'none', boxShadow: '0 10px 15px -3px rgb(0 0 0 / 0.1)', padding: '12px' }}
                  formatter={(val: any) => [formatCurrency(Number(val)), "Doanh thu"]}
                  labelFormatter={(label) => format(new Date(label), "dd MMMM, yyyy", { locale: vi })}
                />
                <Area 
                  type="monotone" 
                  dataKey="amount" 
                  stroke="#10b981" 
                  strokeWidth={3}
                  fillOpacity={1} 
                  fill="url(#colorAmount)" 
                />
              </AreaChart>
            </ResponsiveContainer>
          </div>
        </div>

        {/* Court Breakdown */}
        <div className="bg-white p-6 rounded-2xl border border-gray-100 shadow-sm space-y-6">
          <h3 className="font-bold text-gray-900 text-lg flex items-center gap-2">
            <LayoutDashboard className="text-blue-600 w-5 h-5" />
            Chi tiết theo từng sân
          </h3>
          <div className="space-y-4 overflow-y-auto max-h-[400px] pr-2 custom-scrollbar">
            {revenueData?.courts.map((court, i) => (
              <div key={i} className="p-4 rounded-xl border border-gray-50 hover:border-emerald-100 hover:bg-emerald-50/30 transition-all duration-300">
                <div className="flex items-center justify-between mb-2">
                  <span className="font-bold text-gray-900 text-sm">{court.courtName}</span>
                  <Badge variant="outline" className="border-gray-200 text-[10px] font-bold text-gray-500">
                    {court.bookingCount} đơn
                  </Badge>
                </div>
                <div className="flex items-center justify-between">
                  <span className="text-xs text-gray-500 font-medium">Doanh thu</span>
                  <span className="text-sm font-black text-emerald-600">{formatCurrency(court.totalRevenue)}</span>
                </div>
                <div className="mt-3 w-full bg-gray-100 h-1.5 rounded-full overflow-hidden">
                  <div 
                    className="bg-emerald-500 h-full rounded-full" 
                    style={{ width: `${(court.totalRevenue / (revenueData.totalRevenue || 1)) * 100}%` }}
                  />
                </div>
              </div>
            ))}
          </div>
          <Button variant="outline" className="w-full rounded-xl border-gray-200 text-xs font-bold h-10 group">
            Xem tất cả <ChevronRight size={14} className="ml-1 group-hover:translate-x-1 transition-transform" />
          </Button>
        </div>
      </div>
    </div>
  );
};

export default OwnerRevenuePage;
