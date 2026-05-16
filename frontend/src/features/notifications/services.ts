import { apiClient } from "@/lib/axios";
import type { PaginatedResponse } from "@/shared/types";
import type { NotificationItem, PagingRequest } from "./types";

export const notificationService = {
  getNotifications: async (params: PagingRequest) => {
    return apiClient.get<PaginatedResponse<NotificationItem>>("/Notification/GetNotification", {
      params: {
        PageIndex: params.pageIndex,
        PageSize: params.pageSize,
      },
    }) as unknown as Promise<PaginatedResponse<NotificationItem>>;
  },

  getAdminNotifications: async (params: PagingRequest) => {
    return apiClient.get<PaginatedResponse<NotificationItem>>("/Notification/AdminGetNotification", {
      params: {
        PageIndex: params.pageIndex,
        PageSize: params.pageSize,
      },
    }) as unknown as Promise<PaginatedResponse<NotificationItem>>;
  },

  getUnreadCount: async () => {
    return apiClient.get<number>("/Notification/GetUnreadCount") as unknown as Promise<number>;
  },

  readNotification: async (id: string) => {
    return apiClient.put<boolean>(`/Notification/ReadNotification/${id}`) as unknown as Promise<boolean>;
  },

  markAllAsRead: async () => {
    return apiClient.put<boolean>("/Notification/MarkAllAsRead") as unknown as Promise<boolean>;
  },
  
  deleteNotification: async (id: string) => {
    return apiClient.delete<boolean>(`/Notification/DeleteNotification/${id}`) as unknown as Promise<boolean>;
  },

  deleteAllRead: async () => {
    return apiClient.delete<boolean>("/Notification/DeleteAllRead") as unknown as Promise<boolean>;
  },
};
