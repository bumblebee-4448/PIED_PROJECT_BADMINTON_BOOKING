import { useNavigate } from "react-router-dom";
import { ArrowLeft } from "lucide-react";

import { Button } from "@/shared/components/ui/button";

/**
 * Page 404 - Không tìm thấy.
 * Hiển thị khi user truy cập URL không tồn tại.
 */
export function NotFoundPage() {
  const navigate = useNavigate();

  return (
    <div className="flex min-h-[70vh] items-center justify-center bg-[#F9FBFA] px-4 py-16 overflow-hidden">
      <div className="max-w-2xl w-full text-center relative">
        <h1 className="text-[10rem] md:text-[14rem] font-black text-[#0B2421] leading-none tracking-tighter opacity-[0.06] absolute top-1/2 left-1/2 -translate-x-1/2 -translate-y-1/2 select-none">
          404
        </h1>
        
        <div className="relative z-10">
          <h2 className="text-4xl md:text-6xl font-black text-[#0B2421] mb-4 tracking-tight">
            Lạc đường rồi!
          </h2>
          <p className="text-gray-400 text-lg md:text-xl font-medium leading-relaxed max-w-lg mx-auto mb-10">
            Trang bạn đang tìm kiếm không tồn tại hoặc đã được di chuyển. 
            Đừng lo, RallyHub sẽ giúp bạn quay lại đúng hướng.
          </p>
        </div>

        <div className="flex flex-col sm:flex-row gap-4 max-w-md mx-auto relative z-20">
          <Button
            onClick={() => {
              if (window.history.length > 2) {
                navigate(-1);
              } else {
                navigate("/");
              }
            }}
            className="flex-1 bg-[#00897B] hover:bg-[#00796B] text-white rounded-2xl h-14 text-base font-bold flex items-center justify-center gap-3 transition-all shadow-xl shadow-emerald-900/10 cursor-pointer"
          >
            <ArrowLeft size={20} /> Quay lại
          </Button>

          <Button
            variant="ghost"
            onClick={() => navigate("/")}
            className="flex-1 h-14 rounded-2xl text-base font-bold text-emerald-600 hover:text-emerald-700 hover:bg-emerald-50 transition-all border border-emerald-100/50 hover:border-emerald-100 cursor-pointer"
          >
            Về trang chủ
          </Button>
        </div>
      </div>
    </div>
  );
}
