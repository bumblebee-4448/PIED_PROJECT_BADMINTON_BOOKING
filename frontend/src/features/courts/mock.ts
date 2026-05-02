export interface Court {
  id: string;
  name: string;
  address: string;
  rating: number;
  reviews: number;
  price: number;
  availableSlots: number;
  imageUrl: string;
  district: string;
  isHot?: boolean;
}

export const MOCK_COURTS: Court[] = [
  {
    id: "1",
    name: "Sân Cầu Lông Quận 3 Pro Center",
    address: "88 Nam Kỳ Khởi Nghĩa, Phường 7, Quận 3",
    rating: 4.8,
    reviews: 186,
    price: 100000,
    availableSlots: 2,
    imageUrl: "https://images.unsplash.com/photo-1626225967045-9c76db7b62dc?w=800&auto=format&fit=crop",
    district: "Quận 3",
  },
  {
    id: "2",
    name: "Sân Cầu Lông Tân Bình Sports",
    address: "123 Lê Văn Sỹ, Phường 13, Tân Bình",
    rating: 4.9,
    reviews: 218,
    price: 80000,
    availableSlots: 3,
    imageUrl: "https://images.unsplash.com/photo-1521537634581-0dced2fee2ef?w=800&auto=format&fit=crop",
    district: "Tân Bình",
  },
  {
    id: "3",
    name: "Cầu Lông Phú Mỹ Hưng Elite",
    address: "456 Nguyễn Lương Bằng, Phú Mỹ Hưng, Quận 7",
    rating: 4.8,
    reviews: 156,
    price: 120000,
    availableSlots: 4,
    imageUrl: "https://images.unsplash.com/photo-1599474924187-334a4ae5bd3c?w=800&auto=format&fit=crop",
    district: "Quận 7",
  },
  {
    id: "4",
    name: "Sân Cầu Lông Quận 9 Champion",
    address: "12 Đỗ Xuân Hợp, Phước Long A, TP. Thủ Đức",
    rating: 4.6,
    reviews: 72,
    price: 70000,
    availableSlots: 4,
    imageUrl: "https://images.unsplash.com/photo-1534438327276-14e5300c3a48?w=800&auto=format&fit=crop",
    district: "Quận 9",
  },
  {
    id: "5",
    name: "Cầu Lông Bình Thạnh Azure",
    address: "789 Phan Văn Trị, Phường 12, Bình Thạnh",
    rating: 4.7,
    reviews: 94,
    price: 90000,
    availableSlots: 1,
    imageUrl: "https://images.unsplash.com/photo-1613918431703-0795a9959684?w=800&auto=format&fit=crop",
    district: "Bình Thạnh",
  },
  {
    id: "6",
    name: "Sân Cầu Lông Gò Vấp Star",
    address: "321 Quang Trung, Phường 10, Gò Vấp",
    rating: 4.5,
    reviews: 128,
    price: 85000,
    availableSlots: 5,
    imageUrl: "https://images.unsplash.com/photo-1517466787929-bc90951d0974?w=800&auto=format&fit=crop",
    district: "Gò Vấp",
  },
];
