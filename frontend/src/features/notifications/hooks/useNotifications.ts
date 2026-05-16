import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { notificationService } from "../services";
import { QUERY_KEYS } from "@/shared/constants";
import { useAuthStore } from "@/features/auth/store";
import type { PagingRequest } from "../types";

export const useNotifications = (params: PagingRequest = { pageIndex: 1, pageSize: 20 }) => {
  const { accessToken, role } = useAuthStore();
  const isAdmin = role?.toLowerCase() === "admin";

  return useQuery({
    queryKey: QUERY_KEYS.NOTIFICATIONS(params),
    queryFn: () => isAdmin 
      ? notificationService.getAdminNotifications(params)
      : notificationService.getNotifications(params),
    enabled: !!accessToken,
    staleTime: 1000 * 60, // 1 minute
  });
};

export const useUnreadCount = () => {
  const { accessToken } = useAuthStore();

  return useQuery({
    queryKey: QUERY_KEYS.UNREAD_COUNT,
    queryFn: () => notificationService.getUnreadCount(),
    enabled: !!accessToken,
    staleTime: 1000 * 30, // 30 seconds
    refetchInterval: 1000 * 60, // Auto refetch every minute
  });
};

export const useNotificationActions = () => {
  const queryClient = useQueryClient();

  const readMutation = useMutation({
    mutationFn: (id: string) => notificationService.readNotification(id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.UNREAD_COUNT });
      queryClient.invalidateQueries({ queryKey: ["notifications"] });
    },
  });

  const markAllReadMutation = useMutation({
    mutationFn: () => notificationService.markAllAsRead(),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.UNREAD_COUNT });
      queryClient.invalidateQueries({ queryKey: ["notifications"] });
    },
  });

  const deleteMutation = useMutation({
    mutationFn: (id: string) => notificationService.deleteNotification(id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.UNREAD_COUNT });
      queryClient.invalidateQueries({ queryKey: ["notifications"] });
    },
  });

  const deleteAllReadMutation = useMutation({
    mutationFn: () => notificationService.deleteAllRead(),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.UNREAD_COUNT });
      queryClient.invalidateQueries({ queryKey: ["notifications"] });
    },
  });

  return {
    readNotification: readMutation.mutate,
    isReading: readMutation.isPending,
    markAllRead: markAllReadMutation.mutate,
    isMarkingAllRead: markAllReadMutation.isPending,
    deleteNotification: deleteMutation.mutate,
    isDeleting: deleteMutation.isPending,
    deleteAllRead: deleteAllReadMutation.mutate,
    isDeletingAllRead: deleteAllReadMutation.isPending,
  };
};
