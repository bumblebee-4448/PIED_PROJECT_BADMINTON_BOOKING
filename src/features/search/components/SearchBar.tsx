import { Search, SlidersHorizontal } from "lucide-react";
import { Input } from "@/shared/components/ui/input";
import { Button } from "@/shared/components/ui/button";
import { useSearchStore } from "../store";

export const SearchBar = () => {
  const { query, setQuery } = useSearchStore();

  return (
    <div className="flex gap-4 w-full">
      <div className="relative flex-1 group">
        <Search className="absolute left-5 top-1/2 -translate-y-1/2 w-5 h-5 text-gray-400 group-focus-within:text-[#00CE98] transition-colors" />
        <Input
          placeholder="Tìm sân theo tên, địa chỉ..."
          value={query}
          onChange={(e) => setQuery(e.target.value)}
          className="h-14 pl-14 pr-6 rounded-2xl border-gray-200 focus:ring-2 focus:ring-[#00CE98]/20 focus:border-[#00CE98] transition-all bg-white shadow-md text-base"
        />
      </div>
      <Button
        variant="outline"
        className="h-14 px-8 rounded-2xl border-gray-200 bg-white hover:bg-gray-50 flex items-center gap-2 font-bold text-gray-700 shadow-md transition-all active:scale-95"
      >
        <SlidersHorizontal size={20} className="text-gray-400" />
        Bộ lọc
      </Button>
    </div>
  );
};
