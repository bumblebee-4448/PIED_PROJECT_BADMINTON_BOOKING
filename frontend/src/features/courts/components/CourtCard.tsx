import { Star, MapPin } from "lucide-react";
import type { Court } from "../mock";
import { cn } from "@/lib/utils";

interface CourtCardProps {
  court: Court;
}

export function CourtCard({ court }: CourtCardProps) {
  return (
    <div className="group bg-white rounded-2xl p-3 flex gap-4 border border-gray-100 hover:border-emerald-200 transition-all duration-300 hover:shadow-lg hover:shadow-emerald-500/5">
      {/* Image Section */}
      <div className="relative w-40 h-28 rounded-xl overflow-hidden flex-shrink-0 shadow-sm">
        <img 
          src={court.imageUrl} 
          alt={court.name} 
          className="w-full h-full object-cover transition-transform duration-500 group-hover:scale-110"
        />
        <div className="absolute top-2 left-2 px-2 py-0.5 bg-white/90 backdrop-blur-md rounded-lg text-[8px] font-bold text-emerald-600 shadow-sm border border-emerald-50">
          FEATURED
        </div>
      </div>

      {/* Content Section */}
      <div className="flex-1 flex flex-col justify-between py-0.5">
        <div>
          <div className="flex justify-between items-start mb-0.5">
            <h3 className="text-base font-black text-[#0B2421] group-hover:text-emerald-600 transition-colors line-clamp-1">
              {court.name}
            </h3>
          </div>

          <div className="flex items-center gap-1.5 text-gray-400 mb-1.5">
            <MapPin size={12} className="text-emerald-500" />
            <span className="text-[10px] font-medium truncate">{court.address}</span>
          </div>

          <div className="flex items-center gap-2">
            <div className="flex items-center gap-1 bg-orange-50 px-1.5 py-0.5 rounded-lg border border-orange-100">
              <Star size={10} className="fill-orange-400 text-orange-400" />
              <span className="text-[10px] font-black text-orange-600">{court.rating}</span>
            </div>
            <span className="text-[8px] font-bold text-gray-300 uppercase tracking-widest">
              ({court.reviews} ĐÁNH GIÁ)
            </span>
          </div>
        </div>

        <div className="flex items-center justify-between mt-2">
          <div className="flex items-baseline gap-1">
            <span className="text-lg font-black text-emerald-600">{court.price.toLocaleString('vi-VN')}đ</span>
            <span className="text-[8px] font-bold text-gray-400 uppercase tracking-widest">/ GIỜ</span>
          </div>

          <div className={cn(
            "px-3 py-1 rounded-lg text-[9px] font-black flex items-center gap-1.5 border",
            court.availableSlots > 0 
              ? "bg-emerald-50 text-emerald-600 border-emerald-100" 
              : "bg-red-50 text-red-600 border-red-100"
          )}>
            <div className={cn(
              "w-1 h-1 rounded-full animate-pulse",
              court.availableSlots > 0 ? "bg-emerald-500" : "bg-red-500"
            )} />
            {court.availableSlots} TRỐNG
          </div>
        </div>
      </div>
    </div>
  );
}
