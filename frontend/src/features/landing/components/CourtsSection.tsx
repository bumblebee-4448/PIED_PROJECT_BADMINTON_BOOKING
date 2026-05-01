import { CourtCard } from "./CourtCard";

const courts = [
  {
    id: "1",
    name: "Sân Cầu Lông Tân Bình",
    location: "Quận Tân Bình, TP.HCM",
    pricePerHour: 80000,
    rating: 4.9,
    reviews: 128,
    available: "Còn 3 sân trống",
    img: "https://images.unsplash.com/photo-1775993167284-8e6a6e56ab69?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHBiYWRtaW50b24lMjBjb3VydCUyMGluZG9vciUyMHNwb3J0c3xlbnwxfHx8fDE3NzY3MDE4Mjh8MA&ixlib=rb-4.1.0&q=80&w=1080",
    tag: "Nổi bật",
    tagColor: "#00C896",
  },
  {
    id: "2",
    name: "Cầu Lông Phú Mỹ Hưng",
    location: "Quận 7, TP.HCM",
    pricePerHour: 100000,
    rating: 4.8,
    reviews: 96,
    available: "Còn 5 sân trống",
    img: "https://images.unsplash.com/photo-1614058585449-0aceebe022cc?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxiYWRtaW50b24lMjBzaHV0dGxlY29jayUyMHNtYXNofGVufDF8fHx8MTc3NjcwMTgzMXww&ixlib=rb-4.1.0&q=80&w=1080",
    tag: "Cao cấp",
    tagColor: "#FFB300",
  },
  {
    id: "3",
    name: "Cầu Lông Bình Thạnh",
    location: "Quận Bình Thạnh, TP.HCM",
    pricePerHour: 65000,
    rating: 4.7,
    reviews: 74,
    available: "Còn 2 sân trống",
    img: "https://images.unsplash.com/photo-1771909720886-a90afd1b37f5?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxpbmRvb3IlMjBzcG9ydHMlMjBmYWNpbGl0eSUyMGxpZ2h0aW5nfGVufDF8fHx8MTc3NjcwMTgzNHww&ixlib=rb-4.1.0&q=80&w=1080",
    tag: "Giá tốt",
    tagColor: "#4CAF50",
  },
];

export function CourtsSection() {
  return (
    <section className="py-24 bg-white">
      <div className="container-landing">
        {/* Header */}
        <div className="flex flex-col md:flex-row md:items-end md:justify-between gap-4 mb-12">
          <div>
            <div
              className="inline-flex items-center gap-2 px-4 py-2 rounded-full mb-4"
              style={{
                background: "rgba(0,200,150,0.1)",
                border: "1px solid rgba(0,200,150,0.2)",
              }}
            >
              <span
                style={{
                  color: "#00897B",
                  fontWeight: 600,
                  fontSize: "0.85rem",
                }}
              >
                📍 Sân nổi bật
              </span>
            </div>
            <h2
              style={{
                fontSize: "clamp(1.8rem, 3.5vw, 2.8rem)",
                fontWeight: 800,
                color: "#1a1a2e",
                lineHeight: 1.3,
              }}
            >
              Sân cầu lông{" "}
              <span className="text-gradient">được yêu thích nhất</span>
            </h2>
          </div>
          <button
            className="text-sm px-6 py-3 rounded-full transition-all hover:shadow-md"
            style={{
              border: "2px solid #00C896",
              color: "#00897B",
              fontWeight: 600,
            }}
          >
            Xem tất cả sân →
          </button>
        </div>

        {/* Courts grid */}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
          {courts.map((court) => (
            <CourtCard key={court.id} court={court} />
          ))}
        </div>
      </div>
    </section>
  );
}
