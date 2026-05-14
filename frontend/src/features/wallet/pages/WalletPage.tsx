import React, { useState } from "react";
import { useWallet } from "../hooks/useWallet";
import { TransactionHistory } from "../components/TransactionHistory";
import { WithdrawalHistory } from "../components/WithdrawalHistory";
import { AddBankModal } from "../components/AddBankModal";
import { DepositModal } from "../components/DepositModal";
import { WithdrawalModal } from "../components/WithdrawalModal";
import { Card, CardContent } from "@/shared/components/ui/card";
import { Button } from "@/shared/components/ui/button";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/shared/components/ui/tabs";
import { Wallet, ArrowUpCircle, ArrowDownCircle, RefreshCw, History, CreditCard } from "lucide-react";

const WalletPage: React.FC = () => {
  const { 
    useWalletInfo, 
    useMyTransactions, 
    useMyWithdrawals,
    addBankMutation,
    removeBankMutation,
    depositMutation,
    withdrawalMutation
  } = useWallet();

  const { data: wallet, isLoading: isWalletLoading, refetch: refetchWallet } = useWalletInfo();
  
  const [pageParams] = useState({ pageIndex: 1, pageSize: 10 });
  const { data: transactions, isLoading: isTxLoading } = useMyTransactions(pageParams);
  const { data: withdrawals, isLoading: isWdLoading } = useMyWithdrawals(pageParams);

  // Modal states
  const [isAddBankOpen, setIsAddBankOpen] = useState(false);
  const [isDepositOpen, setIsDepositOpen] = useState(false);
  const [isWithdrawalOpen, setIsWithdrawalOpen] = useState(false);

  if (isWalletLoading) {
    return (
      <div className="container mx-auto p-6 flex flex-col items-center justify-center min-h-[400px]">
        <RefreshCw className="w-8 h-8 animate-spin text-blue-600 mb-4" />
        <p className="text-slate-500">Đang tải thông tin ví...</p>
      </div>
    );
  }

  if (!wallet) return null;

  const handleAddBank = (data: any) => {
    addBankMutation.mutate(data, {
      onSuccess: () => setIsAddBankOpen(false)
    });
  };

  const handleRemoveBank = () => {
    if (window.confirm("Bạn có chắc chắn muốn xóa liên kết ngân hàng?")) {
      removeBankMutation.mutate();
    }
  };

  const handleWithdrawal = (amount: number) => {
    withdrawalMutation.mutate({ amount }, {
      onSuccess: () => setIsWithdrawalOpen(false)
    });
  };

  return (
    <div className="min-h-screen bg-slate-50 w-full px-4 md:px-8 lg:px-16 pt-24 md:pt-32 pb-12 space-y-6 animate-in fade-in duration-500 max-w-[1400px] mx-auto">
      {/* Top Section: Wallet Summary (Compact & Refined Style) */}
      <section className="w-full">
        <Card className="border border-emerald-100 shadow-[0_15px_40px_rgba(16,185,129,0.08)] bg-white text-slate-900 overflow-hidden relative rounded-[2rem] min-h-[280px] flex flex-col justify-center">
          {/* Subtle Decorative Background */}
          <div className="absolute top-0 right-0 p-6 opacity-[0.02] pointer-events-none text-emerald-600">
            <Wallet className="w-64 h-64 rotate-12" />
          </div>
          <div className="absolute top-0 left-0 w-full h-1 bg-gradient-to-r from-emerald-400 via-teal-500 to-emerald-600" />
          
          <CardContent className="p-6 md:p-8 flex flex-col items-center text-center relative z-10 w-full">
            <div className="bg-emerald-50 text-emerald-700 px-3 py-1 rounded-full text-[10px] font-bold uppercase tracking-widest mb-4">
              Số dư ví hiện tại
            </div>
            
            <div className="flex items-baseline justify-center gap-2 mb-8">
              <span className="text-5xl md:text-7xl font-black tracking-tighter text-slate-900">
                {wallet.balance.toLocaleString()}
              </span>
              <span className="text-xl md:text-2xl font-bold text-emerald-600">đ</span>
              <Button 
                variant="ghost" 
                size="icon" 
                className="text-slate-300 hover:text-emerald-600 hover:bg-emerald-50 ml-2 rounded-full h-10 w-10 transition-all"
                onClick={() => refetchWallet()}
              >
                <RefreshCw className={`w-5 h-5 ${isWalletLoading ? 'animate-spin' : ''}`} />
              </Button>
            </div>
            
            <div className="grid grid-cols-2 gap-4 w-full max-w-xl mb-8">
              <Button 
                onClick={() => setIsDepositOpen(true)}
                className="bg-emerald-600 text-white hover:bg-emerald-700 font-bold px-6 py-4 h-auto text-base rounded-xl shadow-md shadow-emerald-100 transition-all hover:scale-[1.02] active:scale-95 flex items-center justify-center gap-3 group"
              >
                <div className="bg-white/20 p-1.5 rounded-lg group-hover:rotate-12 transition-transform">
                  <ArrowUpCircle className="w-5 h-5" />
                </div>
                Nạp tiền
              </Button>
              <Button 
                onClick={() => setIsWithdrawalOpen(true)}
                variant="outline"
                className="border border-emerald-100 bg-white text-emerald-700 hover:bg-emerald-50 font-bold px-6 py-4 h-auto text-base rounded-xl shadow-sm transition-all hover:scale-[1.02] active:scale-95 flex items-center justify-center gap-3 group"
              >
                <div className="bg-emerald-50 p-1.5 rounded-lg group-hover:-rotate-12 transition-transform">
                  <ArrowDownCircle className="w-5 h-5 text-emerald-600" />
                </div>
                Rút tiền
              </Button>
            </div>

            <div className="w-full max-w-xl">
              {!wallet.bankAccount ? (
                <div 
                  onClick={() => setIsAddBankOpen(true)}
                  className="bg-amber-50/50 border border-amber-100 rounded-xl p-4 flex items-center justify-between cursor-pointer hover:bg-amber-50 transition-all group"
                >
                  <div className="flex items-center gap-3">
                    <div className="bg-amber-100 p-2 rounded-xl text-amber-600">
                      <CreditCard className="w-5 h-5" />
                    </div>
                    <div className="text-left">
                      <p className="text-[9px] text-amber-600/60 font-bold uppercase tracking-wider mb-0.5">Yêu cầu bảo mật</p>
                      <p className="text-sm font-bold text-slate-700">Chưa liên kết ngân hàng!</p>
                    </div>
                  </div>
                  <div className="flex items-center gap-2 text-amber-700 font-bold text-[10px] bg-white px-3 py-1.5 rounded-lg shadow-sm group-hover:bg-amber-600 group-hover:text-white transition-all border border-amber-100">
                    Liên kết ngay
                  </div>
                </div>
              ) : (
                <div className="bg-slate-50 border border-slate-100 rounded-xl p-4 flex items-center justify-between">
                  <div className="flex items-center gap-3 text-left">
                    <div className="bg-emerald-100 p-2 rounded-xl text-emerald-600">
                      <CreditCard className="w-5 h-5" />
                    </div>
                    <div>
                      <p className="text-[9px] text-slate-400 font-bold uppercase tracking-wider mb-0.5">Tài khoản thụ hưởng</p>
                      <p className="text-base font-bold text-slate-800">
                        {wallet.bankName} • {wallet.bankAccount}
                      </p>
                    </div>
                  </div>
                  <Button 
                    variant="ghost" 
                    size="sm" 
                    onClick={handleRemoveBank}
                    className="text-[10px] text-slate-400 hover:text-red-500 hover:bg-red-50 h-8 px-3 rounded-lg font-bold transition-all"
                  >
                    Xóa liên kết
                  </Button>
                </div>
              )}
            </div>
          </CardContent>
        </Card>
      </section>

      {/* Bottom Section: History Activity */}
      <section className="space-y-4 w-full">
        <h3 className="text-xl font-bold text-slate-800 px-2">Lịch sử hoạt động</h3>
        
        <Card className="border-none shadow-lg bg-white overflow-hidden rounded-3xl">
          <CardContent className="p-0">
            <Tabs defaultValue="transactions" className="w-full">
              <div className="px-6 pt-6 pb-2 border-b border-slate-50">
                <TabsList className="bg-slate-100/50 p-1 rounded-xl h-auto inline-flex gap-1 w-fit">
                  <TabsTrigger 
                    value="transactions" 
                    className="gap-2 px-8 py-2.5 rounded-lg data-[state=active]:bg-white data-[state=active]:text-emerald-600 data-[state=active]:shadow-sm transition-all font-bold text-xs"
                  >
                    <History className="w-4 h-4" />
                    Biến động số dư
                  </TabsTrigger>
                  <TabsTrigger 
                    value="withdrawals" 
                    className="gap-2 px-8 py-2.5 rounded-lg data-[state=active]:bg-white data-[state=active]:text-emerald-600 data-[state=active]:shadow-sm transition-all font-bold text-xs"
                  >
                    <ArrowDownCircle className="w-4 h-4" />
                    Yêu cầu rút tiền
                  </TabsTrigger>
                </TabsList>
              </div>
              
              <div className="px-6 py-6">
                <TabsContent value="transactions" className="mt-0 outline-none focus-visible:ring-0">
                  <TransactionHistory 
                    transactions={transactions?.items || []} 
                    isLoading={isTxLoading} 
                  />
                </TabsContent>
                <TabsContent value="withdrawals" className="mt-0 outline-none focus-visible:ring-0">
                  <WithdrawalHistory 
                    withdrawals={withdrawals?.items || []} 
                    isLoading={isWdLoading} 
                  />
                </TabsContent>
              </div>
            </Tabs>
          </CardContent>
        </Card>
      </section>

      {/* Modals */}
      <AddBankModal 
        isOpen={isAddBankOpen}
        onClose={() => setIsAddBankOpen(false)}
        onSubmit={handleAddBank}
        isLoading={addBankMutation.isPending}
      />

      <DepositModal 
        isOpen={isDepositOpen}
        onClose={() => setIsDepositOpen(false)}
        onDeposit={(amt) => depositMutation.mutateAsync(amt)}
        isLoading={depositMutation.isPending}
      />

      <WithdrawalModal 
        isOpen={isWithdrawalOpen}
        onClose={() => setIsWithdrawalOpen(false)}
        onSubmit={handleWithdrawal}
        isLoading={withdrawalMutation.isPending}
        wallet={wallet}
      />
    </div>
  );
};

export default WalletPage;
