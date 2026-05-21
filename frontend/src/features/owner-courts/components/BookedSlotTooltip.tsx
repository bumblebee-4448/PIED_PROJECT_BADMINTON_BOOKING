import { useState } from "react";
import { useBookingDetail } from "../hooks/useOwnerSlots";
import { Loader2, Phone, Mail, Clock } from "lucide-react";
import { Tooltip, TooltipTrigger, TooltipContent, TooltipProvider } from "@/shared/components/ui/tooltip";

export function BookedSlotTooltip({ bookingDetailId }: { bookingDetailId: string }) {
  const [isOpen, setIsOpen] = useState(false);
  
  const { data: detail, isLoading } = useBookingDetail(bookingDetailId, {
    enabled: isOpen
  });
  
  return (
    <TooltipProvider>
      <Tooltip open={isOpen} onOpenChange={setIsOpen}>
        <TooltipTrigger asChild>
          <div className="absolute inset-0 z-[10] cursor-pointer" />
        </TooltipTrigger>
        <TooltipContent 
          side="top" 
          align="center"
          className="p-0 border-none bg-transparent shadow-none z-[9999]"
        >
          <div className="bg-[#0B2421] text-white text-xs p-4 rounded-2xl shadow-2xl border border-emerald-950/80 w-64 text-left relative animate-in fade-in zoom-in-95 duration-200 mb-2">
            {isLoading ? (
              <div className="flex items-center justify-center py-2 gap-2">
                <Loader2 className="animate-spin text-emerald-500" size={16} />
                <span className="text-gray-300 text-[10px] font-bold uppercase tracking-wider">Đang tải...</span>
              </div>
            ) : detail ? (
              <div className="space-y-3">
                <div className="flex items-center gap-2 pb-2 border-b border-emerald-800/50">
                  <div className="w-6 h-6 rounded-lg bg-emerald-500/20 border border-emerald-500/30 flex items-center justify-center text-xs font-black text-emerald-400">
                    {detail.name?.charAt(0).toUpperCase()}
                  </div>
                  <div className="min-w-0">
                    <p className="text-[8px] font-black text-emerald-400 uppercase tracking-widest leading-none mb-0.5">Người đặt</p>
                    <p className="font-bold text-white text-[11px] truncate w-44">{detail.name}</p>
                  </div>
                </div>
                
                <div className="space-y-1.5">
                  <div className="flex items-center gap-2 text-gray-300">
                    <Phone size={12} className="text-emerald-500 shrink-0" />
                    <span className="text-[10px] font-bold">{detail.phoneNumber || "Chưa cung cấp"}</span>
                  </div>
                  <div className="flex items-center gap-2 text-gray-300">
                    <Mail size={12} className="text-emerald-500 shrink-0" />
                    <span className="text-[10px] font-bold truncate w-48">{detail.gmail}</span>
                  </div>
                  <div className="flex items-center gap-2 text-emerald-400 pt-1 border-t border-emerald-800/30">
                    <Clock size={12} className="shrink-0" />
                    <span className="text-[10px] font-black">
                      {detail.startTime.substring(0, 5)} - {detail.endTime.substring(0, 5)}
                    </span>
                  </div>
                </div>
              </div>
            ) : (
              <p className="text-[10px] text-gray-400 font-bold">Không tìm thấy thông tin</p>
            )}
            <div className="absolute top-full left-1/2 -translate-x-1/2 w-2.5 h-2.5 bg-[#0B2421] rotate-45 -mt-1.5 border-r border-b border-emerald-950/80" />
          </div>
        </TooltipContent>
      </Tooltip>
    </TooltipProvider>
  );
}
