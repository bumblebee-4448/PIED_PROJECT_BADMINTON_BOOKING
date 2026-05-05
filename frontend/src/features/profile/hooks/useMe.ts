import { useQuery } from "@tanstack/react-query";
import { useAuthStore } from "@/features/auth/store";
import { profileService } from "../services";
import { QUERY_KEYS } from "@/shared/constants";
import { useEffect } from "react";

export const useMe = () => {
  const { accessToken, role, setAuth, logout } = useAuthStore();

  const query = useQuery({
    queryKey: QUERY_KEYS.ME,
    queryFn: () => profileService.getMe(),
    enabled: !!accessToken, // Chỉ gọi khi đã có token
    staleTime: 1000 * 60 * 5, // Dữ liệu được coi là tươi trong 5 phút
    retry: 1,
  });

  // Đồng bộ hóa dữ liệu Query vào AuthStore khi có kết quả mới
  const storeUser = useAuthStore((state) => state.user);
  useEffect(() => {
    if (query.data && accessToken && role) {
      // Kết hợp data mới từ GetMe với id/role hiện tại (vì GetMe không trả về id/role)
      const mergedUser = {
        ...storeUser,
        ...query.data,
      };
      setAuth(accessToken, role, mergedUser);
    }
  }, [query.data, accessToken, role, setAuth]);

  // Xử lý khi Token hết hạn hoặc lỗi Auth
  useEffect(() => {
    if (query.isError) {
      const status = (query.error as any)?.response?.status;
      if (status === 401) {
        logout();
      }
    }
  }, [query.isError, query.error, logout]);

  return query;
};
