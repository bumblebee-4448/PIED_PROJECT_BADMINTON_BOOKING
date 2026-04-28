import { useMemo } from "react";
import type { Court } from "../types";
import { useSearchStore } from "../store";

const MOCK_COURTS: Court[] = [
  {
    id: "1",
    name: "Sân Cầu Lông Quận 3 Pro Center",
    address: "88 Nam Kỳ Khởi Nghĩa, Phường 7, Quận 3",
    district: "Quận 3",
    rating: 4.8,
    reviews: 186,
    pricePerHour: 100000,
    image: "https://images.unsplash.com/photo-1626225967045-2c360fdec2a0?auto=format&fit=crop&q=80&w=800",
    availableCourts: 2,
    isFavorite: true,
  },
  {
    id: "2",
    name: "Sân Cầu Lông Tân Bình Sports",
    address: "123 Lê Văn Sỹ, Phường 13, Tân Bình",
    district: "Tân Bình",
    rating: 4.9,
    reviews: 218,
    pricePerHour: 80000,
    image: "https://images.unsplash.com/photo-1521537634581-0dced2fee2ef?auto=format&fit=crop&q=80&w=800",
    availableCourts: 3,
  },
  {
    id: "3",
    name: "Cầu Lông Phú Mỹ Hưng Elite",
    address: "456 Nguyễn Lương Bằng, Phú Mỹ Hưng, Quận 7",
    district: "Quận 7",
    rating: 4.8,
    reviews: 156,
    pricePerHour: 120000,
    image: "https://images.unsplash.com/photo-1599474924187-334a4ae5bd3c?auto=format&fit=crop&q=80&w=800",
    availableCourts: 4,
  },
  {
    id: "4",
    name: "Sân Cầu Lông Quận 9 Champion",
    address: "12 Đỗ Xuân Hợp, Phước Long A, TP. Thủ Đức",
    district: "Quận 9",
    rating: 4.6,
    reviews: 72,
    pricePerHour: 70000,
    image: "https://images.unsplash.com/photo-1613918431703-09419139886b?auto=format&fit=crop&q=80&w=800",
    availableCourts: 4,
  },
  {
    id: "5",
    name: "Cầu Lông Bình Thạnh Arena",
    address: "789 Đinh Bộ Lĩnh, Phường 26, Bình Thạnh",
    district: "Bình Thạnh",
    rating: 4.7,
    reviews: 94,
    pricePerHour: 65000,
    image: "https://images.unsplash.com/photo-1554068865-24cecd4e34b8?auto=format&fit=crop&q=80&w=800",
    availableCourts: 3,
  },
  {
    id: "6",
    name: "Cầu Lông Gò Vấp Star",
    address: "55 Phan Văn Trị, Phường 7, Gò Vấp",
    district: "Gò Vấp",
    rating: 4.5,
    reviews: 53,
    pricePerHour: 60000,
    image: "https://images.unsplash.com/photo-1534438327276-14e5300c3a48?auto=format&fit=crop&q=80&w=800",
    availableCourts: 2,
  },
];

export const useSearchCourts = () => {
  const { query, selectedDistrict } = useSearchStore();

  const filteredCourts = useMemo(() => {
    return MOCK_COURTS.filter((court) => {
      const matchesQuery =
        court.name.toLowerCase().includes(query.toLowerCase()) ||
        court.address.toLowerCase().includes(query.toLowerCase());
      const matchesDistrict =
        selectedDistrict === "Tất cả" || court.district === selectedDistrict;

      return matchesQuery && matchesDistrict;
    });
  }, [query, selectedDistrict]);

  return {
    courts: filteredCourts,
    totalResults: filteredCourts.length,
  };
};
