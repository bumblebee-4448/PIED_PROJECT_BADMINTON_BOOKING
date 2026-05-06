import { useEffect, useRef, useState } from 'react';
import vietmapgl from "@vietmap/vietmap-gl-js/dist/vietmap-gl";
import { useMapSearchByBoundingBox, useMapSearchByText } from './useMapSearch';
import type { BoundingBoxRequest } from '../types';

/**
 * API Key cho VietMap được lấy từ biến môi trường
 */
const VIETMAP_API_KEY = import.meta.env.VITE_VIETMAP_API_KEY;

interface UseCourtMapProps {
  mapContainerRef: React.RefObject<HTMLDivElement | null>;
  searchQuery?: string;
  onMarkerClick: (courtId: string) => void;
}

/**
 * Hook tùy chỉnh để quản lý bản đồ sân cầu lông sử dụng VietMap GL JS.
 * Hook này xử lý việc khởi tạo bản đồ, tìm kiếm theo vùng nhìn (bounding box),
 * tìm kiếm theo văn bản, và quản lý các markers trên bản đồ.
 */
export function useCourtMap({ mapContainerRef, searchQuery, onMarkerClick }: UseCourtMapProps) {
  // Tham chiếu đến đối tượng bản đồ VietMap
  const mapRef = useRef<vietmapgl.Map | null>(null);
  // Lưu trữ các markers đang hiển thị trên bản đồ để quản lý (thêm/xóa)
  const markersRef = useRef<{ [key: string]: vietmapgl.Marker }>({});
  
  // Trạng thái lưu trữ tọa độ vùng nhìn hiện tại (minLat, maxLat, minLon, maxLon)
  const [bbox, setBbox] = useState<BoundingBoxRequest>({
    minLat: 0,
    maxLat: 0,
    minLon: 0,
    maxLon: 0
  });

  // Tự động gọi API lấy danh sách sân trong vùng nhìn hiện tại mỗi khi bbox thay đổi
  const { data: mapData, isLoading: isBboxLoading } = useMapSearchByBoundingBox(bbox, !!bbox.minLat);
  
  // Sử dụng Query thay vì Mutation để tìm kiếm theo văn bản, giúp tránh loop vô hạn và tự động quản lý cache
  const { data: textSearchData, isLoading: isTextLoading } = useMapSearchByText(
    { text: searchQuery || "", radiusKm: 10 },
    !!searchQuery
  );

  const isLoading = isBboxLoading || isTextLoading;

  // Khi có kết quả tìm kiếm theo văn bản, di chuyển bản đồ đến vị trí sân đầu tiên
  useEffect(() => {
    if (textSearchData && textSearchData.listCourts.length > 0 && mapRef.current) {
      const firstCourt = textSearchData.listCourts[0];
      mapRef.current.flyTo({
        center: [Number(firstCourt.longitude), Number(firstCourt.latitude)],
        zoom: 14
      });
    }
  }, [textSearchData]);

  /**
   * Khởi tạo bản đồ khi component mount
   */
  useEffect(() => {
    if (!mapContainerRef.current || mapRef.current) return;

    // Tạo instance bản đồ mới
    const map = new vietmapgl.Map({
      container: mapContainerRef.current,
      style: `https://maps.vietmap.vn/maps/styles/tm/style.json?apikey=${VIETMAP_API_KEY}`,
      center: [106.660172, 10.762622], // Mặc định ở TP.HCM
      zoom: 13,
    });

    // Thêm bộ điều khiển điều hướng (zoom, xoay)
    map.addControl(new vietmapgl.NavigationControl(), 'top-right');

    // Khi bản đồ tải xong, lưu vào ref và cập nhật bbox lần đầu
    map.on('load', () => {
      mapRef.current = map;
      updateBbox();
    });

    // Khi người dùng di chuyển hoặc zoom bản đồ xong, cập nhật lại vùng nhìn
    map.on('moveend', () => {
      updateBbox();
    });

    // Hàm lấy tọa độ 4 góc của màn hình hiện tại
    const updateBbox = () => {
      const bounds = map.getBounds();
      setBbox({
        minLat: bounds.getSouth(),
        maxLat: bounds.getNorth(),
        minLon: bounds.getWest(),
        maxLon: bounds.getEast()
      });
    };

    // Dọn dẹp bản đồ khi component unmount
    return () => {
      map.remove();
      mapRef.current = null;
    };
  }, [mapContainerRef]);

  /**
   * Cập nhật các Markers (ghim) trên bản đồ khi dữ liệu sân thay đổi
   */
  useEffect(() => {
    if (!mapRef.current || !mapData) return;

    const courts = mapData.listCourts;
    const newMarkerIds = new Set(courts.map(c => c.id));

    // Xóa những markers cũ không còn nằm trong danh sách kết quả mới (vừa di chuyển khỏi vùng nhìn)
    Object.keys(markersRef.current).forEach(id => {
      if (!newMarkerIds.has(id)) {
        markersRef.current[id].remove();
        delete markersRef.current[id];
      }
    });

    // Thêm các markers mới cho những sân chưa có trên bản đồ
    courts.forEach(court => {
      if (!markersRef.current[court.id]) {
        // Tạo element HTML tùy chỉnh cho marker
        const el = document.createElement('div');
        el.className = 'custom-marker';
        el.innerHTML = `
          <div class="flex flex-col items-center group">
            <div class="bg-emerald-500 text-white p-2 rounded-full shadow-lg border-2 border-white transition-transform group-hover:scale-125 cursor-pointer">
              <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M20 10c0 6-8 12-8 12s-8-6-8-12a8 8 0 0 1 16 0Z"/><circle cx="12" cy="10" r="3"/></svg>
            </div>
            <div class="mt-1 bg-white px-2 py-0.5 rounded-md shadow-sm border border-gray-100 text-[10px] font-bold text-emerald-700 opacity-0 group-hover:opacity-100 transition-opacity whitespace-nowrap">
              Xem chi tiết
            </div>
          </div>
        `;
        
        // Sự kiện khi click vào marker
        el.addEventListener('click', () => {
          onMarkerClick(court.id);
        });

        // Tạo marker và thêm vào bản đồ
        const marker = new vietmapgl.Marker({ element: el })
          .setLngLat([Number(court.longitude), Number(court.latitude)])
          .addTo(mapRef.current!);
          
        // Lưu marker vào ref để quản lý sau này
        markersRef.current[court.id] = marker;
      }
    });
  }, [mapData, onMarkerClick]);

  // Marker cho vị trí người dùng
  const userMarkerRef = useRef<vietmapgl.Marker | null>(null);

  /**
   * Hàm định vị vị trí hiện tại của người dùng
   */
  const handleLocateMe = () => {
    if (!navigator.geolocation || !mapRef.current) return;

    navigator.geolocation.getCurrentPosition((position) => {
      const { longitude, latitude } = position.coords;
      if (mapRef.current) {
        // Bay tới vị trí người dùng
        mapRef.current.flyTo({
          center: [longitude, latitude],
          zoom: 15
        });

        // Tạo hoặc cập nhật marker vị trí người dùng (màu xanh dương nhấp nháy)
        if (userMarkerRef.current) {
          userMarkerRef.current.setLngLat([longitude, latitude]);
        } else {
          const el = document.createElement('div');
          el.className = 'user-marker';
          el.innerHTML = `
            <div class="relative flex items-center justify-center">
              <div class="absolute w-8 h-8 bg-blue-500/30 rounded-full animate-ping"></div>
              <div class="w-4 h-4 bg-blue-600 rounded-full border-2 border-white shadow-lg"></div>
            </div>
          `;
          
          userMarkerRef.current = new vietmapgl.Marker({ element: el })
            .setLngLat([longitude, latitude])
            .addTo(mapRef.current);
        }
      }
    });
  };

  return {
    isLoading,
    handleLocateMe
  };
}
