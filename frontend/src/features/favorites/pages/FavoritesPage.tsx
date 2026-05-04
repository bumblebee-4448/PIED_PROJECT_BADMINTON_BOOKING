import { useFavorites } from "../hooks/useFavorites";
import { FavoriteList } from "../components/FavoriteList";
import { LoadingSpinner } from "@/shared/components/common/LoadingSpinner";
import { ErrorState } from "@/shared/components/common/ErrorState";

export function FavoritesPage() {
  const { data, isLoading, isError, error } = useFavorites();

  if (isLoading) {
    return (
      <div className="flex items-center justify-center min-h-[60vh]">
        <LoadingSpinner />
      </div>
    );
  }

  if (isError) {
    return (
      <div className="max-w-4xl mx-auto px-6 py-12">
        <ErrorState 
          message={error instanceof Error ? error.message : "Đã có lỗi xảy ra khi tải danh sách yêu thích"} 
        />
      </div>
    );
  }

  const favoriteCourts = data?.items || [];
  const totalCount = data?.totalItems || 0;

  return (
    <div className="min-h-screen bg-gray-50/50 pt-28 pb-20">
      <div className="max-w-4xl mx-auto px-6">
        {/* Header Section */}
        <div className="mb-10">
          <h1 className="text-3xl font-black text-[#0B2421] flex items-center gap-3 mb-2">
            Sân yêu thích <span className="text-red-500 animate-pulse">❤️</span>
          </h1>
          <p className="text-gray-400 font-bold text-sm uppercase tracking-widest">
            {totalCount} sân đã lưu
          </p>
        </div>

        {/* List Section */}
        <FavoriteList courts={favoriteCourts} />
      </div>
    </div>
  );
}
