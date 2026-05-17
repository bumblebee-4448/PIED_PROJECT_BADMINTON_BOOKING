import React, { useState } from "react";
import { Card, CardContent } from "@/shared/components/ui/card";
import { Button } from "@/shared/components/ui/button";
import {
  Wallet,
  ArrowUpCircle,
  ArrowDownCircle,
  RefreshCw,
  CreditCard,
  History,
} from "lucide-react";
import { Pagination } from "@/shared/components/common/Pagination";
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
import {
  AlertDialog,
  AlertDialogAction,
  AlertDialogCancel,
  AlertDialogContent,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogTitle,
} from "@/shared/components/ui/alert-dialog";

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

  const [txPage, setTxPage] = useState(1);
  const [wdPage, setWdPage] = useState(1);
  const pageSize = 10;

  const { data: transactions, isLoading: isTxLoading } = useMyTransactions({ pageIndex: txPage, pageSize });
  const { data: withdrawals, isLoading: isWdLoading } = useMyWithdrawals({ pageIndex: wdPage, pageSize });

  const [isDepositOpen, setIsDepositOpen] = useState(false);
  const [isWithdrawalOpen, setIsWithdrawalOpen] = useState(false);
  const [isAddBankOpen, setIsAddBankOpen] = useState(false);
  const [isRemoveBankConfirmOpen, setIsRemoveBankConfirmOpen] = useState(false);

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
    setIsRemoveBankConfirmOpen(true);
  };

  return (
    <div className="min-h-screen bg-slate-50 w-full px-4 md:px-8 lg:px-16 pt-8 pb-12 space-y-6 animate-in fade-in duration-500 max-w-[1400px] mx-auto">
      {/* Header Info */}
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4 px-2">
        <div>
          <h1 className="text-xl font-bold text-slate-800 tracking-tight">
            Quản lý ví
          </h1>
          <p className="text-slate-500 text-sm font-medium">
            Theo dõi số dư và thực hiện rút tiền về tài khoản
          </p>
        </div>
      </div>

      {/* Top Section: Wallet Summary */}
      <section className="w-full">
        <Card className="border border-emerald-100 shadow-[0_10px_30px_rgba(16,185,129,0.05)] bg-white text-slate-900 overflow-hidden relative rounded-3xl min-h-[250px] flex flex-col justify-center">
          <div className="absolute top-0 right-0 p-6 opacity-[0.02] pointer-events-none text-emerald-600">
            <Wallet className="w-48 h-48 rotate-12" />
          </div>
          <div className="absolute top-0 left-0 w-full h-1 bg-gradient-to-r from-emerald-400 to-emerald-600" />

          <CardContent className="p-6 md:p-10 flex flex-col items-center text-center relative z-10 w-full">
            <div className="bg-emerald-50 text-emerald-700 px-3 py-1 rounded-full text-[10px] font-bold uppercase tracking-widest mb-4">
              Số dư ví hiện tại 
            </div>

            <div className="flex items-baseline justify-center gap-2 mb-8">
              <span className="text-5xl md:text-6xl font-bold tracking-tight text-slate-900">
                {wallet.balance.toLocaleString()}
              </span>
              <span className="text-xl font-bold text-emerald-600">
                đ
              </span>
              <Button
                variant="ghost"
                size="icon"
                className="text-slate-300 hover:text-emerald-600 hover:bg-emerald-50 ml-2 rounded-full h-9 w-9 transition-all"
                onClick={() => refetchWallet()}
              >
                <RefreshCw
                  className={`w-4 h-4 ${isWalletLoading ? "animate-spin" : ""}`}
                />
              </Button>
            </div>

            <div className="grid grid-cols-2 gap-4 w-full max-w-lg mb-8">
              <Button
                onClick={() => setIsDepositOpen(true)}
                className="bg-emerald-600 text-white hover:bg-emerald-700 font-bold px-6 py-4 h-auto text-sm rounded-xl shadow-md shadow-emerald-50 transition-all active:scale-95 flex items-center justify-center gap-2"
              >
                <ArrowUpCircle className="w-5 h-5" />
                Nạp tiền
              </Button>
              <Button
                onClick={() => setIsWithdrawalOpen(true)}
                variant="outline"
                className="border border-emerald-100 bg-white text-emerald-700 hover:bg-emerald-50 font-bold px-6 py-4 h-auto text-sm rounded-xl transition-all active:scale-95 flex items-center justify-center gap-2"
              >
                <ArrowDownCircle className="w-5 h-5 text-emerald-600" />
                Rút tiền
              </Button>
            </div>

            <div className="w-full max-w-lg">
              {!wallet.bankAccount ? (
                <div
                  onClick={() => setIsAddBankOpen(true)}
                  className="bg-amber-50/50 border border-amber-100 rounded-xl p-4 flex items-center justify-between cursor-pointer hover:bg-amber-50 transition-all"
                >
                  <div className="flex items-center gap-3">
                    <div className="bg-amber-100 p-2 rounded-xl text-amber-600">
                      <CreditCard className="w-4 h-4" />
                    </div>
                    <div className="text-left">
                      <p className="text-[9px] text-amber-600 font-bold uppercase tracking-wider mb-0.5">
                        Cài đặt thanh toán
                      </p>
                      <p className="text-sm font-bold text-slate-700 leading-none">
                        Chưa liên kết tài khoản ngân hàng
                      </p>
                    </div>
                  </div>
                  <div className="text-[10px] font-bold text-amber-700 underline underline-offset-4">
                    Liên kết ngay
                  </div>
                </div>
              ) : (
                <div className="bg-slate-50 border border-slate-100 rounded-xl p-4 flex items-center justify-between">
                  <div className="flex items-center gap-3 text-left">
                    <div className="bg-emerald-100 p-2 rounded-xl text-emerald-600">
                      <CreditCard className="w-4 h-4" />
                    </div>
                    <div>
                      <p className="text-[9px] text-slate-400 font-bold uppercase tracking-wider mb-0.5">
                        Tài khoản nhận doanh thu
                      </p>
                      <p className="text-sm font-bold text-slate-800">
                        {wallet.bankName} • {wallet.bankAccount}
                      </p>
                    </div>
                  </div>
                  <Button
                    variant="ghost"
                    size="sm"
                    onClick={handleRemoveBank}
                    className="text-[10px] text-slate-400 hover:text-rose-500 font-bold h-8 px-2 rounded-lg transition-all"
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
          <h3 className="text-lg font-bold text-slate-800">
            Lịch sử giao dịch
          </h3>
        </div>

        <Card className="border-none shadow-sm bg-white overflow-hidden rounded-3xl">
          <CardContent className="p-0">
            <Tabs defaultValue="transactions" className="w-full">
              <div className="px-6 pt-4 border-b border-slate-50">
                <TabsList className="bg-slate-50 p-1 rounded-xl mb-3 w-fit inline-flex">
                  <TabsTrigger
                    value="transactions"
                    className="rounded-lg font-bold text-[11px] py-1.5 px-6 data-[state=active]:bg-white data-[state=active]:text-emerald-600 data-[state=active]:shadow-sm transition-all"
                  >
                    Biến động số dư
                  </TabsTrigger>
                  <TabsTrigger
                    value="withdrawals"
                    className="rounded-lg font-bold text-[11px] py-1.5 px-6 data-[state=active]:bg-white data-[state=active]:text-emerald-600 data-[state=active]:shadow-sm transition-all"
                  >
                    Yêu cầu rút tiền
                  </TabsTrigger>
                </TabsList>
              </div>

              <TabsContent
                value="transactions"
                className="m-0 focus-visible:outline-none focus-visible:ring-0"
              >
                <div className="space-y-4 px-6 pb-6 pt-2">
                  <TransactionHistory 
                    transactions={transactions?.items || []} 
                    isLoading={isTxLoading} 
                  />
                  {transactions && transactions.totalItems > pageSize && (
                    <Pagination 
                      meta={{
                        totalItems: transactions.totalItems,
                        totalPages: Math.ceil(transactions.totalItems / pageSize),
                        itemsPerPage: pageSize,
                        currentPage: txPage,
                        hasPreviousPage: txPage > 1,
                        hasNextPage: txPage < Math.ceil(transactions.totalItems / pageSize)
                      }}
                      onPageChange={setTxPage}
                    />
                  )}
                </div>
              </TabsContent>

              <TabsContent
                value="withdrawals"
                className="m-0 focus-visible:outline-none focus-visible:ring-0"
              >
                <div className="space-y-4 px-6 pb-6 pt-2">
                  <WithdrawalHistory 
                    withdrawals={withdrawals?.items || []} 
                    isLoading={isWdLoading} 
                  />
                  {withdrawals && withdrawals.totalItems > pageSize && (
                    <Pagination 
                      meta={{
                        totalItems: withdrawals.totalItems,
                        totalPages: Math.ceil(withdrawals.totalItems / pageSize),
                        itemsPerPage: pageSize,
                        currentPage: wdPage,
                        hasPreviousPage: wdPage > 1,
                        hasNextPage: wdPage < Math.ceil(withdrawals.totalItems / pageSize)
                      }}
                      onPageChange={setWdPage}
                    />
                  )}
                </div>
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

      {/* Remove Bank Confirmation */}
      <AlertDialog open={isRemoveBankConfirmOpen} onOpenChange={setIsRemoveBankConfirmOpen}>
        <AlertDialogContent className="rounded-2xl">
          <AlertDialogHeader>
            <AlertDialogTitle className="flex items-center gap-2 text-rose-600 font-bold">
              Xác nhận xóa liên kết
            </AlertDialogTitle>
            <AlertDialogDescription className="text-sm font-medium">
              Bạn có chắc chắn muốn xóa liên kết ngân hàng này? Bạn sẽ cần thiết lập lại để có thể thực hiện rút tiền.
            </AlertDialogDescription>
          </AlertDialogHeader>
          <AlertDialogFooter>
            <AlertDialogCancel className="rounded-xl font-bold">Hủy bỏ</AlertDialogCancel>
            <AlertDialogAction 
              className="bg-rose-600 hover:bg-rose-700 text-white rounded-xl font-bold"
              onClick={() => removeBankMutation.mutate()}
            >
              Xác nhận xóa
            </AlertDialogAction>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialog>
    </div>
  );
};

export default OwnerWalletPage;
