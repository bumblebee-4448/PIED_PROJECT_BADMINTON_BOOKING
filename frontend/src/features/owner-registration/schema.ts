import { z } from "zod";

const MAX_FILE_SIZE = 5 * 1024 * 1024; // 5MB
const ACCEPTED_IMAGE_TYPES = ["image/jpeg", "image/jpg", "image/png", "image/webp"];
const ACCEPTED_LICENSE_TYPES = [...ACCEPTED_IMAGE_TYPES, "application/pdf"];

export const ownerRegistrationSchema = z.object({
  businessName: z
    .string()
    .min(3, "Tên doanh nghiệp phải có ít nhất 3 ký tự")
    .max(100, "Tên doanh nghiệp không được quá 100 ký tự"),

  taxCode: z
    .string()
    .min(10, "Mã số thuế phải có ít nhất 10 ký tự")
    .max(14, "Mã số thuế không được quá 14 ký tự")
    .regex(/^[0-9-]+$/, "Mã số thuế chỉ được chứa số và dấu gạch ngang"),

  businessAddress: z
    .string()
    .min(10, "Địa chỉ kinh doanh phải có ít nhất 10 ký tự")
    .max(255, "Địa chỉ không được quá 255 ký tự"),

  identityNumber: z
    .string()
    .regex(/^[0-9]{9,12}$/, "Số CCCD/CMND phải là 9 hoặc 12 chữ số"),

  businessLicenseFile: z
    .instanceof(File, { message: "Vui lòng tải lên giấy phép kinh doanh" })
    .refine((f) => f.size <= MAX_FILE_SIZE, "File không được vượt quá 5MB")
    .refine(
      (f) => ACCEPTED_LICENSE_TYPES.includes(f.type),
      "Chỉ chấp nhận định dạng JPG, PNG, WebP hoặc PDF"
    ),

  identityCardFrontFile: z
    .instanceof(File, { message: "Vui lòng tải lên ảnh CCCD mặt trước" })
    .refine((f) => f.size <= MAX_FILE_SIZE, "File không được vượt quá 5MB")
    .refine(
      (f) => ACCEPTED_IMAGE_TYPES.includes(f.type),
      "Chỉ chấp nhận định dạng JPG, PNG hoặc WebP"
    ),

  identityCardBackFile: z
    .instanceof(File, { message: "Vui lòng tải lên ảnh CCCD mặt sau" })
    .refine((f) => f.size <= MAX_FILE_SIZE, "File không được vượt quá 5MB")
    .refine(
      (f) => ACCEPTED_IMAGE_TYPES.includes(f.type),
      "Chỉ chấp nhận định dạng JPG, PNG hoặc WebP"
    ),
});

export type OwnerRegistrationSchema = z.infer<typeof ownerRegistrationSchema>;
