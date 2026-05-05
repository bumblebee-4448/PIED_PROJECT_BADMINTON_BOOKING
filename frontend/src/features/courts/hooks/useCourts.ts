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
