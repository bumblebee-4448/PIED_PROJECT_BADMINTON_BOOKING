export interface OwnerRegistrationForm {
  businessName: string;
  taxCode: string;
  businessAddress: string;
  identityNumber: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  businessLicenseFile: File | null;
  identityCardFrontFile: File | null;
  identityCardBackFile: File | null;
}

export interface OwnerRegistrationResponse {
  success: boolean;
  message: string;
  data?: any;
}
