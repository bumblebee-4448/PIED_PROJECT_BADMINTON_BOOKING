export interface Feedback {
  id: string;
  feedbackId?: string;
  bookingId: string;
  customerId?: string;
  nameCustomer: string;
  comment: string | null;
  rating: number;
  createdAt: string;
}

export interface FeedbackListResponse {
  items: Feedback[];
  totalItems: number;
  pageSize: number;
  pageIndex: number;
}

export interface CreateFeedbackRequest {
  bookingId: string;
  rating: number;
  comment?: string | null;
}

export interface UpdateFeedbackRequest {
  id: string;
  bookingId: string;
  rating: number;
  comment?: string | null;
}

export interface DeleteFeedbackRequest {
  id: string;
}

export interface FeedbackLookupRequest {
  bookingId: string;
  courtId?: string;
  courtName: string;
  address: string;
}
