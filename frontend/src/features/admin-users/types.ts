export interface UserListItem {
  id: string;
  userName: string;
  email: string;
  phoneNumber: string;
  role: string;
  status: string;
  firstName: string;
  lastName: string;
  avatarUrl?: string;
}

export interface UserDetail extends UserListItem {
  // Add more fields if needed based on API response
  address?: string;
  createdAt?: string;
}

export interface FilterUserRequest {
  search?: string;
  id?: string;
  role?: string;
  status?: string;
  pageIndex: number;
  pageSize: number;
}

export interface BanUnbanUserRequest {
  id: string;
  status: string;
}
