import { useMutation } from "@tanstack/react-query";
import { useAuthStore } from "../store";

export const useLogout = () => {
  const { logout } = useAuthStore();

  return useMutation({
    mutationFn: async () => {
      // TODO: Call logout API
      logout();
    },
  });
};
