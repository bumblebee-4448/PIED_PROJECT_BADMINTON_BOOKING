import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { ownerCourtService } from "../services";
import type { CreateSubCourtRequest, GetMySubCourtsRequest } from "../types";
import { toast } from "sonner";

export const useCreateSubCourt = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (data: CreateSubCourtRequest) => ownerCourtService.createSubCourt(data),
    onSuccess: () => {
      toast.success("Đã tạo sân con thành công");
      queryClient.invalidateQueries({ queryKey: ["owner-sub-courts"] });
    },
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Tạo sân con thất bại");
    },
  });
};

export const useOwnerSubCourts = (params: GetMySubCourtsRequest) => {
  return useQuery({
    queryKey: ["owner-sub-courts", params],
    queryFn: () => ownerCourtService.getSubCourts(params as { courtId: string; pageIndex: number; pageSize: number; name?: string }),
    enabled: !!params.courtId,
  });
};

export const useUpdateSubCourtInfo = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (data: { subCourtId: string; name: string }) => ownerCourtService.updateSubCourtInfo(data),
    onSuccess: () => {
      toast.success("Cập nhật thông tin sân con thành công");
      queryClient.invalidateQueries({ queryKey: ["owner-sub-courts"] });
    },
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Cập nhật thất bại");
    },
  });
};

export const useRemoveSubCourt = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (subCourtId: string) => ownerCourtService.removeSubCourt(subCourtId),
    onSuccess: () => {
      toast.success("Xóa sân con thành công");
      queryClient.invalidateQueries({ queryKey: ["owner-sub-courts"] });
    },
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Xóa sân con thất bại");
    },
  });
};
