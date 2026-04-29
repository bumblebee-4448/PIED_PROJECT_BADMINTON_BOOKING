import { Trophy } from "lucide-react";
import { LoginForm } from "../components/LoginForm";

export const LoginPage = () => {
  return (
    <div className="min-h-screen w-full flex items-center justify-center p-4 sm:p-6 lg:p-8 relative overflow-hidden bg-[#F8FAFC]">
      
      {/* --- Dynamic Background Elements --- */}
      <div className="absolute inset-0 z-0">
        {/* Main Gradient Mesh */}
        <div 
          className="absolute inset-0 opacity-30"
          style={{
            background: `
              radial-gradient(at 0% 0%, #00CE98 0px, transparent 50%),
              radial-gradient(at 100% 0%, #004E43 0px, transparent 50%),
              radial-gradient(at 100% 100%, #00CE98 0px, transparent 50%),
              radial-gradient(at 0% 100%, #004E43 0px, transparent 50%)
            `
          }}
        />
        
        {/* Animated Floating Orbs */}
        <div className="absolute top-[-10%] left-[-10%] w-[40%] h-[40%] bg-[#00CE98]/10 blur-[120px] rounded-full animate-pulse" />
        <div className="absolute bottom-[-10%] right-[-10%] w-[40%] h-[40%] bg-[#004E43]/10 blur-[120px] rounded-full animate-pulse duration-[4000ms]" />
        
        {/* Subtle Grid Pattern */}
        <div 
          className="absolute inset-0 opacity-[0.03]" 
          style={{ backgroundImage: 'radial-gradient(#004E43 1px, transparent 1px)', backgroundSize: '40px 40px' }}
        />
      </div>

      {/* --- Main Card --- */}
      <div className="w-full max-w-[450px] md:max-w-4xl lg:max-w-5xl bg-white/95 backdrop-blur-sm rounded-[1.5rem] md:rounded-[2.5rem] shadow-[0_20px_50px_rgba(0,78,67,0.15)] overflow-hidden flex flex-col md:flex-row min-h-[550px] md:min-h-[600px] relative z-10 border border-white/20">
        
        {/* --- Left Side: Login Form --- */}
        <div className="flex-1 p-6 sm:p-10 md:p-12 lg:p-16 flex flex-col justify-center bg-white/50">
          <div className="mb-6 md:mb-8 text-center md:text-left">
            <h1 className="text-3xl md:text-4xl font-extrabold text-[#091E1B] tracking-tight">
              Đăng nhập <span className="text-[#00CE98]">🏸</span>
            </h1>
            <p className="text-[#6B7280] mt-2 text-sm md:text-base">
              Chào mừng bạn trở lại với <span className="font-bold text-[#004E43]">RallyHub</span>.
            </p>
          </div>

          <LoginForm />

          <p className="mt-8 text-center md:text-left text-[#9CA3AF] text-[10px] md:text-xs font-medium">
            © 2026 RallyHub Ecosystem. All Rights Reserved.
          </p>
        </div>


        {/* --- Right Side: Visual Content --- */}
        <div 
          className="hidden md:flex flex-1 relative overflow-hidden items-center justify-center p-8 lg:p-12 text-white"
          style={{ background: "linear-gradient(to bottom right, #004E43, #00CE98)" }}
        >
          {/* Abstract Wavy Pattern SVG */}
          <div className="absolute inset-0 opacity-10 pointer-events-none">
            <svg width="100%" height="100%" viewBox="0 0 1000 1000" xmlns="http://www.w3.org/2000/svg">
              <path d="M0,1000 C300,800 400,900 700,700 C1000,500 1000,0 1000,0 L0,0 Z" fill="white" />
            </svg>
          </div>

          <div className="relative z-10 w-full max-w-sm">
            <div className="space-y-4 text-center lg:text-left">
              <h2 className="text-3xl lg:text-4xl xl:text-5xl font-black leading-tight tracking-tighter">
                Sẵn sàng cho <br className="hidden xl:block" />
                <span className="text-[#FFD700]">những cú Smash</span>
              </h2>
              <p className="text-base lg:text-lg text-white/90 font-medium italic border-l-4 border-[#FFD700] pl-4 py-1">
                "Nâng tầm đam mê, bứt phá giới hạn."
              </p>
            </div>

            <div className="mt-8 lg:mt-12 relative group">
              <div className="absolute -inset-4 bg-white/10 rounded-[2rem] blur-xl" />
              <img 
                src="/badminton_player_login_side_1777042795696.png" 
                alt="Badminton Player" 
                className="relative rounded-[1.5rem] lg:rounded-[2rem] shadow-2xl w-full object-cover transform transition-transform duration-700 group-hover:scale-[1.02]"
              />
              
              <div className="absolute -top-4 -right-4 lg:-top-6 lg:-right-6 bg-white rounded-xl lg:rounded-2xl p-3 lg:p-4 shadow-xl hidden lg:block">
                <Trophy className="w-6 h-6 lg:w-8 lg:h-8 text-[#FFD700]" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
