export interface Court {
  courtId: string;
  name: string;
  address: string;
  status: string;
  averageRating: number;
  phoneNumber: string;
  pictureUrl: string;
  mapUrl: string;
}

export interface CourtDetail extends Court {
  openTime: string;
  closeTime: string;
  description: string | null;
}

export interface CourtFilters {
  search?: string;
  district?: string;
  page?: number;
  limit?: number;
}

export interface ApiResponse<T> {
  success: boolean;
  message: string;
  data: T;
  errors?: any;
  traceId?: string;
  timestampUtc?: string;
}

export interface CourtListResponse {
  items: Court[];
  totalItems: number;
  pageSize: number;
  pageIndex: number;
}
