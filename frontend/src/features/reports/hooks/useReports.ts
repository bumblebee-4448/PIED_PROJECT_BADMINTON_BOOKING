import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { toast } from "sonner";
import { reportsService } from "../services";
import { QUERY_KEYS } from "@/shared/constants";
import type { 
  CreateReportBookingRequest, 
  CreateSystemReportRequest,
  GetReportBookingsRequest,
  GetSystemReportRequest
} from "../types";




export function useCreateReportBooking() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (data: CreateReportBookingRequest) => reportsService.createBookingReport(data),
    onSuccess: () => {
      toast.success("Báo cáo đơn đặt sân thành công");
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.REPORTS_BOOKING });
    },
    onError: (error: any) => {
      toast.error(error?.response?.data?.message || "Không thể gửi báo cáo. Vui lòng thử lại.");
    },
  });
}

export function useCreateSystemReport() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (data: CreateSystemReportRequest) => reportsService.createSystemReport(data),
    onSuccess: () => {
      toast.success("Gửi báo cáo hệ thống thành công");
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.REPORTS_SYSTEM });
    },
    onError: (error: any) => {
      toast.error(error?.response?.data?.message || "Không thể gửi báo cáo hệ thống. Vui lòng thử lại.");
    },
  });
}

export function useBookingReports(
  params: GetReportBookingsRequest = {}
) {
  return useQuery({
    queryKey: [...QUERY_KEYS.REPORTS_BOOKING, params],
    queryFn: () => reportsService.getBookingReports(params),
    refetchInterval: 60000,
    refetchIntervalInBackground: true,
    staleTime: 30000,
  });
}

export function useSystemReports(
  params: GetSystemReportRequest = {}
) {
  return useQuery({
    queryKey: [...QUERY_KEYS.REPORTS_SYSTEM, params],
    queryFn: () => reportsService.getSystemReports(params),
    refetchInterval: 60000,
    refetchIntervalInBackground: true,
    staleTime: 30000,
  });
}

export function useConfirmBookingReport() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (reportBookingId: string) =>
      reportsService.confirmBookingReport(reportBookingId),
    onSuccess: () => {
      toast.success("Đã xử lý báo cáo đặt sân");
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.REPORTS_BOOKING });
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.NOTIFICATIONS() });
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.UNREAD_COUNT });
    },
    onError: (error: any) => {
      toast.error(error?.response?.data?.message || "Không thể xử lý báo cáo. Vui lòng thử lại.");
    },
  });
}

export function useSubmitSystemReportReply() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (id: string) => reportsService.submitSystemReportReply({ id }),
    onSuccess: () => {
      toast.success("Đã phản hồi báo cáo hệ thống");
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.REPORTS_SYSTEM });
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.NOTIFICATIONS() });
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.UNREAD_COUNT });
    },
    onError: (error: any) => {
      toast.error(error?.response?.data?.message || "Không thể phản hồi báo cáo. Vui lòng thử lại.");
    },
  });
}

