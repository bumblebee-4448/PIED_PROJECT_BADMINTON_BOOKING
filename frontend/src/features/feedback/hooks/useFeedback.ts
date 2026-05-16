import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { toast } from "sonner";

import { QUERY_KEYS } from "@/shared/constants";
import { feedbackService } from "../services";
import type { CreateFeedbackRequest, DeleteFeedbackRequest, UpdateFeedbackRequest } from "../types";

function getErrorMessage(error: unknown) {
  if (typeof error !== "object" || error === null) {
    return "Đã có lỗi xảy ra";
  }

  const response = "response" in error ? error.response : undefined;
  if (typeof response !== "object" || response === null) {
    return "message" in error && typeof error.message === "string"
      ? error.message
      : "Đã có lỗi xảy ra";
  }

  const data = "data" in response ? response.data : undefined;
  if (typeof data !== "object" || data === null) {
    return "Đã có lỗi xảy ra";
  }

  const errors = "errors" in data ? data.errors : undefined;
  if (typeof errors === "object" && errors !== null) {
    const originalMessage =
      "originalMessage" in errors ? errors.originalMessage : undefined;
    if (typeof originalMessage === "string") {
      return originalMessage;
    }
  }

  const message = "message" in data ? data.message : undefined;
  const pascalMessage = "Message" in data ? data.Message : undefined;

  return typeof message === "string"
    ? message
    : typeof pascalMessage === "string"
      ? pascalMessage
      : "Đã có lỗi xảy ra";
}

function isFeedbackNotFound(error: unknown) {
  return getErrorMessage(error).toLowerCase().includes("feedback not found");
}

export function useUpsertFeedback() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (payload: CreateFeedbackRequest | UpdateFeedbackRequest) => {
      try {
        // If it has an ID, it's an update
        if ("id" in payload && payload.id) {
          await feedbackService.update(payload as UpdateFeedbackRequest);
          return "updated" as const;
        }
        
        await feedbackService.create(payload as CreateFeedbackRequest);
        return "created" as const;
      } catch (error) {
        // Fallback for cases where UI thinks it's an update but backend disagrees
        if (isFeedbackNotFound(error)) {
          await feedbackService.create(payload as CreateFeedbackRequest);
          return "created" as const;
        }
        throw error;
      }
    },
    onSuccess: (result) => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.BOOKINGS });
      queryClient.invalidateQueries({ queryKey: ["court-feedbacks"] });
      queryClient.invalidateQueries({ queryKey: ["feedback-lookup"] });
      toast.success(
        result === "updated"
          ? "Cập nhật đánh giá thành công"
          : "Gửi đánh giá thành công",
      );
    },
    onError: (error) => {
      toast.error(getErrorMessage(error));
    },
  });
}

export function useDeleteFeedback() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (payload: DeleteFeedbackRequest) =>
      feedbackService.delete(payload),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.BOOKINGS });
      queryClient.invalidateQueries({ queryKey: ["court-feedbacks"] });
      queryClient.invalidateQueries({ queryKey: ["feedback-lookup"] });
      toast.success("Xóa đánh giá thành công");
    },
    onError: (error) => {
      toast.error(getErrorMessage(error));
    },
  });
}

export function useCourtFeedbacks(
  courtId: string,
  pageIndex = 1,
  pageSize = 10
) {
  return useQuery({
    queryKey: QUERY_KEYS.COURT_FEEDBACKS(courtId, pageIndex, pageSize),
    queryFn: () => feedbackService.getByCourt(courtId, pageIndex, pageSize),
    enabled: !!courtId,
    staleTime: 30000,
    refetchInterval: 60000,
    refetchIntervalInBackground: true,
  });
}

