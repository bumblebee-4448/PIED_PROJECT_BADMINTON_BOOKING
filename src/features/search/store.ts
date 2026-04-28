import { create } from "zustand";
import type { SearchState, ViewMode } from "./types";

interface SearchStore extends SearchState {
  setQuery: (query: string) => void;
  setSelectedDistrict: (district: string) => void;
  setViewMode: (mode: ViewMode) => void;
}

export const useSearchStore = create<SearchStore>((set) => ({
  query: "",
  selectedDistrict: "Tất cả",
  viewMode: "list",
  setQuery: (query) => set({ query }),
  setSelectedDistrict: (selectedDistrict) => set({ selectedDistrict }),
  setViewMode: (viewMode) => set({ viewMode }),
}));
