export interface CreateCourtRequest {
  name: string;
  openTime: string; // HH:mm
  closeTime: string; // HH:mm
  address: string;
  latitude: number; 
  longitude: number; 
  mapUrl: string;
  pictureUrl: File | null;
}

export interface MyCourtListItem {
  courtId: string;
  name: string;
  status: string;
  address: string;
  startTime: string;
  endTime: string;
  pictureUrl: string;
  mapUrl: string;
  latitude: number;
  longitude: number;
}

export type OwnerCourt = MyCourtListItem;

export interface GetMyCourtsRequest {
  pageIndex: number;
  pageSize: number;
  name?: string;
}

export interface CreateSubCourtRequest {
  courtId: string;
  name: string;
  defaultPrice: number;
}

export interface SubCourtListItem {
  subCourtId: string;
  courtId: string;
  name: string;
}

export interface GetMySubCourtsRequest {
  pageIndex: number;
  pageSize: number;
  courtId?: string;
  name?: string;
}

export interface SlotConfig {
  id: string;
  startTime: string;
  endTime: string;
  price: number;
}

export type AvailableSlot = {
  startTime: string;
  endTime: string;
  price: number;
  isAvailable: boolean;
  type?: "Default" | "Booked" | "Blocked" | "Override" | string;
  reason?: string;
  bookingDetailId?: string;
};

export interface GetBookingDetailResponse {
  name?: string;
  phoneNumber?: string;
  gmail: string;
  subCourtName: string;
  startTime: string;
  endTime: string;
}

export interface CreateOverrideSlotRequest {
  subCourtId: string;
  isRecurring: boolean;
  dayOfWeek?: number;
  date?: string;
  startTime: string;
  endTime: string;
  price: number;
}

export interface OverrideSlotResponse {
  id: string;
  date?: string;
  dayOfWeek?: number;
  startTime: string;
  endTime: string;
  price: number;
}

export interface GetAvailableSlotsRequest {
  subCourtId: string;
  date: string; // yyyy-MM-dd
}

export interface CreateExceptionSlotRequest {
  subCourtId: string;
  isRecurring?: boolean;
  dayOfWeek?: number;
  date?: string;
  startTime: string;
  endTime: string;
  reason: string;
}

export interface ExceptionSlotResponse {
  id: string;
  subCourtId: string;
  date: string;
  startTime: string;
  endTime: string;
  reason: string;
}
