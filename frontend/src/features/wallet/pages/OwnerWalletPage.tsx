import React, { useState } from "react";
import { Card, CardContent } from "@/shared/components/ui/card";
import { Button } from "@/shared/components/ui/button";
import {
  Wallet,
  ArrowUpCircle,
  ArrowDownCircle,
  RefreshCw,
  CreditCard,
  TrendingUp,
  History,
} from "lucide-react";
import { useWallet } from "../hooks/useWallet";
import { DepositModal } from "../components/DepositModal";
import { WithdrawalModal } from "../components/WithdrawalModal";
import { AddBankModal } from "../components/AddBankModal";
import { WithdrawalHistory } from "../components/WithdrawalHistory";
import { TransactionHistory } from "../components/TransactionHistory";
import {
  Tabs,
  TabsContent,
  TabsList,
  TabsTrigger,
} from "@/shared/components/ui/tabs";

export const OwnerWalletPage: React.FC = () => {
  const {
    useWalletInfo,
    depositMutation,
    withdrawalMutation,
    addBankMutation,
    removeBankMutation,
    useMyTransactions,
    useMyWithdrawals,
  } = useWallet();

  const {
    data: wallet,
    isLoading: isWalletLoading,
    refetch: refetchWallet,
  } = useWalletInfo();

  const [pageParams] = useState({ pageIndex: 1, pageSize: 10 });
  const { data: transactions, isLoading: isTxLoading } = useMyTransactions(pageParams);
  const { data: withdrawals, isLoading: isWdLoading } = useMyWithdrawals(pageParams);

  const [isDepositOpen, setIsDepositOpen] = useState(false);
  const [isWithdrawalOpen, setIsWithdrawalOpen] = useState(false);
  const [isAddBankOpen, setIsAddBankOpen] = useState(false);

  if (isWalletLoading || !wallet) {
    return (
      <div className="flex items-center justify-center min-h-[60vh]">
        <RefreshCw className="w-8 h-8 animate-spin text-emerald-600" />
      </div>
    );
  }

  const handleDeposit = async (amount: number) => {
    return depositMutation.mutateAsync(amount);
  };

  const handleWithdrawal = async (amount: number) => {
    return withdrawalMutation.mutateAsync({ amount });
  };

  const handleAddBank = (data: any) => {
    addBankMutation.mutate(data);
    setIsAddBankOpen(false);
  };

  const handleRemoveBank = () => {
    if (window.confirm("Bạn có chắc chắn muốn xóa liên kết ngân hàng này?")) {
      removeBankMutation.mutate();
    }
  };

  return (
    <div className="min-h-screen bg-slate-50 w-full px-4 md:px-8 lg:px-16 pt-8 pb-12 space-y-6 animate-in fade-in duration-500 max-w-[1400px] mx-auto">
      {/* Header Info */}
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4 px-2">
        <div>
          <h1 className="text-2xl font-black text-slate-800 tracking-tight">
            Quản lý doanh thu
          </h1>
          <p className="text-slate-500 text-sm font-medium">
            Theo dõi số dư và thực hiện rút tiền về tài khoản
          </p>
        </div>
        <div className="flex items-center gap-2 bg-white px-4 py-2 rounded-2xl shadow-sm border border-slate-100">
          <div className="bg-emerald-50 p-1.5 rounded-lg text-emerald-600">
            <TrendingUp className="w-4 h-4" />
          </div>
        </div>
      </div>

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
              <span className="text-xl md:text-2xl font-bold text-emerald-600">
                đ
              </span>
              <Button
                variant="ghost"
                size="icon"
                className="text-slate-300 hover:text-emerald-600 hover:bg-emerald-50 ml-2 rounded-full h-10 w-10 transition-all"
                onClick={() => refetchWallet()}
              >
                <RefreshCw
                  className={`w-5 h-5 ${isWalletLoading ? "animate-spin" : ""}`}
                />
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
                      <p className="text-[9px] text-amber-600/60 font-bold uppercase tracking-wider mb-0.5">
                        Cài đặt thanh toán
                      </p>
                      <p className="text-sm font-bold text-slate-700">
                        Chưa thiết lập tài khoản nhận tiền!
                      </p>
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
                      <p className="text-[9px] text-slate-400 font-bold uppercase tracking-wider mb-0.5">
                        Tài khoản nhận doanh thu
                      </p>
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
                    Thay đổi
                  </Button>
                </div>
              )}
            </div>
          </CardContent>
        </Card>
      </section>

      {/* History Activity Section */}
      <section className="space-y-4 w-full">
        <div className="flex items-center gap-2 px-2">
          <History className="w-5 h-5 text-slate-400" />
          <h3 className="text-xl font-bold text-slate-800">
            Lịch sử giao dịch
          </h3>
        </div>

        <Card className="border-none shadow-lg bg-white overflow-hidden rounded-3xl">
          <CardContent className="p-0">
            <Tabs defaultValue="transactions" className="w-full">
              <div className="px-6 pt-6 border-b border-slate-50">
                <TabsList className="bg-slate-100/50 p-1 rounded-xl mb-4 w-fit inline-flex gap-1">
                  <TabsTrigger
                    value="transactions"
                    className="rounded-lg font-bold text-xs py-2 px-8 data-[state=active]:bg-white data-[state=active]:text-emerald-600 data-[state=active]:shadow-sm transition-all"
                  >
                    Biến động số dư
                  </TabsTrigger>
                  <TabsTrigger
                    value="withdrawals"
                    className="rounded-lg font-bold text-xs py-2 px-8 data-[state=active]:bg-white data-[state=active]:text-emerald-600 data-[state=active]:shadow-sm transition-all"
                  >
                    Yêu cầu rút tiền
                  </TabsTrigger>
                </TabsList>
              </div>

              <TabsContent
                value="transactions"
                className="m-0 focus-visible:outline-none focus-visible:ring-0"
              >
                <TransactionHistory 
                  transactions={transactions?.items || []} 
                  isLoading={isTxLoading} 
                />
              </TabsContent>

              <TabsContent
                value="withdrawals"
                className="m-0 focus-visible:outline-none focus-visible:ring-0"
              >
                <WithdrawalHistory 
                  withdrawals={withdrawals?.items || []} 
                  isLoading={isWdLoading} 
                />
              </TabsContent>
            </Tabs>
          </CardContent>
        </Card>
      </section>

      {/* Modals */}
      <DepositModal
        isOpen={isDepositOpen}
        onClose={() => setIsDepositOpen(false)}
        onDeposit={handleDeposit}
        isLoading={depositMutation.isPending}
      />

      <WithdrawalModal
        isOpen={isWithdrawalOpen}
        onClose={() => setIsWithdrawalOpen(false)}
        onSubmit={handleWithdrawal}
        isLoading={withdrawalMutation.isPending}
        wallet={wallet}
      />

      <AddBankModal
        isOpen={isAddBankOpen}
        onClose={() => setIsAddBankOpen(false)}
        onSubmit={handleAddBank}
        isLoading={addBankMutation.isPending}
      />
    </div>
  );
};

export default OwnerWalletPage;
