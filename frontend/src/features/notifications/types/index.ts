import type { PaginatedResponse } from "@/shared/types";

export interface NotificationItem {
  id: string;
  userId: string;
  title: string;
  content: string;
  type: string;
  isRead: boolean;
  createdAt: string;
  updatedAt: string;
  data?: any;
}

export type GetNotificationResponse = PaginatedResponse<NotificationItem>;

export interface PagingRequest {
  pageSize?: number;
  pageIndex?: number;
}
