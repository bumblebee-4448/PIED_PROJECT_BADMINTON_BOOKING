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
  ExceptionSlotResponse
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
    formData.append("Latitude", data.latitude.toString());
    formData.append("Longitude", data.longitude.toString());
    formData.append("MapUrl", data.mapUrl);
    if (data.pictureUrl) {
      formData.append("PictureUrl", data.pictureUrl);
    }

    return apiClient.post("/Owner/OwnerCreateCourt", formData, {
      headers: { "Content-Type": undefined },
    });
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
      CourtId: data.courtId,
      Name: data.name,
      DefaultPrice: data.defaultPrice,
    });
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

  // Exception (Block) Slots
  createExceptionSlot: async (data: CreateExceptionSlotRequest) => {
    return apiClient.post("/Owner/CreateExceptionSlot", {
      SubCourtId: data.subCourtId,
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

  getBookingDetail: async (bookingDetailsId: string) => {
    return apiClient.post("/Booking/GetBookingDetail", null, {
      params: { bookingDetailsId }
    }) as unknown as Promise<GetBookingDetailResponse>;
  },
};
