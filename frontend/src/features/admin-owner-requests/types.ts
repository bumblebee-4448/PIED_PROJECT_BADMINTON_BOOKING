export interface OwnerRequest {
  id: string;
  businessName: string;
  taxCode: string;
  businessAddress: string;
  identityNumber: string;
  firstName?: string;
  lastName?: string;
  phoneNumber?: string;
  businessLicenseUrl: string;
  identityCardFrontUrl: string;
  identityCardBackUrl: string;
  status: "Pending" | "Approved" | "Rejected";
  createdAt: string;
  customerId: string;
  customerEmail?: string;
  // Backend có thể trả về thông tin customer dạng nested
  customer?: {
    firstName?: string;
    lastName?: string;
    phoneNumber?: string;
    email?: string;
  };
}

export interface GetOwnerRequestsParams {
  id?: string;
  search?: string;
  pageSize?: number;
  pageIndex?: number;
}

export interface GetOwnerRequestsResponse {
  items: OwnerRequest[];
  totalCount: number;
  pageIndex: number;
  pageSize: number;
}

export interface RejectOwnerRequestParams {
  ownerRequestId: string;
  rejectReason: string;
}
