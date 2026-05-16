import { useQuery } from "@tanstack/react-query";

import { QUERY_KEYS } from "@/shared/constants";
import { useAuthStore } from "@/features/auth/store";
import { courtService } from "@/features/courts/services";
import { feedbackService } from "../services";
import type { Feedback } from "../types";

const LOOKUP_PAGE_SIZE = 100;

function normalizeText(value?: string | null) {
  return (value || "").trim().toLowerCase();
}

function isCompletedBooking(status?: string) {
  const s = normalizeText(status);
  return s === "complete" || s === "completed";
}

export function useFeedbackLookup(
  booking: {
    bookingId: string;
    courtId?: string;
    courtName: string;
    address: string;
    status: string;
  },
  enabled = true,
) {
  const user = useAuthStore((state) => state.user);
  const customerName = [user?.firstName, user?.lastName]
    .filter(Boolean)
    .join(" ")
    .trim();

  return useQuery({
    queryKey: [
      ...QUERY_KEYS.FEEDBACK_LOOKUP(booking.bookingId),
      booking.courtId,
      booking.courtName,
      customerName,
    ],
    enabled:
      enabled &&
      isCompletedBooking(booking.status) &&
      !!booking.bookingId,
    staleTime: 0,
    refetchInterval: 3000,
    refetchIntervalInBackground: true,
    queryFn: async (): Promise<Feedback | null> => {
      // 1. Try direct API first (Best approach)
      const directFeedback = await feedbackService.getByBookingId(booking.bookingId);
      if (directFeedback) return directFeedback;

      // 2. Fallback heuristic (Only if direct API fails or not yet implemented on backend)
      let courtId = booking.courtId;

      if (!courtId && booking.courtName) {
        try {
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
        } catch (e) {
          console.error("Error fetching courts for fallback lookup:", e);
        }
      }

      if (!courtId) {
        return null;
      }

      try {
        const feedbacks = await feedbackService.getByCourt(
          courtId,
          1,
          LOOKUP_PAGE_SIZE,
        );

        const normalizedFullName = normalizeText(customerName);
        const normalizedFirstName = normalizeText(user?.firstName);

        return (
          feedbacks.items.find(
            (feedback: Feedback) => feedback.bookingId === booking.bookingId,
          ) ||
          feedbacks.items.find((feedback: Feedback) => {
            const feedbackName = normalizeText(feedback.nameCustomer);
            return (
              feedbackName === normalizedFullName ||
              (!!normalizedFirstName && feedbackName === normalizedFirstName)
            );
          }) ||
          null
        );
      } catch (e) {
        console.error("Error fetching court feedbacks for fallback lookup:", e);
        return null;
      }
    },
  });
}
