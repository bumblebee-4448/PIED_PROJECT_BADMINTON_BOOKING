import { Star, MapPin, Phone, Heart } from "lucide-react";
import type { Court } from "../types";
import { cn } from "@/lib/utils";
import { Badge } from "@/shared/components/ui/badge";
import { useAuthStore } from "@/features/auth/store";
import { useFavorites } from "@/features/favorites/hooks/useFavorites";
import { useAddFavorite, useRemoveFavorite } from "@/features/favorites/hooks/useFavoriteMutations";
import { Button } from "@/shared/components/ui/button";

interface CourtCardProps {
  court: Court;
  onClick?: (id: string) => void;
}

export function CourtCard({ court, onClick }: CourtCardProps) {
  const { user, setLoginPromptOpen } = useAuthStore();
  const { data: favoritesResponse } = useFavorites(1, 100);
  const { mutate: addFavorite, isPending: isAdding } = useAddFavorite();
  const { mutate: removeFavorite, isPending: isRemoving } = useRemoveFavorite();

  const isFavorite = favoritesResponse?.items.some(f => f.courtId === court.courtId);
  const isLoading = isAdding || isRemoving;

  const handleFavoriteClick = (e: React.MouseEvent) => {
    e.stopPropagation();
    
    if (!user) {
      setLoginPromptOpen(true);
      return;
    }

    if (isFavorite) {
      removeFavorite(court.courtId);
    } else {
      addFavorite({ 
        courtId: court.courtId,
        courtName: court.name,
        courtAddress: court.address 
      });
    }
  };

  return (
    <div 
      onClick={() => onClick?.(court.courtId)}
      className={cn(
        "group bg-white rounded-2xl p-3 flex gap-4 border border-gray-100 hover:border-emerald-200 transition-all duration-300 hover:shadow-lg hover:shadow-emerald-500/5 cursor-pointer"
      )}
    >
      {/* Image Section */}
      <div className="relative w-40 h-28 rounded-xl overflow-hidden flex-shrink-0 shadow-sm bg-gray-50">
        <img 
          src={court.pictureUrl || "https://images.unsplash.com/photo-1626225967045-9c76db7b62dc?w=800&auto=format&fit=crop"} 
          alt={court.name} 
          className="w-full h-full object-cover transition-transform duration-500 group-hover:scale-110"
        />
        <div className="absolute top-2 left-2 flex flex-col gap-1.5">
          <Badge variant="secondary" className="bg-white/90 backdrop-blur-md text-[8px] font-bold text-emerald-600 border-emerald-50">
            {court.status.toUpperCase()}
          </Badge>
        </div>

        {/* Favorite Button */}
        <div className="absolute top-2 right-2">
          <Button
            size="icon"
            variant="ghost"
            onClick={handleFavoriteClick}
            disabled={isLoading}
            className={cn(
              "w-8 h-8 rounded-full bg-white/70 backdrop-blur-md border border-white/50 shadow-sm transition-all duration-300 hover:scale-110 active:scale-95 group/heart",
              isFavorite ? "text-red-500 bg-white/90" : "text-gray-400 hover:text-red-400"
            )}
          >
            <Heart 
              size={16} 
              className={cn(
                "transition-all duration-300",
                isFavorite ? "fill-current scale-110" : "group-hover/heart:scale-110"
              )} 
            />
          </Button>
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

          <div className="flex items-center gap-1.5 text-gray-400 mb-1">
            <MapPin size={12} className="text-emerald-500" />
            <span className="text-[10px] font-medium truncate">{court.address}</span>
          </div>

          <div className="flex items-center gap-1.5 text-gray-400 mb-1.5">
            <Phone size={10} className="text-emerald-500" />
            <span className="text-[10px] font-medium truncate">{court.phoneNumber}</span>
          </div>

          <div className="flex items-center gap-2">
            <div className="flex items-center gap-1 bg-orange-50 px-1.5 py-0.5 rounded-lg border border-orange-100">
              <Star size={10} className="fill-orange-400 text-orange-400" />
              <span className="text-[10px] font-black text-orange-600">{court.averageRating}</span>
            </div>
            {/* Placeholder for reviews since not in filter API snippet */}
            <span className="text-[8px] font-bold text-gray-300 uppercase tracking-widest">
              (ĐANG CẬP NHẬT)
            </span>
          </div>
        </div>

        <div className="flex items-center justify-between mt-2">
          <div className="flex items-baseline gap-1">
            <span className="text-lg font-black text-emerald-600">Liên hệ</span>
          </div>

          <div className={cn(
            "px-3 py-1 rounded-lg text-[9px] font-black flex items-center gap-1.5 border",
            court.status === "Active" 
              ? "bg-emerald-50 text-emerald-600 border-emerald-100" 
              : "bg-red-50 text-red-600 border-red-100"
          )}>
            <div className={cn(
              "w-1 h-1 rounded-full animate-pulse",
              court.status === "Active" ? "bg-emerald-500" : "bg-red-500"
            )} />
            {court.status === "Active" ? "SẴN SÀNG" : "BẬN"}
          </div>
        </div>
      </div>
    </div>
  );
}
