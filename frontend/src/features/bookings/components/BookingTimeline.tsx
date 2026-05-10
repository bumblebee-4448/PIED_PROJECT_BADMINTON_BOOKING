import { 
  Clock, 
  Info
} from "lucide-react";
import { Badge } from "@/shared/components/ui/badge";
import { cn } from "@/lib/utils";
import { format, isSameDay } from "date-fns";
import { vi } from "date-fns/locale";
import { useAvailableSlots } from "../hooks";
import type { AvailableSlot, SubCourt } from "../types";

// Generate time slots from 05:00 to 23:00 with 30min intervals
const TIME_SLOTS = Array.from({ length: 37 }, (_, i) => {
  const hour = Math.floor(i / 2) + 5;
  const minute = i % 2 === 0 ? "00" : "30";
  return `${hour.toString().padStart(2, "0")}:${minute}`;
});

interface BookingTimelineProps {
  subCourts: SubCourt[];
  selectedDate: Date;
  selectedSlots: AvailableSlot[];
  onToggleSlot: (slot: AvailableSlot & { subCourtId: string }) => void;
}

export function BookingTimeline({ 
  subCourts, 
  selectedDate, 
  selectedSlots, 
  onToggleSlot,
}: BookingTimelineProps) {
  const subCourtQueries = useAvailableSlots(subCourts, selectedDate);
  const isToday = isSameDay(selectedDate, new Date());
  const now = new Date();
  const currentHour = now.getHours();
  const currentMinute = now.getMinutes();



  const isSlotSelected = (slot: AvailableSlot, subId: string) => {
    return selectedSlots.some(s => 
      (s as any).subCourtId === subId && 
      s.startTime === slot.startTime && 
      s.endTime === slot.endTime
    );
  };

  return (
    <div className="bg-white rounded-[2.5rem] border border-gray-100 shadow-xl shadow-emerald-900/5 overflow-hidden flex flex-col h-[600px]">
      {/* Header Info */}
      <div className="p-6 border-b border-gray-50 flex items-center justify-between bg-white sticky top-0 z-10">
        <div className="flex items-center gap-4">
          <div className="bg-emerald-50 p-3 rounded-2xl text-emerald-600">
            <Clock size={24} />
          </div>
          <div>
            <h2 className="text-lg font-black text-[#0B2421]">Sơ đồ sân trống</h2>
            <p className="text-xs text-gray-500 font-bold uppercase tracking-widest">
              {format(selectedDate, "EEEE, dd 'tháng' MM", { locale: vi })}
            </p>
          </div>
        </div>

        <div className="flex items-center gap-6">
          <div className="flex items-center gap-2">
            <div className="w-3 h-3 rounded-full bg-emerald-50 border border-emerald-100" />
            <span className="text-[10px] font-black text-gray-400 uppercase tracking-wider">Trống</span>
          </div>
          <div className="flex items-center gap-2">
            <div className="w-3 h-3 rounded-full bg-emerald-500 shadow-lg shadow-emerald-500/20" />
            <span className="text-[10px] font-black text-gray-400 uppercase tracking-wider">Đang chọn</span>
          </div>
          <div className="flex items-center gap-2">
            <div className="w-3 h-3 rounded-full bg-gray-100 border border-gray-200" />
            <span className="text-[10px] font-black text-gray-400 uppercase tracking-wider">Đã đặt</span>
          </div>
        </div>
      </div>

      {/* Timeline Grid */}
      <div className="flex-1 overflow-auto relative">
        <div className="min-w-[1400px]">
          {/* Time Header */}
          <div className="flex border-b border-gray-100 bg-gray-50/50 sticky top-0 z-20">
            <div className="w-48 shrink-0 border-r border-gray-100 p-4 bg-gray-50 flex items-center gap-2">
              <span className="text-[10px] font-black text-gray-400 uppercase tracking-[0.2em]">Sân con</span>
            </div>
            <div className="flex flex-1">
              {TIME_SLOTS.map((time, idx) => (
                <div 
                  key={time} 
                  className={cn(
                    "flex-1 text-center py-3 text-[10px] font-black text-gray-400 border-r border-gray-100/50 uppercase tracking-tighter",
                    idx % 2 !== 0 && "bg-gray-100/20"
                  )}
                >
                  {time}
                </div>
              ))}
            </div>
          </div>

          {/* Sub-court Rows */}
          <div className="divide-y divide-gray-100">
            {subCourts.map((sub, rowIndex) => {
              const query = subCourtQueries[rowIndex];
              const slots = (query.data as any[]) || [];
              
              return (
                <div key={sub.subCourtId} className="flex group hover:bg-emerald-50/10 transition-colors relative">
                  {/* Sub-court info */}
                  <div className="w-48 shrink-0 border-r border-gray-100 p-5 bg-white sticky left-0 z-10 shadow-[4px_0_12px_rgba(0,0,0,0.02)]">
                    <p className="font-black text-sm text-[#0B2421] truncate">{sub.name}</p>
                    <div className="flex items-center gap-1.5 mt-1">
                      <div className="w-1.5 h-1.5 rounded-full bg-emerald-500" />
                      <p className="text-[9px] font-bold text-gray-400 uppercase tracking-widest">Sẵn sàng</p>
                    </div>
                  </div>

                  {/* Slots row container */}
                  <div className="flex-1 relative h-20 bg-white">
                    {/* Background Grid Lines */}
                    <div className="absolute inset-0 flex pointer-events-none">
                      {TIME_SLOTS.slice(0, -1).map((time) => (
                        <div key={time} className="flex-1 border-r border-gray-50" />
                      ))}
                    </div>

                    {query.isLoading ? (
                      <div className="absolute inset-0 flex items-center justify-center px-6">
                        <div className="w-full h-3 bg-emerald-50 animate-pulse rounded-full" />
                      </div>
                    ) : (
                      <div className="absolute inset-0">
                        {slots.map((slot, slotIdx) => {
                          const [sH, sM] = slot.startTime.split(':').map(Number);
                          const isPast = isToday && (sH < currentHour || (sH === currentHour && sM < currentMinute));
                          const [eH, eM] = slot.endTime.split(':').map(Number);
                          
                          // Clamp times to timeline range (05:00 - 23:00)
                          const startMins = Math.max(0, (sH - 5) * 60 + sM);
                          const endMins = Math.min(1080, (eH - 5) * 60 + eM);
                          
                          if (startMins >= endMins) return null;

                          const left = (startMins / 1080) * 100;
                          const width = ((endMins - startMins) / 1080) * 100;
                          
                          const durationMins = endMins - startMins;
                          const selected = isSlotSelected(slot, sub.subCourtId);
                          const disabled = !slot.isAvailable || isPast;

                          return (
                            <div 
                              key={`${slot.startTime}-${slotIdx}`}
                              className="absolute h-full py-2.5 px-0.5 transition-all duration-300"
                              style={{ left: `${left}%`, width: `${width}%` }}
                            >
                              <div 
                                onClick={() => !disabled && onToggleSlot({ ...slot, subCourtId: sub.subCourtId })}
                                className={cn(
                                  "w-full h-full rounded-2xl border-2 flex flex-col items-center justify-center gap-0.5 transition-all relative group/slot overflow-hidden",
                                  selected 
                                    ? "bg-emerald-500 border-emerald-600 text-white shadow-lg shadow-emerald-500/30 scale-[1.02] z-10" 
                                    : disabled
                                      ? "bg-gray-100 border-gray-200 text-gray-300 cursor-not-allowed"
                                      : "bg-emerald-50/30 border-emerald-100/50 text-emerald-700 hover:border-emerald-500 hover:bg-emerald-50 cursor-pointer"
                                )}
                              >
                                <span className={cn(
                                  "text-[10px] font-black leading-none",
                                  durationMins < 45 && "hidden"
                                )}>
                                  {slot.startTime.substring(0, 5)}
                                </span>
                                {durationMins >= 60 && (
                                  <span className={cn(
                                    "text-[8px] font-bold leading-none opacity-80",
                                    selected ? "text-emerald-100" : "text-emerald-600/60"
                                  )}>
                                    {(slot.price ?? 0).toLocaleString()}đ
                                  </span>
                                )}

                                {/* Selection Indicator */}
                                {selected && (
                                  <div className="absolute top-1 right-1 w-1.5 h-1.5 rounded-full bg-white animate-pulse" />
                                )}

                                {/* Hover Tooltip */}
                                <div className={cn(
                                  "absolute left-1/2 -translate-x-1/2 w-40 p-3 bg-[#0B2421] text-white text-[10px] rounded-2xl opacity-0 group-hover/slot:opacity-100 pointer-events-none transition-all z-50 shadow-2xl border border-white/10",
                                  rowIndex === 0 ? "top-[110%]" : "bottom-[110%]"
                                )}>
                                  <div className="flex items-center justify-between border-b border-white/10 pb-2 mb-2">
                                    <span className="font-black text-emerald-400">{slot.startTime.substring(0, 5)} - {slot.endTime.substring(0, 5)}</span>
                                    <Badge variant="outline" className="text-[8px] h-4 border-white/20 text-white font-black">
                                      {durationMins}'
                                    </Badge>
                                  </div>
                                  <div className="space-y-1">
                                    <p className="font-bold text-gray-400 uppercase tracking-widest text-[8px]">Giá tiền</p>
                                    <p className="text-sm font-black text-emerald-400">{(slot.price ?? 0).toLocaleString()} VNĐ</p>
                                  </div>
                                  {!slot.isAvailable ? (
                                    <p className="mt-2 pt-2 border-t border-white/10 text-rose-400 font-bold italic text-[9px]">Hiện không khả dụng</p>
                                  ) : isPast ? (
                                    <p className="mt-2 pt-2 border-t border-white/10 text-rose-400 font-bold italic text-[9px]">Đã quá giờ đặt</p>
                                  ) : null}
                                </div>
                              </div>
                            </div>
                          );
                        })}
                      </div>
                    )}
                  </div>
                </div>
              );
            })}
          </div>
        </div>
      </div>

      {/* Footer Info */}
      <div className="p-4 border-t border-gray-50 bg-gray-50/50 flex items-center justify-between">
        <div className="flex items-center gap-3 text-[10px] text-gray-400 font-bold uppercase tracking-widest">
          <Info size={14} className="text-emerald-500" />
          <span>Mẹo: Click vào khung giờ màu xanh để chọn. Chỉ có thể chọn sân trong cùng một khu vực.</span>
        </div>
        {selectedSlots.length > 0 && (
          <div className="flex items-center gap-2">
            <span className="text-[10px] font-black text-emerald-600 uppercase">Đã chọn {selectedSlots.length} slot</span>
          </div>
        )}
      </div>
    </div>
  );
}
