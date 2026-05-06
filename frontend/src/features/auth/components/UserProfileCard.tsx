import { useState } from "react";
import { Link } from "react-router-dom";
import {
  User,
  Settings,
  LogOut,
  ChevronUp,
  ChevronDown,
  ShieldCheck,
  UserCircle,
} from "lucide-react";
import { useAuthStore } from "../store";
import { useLogout } from "../hooks";
import { cn } from "@/lib/utils";
import { Button } from "@/shared/components/ui/button";

export function UserProfileCard() {
  const [isOpen, setIsOpen] = useState(false);
  const { accessToken, user, role } = useAuthStore();
  const { mutate: logout, isLoading } = useLogout();

  if (!accessToken || !user) return null;

  return (
    <div className="fixed bottom-6 right-6 z-50 flex flex-col items-end gap-3 pointer-events-none">
      {/* ─── Profile Details Card (Collapsible) ───────────────── */}
      <div
        className={cn(
          "w-64 bg-white/80 backdrop-blur-xl border border-white/20 rounded-2xl shadow-[0_20px_50px_rgba(0,0,0,0.1)] transition-all duration-500 origin-bottom-right pointer-events-auto",
          isOpen
            ? "scale-100 opacity-100 translate-y-0"
            : "scale-75 opacity-0 translate-y-10 pointer-events-none",
        )}
      >
        <div className="p-5">
          {/* User Header */}
          <div className="flex items-center gap-3 mb-4">
            <div className="w-12 h-12 rounded-full bg-gradient-to-br from-[#004E43] to-[#00CE98] flex items-center justify-center text-white shadow-inner overflow-hidden">
              {user.avartarUrl ? (
                <img
                  src={user.avartarUrl}
                  alt="avatar"
                  className="w-full h-full object-cover"
                />
              ) : user.firstName ? (
                <span className="text-lg font-bold">
                  {user.firstName.charAt(0).toUpperCase()}
                </span>
              ) : (
                <User size={24} />
              )}
            </div>
            <div className="flex flex-col overflow-hidden">
              <span
                className="font-extrabold text-[#091E1B] truncate"
                title={`${user.lastName} ${user.firstName}`}
              >
                {user.lastName} {user.firstName}
              </span>
              <span className="text-[10px] font-bold uppercase tracking-widest text-[#9CA3AF] flex items-center gap-1">
                {role === "Admin" ? (
                  <>
                    <ShieldCheck size={10} className="text-[#00CE98]" />
                    Quản trị viên
                  </>
                ) : (
                  <>
                    <UserCircle size={10} className="text-[#004E43]" />
                    Thành viên
                  </>
                )}
              </span>
            </div>
          </div>

          <div className="space-y-2">
            <Link to="/profile" onClick={() => setIsOpen(false)}>
              <Button
                variant="ghost"
                className="w-full justify-start gap-3 rounded-xl hover:bg-[#F3F4F6] text-[#374151] font-bold h-10 px-3"
              >
                <Settings size={18} className="text-[#6B7280]" />
                <span>Cập nhật Profile</span>
              </Button>
            </Link>

            <Button
              variant="ghost"
              onClick={() => logout()}
              disabled={isLoading}
              className="w-full justify-start gap-3 rounded-xl hover:bg-red-50 text-red-500 font-bold h-10 px-3"
            >
              <LogOut size={18} />
              <span>{isLoading ? "Đang xử lý..." : "Đăng xuất"}</span>
            </Button>
          </div>
        </div>
      </div>

      {/* ─── Toggle Button ───────────────────────────────────── */}
      <Button
        variant="ghost"
        onClick={() => setIsOpen(!isOpen)}
        className={cn(
          "h-14 px-4 rounded-2xl flex items-center gap-3 shadow-lg transition-all duration-300 pointer-events-auto active:scale-95 group overflow-hidden relative hover:bg-transparent",
          isOpen
            ? "bg-[#091E1B] text-white shadow-[#091E1B]/30 hover:bg-[#091E1B]/90"
            : "bg-white text-[#091E1B] shadow-gray-200 hover:bg-gray-50",
        )}
      >
        <div className="w-8 h-8 rounded-full bg-gradient-to-tr from-[#004E43] to-[#00CE98] flex items-center justify-center text-white group-hover:scale-110 transition-transform overflow-hidden">
          {user.avartarUrl ? (
            <img
              src={user.avartarUrl}
              alt="avatar"
              className="w-full h-full object-cover"
            />
          ) : (
            <span className="text-xs font-black">
              {user.firstName?.charAt(0).toUpperCase() || "U"}
            </span>
          )}
        </div>

        <span className="font-bold text-sm">Tài khoản</span>

        {isOpen ? <ChevronDown size={18} /> : <ChevronUp size={18} />}

        {/* Subtle Shine Effect */}
        <div className="absolute inset-0 bg-white/10 -translate-x-full group-hover:translate-x-full transition-transform duration-1000 skew-x-12" />
      </Button>
    </div>
  );
}
