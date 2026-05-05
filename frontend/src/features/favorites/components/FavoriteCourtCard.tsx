import { MapPin, Star, Trash2, Calendar, ArrowRight } from "lucide-react";
import { Button } from "@/shared/components/ui/button";
import { Badge } from "@/shared/components/ui/badge";
import type { CourtLike } from "../types";
import { useRemoveFavorite } from "../hooks/useFavoriteMutations";
import { cn } from "@/lib/utils";

interface FavoriteCourtCardProps {
  court: CourtLike;
  onViewDetail?: (id: string) => void;
}

export function FavoriteCourtCard({ court, onViewDetail }: FavoriteCourtCardProps) {
  const { mutate: removeFavorite, isPending } = useRemoveFavorite();

  const getTagColor = (tag?: string) => {
    switch (tag) {
      case "Pro":
        return "bg-emerald-500 hover:bg-emerald-600";
      case "Nổi bật":
        return "bg-blue-500 hover:bg-blue-600";
      case "Giá tốt":
        return "bg-[#0B2421] hover:bg-[#153a35]";
      default:
        return "bg-gray-500";
    }
  };

  return (
    <div className="group bg-white rounded-[32px] p-4 flex flex-col md:flex-row gap-6 border border-gray-100 hover:border-emerald-200 transition-all duration-300 hover:shadow-[0_20px_50px_rgba(0,0,0,0.04)]">
      {/* Image Section */}
      <div className="relative w-full md:w-64 h-44 rounded-[24px] overflow-hidden flex-shrink-0">
        <img 
          src={court.imageUrl || "https://images.unsplash.com/photo-1626225967045-9c76db7b62dc?w=800&auto=format&fit=crop"} 
          alt={court.courtName} 
          className="w-full h-full object-cover transition-transform duration-700 group-hover:scale-110"
        />
        {court.tag && (
          <Badge className={cn("absolute top-3 left-3 px-3 py-1 text-[10px] font-bold border-none shadow-sm", getTagColor(court.tag))}>
            {court.tag}
          </Badge>
        )}
      </div>

      {/* Content Section */}
      <div className="flex-1 flex flex-col justify-between">
        <div>
          <h3 className="text-xl font-bold text-[#0B2421] group-hover:text-emerald-600 transition-colors mb-2">
            {court.courtName}
          </h3>

          <div className="flex items-center gap-2 text-gray-400 mb-3">
            <MapPin size={14} className="text-emerald-500" />
            <span className="text-xs font-medium">{court.courtAddress}</span>
          </div>

          <div className="flex items-center gap-3">
            <div className="flex items-center gap-1.5 bg-orange-50 px-2 py-1 rounded-lg border border-orange-100">
              <Star size={12} className="fill-orange-400 text-orange-400" />
              <span className="text-xs font-bold text-orange-600">{court.rating || 0}</span>
            </div>
          </div>

          {/* Removed price and available slots section as per request */}
        </div>

        {/* Action Buttons */}
        <div className="flex items-center border-t border-gray-50 mt-6 pt-4">
          <Button 
            variant="ghost" 
            className="flex-1 gap-2 text-red-500 hover:text-red-600 hover:bg-red-50 font-bold text-xs h-10 rounded-xl"
            onClick={() => removeFavorite(court.courtId)}
            disabled={isPending}
          >
            <Trash2 size={16} />
            Xóa khỏi yêu thích
          </Button>
          
          <div className="w-[1px] h-6 bg-gray-100" />
          
          <Button 
            variant="ghost" 
            className="flex-1 gap-2 text-emerald-600 hover:text-emerald-700 hover:bg-emerald-50 font-bold text-xs h-10 rounded-xl"
          >
            <Calendar size={16} />
            Đặt sân
          </Button>

          <div className="w-[1px] h-6 bg-gray-100" />

          <Button 
            variant="ghost" 
            className="flex-1 gap-2 text-gray-400 hover:text-[#0B2421] hover:bg-gray-50 font-bold text-xs h-10 rounded-xl"
            onClick={() => onViewDetail?.(court.courtId)}
          >
            Chi tiết
            <ArrowRight size={16} />
          </Button>
        </div>
      </div>
    </div>
  );
}
