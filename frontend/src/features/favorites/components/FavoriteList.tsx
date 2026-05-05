import { FavoriteCourtCard } from "./FavoriteCourtCard";
import type { CourtLike } from "../types";
import { EmptyState } from "@/shared/components/common/EmptyState";

interface FavoriteListProps {
  courts: CourtLike[];
  onViewDetail?: (id: string) => void;
}

export function FavoriteList({ courts, onViewDetail }: FavoriteListProps) {
  if (courts.length === 0) {
    return (
      <EmptyState 
        title="Chưa có sân yêu thích" 
        description="Hãy thêm các sân bạn yêu thích vào danh sách để dễ dàng đặt sân sau này."
      />
    );
  }

  return (
    <div className="flex flex-col gap-6">
      {courts.map((court) => (
        <FavoriteCourtCard 
          key={court.courtId} 
          court={court} 
          onViewDetail={onViewDetail}
        />
      ))}
    </div>
  );
}
