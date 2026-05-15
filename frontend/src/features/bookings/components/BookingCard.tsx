import { 
  MapPin, 
  Calendar, 
  Clock, 
  CheckCircle2,
  XCircle,
  Clock3,
  Phone,
  Hash,
  CreditCard
} from "lucide-react";
import { format, parseISO } from "date-fns";
import { cn } from "@/lib/utils";
import { Button } from "@/shared/components/ui/button";
import type { GetBookingResponse, TransactionItem } from "../types";

interface BookingCardProps {
  booking: GetBookingResponse;
  transaction?: TransactionItem;
  onCancelClick?: (id: string) => void;
  onRefundClick?: (id: string) => void;
  onViewPaymentClick?: (transaction: TransactionItem) => void;
}

export function BookingCard({ booking, transaction, onCancelClick, onRefundClick, onViewPaymentClick }: BookingCardProps) {
  const getStatusConfig = (status: string) => {
    switch (status) {
      case "Pending":
        return {
          label: "Chờ thanh toán",
          icon: <Clock3 size={14} />,
          className: "bg-amber-50 text-amber-600 border-amber-100",
        };
      case "Banked":
        return {
          label: "Đã thanh toán",
          icon: <CheckCircle2 size={14} />,
          className: "bg-emerald-50 text-emerald-600 border-emerald-100",
        };
      case "Complete":
      case "Completed":
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
      case "Refund":
        return {
          label: "Đã hoàn tiền",
          icon: <XCircle size={14} />,
          className: "bg-gray-100 text-gray-600 border-gray-200",
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

  const status = booking.status || "Pending";
  const statusConfig = getStatusConfig(status);
  
  const id = booking.bookingId || "";
  const finalPrice = booking.finalPrice || 0;
  const courtName = booking.courtName || "Đơn hàng";
  const address = booking.address || "Thông tin địa chỉ đang cập nhật";
  const slotsResponses = booking.slotsResponses || [];
  const rawDate = booking.date || (slotsResponses.length > 0 ? slotsResponses[0].date : null);
  const date = rawDate ? format(parseISO(rawDate), "dd/MM/yyyy") : "N/A";
  const phoneNumber = booking.phoneNumber || "N/A";
  const urlMap = booking.urlMap;

  return (
    <div className="bg-white rounded-3xl border border-gray-100 shadow-sm hover:shadow-xl transition-all duration-500 overflow-hidden group mb-6">
      <div className="p-6 md:p-8">
        {/* Header */}
        <div className="flex flex-col md:flex-row justify-between items-start md:items-center gap-4 mb-8">
          <div>
            <h3 className="text-xl font-black text-gray-900 mb-1 group-hover:text-[#00897B] transition-colors">
              {courtName}
            </h3>
            <div className="flex items-center gap-1.5 text-gray-400 text-sm">
              <MapPin size={14} />
              <span>{address}</span>
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
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mb-8">
          <div className="bg-gray-50/50 rounded-2xl p-4 border border-gray-100/50 flex flex-col items-center justify-center text-center">
            <span className="text-[10px] uppercase tracking-widest font-black text-gray-400 mb-2">Ngày đặt</span>
            <div className="flex items-center gap-2 font-bold text-gray-700">
              <Calendar size={16} className="text-[#00897B]" />
              <span>{date}</span>
            </div>
          </div>
          <div className="bg-gray-50/50 rounded-2xl p-4 border border-gray-100/50 flex flex-col items-center justify-center text-center">
            <span className="text-[10px] uppercase tracking-widest font-black text-gray-400 mb-2">Liên hệ</span>
            <div className="flex items-center gap-2 font-bold text-gray-700">
              <Phone size={16} className="text-[#00897B]" />
              <span>{phoneNumber}</span>
            </div>
          </div>
          {transaction && (
            <div className="bg-emerald-50/30 rounded-2xl p-4 border border-emerald-100/50 flex flex-col items-center justify-center text-center md:col-span-2">
              <span className="text-[10px] uppercase tracking-widest font-black text-emerald-600 mb-2">Ngày chuyển khoản</span>
              <div className="flex items-center gap-2 font-bold text-emerald-700">
                <Calendar size={16} className="text-emerald-500" />
                <span>{format(parseISO(transaction.createdAt), "HH:mm - dd/MM/yyyy")}</span>
              </div>
            </div>
          )}
        </div>

        {/* Slots List */}
        <div className="space-y-3 mb-8">
          <p className="text-[10px] font-black text-gray-400 uppercase tracking-widest ml-1">Danh sách Slot ({slotsResponses.length})</p>
          <div className="flex flex-wrap gap-2">
            {slotsResponses.length > 0 ? (
              slotsResponses.map((slot) => (
                <div 
                  key={slot.slotId}
                  className="px-4 py-2 bg-emerald-50/50 rounded-xl border border-emerald-100 flex items-center gap-3"
                >
                  <Clock size={14} className="text-emerald-500" />
                  <span className="text-xs font-black text-[#0B2421]">
                    {(slot.startTime || "").slice(0, 5)} - {(slot.endTime || "").slice(0, 5)}
                  </span>
                  <span className="text-[10px] font-bold text-emerald-600">
                    {(slot.price || 0).toLocaleString()}đ
                  </span>
                </div>
              ))
            ) : (
              <div className="flex items-center gap-2 text-gray-400 italic text-sm ml-1">
                <Clock size={14} />
                <span>Không có thông tin slot</span>
              </div>
            )}
          </div>
        </div>

        {/* Footer Area */}
        <div className="flex flex-col md:flex-row justify-between items-center pt-6 border-t border-gray-50 gap-6">
          <div className="flex flex-col">
            <span className="text-2xl font-black text-[#00897B]">
              {finalPrice.toLocaleString()}đ
            </span>
            <span className="text-[10px] text-gray-400 font-bold uppercase tracking-tighter flex items-center gap-1">
              <Hash size={10} />
              Mã đơn: {id.toString().substring(0, 8)}
            </span>
          </div>

          <div className="flex items-center gap-4 w-full md:w-auto">
            {(status === "Pending" || status === "Banked") && (
              <Button
                variant="ghost"
                onClick={() => onCancelClick?.(id)}
                className={cn(
                  "flex-1 md:flex-none font-bold text-sm transition-colors px-4 rounded-2xl",
                  status === "Pending" 
                    ? "text-red-500 hover:text-red-600 hover:bg-red-50" 
                    : "text-orange-500 hover:text-orange-600 hover:bg-orange-50"
                )}
              >
                {status === "Pending" ? "Hủy đơn" : "Hủy & Hoàn tiền"}
              </Button>
            )}

            {transaction && (
              <Button
                variant="outline"
                onClick={() => onViewPaymentClick?.(transaction)}
                className="flex-1 md:flex-none border-emerald-100 text-[#00897B] font-bold text-sm hover:bg-emerald-50 transition-colors px-4 rounded-2xl h-12"
              >
                <CreditCard size={16} className="mr-2" />
                Chi tiết thanh toán
              </Button>
            )}
            
            {urlMap && (
              <Button 
                variant="ghost"
                onClick={() => window.open(urlMap, "_blank")}
                className="flex-1 md:flex-none group/btn hover:bg-emerald-50 rounded-2xl h-12 px-6"
              >
                <span className="font-bold text-[#00897B] mr-2">Bản đồ</span>
                <MapPin size={18} className="text-[#00897B]" />
              </Button>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}
