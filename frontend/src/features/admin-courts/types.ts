export interface PendingCourt {
  courtId: string;
  ownerId: string;
  ownerName: string;
  name: string;
  status: string;
  address: string;
  openTime: string;
  closeTime: string;
  pictureUrl: string;
  description?: string;
  mapUrl?: string;
}

export interface GetPendingCourtsRequest {
  pageIndex: number;
  pageSize: number;
  name?: string;
}

export interface RejectCourtRequest {
  reason: string;
}
