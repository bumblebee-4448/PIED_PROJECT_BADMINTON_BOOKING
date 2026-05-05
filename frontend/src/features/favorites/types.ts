export interface CourtLike {
  courtId: string;
  courtName: string;
  courtAddress: string;
  // Các field mở rộng để UI hiển thị giống thiết kế (Mock/Future expansion)
  rating?: number;
  reviews?: number;
  price?: number;
  availableSlots?: number;
  imageUrl?: string;
  tag?: string;
}

export interface LikeListResponse {
  items: CourtLike[];
  totalItems: number; // Khớp với TotalItems trong PageResult backend
  pageIndex: number;
  pageSize: number;
}
