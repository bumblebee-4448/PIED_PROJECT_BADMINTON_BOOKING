import { z } from "zod";

export const addCourtLikeSchema = z.object({
  courtId: z.string().uuid(),
  courtName: z.string(),
  courtAddress: z.string(),
});

export type AddCourtLikeInput = z.infer<typeof addCourtLikeSchema>;

export const deleteCourtLikeSchema = z.object({
  courtId: z.string().uuid(),
});

export type DeleteCourtLikeInput = z.infer<typeof deleteCourtLikeSchema>;
