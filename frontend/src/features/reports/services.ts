import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { PaginatedResponse } from "@/shared/types";
import type {
  CreateReportBookingRequest,
  ReportBookingResponse,
  GetReportBookingsRequest,
  CreateSystemReportRequest,
  SystemReportResponse,
  GetSystemReportRequest,
  SubmitReportReplyRequest,
} from "./types";

export const reportsService = {
  // Booking Reports
  createBookingReport: async (data: CreateReportBookingRequest): Promise<string> => {
    return apiClient.post(API_ENDPOINTS.REPORT.CREATE_BOOKING, data) as Promise<string>;
  },

  getBookingReports: async (
    params: GetReportBookingsRequest,
  ): Promise<PaginatedResponse<ReportBookingResponse>> => {
    return apiClient.get(API_ENDPOINTS.REPORT.GET_BOOKING, {
      params: {
        PageIndex: params.pageIndex,
        PageSize: params.pageSize,
      },
    }) as unknown as Promise<PaginatedResponse<ReportBookingResponse>>;
  },

  confirmBookingReport: async (reportBookingId: string): Promise<string> => {
    return apiClient.patch(API_ENDPOINTS.REPORT.CONFIRM_BOOKING, {
      reportId: reportBookingId,
    }) as Promise<string>;
  },

  // System Reports
  createSystemReport: async (data: CreateSystemReportRequest): Promise<string> => {
    return apiClient.post(API_ENDPOINTS.SYSTEM_REPORT.CREATE, data) as Promise<string>;
  },

  getSystemReports: async (
    params: GetSystemReportRequest,
  ): Promise<PaginatedResponse<SystemReportResponse>> => {
    return apiClient.get(API_ENDPOINTS.SYSTEM_REPORT.GET_ALL, {
      params: {
        PageIndex: params.pageIndex,
        PageSize: params.pageSize,
      },
    }) as unknown as Promise<PaginatedResponse<SystemReportResponse>>;
  },

  submitSystemReportReply: async (data: SubmitReportReplyRequest): Promise<string> => {
    return apiClient.patch(API_ENDPOINTS.SYSTEM_REPORT.REPLY, data) as Promise<string>;
  },
};
