import { useQuery } from "@tanstack/react-query";

import { useAuthStore } from "@/features/auth/store";
import { courtService } from "@/features/courts/services";
import type { CourtFeedback } from "@/features/courts/types";
import type { GetBookingResponse } from "../types";

const LOOKUP_PAGE_SIZE = 100;

function normalizeText(value?: string | null) {
  return (value || "").trim().toLowerCase();
}

function isCompletedBooking(status?: string) {
  return status === "Complete" || status === "Completed";
}

export function useBookingFeedbackLookup(
  booking: GetBookingResponse,
  enabled = true,
) {
  const user = useAuthStore((state) => state.user);
  const customerName = [user?.firstName, user?.lastName]
    .filter(Boolean)
    .join(" ")
    .trim();

  return useQuery({
    queryKey: [
      "booking-feedback-lookup",
      booking.bookingId,
      booking.courtId,
      booking.courtName,
      customerName,
    ],
    enabled:
      enabled &&
      isCompletedBooking(booking.status) &&
      !!booking.bookingId &&
      (!!booking.courtId || !!booking.courtName) &&
      !!customerName,
    staleTime: 30_000,
    queryFn: async (): Promise<CourtFeedback | null> => {
      let courtId = booking.courtId;

      if (!courtId) {
        const courts = await courtService.getCourts({
          search: booking.courtName,
          page: 1,
          limit: 10,
        });

        const matchedCourt =
          courts.items.find(
            (court) =>
              normalizeText(court.name) === normalizeText(booking.courtName) &&
              normalizeText(court.address) === normalizeText(booking.address),
          ) ||
          courts.items.find(
            (court) =>
              normalizeText(court.name) === normalizeText(booking.courtName),
          );

        courtId = matchedCourt?.courtId;
      }

      if (!courtId) {
        return null;
      }

      const feedbacks = await courtService.getCourtFeedbacks(
        courtId,
        1,
        LOOKUP_PAGE_SIZE,
      );

      const normalizedFullName = normalizeText(customerName);
      const normalizedFirstName = normalizeText(user?.firstName);

      return (
        feedbacks.items.find(
          (feedback) => feedback.bookingId === booking.bookingId,
        ) ||
        feedbacks.items.find((feedback) => {
          const feedbackName = normalizeText(feedback.nameCustomer);
          return (
            feedbackName === normalizedFullName ||
            (!!normalizedFirstName && feedbackName === normalizedFirstName)
          );
        }) ||
        null
      );
    },
  });
}
