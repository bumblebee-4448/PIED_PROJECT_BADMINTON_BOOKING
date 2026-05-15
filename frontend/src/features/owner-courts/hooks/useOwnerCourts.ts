import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { ownerCourtService } from "../services";
import type { CreateCourtRequest, GetMyCourtsRequest } from "../types";
import { toast } from "sonner";

export const useCreateCourt = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (data: CreateCourtRequest) => ownerCourtService.createCourt(data),
    onSuccess: () => {
      toast.success("Đã tạo sân thành công, đang chờ Admin duyệt");
      queryClient.invalidateQueries({ queryKey: ["owner-courts"] });
    },
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Tạo sân thất bại");
    },
  });
};

export const useOwnerCourts = (params: GetMyCourtsRequest) => {
  return useQuery({
    queryKey: ["owner-courts", params],
    queryFn: () => ownerCourtService.getCourts(params),
  });
};

export const useUpdateCourtInfo = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (data: any) => ownerCourtService.updateCourtInfo(data),
    onSuccess: () => {
      toast.success("Cập nhật thông tin sân thành công");
      queryClient.invalidateQueries({ queryKey: ["owner-courts"] });
    },
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Cập nhật thất bại");
    },
  });
};

export const useRemoveCourt = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (courtId: string) => ownerCourtService.removeCourt(courtId),
    onSuccess: () => {
      toast.success("Xóa sân thành công");
      queryClient.invalidateQueries({ queryKey: ["owner-courts"] });
    },
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Xóa sân thất bại");
    },
  });
};
