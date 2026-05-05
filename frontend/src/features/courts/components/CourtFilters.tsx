import { Search } from "lucide-react";
// import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";

// const DISTRICTS = ["Tất cả", "Tân Bình", "Quận 1", "Quận 2", "Quận 3", "Quận 4", "Quận 5", "Quận 6", "Quận 7"];

interface CourtFiltersProps {
  searchQuery: string;
  setSearchQuery: (val: string) => void;
  selectedDistrict: string;
  setSelectedDistrict: (val: string) => void;
}

export function CourtFilters({
  searchQuery,
  setSearchQuery,
}: CourtFiltersProps) {
  return (
    <div className="max-w-6xl mx-auto px-4 sm:px-6">
      <div className="mb-6">
        <div className="flex items-center gap-2 mb-1">
          <h1 className="text-3xl font-black text-[#0B2421]">
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
          <Search className="absolute left-4 top-1/2 -translate-y-1/2 text-gray-400 group-focus-within:text-emerald-500 transition-colors z-10" size={18} />
          <Input 
            placeholder="Tìm sân theo tên, địa chỉ..."
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
            className="pl-12 h-12 bg-white border-gray-200 rounded-xl shadow-sm focus:ring-emerald-500/20 focus:border-emerald-500/50 transition-all font-medium text-[#0B2421] text-sm"
          />
        </div>
        
        {/* <Button variant="outline" className="h-11 px-6 rounded-xl border-gray-100 bg-white hover:bg-gray-50 font-bold text-[#0B2421] flex gap-2 text-sm">
          <SlidersHorizontal size={18} />
          Bộ lọc
        </Button> */}
      </div>

      {/* District Tags */}
      {/* <div className="flex items-center gap-2 overflow-x-auto no-scrollbar pb-2">
        {DISTRICTS.map((district) => (
          <Button
            key={district}
            variant={selectedDistrict === district ? "default" : "outline"}
            onClick={() => setSelectedDistrict(district)}
            className={cn(
              "px-5 py-2 rounded-xl whitespace-nowrap text-xs font-bold transition-all border h-auto",
              selectedDistrict === district 
                ? "bg-[#00897B] text-white border-[#00897B] shadow-lg shadow-emerald-900/10 hover:bg-[#00796B]" 
                : "bg-white text-gray-500 border-gray-100 hover:border-emerald-200 hover:text-emerald-600"
            )}
          >
            {district}
          </Button>
        ))}
      </div> */}
    </div>
  );
}
