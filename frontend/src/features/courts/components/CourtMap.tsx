import { useRef, useState } from 'react';
import type { FormEvent } from 'react';
import "@vietmap/vietmap-gl-js/dist/vietmap-gl.css";
import { useCourtMap } from '../hooks/useCourtMap';
import { Crosshair, Loader2, Search, X } from 'lucide-react';
import { Button } from '@/shared/components/ui/button';
import { Input } from '@/shared/components/ui/input';

interface CourtMapProps {
  onMarkerClick: (courtId: string) => void;
}

export function CourtMap({ onMarkerClick }: CourtMapProps) {
  const mapContainerRef = useRef<HTMLDivElement>(null);
  const [mapSearchInput, setMapSearchInput] = useState("");
  const [mapSearchQuery, setMapSearchQuery] = useState("");
  
  const { isLoading, handleLocateMe } = useCourtMap({
    mapContainerRef,
    searchQuery: mapSearchQuery,
    onMarkerClick
  });

  const handleSearchSubmit = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    setMapSearchQuery(mapSearchInput.trim());
  };

  const handleClearSearch = () => {
    setMapSearchInput("");
    setMapSearchQuery("");
  };

  return (
    <div className="relative w-full h-full overflow-hidden rounded-[2.5rem] border border-gray-100 shadow-sm bg-gray-50">
      <div ref={mapContainerRef} className="w-full h-full" />
      
      {/* Overlay UI */}
      <form
        onSubmit={handleSearchSubmit}
        className="absolute left-4 top-4 z-10 flex w-[calc(100%-2rem)] max-w-md items-center gap-2 rounded-2xl border border-gray-100 bg-white/95 p-2 shadow-xl backdrop-blur-md sm:left-6 sm:top-6 sm:w-[26rem]"
      >
        <div className="relative min-w-0 flex-1">
          <Search
            size={18}
            className="pointer-events-none absolute left-3 top-1/2 -translate-y-1/2 text-gray-400"
          />
          <Input
            value={mapSearchInput}
            onChange={(event) => setMapSearchInput(event.target.value)}
            placeholder="Tìm khu vực trên bản đồ"
            className="h-11 rounded-xl border-gray-100 bg-gray-50 pl-10 pr-9 text-sm font-semibold shadow-none focus-visible:ring-emerald-200"
          />
          {mapSearchInput && (
            <button
              type="button"
              onClick={handleClearSearch}
              className="absolute right-2 top-1/2 flex h-7 w-7 -translate-y-1/2 items-center justify-center rounded-lg text-gray-400 transition-colors hover:bg-white hover:text-gray-600"
              aria-label="Xóa tìm kiếm bản đồ"
            >
              <X size={16} />
            </button>
          )}
        </div>
        <Button
          type="submit"
          disabled={!mapSearchInput.trim()}
          className="h-11 shrink-0 rounded-xl px-4 text-xs font-black uppercase tracking-wider"
        >
          <Search size={16} />
          Tìm
        </Button>
      </form>

      <div className="absolute bottom-6 right-6 flex flex-col gap-2">
        <Button 
          size="icon" 
          onClick={handleLocateMe}
          className="bg-white hover:bg-emerald-50 text-emerald-600 shadow-xl border border-emerald-100 w-12 h-12 rounded-2xl"
        >
          <Crosshair size={24} />
        </Button>
      </div>

      {isLoading && (
        <div className="absolute top-4 left-1/2 -translate-x-1/2 bg-white/90 backdrop-blur-md px-4 py-2 rounded-full shadow-lg border border-emerald-50 flex items-center gap-2">
          <Loader2 size={16} className="animate-spin text-emerald-500" />
          <span className="text-xs font-bold text-emerald-700 uppercase tracking-wider">Đang cập nhật...</span>
        </div>
      )}

      {/* Custom styles for markers */}
      <style>{`
        .custom-marker {
          cursor: pointer;
        }
      `}</style>
    </div>
  );
}
