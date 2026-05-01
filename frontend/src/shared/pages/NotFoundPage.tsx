import { useNavigate, Link } from "react-router-dom";
import { FileQuestion, ArrowLeft } from "lucide-react";

import { Button } from "@/shared/components/ui/button";

/**
 * Page 404 - Không tìm thấy.
 * Hiển thị khi user truy cập URL không tồn tại.
 */
export function NotFoundPage() {
  const navigate = useNavigate();

  return (
    <div className="flex min-h-[70vh] items-center justify-center bg-[#F1F5F9]/50 px-4">
      <div className="max-w-md w-full bg-white p-10 rounded-[2.5rem] shadow-xl shadow-gray-200/50 text-center border border-gray-100">
        <div className="w-20 h-20 bg-emerald-50 rounded-3xl flex items-center justify-center mx-auto mb-6">
          <FileQuestion className="h-10 w-10 text-emerald-500" />
        </div>
        
        <h1 className="text-6xl font-black text-[#0B2421] mb-2 tracking-tighter">404</h1>
        <h2 className="text-xl font-extrabold text-[#0B2421] mb-3">Lạc đường rồi!</h2>
        <p className="text-gray-400 text-sm font-medium leading-relaxed mb-8">
          Trang bạn đang tìm kiếm không tồn tại hoặc đã được di chuyển. Đừng lo, hãy quay lại nhé!
        </p>

        <div className="flex flex-col gap-3">
          <Button 
            onClick={() => navigate(-1)}
            className="w-full bg-[#0B2421] hover:bg-[#0B2421]/90 text-white rounded-2xl h-12 font-bold flex items-center justify-center gap-2 transition-all shadow-lg shadow-gray-200"
          >
            <ArrowLeft size={18} /> Quay lại trang trước
          </Button>
          
          <Button variant="ghost" asChild className="w-full h-12 rounded-2xl font-bold text-emerald-600 hover:text-emerald-700 hover:bg-emerald-50 transition-all">
            <Link to="/">Về trang chủ</Link>
          </Button>
        </div>
      </div>
    </div>
  );
}
