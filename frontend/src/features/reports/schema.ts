import { z } from "zod";

export const createReportBookingSchema = z.object({
  reason: z.string().min(10, "Lý do phải có ít nhất 10 ký tự").max(500, "Lý do không được quá 500 ký tự"),
  bookingId: z.string().uuid("Mã đặt sân không hợp lệ"),
});

export const createSystemReportSchema = z.object({
  title: z.string().min(5, "Tiêu đề phải có ít nhất 5 ký tự").max(100, "Tiêu đề không được quá 100 ký tự"),
  reason: z.string().min(10, "Nội dung báo cáo phải có ít nhất 10 ký tự").max(1000, "Nội dung báo cáo không được quá 1000 ký tự"),
});

export type CreateReportBookingFormValues = z.infer<typeof createReportBookingSchema>;
export type CreateSystemReportFormValues = z.infer<typeof createSystemReportSchema>;
