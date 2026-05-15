import { useState, useMemo, useCallback, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import {
  ChevronLeft,
  ChevronRight,
  List,
  Loader2,
  Map as MapIcon,
  Search,
} from "lucide-react";
import { Button } from "@/shared/components/ui/button";
import { useCourts } from "../hooks/useCourts";
import { CourtCard } from "../components/CourtCard";
import { CourtFilters } from "../components/CourtFilters";
import { CourtMap } from "../components/CourtMap";
import { cn } from "@/lib/utils";
import { useCourtSearch } from "../hooks/useCourtSearch";
import type { ApiResponse, CourtListResponse } from "../types";

const PAGE_SIZE = 10;

const unwrapCourtListResponse = (
  response: CourtListResponse | ApiResponse<CourtListResponse> | undefined
) => {
  if (response && "data" in response) {
    return response.data;
  }

  return response;
};

export function CourtSearchPage() {
  const navigate = useNavigate();
  const { searchQuery, setSearchQuery, debouncedSearch } = useCourtSearch();
  const [viewMode, setViewMode] = useState<"list" | "map">("list");
  const [pageIndex, setPageIndex] = useState(1);

  useEffect(() => {
    setPageIndex(1);
  }, [debouncedSearch]);

  const filters = useMemo(
    () => ({
      search: debouncedSearch,
      page: pageIndex,
      limit: PAGE_SIZE,
    }),
    [debouncedSearch, pageIndex]
  );

  const { data: response, isLoading, isError } = useCourts(filters);
  const courtPage = useMemo(
    () =>
      unwrapCourtListResponse(
        response as CourtListResponse | ApiResponse<CourtListResponse> | undefined
      ),
    [response]
  );

  const courts = courtPage?.items ?? [];
  const totalItems = courtPage?.totalItems ?? courts.length;
  const currentPage = courtPage?.pageIndex ?? pageIndex;
  const pageSize = courtPage?.pageSize ?? PAGE_SIZE;
  const totalPages = Math.max(1, Math.ceil(totalItems / pageSize));

  const handleCardClick = useCallback((id: string) => {
    navigate(`/courts/${id}`);
  }, [navigate]);

  const handlePreviousPage = useCallback(() => {
    setPageIndex((page) => Math.max(1, page - 1));
  }, []);

  const handleNextPage = useCallback(() => {
    setPageIndex((page) => Math.min(totalPages, page + 1));
  }, [totalPages]);

  return (
    <div className="min-h-screen bg-[#F9FBFA] pb-20 pt-20">
      {viewMode === "list" && (
        <div className="bg-transparent pb-4 pt-8">
          <CourtFilters searchQuery={searchQuery} setSearchQuery={setSearchQuery} />
        </div>
      )}

      <div
        className={cn(
          "mx-auto max-w-6xl px-4 sm:px-6",
          viewMode === "list" ? "mt-6" : "mt-8"
        )}
      >
        <div
          className={cn(
            "mb-6 flex items-center",
            viewMode === "list" ? "justify-between" : "justify-end"
          )}
        >
          {viewMode === "list" && (
            <p className="text-[10px] font-bold uppercase tracking-[0.2em] text-gray-400">
              {isLoading ? (
                <span className="flex items-center gap-2">
                  <Loader2 size={12} className="animate-spin" /> ĐANG TÌM KIẾM...
                </span>
              ) : (
                <>
                  TÌM THẤY{" "}
                  <span className="font-black text-[#0B2421]">{totalItems}</span> SÂN
                </>
              )}
            </p>
          )}

          <div className="flex rounded-xl border border-gray-100 bg-white p-1 shadow-sm">
            <Button
              variant="ghost"
              onClick={() => setViewMode("list")}
              className={cn(
                "flex h-auto items-center gap-2 rounded-lg px-3 py-1.5 text-[10px] font-black uppercase tracking-wider transition-all",
                viewMode === "list"
                  ? "bg-emerald-50 text-emerald-600 hover:bg-emerald-100"
                  : "text-gray-400 hover:bg-gray-50 hover:text-gray-600"
              )}
            >
              <List size={14} /> Danh sách
            </Button>
            <Button
              variant="ghost"
              onClick={() => setViewMode("map")}
              className={cn(
                "flex h-auto items-center gap-2 rounded-lg px-3 py-1.5 text-[10px] font-black uppercase tracking-wider transition-all",
                viewMode === "map"
                  ? "bg-emerald-50 text-emerald-600 hover:bg-emerald-100"
                  : "text-gray-400 hover:bg-gray-50 hover:text-gray-600"
              )}
            >
              <MapIcon size={14} /> Bản đồ
            </Button>
          </div>
        </div>

        {isError && (
          <div className="mb-6 rounded-2xl border border-red-100 bg-red-50 p-6 text-center">
            <p className="font-bold text-red-600">
              Đã có lỗi xảy ra khi tải danh sách sân. Vui lòng thử lại sau.
            </p>
          </div>
        )}

        {viewMode === "list" ? (
          <div className="space-y-6">
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
                <div className="rounded-[2.5rem] border border-gray-100 bg-white p-20 text-center shadow-sm">
                  <div className="mx-auto mb-6 flex h-20 w-20 items-center justify-center rounded-3xl bg-gray-50">
                    <Search className="text-gray-300" size={32} />
                  </div>
                  <h3 className="mb-2 text-xl font-black text-[#0B2421]">
                    Không tìm thấy sân
                  </h3>
                  <p className="text-sm font-medium text-gray-400">
                    Hãy thử thay đổi từ khóa hoặc khu vực lọc của bạn nhé!
                  </p>
                </div>
              ) : (
                <div className="space-y-4">
                  {[1, 2, 3].map((item) => (
                    <div
                      key={item}
                      className="h-32 animate-pulse rounded-2xl bg-gray-100"
                    />
                  ))}
                </div>
              )}
            </div>

            {!isLoading && totalItems > pageSize && (
              <div className="flex items-center justify-between rounded-2xl border border-gray-100 bg-white px-4 py-3 shadow-sm">
                <p className="text-xs font-bold text-gray-400">
                  Trang <span className="text-[#0B2421]">{currentPage}</span> /{" "}
                  {totalPages}
                </p>
                <div className="flex items-center gap-2">
                  <Button
                    variant="outline"
                    onClick={handlePreviousPage}
                    disabled={pageIndex <= 1}
                    className="h-9 rounded-xl border-gray-100 text-xs font-bold"
                  >
                    <ChevronLeft size={16} />
                    Trước
                  </Button>
                  <Button
                    variant="outline"
                    onClick={handleNextPage}
                    disabled={pageIndex >= totalPages}
                    className="h-9 rounded-xl border-gray-100 text-xs font-bold"
                  >
                    Sau
                    <ChevronRight size={16} />
                  </Button>
                </div>
              </div>
            )}
          </div>
        ) : (
          <div className="h-[70vh] w-full">
            <CourtMap onMarkerClick={handleCardClick} searchQuery={debouncedSearch} />
          </div>
        )}
      </div>
    </div>
  );
}
