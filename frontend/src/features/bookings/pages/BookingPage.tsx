import { useState, useMemo } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { format } from "date-fns";
import { 
  ChevronLeft, 
  Calendar as CalendarIcon, 
  MapPin, 
  Loader2
} from "lucide-react";

import { useSubCourts } from "../hooks/useSubCourts";
import { useCreateBooking, useCreateBookingByWallet } from "../hooks/useBookingOperations";
import { BookingPaymentSummary } from "../components/BookingPaymentSummary";
import { PaymentQrDialog } from "../components/PaymentQrDialog";
import { WalletConfirmDialog } from "../components/WalletConfirmDialog";
import { useCourtDetail } from "@/features/courts/hooks/useCourts";
import { useWallet } from "@/features/wallet";
import type { AvailableSlot, CreateBookingResponse, SubCourt } from "../types";
import { toast } from "sonner";
import { BookingTimeline } from "../components/BookingTimeline";

export function BookingPage() {
  const { id: courtId } = useParams<{ id: string }>();
  const navigate = useNavigate();

  // State
  const [selectedDate, setSelectedDate] = useState<Date>(new Date());

  const [selectedSlots, setSelectedSlots] = useState<AvailableSlot[]>([]);
  const [bookingResponse, setBookingResponse] = useState<CreateBookingResponse | null>(null);
  const [isQrOpen, setIsQrOpen] = useState(false);
  const [isWalletConfirmOpen, setIsWalletConfirmOpen] = useState(false);

  // Queries
  const { data: court, isLoading: isCourtLoading } = useCourtDetail(courtId || "");
  const { data: subCourts, isLoading: isSubCourtsLoading } = useSubCourts(courtId || "");
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
        courtId: item.courtId || courtId
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
    setSelectedSlots(prev => {
      const exists = prev.find(s => 
        (s as any).subCourtId === slot.subCourtId && 
        s.startTime === slot.startTime && 
        s.endTime === slot.endTime
      );
      
      if (exists) {
        return prev.filter(s => s !== exists);
      }
      return [...prev, slot];
    });
  };

  const handleBookBank = async () => {
    if (selectedSlots.length === 0) return;

    // Group selected slots by subCourtId
    const groupedItems = selectedSlots.reduce((acc, slot) => {
      const subCourtId = (slot as any).subCourtId;
      if (!acc[subCourtId]) {
        acc[subCourtId] = { subCourtId, slots: [] };
      }
      acc[subCourtId].slots.push({ 
        startTime: slot.startTime, 
        endTime: slot.endTime 
      });
      return acc;
    }, {} as Record<string, { subCourtId: string; slots: { startTime: string; endTime: string }[] }>);

    try {
      const result = await createBooking.mutateAsync({
        date: formattedDate,
        items: Object.values(groupedItems)
      });
      setBookingResponse(result);
      setIsQrOpen(true);
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
    const groupedItems = selectedSlots.reduce((acc, slot) => {
      const subCourtId = (slot as any).subCourtId;
      if (!acc[subCourtId]) {
        acc[subCourtId] = { subCourtId, slots: [] };
      }
      acc[subCourtId].slots.push({ 
        startTime: slot.startTime, 
        endTime: slot.endTime 
      });
      return acc;
    }, {} as Record<string, { subCourtId: string; slots: { startTime: string; endTime: string }[] }>);

    try {
      await createBookingByWallet.mutateAsync({
        date: formattedDate,
        items: Object.values(groupedItems)
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
            <Loader2 size={48} className="text-emerald-500 animate-spin relative" />
          </div>
          <p className="text-gray-400 font-black uppercase tracking-widest animate-pulse">ĐANG TẢI DỮ LIỆU...</p>
        </div>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-[#F9FBFA] pb-32 pt-20">
      <PaymentQrDialog 
        isOpen={isQrOpen}
        bookingResponse={bookingResponse}
        onClose={() => setIsQrOpen(false)}
        onSuccess={() => {
          setIsQrOpen(false);
          toast.success("Hệ thống đang xác nhận thanh toán của bạn!");
          navigate("/history");
        }}
      />

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
        {/* Breadcrumbs / Back */}
        <button 
          onClick={() => navigate(-1)}
          className="flex items-center gap-2 text-gray-400 hover:text-[#0B2421] transition-colors mb-8 group"
        >
          <div className="p-2 bg-white rounded-xl border border-gray-100 shadow-sm group-hover:scale-110 transition-transform">
            <ChevronLeft size={16} />
          </div>
          <span className="text-[10px] font-black uppercase tracking-[0.2em]">Quay lại</span>
        </button>

        {/* Page Header */}
        <div className="flex flex-col md:flex-row md:items-end justify-between gap-8 mb-12">
          <div className="space-y-4">
            <div className="inline-flex items-center gap-2 px-3 py-1 bg-emerald-50 text-emerald-600 rounded-full text-[10px] font-black uppercase tracking-widest">
              Tiện ích đặt sân
            </div>
            <h1 className="text-4xl md:text-5xl font-black text-[#0B2421] leading-tight">
              Đặt sân <span className="text-emerald-500">{court?.name}</span>
            </h1>
            <div className="flex flex-wrap items-center gap-4">
              <div className="flex items-center gap-2 px-4 py-2 bg-white rounded-2xl border border-gray-100 shadow-sm">
                <MapPin size={14} className="text-emerald-500" />
                <span className="text-xs font-bold text-gray-600">{court?.address}</span>
              </div>
            </div>
          </div>

          <div className="flex flex-col gap-3 min-w-[300px]">
            <p className="text-[10px] font-black text-gray-400 uppercase tracking-widest ml-1">Chọn ngày thi đấu</p>
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
                    const [year, month, day] = e.target.value.split('-').map(Number);
                    setSelectedDate(new Date(year, month - 1, day));
                    setSelectedSlots([]); // Clear slots on date change
                  }}
                  className="w-full h-14 pl-12 pr-4 rounded-2xl border-2 border-gray-100 bg-white font-black text-xs uppercase tracking-widest focus:border-emerald-500 focus:outline-none transition-all appearance-none cursor-pointer"
                />
              </div>
            </div>
          </div>
        </div>

        {/* New Unified Timeline View */}
        <div className="space-y-4">
          <p className="text-[10px] font-black text-gray-400 uppercase tracking-[0.2em] mb-4 ml-1">Lịch thi đấu chi tiết</p>
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
