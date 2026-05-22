import React, { useState, useMemo } from "react";
import { cn } from "@/lib/utils";
import { Search, ZoomIn, ZoomOut, Lock as LockIcon } from "lucide-react";

export interface SlotData {
  startTime: string; // HH:mm
  endTime: string; // HH:mm
  price: number;
  isAvailable: boolean;
  type: "Default" | "Override" | "Booked" | "Blocked";
  bookingDetailId?: string;
  reason?: string;
  [key: string]: any;
}

export interface SubCourtData {
  id: string;
  name: string;
  slots: SlotData[];
}

interface CourtScheduleGridProps {
  subCourts: SubCourtData[];
  startTime?: string; // e.g. "05:00"
  endTime?: string; // e.g. "23:00"
  intervalMinutes?: number; // e.g. 30
  onSlotClick?: (subCourtId: string, slot: SlotData) => void;
  isSlotSelected?: (subCourtId: string, slot: SlotData) => boolean;
  isSlotDisabled?: (subCourtId: string, slot: SlotData) => boolean;
  renderCellExtra?: (subCourtId: string, slot: SlotData) => React.ReactNode;
  isLoading?: boolean;
  selectedDate?: Date;
}

const getEndTimeOfSlot = (startTimeStr: string, intervalMins: number) => {
  const [h, m] = startTimeStr.split(":").map(Number);
  const totalMins = h * 60 + m + intervalMins;
  const endH = Math.floor(totalMins / 60) % 24;
  const endM = totalMins % 60;
  return `${endH.toString().padStart(2, "0")}:${endM.toString().padStart(2, "0")}`;
};

