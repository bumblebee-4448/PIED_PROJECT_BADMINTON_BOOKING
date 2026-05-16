import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toast } from "sonner";

import { QUERY_KEYS } from "@/shared/constants";
import { bookingsService } from "../services";
import type { BookingFeedbackPayload, DeleteFeedbackPayload } from "../types";

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

export function useUpsertBookingFeedback() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (payload: BookingFeedbackPayload) => {
      try {
        await bookingsService.updateFeedback(payload);
        return "updated" as const;
      } catch (error) {
        if (!isFeedbackNotFound(error)) {
          throw error;
        }

        await bookingsService.createFeedback(payload);
        return "created" as const;
      }
    },
    onSuccess: (result) => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.BOOKINGS });
      queryClient.invalidateQueries({ queryKey: ["court-feedbacks"] });
      queryClient.invalidateQueries({ queryKey: ["booking-feedback-lookup"] });
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

export function useDeleteBookingFeedback() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (payload: DeleteFeedbackPayload) =>
      bookingsService.deleteFeedback(payload),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.BOOKINGS });
      queryClient.invalidateQueries({ queryKey: ["court-feedbacks"] });
      queryClient.invalidateQueries({ queryKey: ["booking-feedback-lookup"] });
      toast.success("Xóa đánh giá thành công");
    },
  });
}
