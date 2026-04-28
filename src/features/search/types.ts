export interface Court {
  id: string;
  name: string;
  address: string;
  district: string;
  rating: number;
  reviews: number;
  pricePerHour: number;
  image: string;
  availableCourts: number;
  isFavorite?: boolean;
}

export type ViewMode = "list" | "map";

export interface SearchState {
  query: string;
  selectedDistrict: string;
  viewMode: ViewMode;
}