export const CourtScheduleGrid: React.FC<CourtScheduleGridProps> = ({
  subCourts,
  startTime = "05:00",
  endTime = "23:00",
  intervalMinutes = 30,
  onSlotClick,
  isSlotSelected,
  isSlotDisabled,
  renderCellExtra,
  isLoading,
  selectedDate = new Date()
}) => {
  const [zoom, setZoom] = useState(100); // 50 to 200

  // Generate column headers (time slots)
  const timeColumns = useMemo(() => {
    const columns: string[] = [];
    const [startH, startM] = startTime.split(":").map(Number);
    const [endH, endM] = endTime.split(":").map(Number);

    let current = startH * 60 + startM;
    const end = endH * 60 + endM;

    while (current < end) {
      const h = Math.floor(current / 60);
      const m = current % 60;
      columns.push(`${h.toString().padStart(2, "0")}:${m.toString().padStart(2, "0")}`);
      current += intervalMinutes;
    }
    return columns;
  }, [startTime, endTime, intervalMinutes]);

  const columnWidth = useMemo(() => {
    return (zoom / 100) * 140; // Increased base width from 120 to 140
  }, [zoom]);

  // Map slots to grid positions for efficient lookup
  const gridData = useMemo(() => {
    const map = new Map<string, Map<string, SlotData>>();

    subCourts.forEach(sc => {
      const scMap = new Map<string, SlotData>();
      sc.slots.forEach(slot => {
        const [sH, sM] = slot.startTime.split(":").map(Number);
        const [eH, eM] = slot.endTime.split(":").map(Number);

        let current = sH * 60 + sM;
        const end = eH * 60 + eM;

        while (current < end) {
          const h = Math.floor(current / 60);
          const m = current % 60;
          const timeKey = `${h.toString().padStart(2, "0")}:${m.toString().padStart(2, "0")}`;
          scMap.set(timeKey, slot);
          current += intervalMinutes;
        }
      });
      map.set(sc.id, scMap);
    });

    return map;
  }, [subCourts, intervalMinutes]);

  // Helper to group consecutive slots for merging cells
  const getGroupedSlots = (scId: string) => {
    const scMap = gridData.get(scId);
    const groups: { time: string; span: number; slot: SlotData | undefined }[] = [];

    if (!scMap) return [];

    for (let i = 0; i < timeColumns.length; i++) {
      const time = timeColumns[i];
      const slot = scMap.get(time);
      const prevGroup = groups[groups.length - 1];

      // Check if this slot should merge with the previous group
      const canMerge = prevGroup &&
        prevGroup.slot &&
        slot &&
        prevGroup.slot.type === slot.type &&
        (
          (slot.type === "Override" && prevGroup.slot.overrideSlotId === slot.overrideSlotId) ||
          (slot.type === "Blocked" && prevGroup.slot.exceptionId === slot.exceptionId) ||
          (slot.type === "Booked" && prevGroup.slot.bookingDetailId === slot.bookingDetailId)
        );

      if (canMerge) {
        prevGroup.span += 1;
      } else {
        groups.push({ time, span: 1, slot });
      }
    }
    return groups;
  };

  if (isLoading) {
    return (
      <div className="flex flex-col items-center justify-center h-80 bg-slate-50/50 rounded-3xl border border-dashed border-slate-200">
        <div className="w-12 h-12 border-4 border-emerald-500 border-t-transparent rounded-full animate-spin mb-4" />
        <p className="text-slate-400 font-semibold text-xs">Đang tải lịch sân...</p>
      </div>
    );
  }

  return (
    <div className="flex flex-col h-full bg-white rounded-xl border border-slate-100 shadow-xl shadow-slate-200/50 overflow-hidden">
      {/* Grid Controls */}
      <div className="p-4 border-b border-slate-50 flex items-center justify-between bg-white/80 backdrop-blur-md sticky top-0 z-[10]">
        <div className="flex items-center gap-2">
          <div className="bg-emerald-50 p-2 rounded-xl text-emerald-600">
            <Search size={16} />
          </div>
          <span className="text-sm font-bold text-slate-800">Lịch sân chi tiết</span>
        </div>

        <div className="flex items-center gap-4 bg-slate-50/50 p-2 px-4 rounded-2xl border border-slate-100">
          <ZoomOut size={14} className="text-slate-400" />
          <div className="w-32 flex items-center">
            <input
              type="range"
              value={zoom}
              onChange={(e) => setZoom(Number(e.target.value))}
              min={50}
              max={200}
              step={10}
              className="w-full h-1.5 bg-slate-200 rounded-lg appearance-none cursor-pointer accent-emerald-500"
            />
          </div>
          <ZoomIn size={14} className="text-slate-400" />
          <span className="text-[10px] font-bold text-slate-500 min-w-[30px]">{zoom}%</span>
        </div>
      </div>

      {/* Grid Content */}
      <div className="overflow-x-auto custom-scrollbar bg-white">
        <div
          className="grid relative min-w-max"
          style={{
            gridTemplateColumns: `160px repeat(${timeColumns.length}, ${columnWidth}px)`,
          }}
        >
          {/* Header row */}
          <div className="contents">
            <div className="sticky top-0 left-0 z-[20] bg-slate-50 border-b border-r border-slate-200 p-4 flex items-center justify-center">
              <span className="text-[10px] font-bold text-slate-400">Sân</span>
            </div>
            {timeColumns.map((time) => (
              <div
                key={time}
                className="sticky top-0 z-[10] bg-slate-50 border-b border-r border-slate-200 p-4 text-center"
              >
                <span className="text-[10px] font-bold text-slate-500">{time} - {getEndTimeOfSlot(time, intervalMinutes)}</span>
              </div>
            ))}
          </div>

          {/* Sub-court rows */}
          {subCourts.map((sc) => (
            <div key={sc.id} className="contents group">
              {/* Row Header (Court Name) */}
              <div className="sticky left-0 z-[5] bg-white border-b border-r border-slate-100 p-5 flex items-center shadow-[4px_0_8px_rgba(0,0,0,0.02)] group-hover:bg-slate-50 transition-colors">
                <span className="text-xs font-bold text-slate-800 truncate">{sc.name}</span>
              </div>

              {/* Grouped Time Cells */}
              {getGroupedSlots(sc.id).map(({ time, span, slot }) => {
                const selected = slot && isSlotSelected?.(sc.id, slot);

                // Check if slot is in the past
                const isPast = slot && (() => {
                  const now = new Date();
                  const slotDate = new Date(selectedDate);
                  const [h, m] = slot.startTime.split(":").map(Number);
                  slotDate.setHours(h, m, 0, 0);
                  return slotDate < now;
                })();

                const disabled = slot && (isSlotDisabled ? isSlotDisabled(sc.id, slot) : (slot.type !== "Booked" && isPast));

                return (
                  <div
                    key={time}
                    onClick={() => {
                      if (!slot) return;

                      if (!disabled) {
                        onSlotClick?.(sc.id, slot);
                      }
                    }}
                    style={{ gridColumn: `span ${span}` }}
                    title={slot?.type === "Blocked" && slot?.reason ? `Lý do khóa: ${slot.reason}` : undefined}
                    className={cn(
                      "h-20 border-b border-r border-slate-100 flex flex-col items-center justify-center gap-1 transition-all relative group",
                      selected ? "bg-emerald-600 hover:bg-emerald-700 z-10 scale-[1.01] shadow-lg shadow-emerald-200" :
                        !slot ? "bg-slate-50 border-slate-200" :
                          isPast && slot.type === "Default" ? "bg-slate-50/50 cursor-not-allowed border-slate-100" :
                            slot.type === "Blocked" ? cn(
                              "bg-slate-700 border-slate-800 text-white",
                              disabled ? "cursor-not-allowed" : "cursor-pointer hover:bg-slate-800"
                            ) :
                              slot.type === "Booked" ? cn(
                                "bg-rose-500 border-rose-600 text-white",
                                disabled ? "cursor-not-allowed" : "cursor-pointer hover:bg-rose-600"
                              ) :
                                slot.type === "Override" ? cn(
                                  "bg-violet-600 border-violet-700 text-white shadow-md",
                                  disabled ? "cursor-not-allowed" : "cursor-pointer hover:bg-violet-700"
                                ) :
                                  "bg-white hover:bg-emerald-50 border-emerald-100 cursor-pointer"
                    )}
                  >
                    {slot ? (
                      <>
                        <div className="flex flex-col items-center">
                          {slot.type !== "Blocked" && (
                            <span className={cn(
                              "text-[11px] font-bold",
                              selected || slot.type === "Booked" || slot.type === "Override" ? "text-white" :
                                isPast ? "text-slate-400" :
                                  "text-emerald-700"
                            )}>
                              {slot.price ? `${slot.price.toLocaleString("vi-VN")} đ` : ""}
                            </span>
                          )}
                          {slot.type === "Blocked" && (
                            <span className="text-[10px] font-bold text-white/90">Đã khóa</span>
                          )}
                          {(span > 1 || slot.type === "Blocked") && (
                            <span className={cn(
                              "text-[8px] font-bold opacity-90",
                              selected || slot.type === "Booked" || slot.type === "Blocked" || slot.type === "Override" ? "text-white/80" :
                                isPast ? "text-slate-300" : "text-slate-500"
                            )}>
                              {slot.startTime.substring(0, 5)} - {slot.endTime.substring(0, 5)}
                            </span>
                          )}
                        </div>
                        {renderCellExtra?.(sc.id, slot)}

                        {/* Status indicators */}
                        {slot.type === "Booked" && !isPast && (
                          <div className="absolute top-2 right-2 w-2 h-2 rounded-full bg-rose-500" />
                        )}
                        {slot.type === "Blocked" && (
                          <div className="absolute inset-0 flex items-center justify-center opacity-10 pointer-events-none">
                            <LockIcon size={32} />
                          </div>
                        )}
                        {slot.type === "Blocked" && slot.reason && (
                          <div className="absolute bottom-full left-1/2 -translate-x-1/2 mb-2 hidden group-hover:flex flex-col items-center z-[99] pointer-events-none animate-in fade-in zoom-in-95 duration-200">
                            <div className="bg-slate-950 text-white text-[10px] font-bold py-1.5 px-3 rounded-xl shadow-2xl border border-slate-800 whitespace-nowrap">
                              <span className="text-amber-400">Lý do khóa:</span> {slot.reason}
                            </div>
                            <div className="w-2.5 h-2.5 bg-slate-950 rotate-45 -mt-1.5 border-r border-b border-slate-800" />
                          </div>
                        )}
                      </>
                    ) : null}
                  </div>
                );
              })}
            </div>
          ))}
        </div>
      </div>

      {/* Footer / Legend */}
      <div className="p-3 bg-slate-50 border-t border-slate-100 flex items-center gap-6 overflow-x-auto no-scrollbar">
        <div className="flex items-center gap-2 shrink-0">
          <div className="w-3 h-3 rounded-full bg-emerald-600 shadow-sm" />
          <span className="text-[9px] font-bold text-slate-600">Đã chọn</span>
        </div>
        <div className="flex items-center gap-2 shrink-0">
          <div className="w-3 h-3 rounded-full bg-white border-2 border-slate-200" />
          <span className="text-[9px] font-bold text-slate-600">Trống</span>
        </div>
        <div className="flex items-center gap-2 shrink-0">
          <div className="w-3 h-3 rounded-full bg-rose-500" />
          <span className="text-[9px] font-bold text-slate-600">Đã đặt</span>
        </div>
        <div className="flex items-center gap-2 shrink-0">
          <div className="w-3 h-3 rounded-full bg-violet-600" />
          <span className="text-[9px] font-bold text-slate-600">Gộp</span>
        </div>
        <div className="flex items-center gap-2 shrink-0">
          <div className="w-3 h-3 rounded-full bg-slate-700" />
          <span className="text-[9px] font-bold text-slate-600">Khóa</span>
        </div>
        <div className="ml-auto flex items-center gap-2 text-[9px] text-slate-400 font-medium shrink-0">
          <span>* Giá vé hiển thị theo từng block 30 phút</span>
        </div>
      </div>
    </div>
  );
};
