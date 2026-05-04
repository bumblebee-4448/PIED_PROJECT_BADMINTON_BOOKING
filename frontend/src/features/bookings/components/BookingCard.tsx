import { 
  MapPin, 
  Calendar, 
  Clock, 
  Layout, 
  Flag, 
  ChevronRight,
  CheckCircle2,
  XCircle,
  Clock3
} from "lucide-react";
import { cn } from "@/lib/utils";
import { Button } from "@/shared/components/ui/button";
import type { BookingHistoryItem, BookingStatus } from "../types";

interface BookingCardProps {
  booking: BookingHistoryItem;
  onCancelClick?: (id: string) => void;
  onViewDetail?: (id: string) => void;
}

export function BookingCard({ booking, onCancelClick, onViewDetail }: BookingCardProps) {
  const getStatusConfig = (status: BookingStatus) => {
    switch (status) {
      case "Banked":
        return {
          label: "Đã chuyển khoản",
          icon: <CheckCircle2 size={14} />,
          className: "bg-emerald-50 text-emerald-600 border-emerald-100",
        };
      case "Complete":
        return {
          label: "Hoàn thành",
          icon: <CheckCircle2 size={14} />,
          className: "bg-blue-50 text-blue-600 border-blue-100",
        };
      case "Cancel":
      case "Cancelled":
        return {
          label: "Đã hủy",
          icon: <XCircle size={14} />,
          className: "bg-red-50 text-red-600 border-red-100",
        };
      case "RefundPending":
        return {
          label: "Chờ hoàn tiền",
          icon: <Clock3 size={14} />,
          className: "bg-orange-50 text-orange-600 border-orange-100",
        };
      default:
        return {
          label: status,
          icon: <Clock3 size={14} />,
          className: "bg-gray-50 text-gray-600 border-gray-100",
        };
    }
  };

  const statusConfig = getStatusConfig(booking.status);

  return (
    <div className="bg-white rounded-3xl border border-gray-100 shadow-sm hover:shadow-xl transition-all duration-500 overflow-hidden group mb-6">
      <div className="p-6 md:p-8">
        {/* Header */}
        <div className="flex flex-col md:flex-row justify-between items-start md:items-center gap-4 mb-8">
          <div>
            <h3 className="text-xl font-black text-gray-900 mb-1 group-hover:text-[#00897B] transition-colors">
              {booking.courtName || "Sân Cầu Lông"}
            </h3>
            <div className="flex items-center gap-1.5 text-gray-400 text-sm">
              <MapPin size={14} />
              <span>{booking.courtAddress || "Địa chỉ chưa cập nhật"}</span>
            </div>
          </div>
          <div className={cn(
            "px-4 py-1.5 rounded-full text-xs font-bold flex items-center gap-2 border",
            statusConfig.className
          )}>
            {statusConfig.icon}
            {statusConfig.label}
          </div>
        </div>

        {/* Info Grid */}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4 mb-8">
          <div className="bg-gray-50/50 rounded-2xl p-4 border border-gray-100/50 flex flex-col items-center justify-center text-center">
            <span className="text-[10px] uppercase tracking-widest font-black text-gray-400 mb-2">Ngày</span>
            <div className="flex items-center gap-2 font-bold text-gray-700">
              <Calendar size={16} className="text-[#00897B]" />
              <span>{booking.date}</span>
            </div>
          </div>
          <div className="bg-gray-50/50 rounded-2xl p-4 border border-gray-100/50 flex flex-col items-center justify-center text-center">
            <span className="text-[10px] uppercase tracking-widest font-black text-gray-400 mb-2">Giờ</span>
            <div className="flex items-center gap-2 font-bold text-gray-700">
              <Clock size={16} className="text-[#00897B]" />
              <span>{booking.startTime} - {booking.endTime}</span>
            </div>
          </div>
          <div className="bg-gray-50/50 rounded-2xl p-4 border border-gray-100/50 flex flex-col items-center justify-center text-center">
            <span className="text-[10px] uppercase tracking-widest font-black text-gray-400 mb-2">Sân con</span>
            <div className="flex items-center gap-2 font-bold text-gray-700">
              <Layout size={16} className="text-[#00897B]" />
              <span>{booking.subCourtName}</span>
            </div>
          </div>
        </div>

        {/* Footer Area */}
        <div className="flex flex-col md:flex-row justify-between items-center pt-6 border-t border-gray-50 gap-6">
          <div className="flex flex-col">
            <span className="text-2xl font-black text-[#00897B]">
              {booking.price?.toLocaleString()}đ
            </span>
            <span className="text-[10px] text-gray-400 font-bold uppercase tracking-tighter">
              #{booking.bookingId?.substring(0, 8)} • {booking.createdAt}
            </span>
          </div>

          <div className="flex items-center gap-4 w-full md:w-auto">
            {booking.status === "Banked" && (
              <Button
                variant="ghost"
                onClick={() => onCancelClick?.(booking.id)}
                className="flex-1 md:flex-none text-red-500 font-bold text-sm hover:text-red-600 hover:bg-red-50 transition-colors px-4 rounded-2xl"
              >
                Hủy đặt sân
              </Button>
            )}
            
            {booking.status === "Complete" && (
              <Button
                variant="ghost"
                className="flex-1 md:flex-none flex items-center justify-center gap-2 text-gray-500 font-bold text-sm hover:text-gray-700 hover:bg-gray-100 transition-colors px-4 rounded-2xl"
              >
                <Flag size={14} />
                Báo cáo
              </Button>
            )}

            <Button 
              variant="ghost"
              onClick={() => onViewDetail?.(booking.id)}
              className="flex-1 md:flex-none group/btn hover:bg-emerald-50 rounded-2xl h-12 px-6"
            >
              <span className="font-bold text-[#00897B] mr-2">Xem chi tiết</span>
              <ChevronRight size={18} className="text-[#00897B] group-hover/btn:translate-x-1 transition-transform" />
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
}
