import { useSearchStore } from "../store";
import { cn } from "@/lib/utils";

const DISTRICTS = [
  "Tất cả",
  "Tân Bình",
  "Quận 1",
  "Quận 2",
  "Quận 3",
  "Quận 4",
  "Quận 5",
  "Quận 6",
  "Quận 7",
  "Quận 8",
  "Quận 9",
  "Quận 10",
];

export const DistrictTabs = () => {
  const { selectedDistrict, setSelectedDistrict } = useSearchStore();

  return (
    <div className="flex gap-2 overflow-x-auto pb-2 scrollbar-hide no-scrollbar">
      {DISTRICTS.map((district) => (
        <button
          key={district}
          onClick={() => setSelectedDistrict(district)}
          className={cn(
            "px-5 py-2 rounded-full whitespace-nowrap text-sm font-semibold transition-all duration-200 border",
            selectedDistrict === district
              ? "bg-[#004E43] text-white border-[#004E43] shadow-md shadow-[#004E43]/20"
              : "bg-white text-gray-500 border-gray-200 hover:border-[#00CE98] hover:text-[#00CE98]"
          )}
        >
          {district}
        </button>
      ))}
    </div>
  );
};
