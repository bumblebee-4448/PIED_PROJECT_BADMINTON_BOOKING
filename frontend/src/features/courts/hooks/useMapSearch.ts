import { useQuery, useMutation } from "@tanstack/react-query";
import { QUERY_KEYS } from "@/shared/constants";
import { courtService } from "../services";
import type { BoundingBoxRequest, RadiusRequest, TextSearchRequest } from "../types";

export const useMapSearchByBoundingBox = (request: BoundingBoxRequest, enabled: boolean = true) => {
  return useQuery({
    queryKey: QUERY_KEYS.MAP_SEARCH({ type: "bbox", ...request }),
    queryFn: () => courtService.searchByBoundingBox(request),
    enabled: enabled && !!request.minLat,
    staleTime: 5000,
  });
};

export const useMapSearchByRadius = (request: RadiusRequest, enabled: boolean = true) => {
  return useQuery({
    queryKey: QUERY_KEYS.MAP_SEARCH({ type: "radius", ...request }),
    queryFn: () => courtService.searchByRadius(request),
    enabled: enabled && !!request.latitude,
  });
};

export const useMapSearchByText = (request: TextSearchRequest, enabled: boolean = true) => {
  return useQuery({
    queryKey: QUERY_KEYS.MAP_SEARCH({ type: "text", ...request }),
    queryFn: () => courtService.searchByText(request),
    enabled: enabled && !!request.text,
  });
};

export const useMapSearchByTextMutation = () => {
  return useMutation({
    mutationFn: (request: TextSearchRequest) => courtService.searchByText(request),
  });
};
