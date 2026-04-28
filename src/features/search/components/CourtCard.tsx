import { MapPin, Star, Heart } from "lucide-react";
import type { Court } from "../types";
import { Button } from "@/shared/components/ui/button";
import { cn } from "@/lib/utils";

interface CourtCardProps {
  court: Court;
}

export const CourtCard = ({ court }: CourtCardProps) => {
  return (
    <div className="bg-white rounded-[1.5rem] border border-gray-100 shadow-sm hover:shadow-md transition-all duration-300 overflow-hidden flex flex-col sm:flex-row group relative">
      {/* Image Section */}
      <div className="relative w-full sm:w-[260px] h-[180px] overflow-hidden">
        <img
          src={court.image}
          alt={court.name}
          className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-500"
        />
        <button className="absolute top-3 right-3 w-8 h-8 rounded-full bg-white/80 backdrop-blur-sm flex items-center justify-center text-gray-400 hover:text-red-500 transition-colors shadow-sm z-10">
          <Heart size={16} fill={court.isFavorite ? "#ef4444" : "none"} className={court.isFavorite ? "text-red-500" : ""} />
        </button>
      </div>

      {/* Content Section */}
      <div className="flex-1 p-5 flex flex-col justify-between">
        <div className="space-y-1.5">
          <h3 className="text-xl font-bold text-[#091E1B] group-hover:text-[#004E43] transition-colors leading-tight">
            {court.name}
          </h3>
          <div className="flex items-center gap-1.5 text-gray-400 text-sm">
            <MapPin size={14} className="text-[#00CE98]" />
            <span className="truncate">{court.address}</span>
          </div>
          <div className="flex items-center gap-4 pt-1">
            <div className="flex items-center gap-1">
              <Star size={16} fill="#FFB300" color="#FFB300" />
              <span className="font-bold text-[#091E1B]">{court.rating}</span>
              <span className="text-gray-400 text-xs">({court.reviews} đánh giá)</span>
            </div>
          </div>
          <div className="text-[#004E43] font-black text-xl pt-1">
            {court.pricePerHour.toLocaleString()}đ<span className="text-sm font-medium text-gray-400">/giờ</span>
          </div>
        </div>

        <div className="flex items-center justify-between mt-3 sm:mt-0">
          <div className="sm:hidden">
             <span className={cn(
               "px-3 py-1 rounded-full text-xs font-bold",
               court.availableCourts > 0 
                ? "bg-emerald-50 text-emerald-600 border border-emerald-100" 
                : "bg-gray-100 text-gray-400"
             )}>
               {court.availableCourts} trống
             </span>
          </div>
          <Button 
            variant="outline" 
            className="rounded-full px-6 font-bold border-[#00CE98] text-[#00897B] hover:bg-[#00CE98]/5 h-10 transition-all active:scale-95"
          >
            Xem chi tiết
          </Button>
        </div>
      </div>

      {/* Desktop Availability & Action (Far Right) */}
      <div className="hidden sm:flex flex-col items-center justify-center pr-8 gap-4">
        <span className={cn(
          "px-3 py-1 rounded-full text-xs font-bold whitespace-nowrap",
          court.availableCourts > 0 
          ? "bg-emerald-50 text-emerald-600 border border-emerald-100" 
          : "bg-gray-100 text-gray-400"
        )}>
          {court.availableCourts} trống
        </span>
        <Button 
          variant="outline" 
          className="rounded-full px-6 font-bold border-gray-200 text-gray-600 hover:border-[#00CE98] hover:text-[#00897B] h-10 transition-all active:scale-95 whitespace-nowrap"
        >
          Xem chi tiết
        </Button>
      </div>
    </div>
  );
};
