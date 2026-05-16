import { apiClient } from "@/lib/axios";
import type { 
  OwnerCourt, 
  SubCourtListItem, 
  SlotConfig, 
  AvailableSlot, 
  GetAvailableSlotsRequest,
  CreateOverrideSlotRequest,
  OverrideSlotResponse,
  CreateExceptionSlotRequest,
  ExceptionSlotResponse,
  GetBookingDetailResponse
} from "./types";
import type { PaginatedResponse } from "@/shared/types";

export const ownerCourtService = {
  // Court Management
  getCourts: async (params: { pageIndex: number; pageSize: number; name?: string }) => {
    return apiClient.get<PaginatedResponse<OwnerCourt>>("/Owner/OwnerGetAllCourts", {
      params: {
        PageIndex: params.pageIndex,
        PageSize: params.pageSize,
        Name: params.name,
      },
    }) as unknown as Promise<PaginatedResponse<OwnerCourt>>;
  },

  createCourt: async (data: any) => {
    const formData = new FormData();
    formData.append("Name", data.name);
    formData.append("OpenTime", data.openTime);
    formData.append("CloseTime", data.closeTime);
    formData.append("Address", data.address);
    formData.append("MapUrl", data.mapUrl);
    if (data.pictureUrl) {
      formData.append("PictureUrl", data.pictureUrl);
    }

    return apiClient.post("/Owner/OwnerCreateCourt", formData, {
      headers: { "Content-Type": undefined },
    });
  },

  updateCourtInfo: async (data: any) => {
    const formData = new FormData();
    // Normalize ID if it contains spaces (sometimes happens with copy-paste or weird formatting)
    const normalizedCourtId = data.courtId?.toString().replace(/\s+/g, '-');
    formData.append("CourtId", normalizedCourtId);
    if (data.name) formData.append("Name", data.name);
    if (data.address) formData.append("Address", data.address);
    if (data.mapUrl) formData.append("MapUrl", data.mapUrl);
    if (data.description) formData.append("Description", data.description);
    if (data.openTime) formData.append("OpenTime", data.openTime);
    if (data.closeTime) formData.append("CloseTime", data.closeTime);
    if (data.timeRefundBefore !== undefined) formData.append("TimeRefundBefore", data.timeRefundBefore.toString());
    if (data.pictureUrl) {
      formData.append("PictureUrl", data.pictureUrl);
    }

    return apiClient.put("/Owner/UpdateCourtInfo", formData, {
      headers: { "Content-Type": undefined },
    });
  },

  removeCourt: async (courtId: string) => {
    const normalizedId = courtId.replace(/\s+/g, '-');
    return apiClient.delete(`/Owner/RemoveCourt/${normalizedId}`);
  },

  // Sub-court Management
  getSubCourts: async (params: { courtId: string; pageIndex: number; pageSize: number; name?: string }) => {
    return apiClient.get<PaginatedResponse<SubCourtListItem>>(
      "/Owner/OwnerGetMySubCourts",
      {
        params: {
          PageIndex: params.pageIndex,
          PageSize: params.pageSize,
          CourtId: params.courtId,
          Name: params.name,
        },
      },
    ) as unknown as Promise<PaginatedResponse<SubCourtListItem>>;
  },

  createSubCourt: async (data: { courtId: string; name: string; defaultPrice: number }) => {
    return apiClient.post("/Owner/OwnerCreateSubCourt", {
      CourtId: data.courtId.replace(/\s+/g, '-'),
      Name: data.name,
      DefaultPrice: data.defaultPrice,
    });
  },

  updateSubCourtInfo: async (data: { subCourtId: string; name: string }) => {
    return apiClient.put("/Owner/UpdateSubCourtInfo", {
      SubCourtId: data.subCourtId.replace(/\s+/g, '-'),
      Name: data.name,
    });
  },

  removeSubCourt: async (subCourtId: string) => {
    const normalizedId = subCourtId.replace(/\s+/g, '-');
    return apiClient.delete(`/Owner/RemoveSubCourt/${normalizedId}`);
  },

  // Slot Configuration
  getSubCourtSlots: async (subCourtId: string) => {
    return apiClient.get<SlotConfig[]>("/Owner/OwnerGetConfigSlot", {
      params: { subCourtId }, 
    }) as unknown as Promise<SlotConfig[]>;
  },

  getAvailableSlots: async (params: GetAvailableSlotsRequest) => {
    return apiClient.get<AvailableSlot[]>("/Owner/GetAvailableSlots", {
      params: {
        SubCourtId: params.subCourtId,
        Date: params.date,
      },
    }) as unknown as Promise<AvailableSlot[]>;
  },

  createOverrideSlot: async (data: CreateOverrideSlotRequest) => {
    return apiClient.post("/Owner/CreateOverrideSlot", {
      SubCourtId: data.subCourtId,
      IsRecurring: data.isRecurring,
      DayOfWeek: data.dayOfWeek,
      Date: data.date,
      StartTime: data.startTime,
      EndTime: data.endTime,
      Price: data.price,
    });
  },

  getOverrideSlotsBySubCourtId: async (subCourtId: string) => {
    return apiClient.get<OverrideSlotResponse[]>("/Owner/GetOverrideSlotBySubCourtId", {
      params: { subCourtId },
    }) as unknown as Promise<OverrideSlotResponse[]>;
  },

  removeOverrideSlot: async (overrideSlotId: string) => {
    return apiClient.delete(`/Owner/RemoveOverrideSlot/${overrideSlotId}`);
  },

  updateConfigSlotPrice: async (data: { configSlotId: string; newPrice: number }) => {
    return apiClient.put("/Owner/UpdateConfigSlotPrice", {
      ConfigSlotId: data.configSlotId,
      NewPrice: data.newPrice,
    });
  },

  // Exception (Block) Slots
  createExceptionSlot: async (data: CreateExceptionSlotRequest) => {
    return apiClient.post("/Owner/CreateExceptionSlot", {
      SubCourtId: data.subCourtId,
      IsRecurring: data.isRecurring,
      DayOfWeek: data.dayOfWeek,
      Date: data.date,
      StartTime: data.startTime,
      EndTime: data.endTime,
      Reason: data.reason,
    });
  },

  getExceptionSlotsBySubCourtId: async (subCourtId: string) => {
    return apiClient.get<ExceptionSlotResponse[]>("/Owner/GetExceptionSlotBySubCourtId", {
      params: { subCourtId },
    }) as unknown as Promise<ExceptionSlotResponse[]>;
  },

  unlockException: async (exceptionId: string) => {
    return apiClient.delete(`/Owner/UnlockException/${exceptionId}`);
  },

  getBookingDetail: async (bookingDetailsId: string) => {
    return apiClient.post("/Booking/GetBookingDetail", null, {
      params: { bookingDetailsId }
    }) as unknown as Promise<GetBookingDetailResponse>;
  },

  getSetupSlots: async (subCourtId: string, date: string) => {
    return apiClient.get("/Owner/GetSetupSlotsBySubCourtId", {
      params: { subCourtId, date }
    });
  },
};
