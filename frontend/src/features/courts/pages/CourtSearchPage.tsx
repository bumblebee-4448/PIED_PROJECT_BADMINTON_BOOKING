import { useState, useMemo, useCallback } from "react";
import { Search, List, Map as MapIcon, Loader2 } from "lucide-react";
import { Button } from "@/shared/components/ui/button";
import { useCourts } from "../hooks/useCourts";
import { CourtCard } from "../components/CourtCard";
import { CourtFilters } from "../components/CourtFilters";
import { CourtDetailDialog } from "../components/CourtDetailDialog";
import { CourtMap } from "../components/CourtMap";
import { cn } from "@/lib/utils";
import { useCourtSearch } from "../hooks/useCourtSearch";

export function CourtSearchPage() {
  const { 
    searchQuery, 
    setSearchQuery, 
    debouncedSearch,
  } = useCourtSearch();
  const [viewMode, setViewMode] = useState<"list" | "map">("list");
  
  // Detail Dialog State
  const [selectedCourtId, setSelectedCourtId] = useState<string | null>(null);
  const [isDialogOpen, setIsDialogOpen] = useState(false);


  const filters = useMemo(() => ({
    search: debouncedSearch,
  }), [debouncedSearch]);

  const { data: response, isLoading, isError } = useCourts(filters);
  const courts = response?.items || [];

  const handleCardClick = useCallback((id: string) => {
    setSelectedCourtId(id);
    setIsDialogOpen(true);
  }, []);

  return (
    <div className="min-h-screen bg-[#F9FBFA] pb-20 pt-20">
      {/* Detail Dialog */}
      <CourtDetailDialog 
        courtId={selectedCourtId}
        isOpen={isDialogOpen}
        onClose={() => setIsDialogOpen(false)}
      />

      {/* Header & Filters Section */}
      <div className="bg-transparent pt-8 pb-4">
        <CourtFilters 
          searchQuery={searchQuery}
          setSearchQuery={setSearchQuery}
        />
      </div>

      {/* Main Content */}
      <div className="max-w-6xl mx-auto px-4 sm:px-6 mt-6">
        <div className="flex items-center justify-between mb-6">
          <p className="text-[10px] font-bold text-gray-400 uppercase tracking-[0.2em]">
            {isLoading ? (
              <span className="flex items-center gap-2">
                <Loader2 size={12} className="animate-spin" /> ĐANG TÌM KIẾM...
              </span>
            ) : (
              <>TÌM THẤY <span className="text-[#0B2421] font-black">{courts.length}</span> SÂN</>
            )}
          </p>

          <div className="flex bg-white border border-gray-100 p-1 rounded-xl shadow-sm">
            <Button 
              variant="ghost"
              onClick={() => setViewMode("list")}
              className={cn(
                "px-3 py-1.5 rounded-lg text-[10px] font-black flex items-center gap-2 transition-all uppercase tracking-wider h-auto",
                viewMode === "list" ? "bg-emerald-50 text-emerald-600 hover:bg-emerald-100" : "text-gray-400 hover:text-gray-600 hover:bg-gray-50"
              )}
            >
              <List size={14} /> Danh sách
            </Button>
            <Button 
              variant="ghost"
              onClick={() => setViewMode("map")}
              className={cn(
                "px-3 py-1.5 rounded-lg text-[10px] font-black flex items-center gap-2 transition-all uppercase tracking-wider h-auto",
                viewMode === "map" ? "bg-emerald-50 text-emerald-600 hover:bg-emerald-100" : "text-gray-400 hover:text-gray-600 hover:bg-gray-50"
              )}
            >
              <MapIcon size={14} /> Bản đồ
            </Button>
          </div>
        </div>

        {isError && (
          <div className="bg-red-50 border border-red-100 rounded-2xl p-6 text-center mb-6">
            <p className="text-red-600 font-bold">Đã có lỗi xảy ra khi tải danh sách sân. Vui lòng thử lại sau.</p>
          </div>
        )}

        {viewMode === "list" ? (
          <div className="grid grid-cols-1 gap-4">
            {!isLoading && courts.length > 0 ? (
              courts.map((court) => (
                <CourtCard 
                  key={court.courtId} 
                  court={court} 
                  onClick={handleCardClick} 
                />
              ))
            ) : !isLoading ? (
              <div className="bg-white rounded-[2.5rem] p-20 text-center border border-gray-100 shadow-sm">
                <div className="w-20 h-20 bg-gray-50 rounded-3xl flex items-center justify-center mx-auto mb-6">
                  <Search className="text-gray-300" size={32} />
                </div>
                <h3 className="text-xl font-black text-[#0B2421] mb-2">Không tìm thấy sân</h3>
                <p className="text-gray-400 text-sm font-medium">Hãy thử thay đổi từ khóa hoặc khu vực lọc của bạn nhé!</p>
              </div>
            ) : (
              // Loading skeletons could go here
              <div className="space-y-4">
                {[1, 2, 3].map(i => (
                  <div key={i} className="h-32 bg-gray-100 animate-pulse rounded-2xl" />
                ))}
              </div>
            )}
          </div>
        ) : (
          <div className="h-[70vh] w-full">
            <CourtMap 
              onMarkerClick={handleCardClick} 
              searchQuery={debouncedSearch}
            />
          </div>
        )}
      </div>
    </div>
  );
}
