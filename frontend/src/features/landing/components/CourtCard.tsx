import React from "react";
import { MapPin, Star, Clock } from "lucide-react";
import { ImageWithFallback } from "@/shared/components/common";
import { useAuthStore } from "@/features/auth/store";

interface Court {
  id: string;
  name: string;
  location: string;
  pricePerHour: number;
  rating: number;
  reviews: number;
  available: string;
  img: string;
  tag: string;
  tagColor: string;
}

interface CourtCardProps {
  court: Court;
}

export const CourtCard: React.FC<CourtCardProps> = ({ court }) => {
  const { accessToken, setLoginPromptOpen } = useAuthStore();

  const handleBooking = () => {
    if (!accessToken) {
      setLoginPromptOpen(true);
    } else {
      // Handle booking logic
    }
  };

  return (
    <div
      className="group rounded-2xl overflow-hidden transition-all duration-300 hover:shadow-2xl hover:-translate-y-2 cursor-pointer"
      style={{ border: "1px solid rgba(0,0,0,0.06)", background: "white" }}
    >
      {/* Image */}
      <div className="relative overflow-hidden" style={{ height: "200px" }}>
        <ImageWithFallback
          src={court.img}
          alt={court.name}
          className="w-full h-full object-cover transition-transform duration-500 group-hover:scale-110"
        />
        <div
          className="absolute inset-0"
          style={{
            background:
              "linear-gradient(to bottom, transparent 50%, rgba(0,0,0,0.4))",
          }}
        />
        <span
          className="absolute top-3 left-3 px-3 py-1 rounded-full text-white text-xs"
          style={{ background: court.tagColor, fontWeight: 700 }}
        >
          {court.tag}
        </span>
      </div>

      {/* Info */}
      <div className="p-5">
        <h3
          style={{
            fontWeight: 700,
            fontSize: "1.05rem",
            color: "#1a1a2e",
            marginBottom: "6px",
          }}
        >
          {court.name}
        </h3>

        <div
          className="flex items-center gap-1 mb-2"
          style={{ color: "#9ca3af", fontSize: "0.85rem" }}
        >
          <MapPin size={13} />
          <span>{court.location}</span>
        </div>

        <div className="flex items-center justify-between mb-4">
          <div className="flex items-center gap-1">
            <Star size={14} fill="#FFB300" color="#FFB300" />
            <span
              style={{
                fontWeight: 700,
                color: "#1a1a2e",
                fontSize: "0.9rem",
              }}
            >
              {court.rating}
            </span>
            <span style={{ color: "#9ca3af", fontSize: "0.8rem" }}>
              ({court.reviews})
            </span>
          </div>
          <div
            className="flex items-center gap-1"
            style={{ color: "#00897B", fontSize: "0.8rem" }}
          >
            <Clock size={13} />
            <span style={{ fontWeight: 600 }}>{court.available}</span>
          </div>
        </div>

        <div className="flex items-center justify-between">
          <div>
            <span
              style={{
                fontWeight: 800,
                fontSize: "1.1rem",
                color: "#00897B",
              }}
            >
              {court.pricePerHour.toLocaleString()}đ/giờ
            </span>
          </div>
          <button
            onClick={handleBooking}
            className="px-5 py-2 rounded-full text-white text-sm transition-all hover:shadow-lg hover:scale-105"
            style={{
              background: "linear-gradient(135deg, #00C896, #00897B)",
              fontWeight: 600,
            }}
          >
            Đặt ngay
          </button>
        </div>
      </div>
    </div>
  );
};
