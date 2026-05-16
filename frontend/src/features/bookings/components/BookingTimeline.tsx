import { 
  Clock, 
  Info
} from "lucide-react";
import { format } from "date-fns";
import { vi } from "date-fns/locale";
import { useAvailableSlots } from "../hooks";
import type { AvailableSlot, SubCourt } from "../types";
import { CourtScheduleGrid } from "@/shared/components/CourtScheduleGrid";


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



  const isSlotSelected = (slot: AvailableSlot, subId: string) => {
    return selectedSlots.some(s => 
      (s as any).subCourtId === subId && 
      s.startTime === slot.startTime && 
      s.endTime === slot.endTime
    );
  };

  return (
    <div className="bg-white rounded-2xl border border-gray-100 shadow-xl shadow-emerald-900/5 overflow-hidden flex flex-col min-h-[600px]">
      {/* Header Info */}
      <div className="px-6 py-3 flex items-center justify-between bg-white sticky top-0 z-10">
        <div className="flex items-center gap-3">
          <div className="bg-emerald-50 p-2 rounded-xl text-emerald-600">
            <Clock size={18} />
          </div>
          <div>
            <h2 className="text-sm font-bold text-[#0B2421]">Chọn ngày</h2>
            <p className="text-[10px] text-gray-400 font-medium">
              {format(selectedDate, "EEEE, dd 'tháng' MM", { locale: vi })}
            </p>
          </div>
        </div>

      </div>

      {/* Timeline Grid (New Grid Design) */}
      <div className="relative px-6 py-2 bg-slate-50/10">
        <CourtScheduleGrid 
          subCourts={subCourts.map((sub, idx) => ({
            id: sub.subCourtId,
            name: sub.name,
            slots: (subCourtQueries[idx].data as any[]) || []
          }))}
          startTime="05:00"
          endTime="23:30"
          selectedDate={selectedDate}
          isLoading={subCourtQueries.some(q => q.isLoading)}
          isSlotSelected={(subId, slot) => isSlotSelected(slot as any, subId)}
          isSlotDisabled={(_subId, slot) => !slot.isAvailable || slot.type === "Blocked"}
          onSlotClick={(subId, slot) => {
            onToggleSlot({ ...(slot as any), subCourtId: subId });
          }}
        />
      </div>

      {/* Footer Info */}
      <div className="p-4 bg-gray-50/30 flex items-center justify-between">
        <div className="flex items-center gap-3 text-[10px] text-gray-400 font-medium">
          <Info size={14} className="text-emerald-500" />
          <span>Mẹo: Click vào khung giờ màu xanh để chọn. Chỉ có thể chọn sân trong cùng một khu vực.</span>
        </div>
        {selectedSlots.length > 0 && (
          <div className="flex items-center gap-2">
            <span className="text-[10px] font-bold text-emerald-600">Đã chọn {selectedSlots.length} slot</span>
          </div>
        )}
      </div>
    </div>
  );
}
