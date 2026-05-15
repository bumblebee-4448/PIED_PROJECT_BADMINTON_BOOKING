import { useQuery } from "@tanstack/react-query";
import { QUERY_KEYS } from "@/shared/constants";
import { courtService } from "../services";
import type { CourtFilters } from "../types";

export const useCourts = (filters: CourtFilters) => {
  return useQuery({
    queryKey: QUERY_KEYS.COURTS(filters),
    queryFn: () => courtService.getCourts(filters),
    placeholderData: (previousData) => previousData,
  });
};

export const useCourtDetail = (id: string) => {
  return useQuery({
    queryKey: QUERY_KEYS.COURT_DETAIL(id),
    queryFn: () => courtService.getCourtById(id),
    enabled: !!id,
  });
};

export const useCourtFeedbacks = (
  courtId: string,
  pageIndex = 1,
  pageSize = 10
) => {
  return useQuery({
    queryKey: QUERY_KEYS.COURT_FEEDBACKS(courtId, pageIndex, pageSize),
    queryFn: () => courtService.getCourtFeedbacks(courtId, pageIndex, pageSize),
    enabled: !!courtId,
  });
};
