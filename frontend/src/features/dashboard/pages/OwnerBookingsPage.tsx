import { useState } from "react";
import {
  CalendarCheck,
  ChevronLeft,
  ChevronRight,
  Search,
} from "lucide-react";
import { format, parseISO } from "date-fns";
import { vi } from "date-fns/locale";
import { cn } from "@/lib/utils";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/shared/components/ui/select";
import { useOwnerCourts } from "@/features/owner-courts/hooks/useOwnerCourts";
import { useOwnerCourtBookings } from "../hooks/useOwnerDashboard";

// ─── Period config ────────────────────────────────────────────────────────────

const PERIODS = [
  { value: "week",    label: "Tuần này" },
  { value: "month",  label: "Tháng này" },
  { value: "quarter",label: "Quý này" },
  { value: "year",   label: "Năm này" },
];

// ─── Status badges (Simplified) ────────────────────────────────────────────────

const statusConfig: Record<string, { label: string; cls: string }> = {
  Paid:       { label: "Đã thanh toán", cls: "text-emerald-600 bg-emerald-50" },
  Banked:     { label: "Đã chuyển khoản", cls: "text-blue-600 bg-blue-50" },
  Pending:    { label: "Chờ xử lý", cls: "text-amber-600 bg-amber-50" },
  Cancelled:  { label: "Đã huỷ", cls: "text-rose-600 bg-rose-50" },
  Completed:  { label: "Hoàn thành", cls: "text-violet-600 bg-violet-50" },
};

// ─── Helpers ──────────────────────────────────────────────────────────────────

function fmtCurrency(n: number) {
  return new Intl.NumberFormat("vi-VN", { style: "currency", currency: "VND" }).format(n);
}

function fmtShortDate(iso: string) {
  try { return format(parseISO(iso), "dd/MM/yyyy", { locale: vi }); }
  catch { return iso; }
}

const PAGE_SIZE = 10;

