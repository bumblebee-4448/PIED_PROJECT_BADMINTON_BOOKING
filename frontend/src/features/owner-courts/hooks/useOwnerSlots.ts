import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { ownerCourtService } from "../services";
import type { 
  GetAvailableSlotsRequest, 
  CreateOverrideSlotRequest,
  CreateExceptionSlotRequest,
  GetBookingDetailResponse
} from "../types";
import { toast } from "sonner";

export const useSubCourtSlots = (subCourtId: string) => {
  return useQuery({
    queryKey: ["sub-court-slots", subCourtId],
    queryFn: () => ownerCourtService.getSubCourtSlots(subCourtId),
    enabled: !!subCourtId,
  });
};

export const useAvailableSlots = (params: GetAvailableSlotsRequest) => {
  return useQuery({
    queryKey: ["available-slots", params],
    queryFn: () => ownerCourtService.getAvailableSlots(params),
    enabled: !!params.subCourtId && !!params.date,
  });
};

export const useOverrideSlots = (subCourtId: string) => {
  return useQuery({
    queryKey: ["override-slots", subCourtId],
    queryFn: () => ownerCourtService.getOverrideSlotsBySubCourtId(subCourtId),
    enabled: !!subCourtId,
  });
};

export const useCreateOverrideSlot = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (data: CreateOverrideSlotRequest) => ownerCourtService.createOverrideSlot(data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["available-slots"] });
      queryClient.invalidateQueries({ queryKey: ["override-slots"] });
    },
  });
};

export const useCreateExceptionSlot = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (data: CreateExceptionSlotRequest) => ownerCourtService.createExceptionSlot(data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["available-slots"] });
    },
  });
};

export const useExceptionSlots = (subCourtId: string) => {
  return useQuery({
    queryKey: ["exception-slots", subCourtId],
    queryFn: () => ownerCourtService.getExceptionSlotsBySubCourtId(subCourtId),
    enabled: !!subCourtId,
  });
};

export const useUnlockException = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (exceptionId: string) => ownerCourtService.unlockException(exceptionId),
    onSuccess: () => {
      toast.success("Mở khóa slot thành công");
      queryClient.invalidateQueries({ queryKey: ["available-slots"] });
    },
  });
};

export const useRemoveOverrideSlot = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (overrideSlotId: string) => ownerCourtService.removeOverrideSlot(overrideSlotId),
    onSuccess: () => {
      toast.success("Gỡ gộp slot thành công");
      queryClient.invalidateQueries({ queryKey: ["available-slots"] });
      queryClient.invalidateQueries({ queryKey: ["override-slots"] });
    },
  });
};

export const useUpdateConfigSlotPrice = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (data: { configSlotId: string; newPrice: number }) => ownerCourtService.updateConfigSlotPrice(data),
    onSuccess: () => {
      toast.success("Cập nhật giá slot thành công");
      queryClient.invalidateQueries({ queryKey: ["available-slots"] });
    },
  });
};

export const useBookingDetail = (bookingDetailsId: string, options?: any) => {
  return useQuery<GetBookingDetailResponse>({
    queryKey: ["booking-detail", bookingDetailsId],
    queryFn: () => ownerCourtService.getBookingDetail(bookingDetailsId),
    enabled: !!bookingDetailsId && (options?.enabled ?? true),
    ...options,
  });
};
