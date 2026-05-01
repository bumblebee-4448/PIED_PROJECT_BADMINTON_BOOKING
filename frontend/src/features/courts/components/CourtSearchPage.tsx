import { useState } from "react";
import { Search, SlidersHorizontal, List, Map as MapIcon } from "lucide-react";
import { MOCK_COURTS } from "../mock";
import { CourtCard } from "./CourtCard";
import { Button } from "@/shared/components/ui/button";
import { cn } from "@/lib/utils";

const DISTRICTS = ["Tất cả", "Tân Bình", "Quận 1", "Quận 2", "Quận 3", "Quận 4", "Quận 5", "Quận 6", "Quận 7"];

export function CourtSearchPage() {
  const [selectedDistrict, setSelectedDistrict] = useState("Tất cả");
  const [searchQuery, setSearchQuery] = useState("");
  const [viewMode, setViewMode] = useState<"list" | "map">("list");

  const filteredCourts = MOCK_COURTS.filter(court => {
    const matchesDistrict = selectedDistrict === "Tất cả" || court.district === selectedDistrict;
    const matchesQuery = court.name.toLowerCase().includes(searchQuery.toLowerCase()) || 
                         court.address.toLowerCase().includes(searchQuery.toLowerCase());
    return matchesDistrict && matchesQuery;
  });

  return (
    <div className="min-h-screen bg-[#F9FBFA] pb-20 pt-20">
      {/* Header Section */}
      <div className="bg-transparent pt-8 pb-4">
        <div className="max-w-6xl mx-auto px-4 sm:px-6">
          <div className="mb-6">
            <div className="flex items-center gap-2 mb-1">
              <h1 className="text-3xl font-black text-[#0B2421] ">
                Tìm sân cầu lông
              </h1>
              <span className="text-2xl">🔍</span>
            </div>
            <p className="text-sm font-medium text-gray-400">
              Tìm kiếm theo tên, địa chỉ hoặc khu vực
            </p>
          </div>

          <div className="flex flex-col md:flex-row gap-3 mb-6">
            {/* Search Input */}
            <div className="flex-1 relative group">
              <Search className="absolute left-4 top-1/2 -translate-y-1/2 text-gray-400 group-focus-within:text-emerald-500 transition-colors" size={18} />
              <input 
                type="text"
                placeholder="Tìm sân theo tên, địa chỉ..."
                value={searchQuery}
                onChange={(e) => setSearchQuery(e.target.value)}
                className="w-full h-12 pl-12 pr-4 bg-white border border-gray-200 rounded-xl shadow-sm focus:outline-none focus:ring-2 focus:ring-emerald-500/20 focus:border-emerald-500/50 transition-all font-medium text-[#0B2421] text-sm"
              />
            </div>
            
            <Button variant="outline" className="h-11 px-6 rounded-xl border-gray-100 bg-white hover:bg-gray-50 font-bold text-[#0B2421] flex gap-2 text-sm">
              <SlidersHorizontal size={18} />
              Bộ lọc
            </Button>
          </div>

          {/* District Tags */}
          <div className="flex items-center gap-2 overflow-x-auto no-scrollbar pb-2">
            {DISTRICTS.map((district) => (
              <button
                key={district}
                onClick={() => setSelectedDistrict(district)}
                className={cn(
                  "px-5 py-2 rounded-xl whitespace-nowrap text-xs font-bold transition-all border",
                  selectedDistrict === district 
                    ? "bg-[#00897B] text-white border-[#00897B] shadow-lg shadow-emerald-900/10" 
                    : "bg-white text-gray-500 border-gray-100 hover:border-emerald-200 hover:text-emerald-600"
                )}
              >
                {district}
              </button>
            ))}
          </div>
        </div>
      </div>

      {/* Main Content */}
      <div className="max-w-6xl mx-auto px-4 sm:px-6 mt-6">
        <div className="flex items-center justify-between mb-6">
          <p className="text-[10px] font-bold text-gray-400 uppercase tracking-[0.2em]">
            TÌM THẤY <span className="text-[#0B2421] font-black">{filteredCourts.length}</span> SÂN
          </p>

          <div className="flex bg-white border border-gray-100 p-1 rounded-xl shadow-sm">
            <button 
              onClick={() => setViewMode("list")}
              className={cn(
                "px-3 py-1.5 rounded-lg text-[10px] font-black flex items-center gap-2 transition-all uppercase tracking-wider",
                viewMode === "list" ? "bg-emerald-50 text-emerald-600" : "text-gray-400 hover:text-gray-600"
              )}
            >
              <List size={14} /> Danh sách
            </button>
            <button 
              onClick={() => setViewMode("map")}
              className={cn(
                "px-3 py-1.5 rounded-lg text-[10px] font-black flex items-center gap-2 transition-all uppercase tracking-wider",
                viewMode === "map" ? "bg-emerald-50 text-emerald-600" : "text-gray-400 hover:text-gray-600"
              )}
            >
              <MapIcon size={14} /> Bản đồ
            </button>
          </div>
        </div>

        {viewMode === "list" ? (
          <div className="grid grid-cols-1 gap-4">
            {filteredCourts.length > 0 ? (
              filteredCourts.map((court) => (
                <CourtCard key={court.id} court={court} />
              ))
            ) : (
              <div className="bg-white rounded-[2.5rem] p-20 text-center border border-gray-100 shadow-sm">
                <div className="w-20 h-20 bg-gray-50 rounded-3xl flex items-center justify-center mx-auto mb-6">
                  <Search className="text-gray-300" size={32} />
                </div>
                <h3 className="text-xl font-black text-[#0B2421] mb-2">Không tìm thấy sân</h3>
                <p className="text-gray-400 text-sm font-medium">Hãy thử thay đổi từ khóa hoặc khu vực lọc của bạn nhé!</p>
              </div>
            )}
          </div>
        ) : (
          <div className="bg-white rounded-[2.5rem] h-[60vh] flex items-center justify-center border border-gray-100 shadow-sm">
            <div className="text-center">
              <MapIcon size={48} className="mx-auto text-emerald-200 mb-4" />
              <p className="text-gray-400 font-bold">Chức năng bản đồ đang được phát triển...</p>
            </div>
          </div>
        )}
      </div>
    </div>
  );
}
