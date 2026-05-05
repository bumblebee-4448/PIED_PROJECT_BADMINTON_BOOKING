import { useQuery } from "@tanstack/react-query";
import { QUERY_KEYS } from "@/shared/constants";
import { favoritesService } from "../services";

export function useFavorites(pageIndex: number = 1, pageSize: number = 10) {
  return useQuery({
    queryKey: [...QUERY_KEYS.FAVORITES, pageIndex, pageSize],
    queryFn: () => favoritesService.getAll(pageIndex, pageSize),
    staleTime: 5 * 60 * 1000, // 5 minutes
  });
}
