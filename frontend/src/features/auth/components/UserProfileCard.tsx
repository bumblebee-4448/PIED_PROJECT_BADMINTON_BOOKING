import { useState } from "react";
import {
  User,
  Settings,
  LogOut,
  ChevronUp,
  ChevronDown,
  ShieldCheck,
  UserCircle,
  Wallet,
} from "lucide-react";
import { useNavigate } from "react-router-dom";
import { useAuthStore } from "../store";
import { useLogout } from "../hooks";
import { useWallet } from "@/features/wallet";
import { cn } from "@/lib/utils";
import { Button } from "@/shared/components/ui/button";
import { EditProfileDialog } from "@/features/profile/components/EditProfileDialog";

export function UserProfileCard() {
  const navigate = useNavigate();
  const [isOpen, setIsOpen] = useState(false);
  const [isEditDialogOpen, setIsEditDialogOpen] = useState(false);
  const { accessToken, user, role } = useAuthStore();
  const { mutate: logout, isLoading } = useLogout();
  const { useWalletInfo } = useWallet();
  const { data: wallet } = useWalletInfo(role !== "Admin");

  if (!accessToken || !user) return null;

  return (
    <div className="relative z-50 flex flex-col items-end">
      {/* ─── Profile Details Card (Collapsible) ───────────────── */}
      <div
        className={cn(
          "absolute top-full right-0 mt-3 w-64 bg-white/95 backdrop-blur-xl border border-gray-100 rounded-2xl shadow-[0_20px_50px_rgba(0,0,0,0.1)] transition-all duration-500 origin-top-right z-[110]",
          isOpen
            ? "scale-100 opacity-100 translate-y-0"
            : "scale-75 opacity-0 -translate-y-4 pointer-events-none",
        )}
      >
        <div className="p-5">
          {/* User Header */}
          <div className="flex items-center gap-3 mb-4">
            <div className="w-12 h-12 rounded-full bg-gradient-to-br from-[#004E43] to-[#00CE98] flex items-center justify-center text-white shadow-inner overflow-hidden">
              {user.avatarUrl ? (
                <img
                  src={user.avatarUrl}
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
          
          {/* Wallet Balance */}
          {wallet && (
            <div 
              onClick={() => {
                const path = role === "Admin" ? "/admin/withdrawals" : role === "Owner" ? "/owner/wallet" : "/wallet";
                navigate(path);
                setIsOpen(false);
              }}
              className="mb-4 p-3 rounded-xl bg-gradient-to-br from-[#004E43]/5 to-[#00CE98]/5 border border-[#004E43]/10 flex items-center justify-between cursor-pointer hover:bg-emerald-50 transition-all group/wallet"
            >
              <div className="flex items-center gap-2">
                <div className="w-8 h-8 rounded-lg bg-white shadow-sm flex items-center justify-center text-[#004E43] group-hover/wallet:scale-110 transition-transform">
                  <Wallet size={16} />
                </div>
                <div className="flex flex-col">
                  <span className="text-[10px] font-bold uppercase tracking-tight text-[#9CA3AF]">Số dư ví</span>
                  <span className="text-sm font-black text-[#091E1B]">
                    {new Intl.NumberFormat("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    }).format(wallet.balance)}
                  </span>
                </div>
              </div>
              <ChevronDown size={12} className="text-slate-300 -rotate-90 group-hover/wallet:translate-x-1 transition-all" />
            </div>
          )}

          <div className="space-y-2">
            <Button 
              variant="ghost" 
              onClick={() => {
                setIsOpen(false);
                setIsEditDialogOpen(true);
              }}
              className="w-full justify-start gap-3 rounded-xl hover:bg-[#F3F4F6] text-[#374151] font-bold h-10 px-3"
            >
              <Settings size={18} className="text-[#6B7280]" />
              <span>Cập nhật Profile</span>
            </Button>

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
          "h-11 px-3 rounded-xl flex items-center gap-3 transition-all duration-300 active:scale-95 group overflow-hidden relative",
          isOpen
            ? "bg-[#091E1B] text-white shadow-lg shadow-[#091E1B]/20"
            : "bg-gray-50 text-[#091E1B] hover:bg-gray-100",
        )}
      >
        <div className="w-8 h-8 rounded-full bg-gradient-to-tr from-[#004E43] to-[#00CE98] flex items-center justify-center text-white group-hover:scale-110 transition-transform overflow-hidden shadow-sm">
          {user.avatarUrl ? (
            <img
              src={user.avatarUrl}
              alt="avatar"
              className="w-full h-full object-cover"
            />
          ) : (
            <span className="text-xs font-black">
              {user.firstName?.charAt(0).toUpperCase() || "U"}
            </span>
          )}
        </div>

        <div className="flex flex-col items-start">
          <span className="text-[10px] font-black uppercase tracking-widest opacity-50 leading-none mb-1">Tài khoản</span>
          <span className="text-xs font-bold leading-none">{user.firstName}</span>
        </div>

        {isOpen ? <ChevronDown size={14} className="opacity-50" /> : <ChevronUp size={14} className="opacity-50" />}

        {/* Subtle Shine Effect */}
        <div className="absolute inset-0 bg-white/10 -translate-x-full group-hover:translate-x-full transition-transform duration-1000 skew-x-12" />
      </Button>

      <EditProfileDialog 
        isOpen={isEditDialogOpen} 
        onOpenChange={setIsEditDialogOpen} 
      />
    </div>
  );
}
