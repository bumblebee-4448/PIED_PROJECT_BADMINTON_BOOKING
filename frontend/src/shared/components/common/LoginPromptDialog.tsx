import { useNavigate } from "react-router-dom";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogTitle,
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { useAuthStore } from "@/features/auth/store";
import { LogIn, UserPlus } from "lucide-react";

export const LoginPromptDialog = () => {
  const navigate = useNavigate();
  const { isLoginPromptOpen, setLoginPromptOpen } = useAuthStore();

  const handleLogin = () => {
    setLoginPromptOpen(false);
    navigate("/login");
  };

  const handleRegister = () => {
    setLoginPromptOpen(false);
    navigate("/register");
  };

  return (
    <Dialog open={isLoginPromptOpen} onOpenChange={setLoginPromptOpen}>
      <DialogContent className="sm:max-w-[425px] rounded-3xl border-none shadow-2xl p-0 overflow-hidden">
        <div className="bg-gradient-to-br from-[#004E43] to-[#00CE98] p-8 text-white text-center">
          <div className="mx-auto w-16 h-16 bg-white/20 rounded-2xl flex items-center justify-center mb-4 backdrop-blur-sm border border-white/30">
            <span className="text-3xl">🏸</span>
          </div>
          <DialogTitle className="text-2xl font-bold mb-2 text-white">Bạn muốn tìm sân ư?</DialogTitle>
          <DialogDescription className="text-white/80 text-lg leading-relaxed">
            Đăng nhập để chúng ta cùng tìm sân phù hợp nhé!
          </DialogDescription>
        </div>
        
        <div className="p-8 bg-white flex flex-col gap-4">
          <Button 
            onClick={handleLogin}
            className="w-full h-14 rounded-full bg-[#004E43] hover:bg-[#003830] text-white font-bold text-lg flex items-center justify-center gap-3 transition-all active:scale-95 shadow-lg"
          >
            <LogIn className="w-6 h-6" />
            Đăng nhập ngay
          </Button>
          
          <Button 
            variant="outline"
            onClick={handleRegister}
            className="w-full h-14 rounded-full border-2 border-[#00CE98] text-[#004E43] font-bold text-lg flex items-center justify-center gap-3 transition-all hover:bg-[#F0FDF9] active:scale-95"
          >
            <UserPlus className="w-6 h-6" />
            Chưa có tài khoản?
          </Button>
          
          <p className="text-center text-gray-400 text-sm mt-2">
            Tham gia ứng dụng RallyHub của chúng tôi để trải nghiệm dịch vụ tốt nhất.
          </p>
        </div>
      </DialogContent>
    </Dialog>
  );
};
