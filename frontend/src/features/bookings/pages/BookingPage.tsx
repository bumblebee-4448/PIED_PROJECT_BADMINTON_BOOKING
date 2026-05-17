import { useState, useMemo, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { format } from "date-fns";
import {
  ChevronLeft,
  Calendar as CalendarIcon,
  MapPin,
  Loader2,
  AlertCircle
} from "lucide-react";

import { useSubCourts } from "../hooks/useSubCourts";
import {
  useCreateBooking,
  useCreateBookingByWallet,
} from "../hooks/useBookingOperations";
import { BookingPaymentSummary } from "../components/BookingPaymentSummary";
import { WalletConfirmDialog } from "../components/WalletConfirmDialog";
import { useCourtDetail } from "@/features/courts/hooks/useCourts";
import { useWallet } from "@/features/wallet";
import type { AvailableSlot, SubCourt } from "../types";
import { toast } from "sonner";
import { BookingTimeline } from "../components/BookingTimeline";

export function BookingPage() {
  const { id: courtId } = useParams<{ id: string }>();
  const navigate = useNavigate();

  // State
  const [selectedDate, setSelectedDate] = useState<Date>(new Date());

  const [selectedSlots, setSelectedSlots] = useState<AvailableSlot[]>([]);

  const [isWalletConfirmOpen, setIsWalletConfirmOpen] = useState(false);
  const [pendingPayment, setPendingPayment] = useState<any>(null);

  // Check for cached payment
  useEffect(() => {
    const cached = localStorage.getItem('rallyhub_pending_payment');
    if (cached) {
      try {
        const parsed = JSON.parse(cached);
        if (parsed.type === "booking" && parsed.expiredAt && new Date(parsed.expiredAt).getTime() > Date.now()) {
          setPendingPayment(parsed);
        } else if (parsed.type === "booking") {
          localStorage.removeItem('rallyhub_pending_payment');
        }
      } catch {}
    }
  }, []);

  // Queries
  const { data: court, isLoading: isCourtLoading } = useCourtDetail(
    courtId || "",
  );
  const { data: subCourts, isLoading: isSubCourtsLoading } = useSubCourts(
    courtId || "",
  );
  const { useWalletInfo } = useWallet();
  const { data: wallet } = useWalletInfo();

  // Normalize sub-courts data (handle both array and paginated object)
  const subCourtsList = useMemo(() => {
    if (!subCourts) return [];
    if (Array.isArray(subCourts)) return subCourts;

    // Handle wrapped response from BE
    const data = subCourts as any;
    const items = data.subCourts || data.SubCourts || data.items || [];

    if (Array.isArray(items)) {
      return items.map((item: any) => ({
        subCourtId: item.subCourtId || item.id || item.Id,
        name: item.name || item.Name,
        courtId: item.courtId || courtId,
      })) as SubCourt[];
    }

    return [];
  }, [subCourts, courtId]);

  const formattedDate = format(selectedDate, "yyyy-MM-dd");

  // Mutations
  const createBooking = useCreateBooking();
  const createBookingByWallet = useCreateBookingByWallet();

  // Handlers
  const handleToggleSlot = (slot: AvailableSlot & { subCourtId: string }) => {
    // Block selecting past, booked, or blocked slots
    if (slot.type === "Blocked" || slot.type === "Booked") return;
    
    const now = new Date();
    const slotDate = new Date(selectedDate);
    const [h, m] = slot.startTime.split(":").map(Number);
    slotDate.setHours(h, m, 0, 0);
    if (slotDate < now) return;

    setSelectedSlots((prev) => {
      const exists = prev.find(
        (s) =>
          (s as any).subCourtId === slot.subCourtId &&
          s.startTime === slot.startTime &&
          s.endTime === slot.endTime,
      );

      if (exists) {
        return prev.filter((s) => s !== exists);
      }
      return [...prev, slot];
    });
  };

  const handleBookBank = async () => {
    if (selectedSlots.length === 0) return;

    // Group selected slots by subCourtId
    const groupedItems = selectedSlots.reduce(
      (acc, slot) => {
        const subCourtId = (slot as any).subCourtId;
        if (!acc[subCourtId]) {
          acc[subCourtId] = { subCourtId, slots: [] };
        }
        acc[subCourtId].slots.push({
          startTime: slot.startTime,
          endTime: slot.endTime,
        });
        return acc;
      },
      {} as Record<
        string,
        { subCourtId: string; slots: { startTime: string; endTime: string }[] }
      >,
    );

    try {
      const result = await createBooking.mutateAsync({
        date: formattedDate,
        items: Object.values(groupedItems),
      });

      navigate("/payment", {
        state: {
          qrCodeUrl: result.qrCodeUrl,
          amount: result.totalPrice,
          transactionId: result.bookingId,
          transactionCode: `#${result.bookingId.split('-')[0].toUpperCase()}`,
          content: "Thanh toán đặt sân",
          bankName: result.bankName,
          bankAccount: result.bankAccount,
          expiredAt: result.expiredAt,
          type: "booking",
          items: result.items,
        }
      });
    } catch {
      toast.error("Không thể tạo đơn đặt sân. Vui lòng thử lại.");
    }
  };

  const handleBookWallet = () => {
    if (selectedSlots.length === 0) return;
    setIsWalletConfirmOpen(true);
  };

  const handleConfirmWalletPayment = async () => {
    if (selectedSlots.length === 0) return;

    // Group selected slots by subCourtId
    const groupedItems = selectedSlots.reduce(
      (acc, slot) => {
        const subCourtId = (slot as any).subCourtId;
        if (!acc[subCourtId]) {
          acc[subCourtId] = { subCourtId, slots: [] };
        }
        acc[subCourtId].slots.push({
          startTime: slot.startTime,
          endTime: slot.endTime,
        });
        return acc;
      },
      {} as Record<
        string,
        { subCourtId: string; slots: { startTime: string; endTime: string }[] }
      >,
    );

    try {
      await createBookingByWallet.mutateAsync({
        date: formattedDate,
        items: Object.values(groupedItems),
      });
      toast.success("Đặt sân thành công bằng ví!");
      setIsWalletConfirmOpen(false);
      navigate("/history");
    } catch {
      toast.error("Thanh toán bằng ví thất bại. Vui lòng kiểm tra số dư.");
    }
  };

  const isLoading = isCourtLoading || isSubCourtsLoading;

  if (isLoading) {
    return (
      <div className="min-h-screen flex items-center justify-center bg-[#F9FBFA]">
        <div className="flex flex-col items-center gap-4">
          <div className="relative">
            <div className="absolute inset-0 bg-emerald-500/20 blur-2xl rounded-full animate-pulse" />
            <Loader2
              size={48}
              className="text-emerald-500 animate-spin relative"
            />
          </div>
          <p className="text-gray-400 font-black uppercase tracking-widest animate-pulse">
            ĐANG TẢI DỮ LIỆU...
          </p>
        </div>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-[#F9FBFA] pb-32 pt-20">
      <WalletConfirmDialog
        isOpen={isWalletConfirmOpen}
        onClose={() => setIsWalletConfirmOpen(false)}
        onConfirm={handleConfirmWalletPayment}
        totalPrice={selectedSlots.reduce((sum, s) => sum + s.price, 0)}
        slotCount={selectedSlots.length}
        date={selectedDate}
        walletBalance={wallet?.balance}
        isLoading={createBookingByWallet.isPending}
      />

      <div className="max-w-7xl mx-auto px-4 sm:px-6">
        {pendingPayment && (
          <div className="mb-6 p-4 bg-amber-50 border border-amber-200 rounded-2xl flex items-center justify-between shadow-sm animate-in fade-in slide-in-from-top-4">
            <div className="flex items-center gap-3">
              <AlertCircle className="text-amber-500 w-8 h-8" />
              <div>
                <p className="text-sm font-bold text-amber-900">Bạn có một giao dịch đang chờ thanh toán</p>
                <p className="text-xs font-medium text-amber-700">Hệ thống đã lưu lại hóa đơn bị gián đoạn. Giao dịch sẽ hết hạn trong ít phút.</p>
              </div>
            </div>
            <button 
              onClick={() => navigate("/payment", { state: pendingPayment })} 
              className="px-6 py-2.5 bg-amber-500 hover:bg-amber-600 text-white font-bold rounded-xl shadow-sm transition-all active:scale-95 text-xs whitespace-nowrap"
            >
              Tiếp tục thanh toán
            </button>
          </div>
        )}

        {/* Breadcrumbs / Back */}
        <button
          onClick={() => navigate(-1)}
          className="flex items-center gap-2 text-gray-400 hover:text-[#0B2421] transition-colors mb-8 group"
        >
          <div className="p-2 bg-white rounded-xl border border-gray-100 shadow-sm group-hover:scale-110 transition-transform">
            <ChevronLeft size={16} />
          </div>
          <span className="text-[10px] font-black uppercase tracking-[0.2em]">
            Quay lại
          </span>
        </button>

        {/* Page Header */}
        <div className="flex flex-col md:flex-row md:items-end justify-between gap-8 mb-6">
          <div className="space-y-3">
            <div className="inline-flex items-center gap-2 px-3 py-1 bg-emerald-50 text-emerald-600 rounded-full text-[10px] font-bold">
              Tiện ích đặt sân
            </div>
            <h1 className="text-4xl md:text-5xl font-bold text-[#0B2421] leading-tight">
              Đặt sân <span className="text-emerald-500">{court?.name}</span>
            </h1>
            <div className="flex flex-wrap items-center gap-4">
              <div className="flex items-center gap-2 px-4 py-2 bg-white rounded-2xl border border-gray-100 shadow-sm">
                <MapPin size={14} className="text-emerald-500" />
                <span className="text-xs font-bold text-gray-600">
                  {court?.address}
                </span>
              </div>
            </div>
          </div>

          <div className="flex flex-col gap-2 min-w-[280px]">
            <p className="text-[10px] font-bold text-gray-400 ml-1">
              Chọn ngày
            </p>
            <div className="relative group">
              <div className="absolute inset-0 bg-emerald-500/5 group-hover:bg-emerald-500/10 blur-xl rounded-full transition-all" />
              <div className="relative">
                <div className="absolute left-4 top-1/2 -translate-y-1/2 text-emerald-500 pointer-events-none">
                  <CalendarIcon size={18} />
                </div>
                <input
                  type="date"
                  value={formattedDate}
                  min={format(new Date(), "yyyy-MM-dd")}
                  onChange={(e) => {
                    const [year, month, day] = e.target.value
                      .split("-")
                      .map(Number);
                    setSelectedDate(new Date(year, month - 1, day));
                    setSelectedSlots([]); // Clear slots on date change
                  }}
                  className="w-full h-14 pl-12 pr-4 rounded-2xl border-2 border-gray-100 bg-white font-bold text-xs focus:border-emerald-500 focus:outline-none transition-all appearance-none cursor-pointer"
                />
              </div>
            </div>
          </div>
        </div>

        {/* New Unified Timeline View */}
        <div className="space-y-2">
          <p className="text-[10px] font-bold text-gray-400 ml-1">
            Lịch thi đấu chi tiết
          </p>
          <BookingTimeline
            subCourts={subCourtsList}
            selectedDate={selectedDate}
            selectedSlots={selectedSlots}
            onToggleSlot={handleToggleSlot}
          />
        </div>
      </div>

      <BookingPaymentSummary
        selectedSlots={selectedSlots}
        onBookBank={handleBookBank}
        onBookWallet={handleBookWallet}
        isLoading={createBooking.isPending || createBookingByWallet.isPending}
      />
    </div>
  );
}
