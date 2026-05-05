import { useQuery } from "@tanstack/react-query";
import { apiClient } from "@/lib/axios";
import type {
  GetOwnerRequestsParams,
  GetOwnerRequestsResponse,
} from "../types";

export function useOwnerRequests(params: GetOwnerRequestsParams = {}) {
  return useQuery<GetOwnerRequestsResponse>({
    queryKey: ["admin", "owner-requests", params],
    queryFn: async () => {
      const response = await apiClient.get("/api/Admin/OwnerRequest", {
        params,
      });
      // apiClient interceptor đã unwrap response.data.data
      return response as unknown as GetOwnerRequestsResponse;
    },
  });
}
