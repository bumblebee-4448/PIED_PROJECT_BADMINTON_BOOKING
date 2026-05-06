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

export interface CourtMapItem {
  id: string;
  latitude: number;
  longitude: number;
}

export interface MapSearchResponse {
  listCourts: CourtMapItem[];
  totalCount: number;
}

export interface BoundingBoxRequest {
  minLon: number;
  minLat: number;
  maxLon: number;
  maxLat: number;
}

export interface RadiusRequest {
  latitude: number;
  longitude: number;
  radiusKm?: number;
}

export interface TextSearchRequest {
  text: string;
  radiusKm?: number;
}
