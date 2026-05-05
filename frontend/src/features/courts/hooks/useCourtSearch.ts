import { useState } from "react";
import { useDebounce } from "@/shared/hooks";

export const useCourtSearch = (initialValue = "", delay = 500) => {
  const [searchQuery, setSearchQuery] = useState(initialValue);
  // debouncedSearch sẽ thay đổi sau khi người dùng ngừng gõ (mặc định 500ms)
  const debouncedSearch = useDebounce(searchQuery, delay);

  const handleSearchChange = (value: string) => {
    // Chỉ cập nhật text để hiển thị lên ô input
    setSearchQuery(value);
  };

  const clearSearch = () => {
    setSearchQuery("");
  };

  return {
    searchQuery,
    setSearchQuery: handleSearchChange,
    debouncedSearch,
    clearSearch,
  };
};
