import { z } from "zod";

export const courtFiltersSchema = z.object({
  search: z.string().optional(),
  district: z.string().optional(),
  page: z.number().optional(),
  limit: z.number().optional(),
});

export type CourtFiltersInput = z.infer<typeof courtFiltersSchema>;
