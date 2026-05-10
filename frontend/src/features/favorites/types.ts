export interface CourtLike {
  courtId: string;
  courtName: string;
  courtAddress: string;
  pictureUrl: string;
  price: number;
  rating: number;
  // Optional fields
  reviews?: number;
  tag?: string;
}

export interface LikeListResponse {
  items: CourtLike[];
  totalItems: number; // Khớp với TotalItems trong PageResult backend
  pageIndex: number;
  pageSize: number;
}
