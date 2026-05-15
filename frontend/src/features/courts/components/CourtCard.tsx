import type { MouseEvent } from "react";
import { Heart, MapPin, Phone, Star } from "lucide-react";
import type { Court } from "../types";
import { cn } from "@/lib/utils";
import { Badge } from "@/shared/components/ui/badge";
import { useAuthStore } from "@/features/auth/store";
import { useFavorites } from "@/features/favorites/hooks/useFavorites";
import {
  useAddFavorite,
  useRemoveFavorite,
} from "@/features/favorites/hooks/useFavoriteMutations";
import { Button } from "@/shared/components/ui/button";

interface CourtCardProps {
  court: Court;
  onClick?: (id: string) => void;
}

const formatCourtPrice = (price?: number) => {
  if (typeof price !== "number" || price < 0) {
    return "Liên hệ";
  }

  return new Intl.NumberFormat("vi-VN", {
    style: "currency",
    currency: "VND",
    maximumFractionDigits: 0,
  }).format(price);
};

export function CourtCard({ court, onClick }: CourtCardProps) {
  const { user, setLoginPromptOpen } = useAuthStore();
  const { data: favoritesResponse } = useFavorites(1, 100);
  const { mutate: addFavorite, isPending: isAdding } = useAddFavorite();
  const { mutate: removeFavorite, isPending: isRemoving } = useRemoveFavorite();

  const isFavorite = favoritesResponse?.items.some((f) => f.courtId === court.courtId);
  const isLoading = isAdding || isRemoving;
  const hasListedPrice = typeof court.defaultPrice === "number" && court.defaultPrice >= 0;

  const handleFavoriteClick = (event: MouseEvent) => {
    event.stopPropagation();

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
        courtAddress: court.address,
      });
    }
  };

  return (
    <div
      onClick={() => onClick?.(court.courtId)}
      className={cn(
        "group flex cursor-pointer gap-4 rounded-2xl border border-gray-100 bg-white p-3 transition-all duration-300 hover:border-emerald-200 hover:shadow-lg hover:shadow-emerald-500/5"
      )}
    >
      <div className="relative h-28 w-40 flex-shrink-0 overflow-hidden rounded-xl bg-gray-50 shadow-sm">
        <img
          src={
            court.pictureUrl ||
            "https://images.unsplash.com/photo-1626225967045-9c76db7b62dc?w=800&auto=format&fit=crop"
          }
          alt={court.name}
          className="h-full w-full object-cover transition-transform duration-500 group-hover:scale-110"
        />
        <div className="absolute left-2 top-2 flex flex-col gap-1.5">
          <Badge
            variant="secondary"
            className="border-emerald-50 bg-white/90 text-[8px] font-bold text-emerald-600 backdrop-blur-md"
          >
            {court.status.toUpperCase()}
          </Badge>
        </div>

        <div className="absolute right-2 top-2">
          <Button
            size="icon"
            variant="ghost"
            onClick={handleFavoriteClick}
            disabled={isLoading}
            className={cn(
              "group/heart h-8 w-8 rounded-full border border-white/50 bg-white/70 shadow-sm backdrop-blur-md transition-all duration-300 hover:scale-110 active:scale-95",
              isFavorite ? "bg-white/90 text-red-500" : "text-gray-400 hover:text-red-400"
            )}
          >
            <Heart
              size={16}
              className={cn(
                "transition-all duration-300",
                isFavorite ? "scale-110 fill-current" : "group-hover/heart:scale-110"
              )}
            />
          </Button>
        </div>
      </div>

      <div className="flex flex-1 flex-col justify-between py-0.5">
        <div>
          <div className="mb-0.5 flex items-start justify-between">
            <h3 className="line-clamp-1 text-base font-black text-[#0B2421] transition-colors group-hover:text-emerald-600">
              {court.name}
            </h3>
          </div>

          <div className="mb-1 flex items-center gap-1.5 text-gray-400">
            <MapPin size={12} className="text-emerald-500" />
            <span className="truncate text-[10px] font-medium">{court.address}</span>
          </div>

          <div className="mb-1.5 flex items-center gap-1.5 text-gray-400">
            <Phone size={10} className="text-emerald-500" />
            <span className="truncate text-[10px] font-medium">
              {court.phoneNumber || "Chưa cập nhật"}
            </span>
          </div>

          <div className="flex items-center gap-2">
            <div className="flex items-center gap-1 rounded-lg border border-orange-100 bg-orange-50 px-1.5 py-0.5">
              <Star size={10} className="fill-orange-400 text-orange-400" />
              <span className="text-[10px] font-black text-orange-600">
                {court.averageRating}
              </span>
            </div>
          </div>
        </div>

        <div className="mt-2 flex items-center justify-between">
          <div className="flex items-baseline gap-1">
            <span className="text-lg font-black text-emerald-600">
              {formatCourtPrice(court.defaultPrice)}
            </span>
            {hasListedPrice && (
              <span className="text-[10px] font-bold text-gray-400">/giờ</span>
            )}
          </div>

          <div
            className={cn(
              "flex items-center gap-1.5 rounded-lg border px-3 py-1 text-[9px] font-black",
              court.status === "Active"
                ? "border-emerald-100 bg-emerald-50 text-emerald-600"
                : "border-red-100 bg-red-50 text-red-600"
            )}
          >
            <div
              className={cn(
                "h-1 w-1 animate-pulse rounded-full",
                court.status === "Active" ? "bg-emerald-500" : "bg-red-500"
              )}
            />
            {court.status === "Active" ? "SẴN SÀNG" : "BẬN"}
          </div>
        </div>
      </div>
    </div>
  );
}
