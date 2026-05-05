import { useMutation, useQueryClient } from "@tanstack/react-query";
import { QUERY_KEYS } from "@/shared/constants";
import { favoritesService } from "../services";
import { toast } from "sonner";

export function useAddFavorite() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: favoritesService.add,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.FAVORITES });
      toast.success("Đã thêm vào danh sách yêu thích");
    },
  });
}

export function useRemoveFavorite() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: favoritesService.remove,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.FAVORITES });
      toast.success("Đã xóa khỏi danh sách yêu thích");
    },
  });
}
