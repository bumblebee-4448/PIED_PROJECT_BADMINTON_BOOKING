import { List, Map } from "lucide-react";
import { useSearchStore } from "../store";
import { cn } from "@/lib/utils";

export const ViewToggle = () => {
  const { viewMode, setViewMode } = useSearchStore();

  return (
    <div className="flex bg-gray-100 p-1 rounded-xl shadow-inner">
      <button
        onClick={() => setViewMode("list")}
        className={cn(
          "flex items-center gap-2 px-4 py-1.5 rounded-lg text-sm font-semibold transition-all duration-200",
          viewMode === "list"
            ? "bg-white text-[#004E43] shadow-sm"
            : "text-gray-500 hover:text-gray-700"
        )}
      >
        <List size={16} />
        Danh sách
      </button>
      <button
        onClick={() => setViewMode("map")}
        className={cn(
          "flex items-center gap-2 px-4 py-1.5 rounded-lg text-sm font-semibold transition-all duration-200",
          viewMode === "map"
            ? "bg-white text-[#004E43] shadow-sm"
            : "text-gray-500 hover:text-gray-700"
        )}
      >
        <Map size={16} />
        Bản đồ
      </button>
    </div>
  );
};
