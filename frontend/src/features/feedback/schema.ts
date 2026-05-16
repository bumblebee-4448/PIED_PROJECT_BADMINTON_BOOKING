import { z } from "zod";

export const feedbackSchema = z.object({
  rating: z.number().min(1, "Vui lòng chọn mức độ hài lòng").max(5),
  comment: z.string().max(500, "Bình luận không được quá 500 ký tự").optional().nullable(),
});

export type FeedbackFormValues = z.infer<typeof feedbackSchema>;
