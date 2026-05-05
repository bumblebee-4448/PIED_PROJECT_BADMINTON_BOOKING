import { useMutation } from "@tanstack/react-query";
import { toast } from "sonner";
import type { OwnerRegistrationForm } from "../types";
import { apiClient } from "@/lib/axios";
import { useOwnerRegistrationStore } from "../store";

export function useOwnerRegistration() {
  const { setDialogOpen } = useOwnerRegistrationStore();

  const mutation = useMutation({
    mutationFn: async (data: OwnerRegistrationForm) => {
      const formData = new FormData();

      // Add text fields
      formData.append("BusinessName", data.businessName);
      formData.append("TaxCode", data.taxCode);
      formData.append("BusinessAddress", data.businessAddress);
      formData.append("IdentityNumber", data.identityNumber);
      formData.append("FirstName", data.firstName);
      formData.append("LastName", data.lastName);
      formData.append("PhoneNumber", data.phoneNumber);

      // Add file fields
      if (data.businessLicenseFile) {
        formData.append("BusinessLicenseUrl", data.businessLicenseFile);
      }
      if (data.identityCardFrontFile) {
        formData.append("IdentityCardFrontUrl", data.identityCardFrontFile);
      }
      if (data.identityCardBackFile) {
        formData.append("IdentityCardBackUrl", data.identityCardBackFile);
      }

      const response = await apiClient.post(
        "/api/Customer/OwnerRequest",
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        },
      );

      // apiClient interceptor đã unwrap response.data.data
      // nên response ở đây là data thuần, không cần .data
      return response;
    },
    onSuccess: () => {
      toast.success("Đăng ký chủ sân thành công!", {
        description:
          "Yêu cầu của bạn đã được gửi. Chúng tôi sẽ xem xét và phản hồi sớm.",
        duration: 5000,
      });
      setDialogOpen(false);
    },
    onError: (error: any) => {
      const message =
        error.response?.data?.message ||
        error.message ||
        "Gửi yêu cầu thất bại. Vui lòng thử lại.";
      toast.error("Đăng ký thất bại", {
        description: message,
        duration: 5000,
      });
    },
  });

  const registerOwner = (data: OwnerRegistrationForm) => {
    mutation.mutate(data);
  };

  return {
    registerOwner,
    isLoading: mutation.isPending,
    setDialogOpen,
  };
}