export function OwnerBookingsPage() {
  const [selectedCourtId, setSelectedCourtId] = useState<string>("");
  const [period, setPeriod]                   = useState<string>("month");
  const [pageIndex, setPageIndex]             = useState(1);

  // Fetch courts list
  const { data: courtsData, isLoading: isCourtsLoading } = useOwnerCourts({
    pageIndex: 1,
    pageSize: 100,
  });

  const courts = courtsData?.items ?? [];
  const effectiveCourtId = selectedCourtId || courts[0]?.courtId || "";

  // Fetch bookings (paginated)
  const { data: bookingsData, isLoading: isBookingsLoading } = useOwnerCourtBookings({
    courtId: effectiveCourtId,
    period,
    pageIndex,
    pageSize: PAGE_SIZE,
  });

  const bookings = bookingsData?.items ?? [];
  const totalItems = bookingsData?.totalItems ?? 0;
  const totalPages = Math.ceil(totalItems / PAGE_SIZE) || 1;

  const isLoading = isCourtsLoading || isBookingsLoading;

  return (
    <div className="p-5 sm:p-7 max-w-[1400px] mx-auto space-y-6 animate-in fade-in duration-500">
      
      {/* Header */}
      <div className="flex flex-col sm:flex-row sm:items-center justify-between gap-4">
        <div>
          <h1 className="text-xl font-bold text-gray-900 tracking-tight flex items-center gap-3">
            <CalendarCheck size={24} className="text-indigo-600" />
            Quản lý đặt sân
          </h1>
          <p className="text-sm text-gray-400 mt-1 font-medium">
            Danh sách chi tiết lịch đặt sân từ khách hàng
          </p>
        </div>

        <div className="flex items-center gap-3">
          {!isCourtsLoading && courts.length > 0 && (
            <Select value={effectiveCourtId} onValueChange={(val) => { setSelectedCourtId(val); setPageIndex(1); }}>
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

          <Select value={period} onValueChange={(val) => { setPeriod(val); setPageIndex(1); }}>
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

      {/* Main Table Container */}
      <div className="bg-white rounded-2xl border border-gray-100 shadow-sm overflow-hidden">
        <div className="overflow-x-auto">
          <table className="w-full text-left">
            <thead>
              <tr className="bg-gray-50/50 border-b border-gray-100">
                <th className="py-4 px-6 text-[10px] font-bold text-gray-400 uppercase tracking-widest">Khách hàng</th>
                <th className="py-4 px-6 text-[10px] font-bold text-gray-400 uppercase tracking-widest">Sân</th>
                <th className="py-4 px-6 text-[10px] font-bold text-gray-400 uppercase tracking-widest">Khung giờ</th>
                <th className="py-4 px-6 text-[10px] font-bold text-gray-400 uppercase tracking-widest">Thanh toán</th>
                <th className="py-4 px-6 text-[10px] font-bold text-gray-400 uppercase tracking-widest">Trạng thái</th>
                <th className="py-4 px-6 text-[10px] font-bold text-gray-400 uppercase tracking-widest text-right">Ngày đặt</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-gray-50">
              {isLoading ? (
                Array.from({ length: 5 }).map((_, i) => (
                  <tr key={i}>
                    <td colSpan={6} className="py-6 px-6">
                      <div className="h-6 bg-gray-50 rounded-lg animate-pulse w-full" />
                    </td>
                  </tr>
                ))
              ) : bookings.length === 0 ? (
                <tr>
                  <td colSpan={6} className="py-24 text-center">
                    <div className="flex flex-col items-center gap-3">
                      <Search size={40} className="text-gray-200" />
                      <p className="text-gray-400 text-sm font-semibold">Không tìm thấy dữ liệu đặt sân</p>
                    </div>
                  </td>
                </tr>
              ) : (
                bookings.map((b) => {
                  const badge = statusConfig[b.status] ?? { label: b.status, cls: "text-gray-500 bg-gray-50" };
                  const timeRange = b.slots.length
                    ? `${b.slots[0].startTime.substring(0, 5)} – ${b.slots[b.slots.length - 1].endTime.substring(0, 5)}`
                    : "—";

                  return (
                    <tr key={b.bookingId} className="hover:bg-gray-50/50 transition-colors">
                      <td className="py-4 px-6">
                        <div className="flex flex-col">
                          <span className="text-sm font-semibold text-gray-900">{b.customerName}</span>
                          <span className="text-[11px] text-gray-400">{b.customerPhone}</span>
                        </div>
                      </td>
                      <td className="py-4 px-6">
                        <span className="text-sm font-medium text-gray-600">{b.courtName}</span>
                      </td>
                      <td className="py-4 px-6">
                        <span className="text-[11px] font-bold text-gray-500 bg-gray-100 px-2 py-0.5 rounded-md">
                          {timeRange}
                        </span>
                      </td>
                      <td className="py-4 px-6">
                        <span className="text-sm font-bold text-emerald-600">{fmtCurrency(b.totalPrice)}</span>
                      </td>
                      <td className="py-4 px-6">
                        <span className={cn("inline-flex px-2 py-0.5 rounded-full text-[10px] font-bold uppercase tracking-wider", badge.cls)}>
                          {badge.label}
                        </span>
                      </td>
                      <td className="py-4 px-6 text-right">
                        <span className="text-[11px] text-gray-400 font-medium">{fmtShortDate(b.createdAt)}</span>
                      </td>
                    </tr>
                  );
                })
              )}
            </tbody>
          </table>
        </div>

        {/* Pagination */}
        {!isLoading && totalItems > 0 && (
          <div className="px-6 py-4 bg-gray-50/30 flex items-center justify-between">
            <div className="text-[11px] font-semibold text-gray-400 uppercase tracking-widest">
              Trang {pageIndex} / {totalPages} · {totalItems} đơn
            </div>

            <div className="flex items-center gap-1">
              <button
                onClick={() => setPageIndex(p => Math.max(1, p - 1))}
                disabled={pageIndex === 1}
                className="w-8 h-8 rounded-lg border border-gray-200 bg-white flex items-center justify-center text-gray-600 hover:border-indigo-600 hover:text-indigo-600 disabled:opacity-30 transition-all"
              >
                <ChevronLeft size={16} />
              </button>
              <button
                onClick={() => setPageIndex(p => Math.min(totalPages, p + 1))}
                disabled={pageIndex === totalPages}
                className="w-8 h-8 rounded-lg border border-gray-200 bg-white flex items-center justify-center text-gray-600 hover:border-indigo-600 hover:text-indigo-600 disabled:opacity-30 transition-all"
              >
                <ChevronRight size={16} />
              </button>
            </div>
          </div>
        )}
      </div>
    </div>
  );
}
