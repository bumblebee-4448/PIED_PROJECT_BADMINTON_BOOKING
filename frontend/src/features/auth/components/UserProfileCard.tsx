import { useState } from "react";
import {
  Settings,
  LogOut,
  ChevronUp,
  ChevronDown,
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
    <div className="relative flex flex-col items-end">
      {/* ─── Profile Details Card (Collapsible) ───────────────── */}
      <div
        className={cn(
          "absolute top-full right-0 mt-2 w-64 bg-white border border-gray-100 rounded-2xl shadow-xl transition-all duration-300 origin-top-right z-[100]",
          isOpen
            ? "scale-100 opacity-100 translate-y-0"
            : "scale-95 opacity-0 -translate-y-2 pointer-events-none",
        )}
      >
        <div className="p-5">
          {/* User Header */}
          <div className="flex items-center gap-3 mb-5 pb-5 border-b border-gray-50">
            <div className="w-12 h-12 rounded-full bg-emerald-100 flex items-center justify-center text-emerald-600 shadow-sm overflow-hidden shrink-0">
              {user.avatarUrl ? (
                <img
                  src={user.avatarUrl}
                  alt="avatar"
                  className="w-full h-full object-cover"
                />
              ) : (
                <span className="text-lg font-bold">
                  {user.firstName?.charAt(0).toUpperCase() || "U"}
                </span>
              )}
            </div>
            <div className="flex flex-col min-w-0">
              <span className="font-bold text-gray-900 truncate text-sm">
                {user.lastName} {user.firstName}
              </span>
              <span className="text-[10px] font-bold text-gray-400 uppercase tracking-widest flex items-center gap-1 mt-0.5">
                {role === "Admin" ? "Quản trị viên" : "Thành viên"}
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
              className="mb-4 p-4 rounded-xl bg-slate-50 border border-slate-100 flex items-center justify-between cursor-pointer transition-colors hover:bg-slate-100"
            >
              <div className="flex items-center gap-3">
                <div className="w-8 h-8 rounded-lg bg-white shadow-sm flex items-center justify-center text-emerald-600">
                  <Wallet size={16} />
                </div>
                <div className="flex flex-col">
                  <span className="text-[10px] font-bold text-gray-400 uppercase tracking-wider">Số dư ví</span>
                  <span className="text-sm font-bold text-gray-900">
                    {wallet.balance.toLocaleString()}đ
                  </span>
                </div>
              </div>
            </div>
          )}

          <div className="space-y-1">
            <Button 
              variant="ghost" 
              onClick={() => {
                setIsOpen(false);
                setIsEditDialogOpen(true);
              }}
              className="w-full justify-start gap-3 rounded-xl hover:bg-gray-50 text-gray-600 font-semibold h-11 px-3"
            >
              <Settings size={18} className="text-gray-400" />
              <span className="text-sm">Cập nhật Profile</span>
            </Button>

            <Button
              variant="ghost"
              onClick={() => logout()}
              disabled={isLoading}
              className="w-full justify-start gap-3 rounded-xl hover:bg-rose-50 text-rose-600 font-semibold h-11 px-3"
            >
              <LogOut size={18} />
              <span className="text-sm">{isLoading ? "Đang xử lý..." : "Đăng xuất"}</span>
            </Button>
          </div>
        </div>
      </div>

      {/* ─── Toggle Button ───────────────────────────────────── */}
      <Button
        variant="ghost"
        onClick={() => setIsOpen(!isOpen)}
        className={cn(
          "h-10 px-3 rounded-xl flex items-center gap-3 transition-all duration-200 active:scale-95",
          isOpen
            ? "bg-gray-900 text-white shadow-lg"
            : "bg-gray-50 text-gray-700 hover:bg-gray-100",
        )}
      >
        <div className="w-7 h-7 rounded-full bg-emerald-100 flex items-center justify-center text-emerald-700 overflow-hidden shadow-sm">
          {user.avatarUrl ? (
            <img
              src={user.avatarUrl}
              alt="avatar"
              className="w-full h-full object-cover"
            />
          ) : (
            <span className="text-[10px] font-bold">
              {user.firstName?.charAt(0).toUpperCase() || "U"}
            </span>
          )}
        </div>

        <div className="hidden sm:flex flex-col items-start text-left">
          <span className="text-[9px] font-bold uppercase tracking-widest opacity-50 leading-none mb-0.5">Tài khoản</span>
          <span className="text-xs font-bold leading-none">{user.firstName}</span>
        </div>

        {isOpen ? <ChevronDown size={14} className="opacity-50" /> : <ChevronUp size={14} className="opacity-50" />}
      </Button>

      <EditProfileDialog 
        isOpen={isEditDialogOpen} 
        onOpenChange={setIsEditDialogOpen} 
      />
    </div>
  );
}
