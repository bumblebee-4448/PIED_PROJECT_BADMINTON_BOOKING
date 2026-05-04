import { cn } from "@/lib/utils";

export type FilterStatus = "all" | "ongoing" | "completed" | "cancelled";

interface BookingFiltersProps {
  activeStatus: FilterStatus;
  onStatusChange: (status: FilterStatus) => void;
  counts?: {
    all: number;
    ongoing: number;
    completed: number;
    cancelled: number;
  };
}

export function BookingFilters({ activeStatus, onStatusChange, counts }: BookingFiltersProps) {
  const FILTERS: { label: string; value: FilterStatus }[] = [
    { label: "Tất cả", value: "all" },
    { label: "Đang diễn ra", value: "ongoing" },
    { label: "Hoàn thành", value: "completed" },
    { label: "Đã hủy", value: "cancelled" },
  ];

  return (
    <div className="flex flex-wrap items-center gap-3 mb-8">
      {FILTERS.map((filter) => {
        const isActive = activeStatus === filter.value;
        const count = counts ? counts[filter.value] : 0;

        return (
          <button
            key={filter.value}
            onClick={() => onStatusChange(filter.value)}
            className={cn(
              "px-5 py-2.5 rounded-full text-sm font-bold transition-all duration-300 flex items-center gap-2",
              isActive
                ? "bg-[#00897B] text-white shadow-lg shadow-[#00897B]/20 scale-105"
                : "bg-gray-100 text-gray-500 hover:bg-gray-200"
            )}
          >
            {filter.label}
            {counts && (
              <span
                className={cn(
                  "flex items-center justify-center min-w-[20px] h-5 px-1.5 rounded-full text-[10px] font-black",
                  isActive ? "bg-white/20 text-white" : "bg-gray-200 text-gray-500"
                )}
              >
                {count}
              </span>
            )}
          </button>
        );
      })}
    </div>
  );
}
