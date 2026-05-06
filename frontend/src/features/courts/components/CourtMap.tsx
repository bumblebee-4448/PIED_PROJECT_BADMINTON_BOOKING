import { useRef } from 'react';
import "@vietmap/vietmap-gl-js/dist/vietmap-gl.css";
import { useCourtMap } from '../hooks/useCourtMap';
import { Crosshair, Loader2 } from 'lucide-react';
import { Button } from '@/shared/components/ui/button';

interface CourtMapProps {
  onMarkerClick: (courtId: string) => void;
  searchQuery?: string;
}

export function CourtMap({ onMarkerClick, searchQuery }: CourtMapProps) {
  const mapContainerRef = useRef<HTMLDivElement>(null);
  
  const { isLoading, handleLocateMe } = useCourtMap({
    mapContainerRef,
    searchQuery,
    onMarkerClick
  });

  return (
    <div className="relative w-full h-full overflow-hidden rounded-[2.5rem] border border-gray-100 shadow-sm bg-gray-50">
      <div ref={mapContainerRef} className="w-full h-full" />
      
      {/* Overlay UI */}
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
