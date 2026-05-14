import React from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/shared/components/ui/card";
import { Button } from "@/shared/components/ui/button";
import { CreditCard, Plus, Trash2 } from "lucide-react";
import type { WalletInfo } from "../types";

interface BankInfoCardProps {
  wallet: WalletInfo;
  onAdd: () => void;
  onRemove: () => void;
  isRemoving: boolean;
}

export const BankInfoCard: React.FC<BankInfoCardProps> = ({ wallet, onAdd, onRemove, isRemoving }) => {
  const hasBank = !!wallet.bankAccount;

  return (
    <Card className="overflow-hidden border-none shadow-2xl bg-slate-900 text-white relative">
      <div className="absolute top-0 right-0 w-32 h-32 bg-emerald-500/10 rounded-full -mr-16 -mt-16 blur-3xl pointer-events-none" />
      
      <CardHeader className="border-b border-white/5 bg-white/5">
        <CardTitle className="flex items-center gap-2 text-md font-bold uppercase tracking-wide">
          <CreditCard className="w-5 h-5 text-emerald-400" />
          Tài khoản ngân hàng
        </CardTitle>
      </CardHeader>
      <CardContent className="p-6 relative z-10">
        {hasBank ? (
          <div className="space-y-6">
            <div className="grid grid-cols-1 gap-4">
              <div className="bg-white/5 p-3 rounded-lg border border-white/5">
                <p className="text-[10px] text-emerald-400 uppercase font-black tracking-widest mb-1">Ngân hàng</p>
                <p className="text-md font-bold">{wallet.bankName}</p>
              </div>
              <div className="bg-white/5 p-3 rounded-lg border border-white/5">
                <p className="text-[10px] text-emerald-400 uppercase font-black tracking-widest mb-1">Số tài khoản</p>
                <p className="text-xl font-mono font-black text-emerald-300 tracking-wider">{wallet.bankAccount}</p>
              </div>
              <div className="bg-white/5 p-3 rounded-lg border border-white/5">
                <p className="text-[10px] text-emerald-400 uppercase font-black tracking-widest mb-1">Chủ tài khoản</p>
                <p className="text-md font-bold uppercase">{wallet.bankAccountName}</p>
              </div>
            </div>
            
            <Button 
              variant="ghost" 
              size="sm" 
              onClick={handleRemoveBank}
              disabled={isRemoving}
              className="w-full text-red-400 hover:text-red-300 hover:bg-red-500/10 border border-transparent hover:border-red-500/20"
            >
              <Trash2 className="w-4 h-4 mr-2" />
              Xóa liên kết
            </Button>
          </div>
        ) : (
          <div className="flex flex-col items-center justify-center py-10 text-center">
            <div className="w-20 h-20 bg-emerald-500/10 rounded-full flex items-center justify-center mb-6 border border-emerald-500/20">
              <Plus className="w-10 h-10 text-emerald-500" />
            </div>
            <h3 className="text-xl font-black mb-3">Liên kết ngân hàng</h3>
            <p className="text-slate-400 text-sm mb-8 leading-relaxed">
              Vui lòng liên kết tài khoản ngân hàng để thực hiện rút tiền an toàn.
            </p>
            <Button 
              onClick={onAdd} 
              className="bg-emerald-600 hover:bg-emerald-500 text-white font-bold w-full py-6 shadow-lg shadow-emerald-900/20"
            >
              <Plus className="w-5 h-5 mr-2" />
              Thêm tài khoản ngay
            </Button>
          </div>
        )}
      </CardContent>
    </Card>
  );
};
