import React from "react";
import { SearchBar } from "../components/SearchBar";
import { DistrictTabs } from "../components/DistrictTabs";
import { ViewToggle } from "../components/ViewToggle";
import { CourtCard } from "../components/CourtCard";
import { useSearchCourts } from "../hooks/useSearchCourts";

export const SearchPage = () => {
  const { courts, totalResults } = useSearchCourts();

  return (
    <div className="min-h-screen bg-[#F8FAFC] pt-28 pb-12">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        {/* Header Section */}
        <div className="mb-10">
          <h1 className="text-4xl font-extrabold text-[#091E1B] tracking-tight flex items-center gap-3">
            Tìm sân Cầu lông <span className="animate-pulse text-3xl">🔍</span>
          </h1>
          <p className="text-[#6B7280] mt-3 text-lg">
            Tìm kiếm theo tên, địa chỉ hoặc khu vực để chọn sân phù hợp nhất.
          </p>
        </div>

        {/* Search & Filter Bar */}
        <div className="mb-8 sticky top-[72px] z-30 bg-[#F8FAFC]/95 backdrop-blur-md py-4 transition-all">
          <SearchBar />
        </div>

        {/* District Filter */}
        <div className="mb-10">
          <DistrictTabs />
        </div>

        {/* Results Info & View Toggle */}
        <div className="flex flex-col sm:flex-row items-center justify-between mb-8 gap-4 border-b border-gray-200 pb-6">
          <div className="text-[#091E1B] font-medium text-lg">
            Tìm thấy <span className="text-[#00CE98] font-black">{totalResults}</span> sân
          </div>
          <ViewToggle />
        </div>

        {/* Courts List / Map */}
        <div className="space-y-6 w-full">
          {courts.length > 0 ? (
            courts.map((court) => (
              <CourtCard key={court.id} court={court} />
            ))
          ) : (
            <div className="py-20 text-center bg-white rounded-[2rem] border border-dashed border-gray-200">
              <div className="text-5xl mb-4">🏸</div>
              <h3 className="text-xl font-bold text-gray-900">Không tìm thấy sân phù hợp</h3>
              <p className="text-gray-500 mt-2">Thử thay đổi từ khóa hoặc khu vực tìm kiếm của bạn.</p>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};
