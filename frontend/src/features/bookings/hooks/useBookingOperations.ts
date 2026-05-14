import { useMutation, useQuery } from "@tanstack/react-query";
import { bookingsService } from "../services";
import type { CreateBookingRequest } from "../types";

export const useAvailableSlots = (subCourtId: string, date: string) => {
  return useQuery({
    queryKey: ["available-slots", subCourtId, date],
    queryFn: () => bookingsService.getAvailableSlots(subCourtId, date),
    enabled: !!subCourtId && !!date,
  });
};

export const useCreateBooking = () => {
  return useMutation({
    mutationFn: (data: CreateBookingRequest) => bookingsService.create(data),
  });
};

export const useCreateBookingByWallet = () => {
  return useMutation({
    mutationFn: (data: CreateBookingRequest) => bookingsService.createByWallet(data),
  });
};

export const useCancelBooking = () => {
  return useMutation({
    mutationFn: (bookingId: string) => bookingsService.cancel(bookingId),
  });
};
