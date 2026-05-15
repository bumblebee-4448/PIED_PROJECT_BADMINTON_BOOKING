import { cn } from "@/lib/utils";
import { Check, Clock, Lock } from "lucide-react";
import type { AvailableSlot } from "../types";

interface SlotPickerProps {
  slots: AvailableSlot[];
  selectedSlots: AvailableSlot[];
  onToggleSlot: (slot: AvailableSlot) => void;
}

export function SlotPicker({ slots, selectedSlots, onToggleSlot }: SlotPickerProps) {
  const isSelected = (slot: AvailableSlot) => 
    selectedSlots.some(s => s.startTime === slot.startTime && s.endTime === slot.endTime);

  return (
    <div className="grid grid-cols-2 md:grid-cols-4 lg:grid-cols-6 gap-3">
      {slots.map((slot, index) => {
        const selected = isSelected(slot);
        const disabled = !slot.isAvailable;

        return (
          <button
            key={index}
            disabled={disabled}
            onClick={() => onToggleSlot(slot)}
            className={cn(
              "relative p-4 rounded-2xl border-2 transition-all flex flex-col items-center justify-center gap-2 group",
              selected
                ? "bg-amber-400 border-amber-500 text-white shadow-md scale-[0.98]"
                : slot.type === "Booked"
                  ? "bg-rose-500 border-rose-600 text-white cursor-not-allowed shadow-md"
                  : slot.type === "Blocked"
                    ? "bg-gray-400 border-gray-500 text-white cursor-not-allowed"
                    : slot.type === "Override"
                      ? "bg-violet-500 border-violet-600 text-white shadow-md"
                      : "bg-white border-gray-100 text-gray-600 hover:border-amber-400 hover:bg-amber-50/30 shadow-sm"
            )}
          >
            {selected && (
              <div className="absolute top-2 right-2 w-4 h-4 bg-emerald-500 rounded-full flex items-center justify-center">
                <Check size={10} className="text-white" strokeWidth={4} />
              </div>
            )}
            
            {disabled && (
              <div className="absolute top-2 right-2 text-gray-300">
                <Lock size={12} />
              </div>
            )}

            <Clock size={16} className={cn(
              "transition-colors",
              selected ? "text-white" : 
              slot.type === "Booked" || slot.type === "Blocked" || slot.type === "Override" ? "text-white" : 
              "text-gray-400 group-hover:text-amber-400"
            )} />
            
            <div className="text-center">
              <p className="text-[11px] font-black uppercase tracking-tighter">
                {slot.startTime.slice(0, 5)} - {slot.endTime.slice(0, 5)}
              </p>
              <p className={cn(
                "text-[10px] font-bold mt-0.5",
                selected ? "text-white/80" : 
                slot.type === "Booked" || slot.type === "Blocked" || slot.type === "Override" ? "text-white/80" : 
                "text-gray-400"
              )}>
                {new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(slot.price)}
              </p>
            </div>
          </button>
        );
      })}
    </div>
  );
}
