import React, { useEffect, useState } from "react";
import { 
  Dialog, 
  DialogContent, 
  DialogTitle, 
  DialogFooter,
  DialogDescription
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { Search } from "lucide-react";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import * as z from "zod";
import type { AddBankInfoRequest } from "../types";
import { Skeleton } from "@/shared/components/ui/skeleton";

interface Bank {
  id: number;
  name: string;
  code: string;
  shortName: string;
  logo: string;
}

const formSchema = z.object({
  bankName: z.string().min(1, "Vui lòng chọn ngân hàng"),
  bankAccount: z.string().min(5, "Số tài khoản không hợp lệ"),
  bankAccountName: z.string().min(2, "Tên chủ tài khoản quá ngắn"),
});

interface AddBankModalProps {
  isOpen: boolean;
  onClose: () => void;
  onSubmit: (data: AddBankInfoRequest) => void;
  isLoading: boolean;
}

export const AddBankModal: React.FC<AddBankModalProps> = ({ isOpen, onClose, onSubmit, isLoading }) => {
  const [banks, setBanks] = useState<Bank[]>([]);
  const [isFetchingBanks, setIsFetchingBanks] = useState(false);
  const [searchTerm, setSearchTerm] = useState("");
  const [showDropdown, setShowDropdown] = useState(false);

  const { register, handleSubmit, formState: { errors }, reset, setValue } = useForm<AddBankInfoRequest>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      bankName: "",
      bankAccount: "",
      bankAccountName: ""
    }
  });


  useEffect(() => {
    if (isOpen) {
      const fetchBanks = async () => {
        setIsFetchingBanks(true);
        try {
          const response = await fetch("https://api.vietqr.io/v2/banks");
          const result = await response.json();
          if (result.code === "00") {
            setBanks(result.data);
          }
        } catch (error) {
          console.error("Failed to fetch banks", error);
        } finally {
          setIsFetchingBanks(false);
        }
      };
      fetchBanks();
    }
  }, [isOpen]);

  const filteredBanks = banks.filter(bank => 
    bank.shortName.toLowerCase().includes(searchTerm.toLowerCase()) ||
    bank.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const handleSelectBank = (bank: Bank) => {
    setValue("bankName", bank.shortName);
    setSearchTerm(bank.shortName);
    setShowDropdown(false);
  };

  const handleFormSubmit = (data: AddBankInfoRequest) => {
    onSubmit(data);
    reset();
    setSearchTerm("");
  };

  return (
    <Dialog open={isOpen} onOpenChange={onClose}>
      <DialogContent className="sm:max-w-[420px] rounded-[1.5rem] border-none shadow-2xl p-0 overflow-hidden">
        <div className="bg-emerald-600 px-6 py-4">
          <DialogTitle className="text-lg font-bold text-white">Liên kết ngân hàng</DialogTitle>
          <DialogDescription className="text-emerald-100 text-xs mt-1">
            Nhập chính xác để đảm bảo tiền về đúng tài khoản.
          </DialogDescription>
        </div>
        
        <form onSubmit={handleSubmit(handleFormSubmit)} className="p-6 space-y-4">
          <div className="space-y-2 relative">
            <Label className="text-[10px] font-bold text-slate-400 uppercase tracking-widest">Chọn ngân hàng</Label>
            
            <div className="relative">
              <Input 
                placeholder="Gõ tên ngân hàng để tìm kiếm..." 
                value={searchTerm}
                onChange={(e) => {
                  setSearchTerm(e.target.value);
                  setShowDropdown(true);
                }}
                onFocus={() => setShowDropdown(true)}
                className="h-10 rounded-xl border-slate-200 focus-visible:ring-emerald-500 pr-10"
              />
              <div className="absolute right-3 top-1/2 -translate-y-1/2 text-slate-300">
                <Search className="w-4 h-4" />
              </div>
            </div>

            {showDropdown && searchTerm && (
              <div className="absolute z-50 w-full mt-1 bg-white border border-slate-100 shadow-2xl rounded-xl max-h-60 overflow-y-auto animate-in fade-in zoom-in-95 duration-200">
                {isFetchingBanks ? (
                  <div className="p-4 space-y-2">
                    <Skeleton className="h-8 w-full" />
                    <Skeleton className="h-8 w-full" />
                  </div>
                ) : filteredBanks.length > 0 ? (
                  filteredBanks.map((bank) => (
                    <div 
                      key={bank.id} 
                      onClick={() => handleSelectBank(bank)}
                      className="flex items-center gap-3 p-3 hover:bg-emerald-50 cursor-pointer transition-colors border-b border-slate-50 last:border-none"
                    >
                      <img src={bank.logo} alt={bank.shortName} className="w-10 h-5 object-contain" />
                      <div className="flex flex-col">
                        <span className="font-bold text-xs text-slate-800">{bank.shortName}</span>
                        <span className="text-[9px] text-slate-400 truncate max-w-[250px]">{bank.name}</span>
                      </div>
                    </div>
                  ))
                ) : (
                  <div className="p-4 text-center text-xs text-slate-400 italic">Không tìm thấy ngân hàng nào</div>
                )}
              </div>
            )}
            
            {/* Hidden field for form registration */}
            <input type="hidden" {...register("bankName")} />
            {errors.bankName && <p className="text-[10px] text-red-500 font-medium">{errors.bankName.message}</p>}
          </div>
          
          <div className="space-y-2">
            <Label htmlFor="bankAccount" className="text-[10px] font-bold text-slate-400 uppercase tracking-widest">Số tài khoản</Label>
            <Input 
              id="bankAccount" 
              {...register("bankAccount")} 
              placeholder="Nhập số tài khoản" 
              className="h-10 rounded-xl border-slate-200 focus-visible:ring-emerald-500"
            />
            {errors.bankAccount && <p className="text-[10px] text-red-500 font-medium">{errors.bankAccount.message}</p>}
          </div>
          
          <div className="space-y-2">
            <Label htmlFor="bankAccountName" className="text-[10px] font-bold text-slate-400 uppercase tracking-widest">Tên chủ tài khoản</Label>
            <Input 
              id="bankAccountName" 
              {...register("bankAccountName")} 
              placeholder="VD: NGUYEN VAN A" 
              className="h-10 rounded-xl border-slate-200 focus-visible:ring-emerald-500 font-bold uppercase"
            />
            {errors.bankAccountName && <p className="text-[10px] text-red-500 font-medium">{errors.bankAccountName.message}</p>}
          </div>

          <DialogFooter className="pt-4 flex gap-2">
            <Button type="button" variant="ghost" onClick={onClose} className="flex-1 font-bold rounded-xl h-10 text-sm">Hủy</Button>
            <Button type="submit" disabled={isLoading} className="flex-[2] bg-emerald-600 hover:bg-emerald-500 font-bold rounded-xl h-10 text-sm shadow-md">
              {isLoading ? "Đang xử lý..." : "Xác nhận liên kết"}
            </Button>
          </DialogFooter>
        </form>
      </DialogContent>
    </Dialog>
  );
};
