import { useState } from "react";
import { 
  Dialog, 
  DialogContent, 
  DialogHeader, 
  DialogTitle, 
  DialogTrigger 
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { Layers, Plus, Loader2, Trash2 } from "lucide-react";
import { useOwnerSubCourts, useCreateSubCourt } from "../hooks/useOwnerSubCourts";
import { 
  Table, 
  TableBody, 
  TableCell, 
  TableHead, 
  TableHeader, 
  TableRow 
} from "@/shared/components/ui/table";

interface SubCourtManagementProps {
  courtId: string;
  courtName: string;
}

export function SubCourtManagement({ courtId, courtName }: SubCourtManagementProps) {
  const [isOpen, setIsOpen] = useState(false);
  const [newSubCourtName, setNewSubCourtName] = useState("");
  const [defaultPrice, setDefaultPrice] = useState<number>(0);

  const { data, isLoading } = useOwnerSubCourts({
    courtId,
    pageIndex: 1,
    pageSize: 100,
  });

  const createSubCourt = useCreateSubCourt();

  const handleCreate = async () => {
    if (!newSubCourtName.trim() || defaultPrice <= 0) return;

    await createSubCourt.mutateAsync({
      courtId,
      name: newSubCourtName,
      defaultPrice,
    });

    setNewSubCourtName("");
    setDefaultPrice(0);
  };

  return (
    <Dialog open={isOpen} onOpenChange={setIsOpen}>
      <DialogTrigger asChild>
        <Button 
          variant="outline" 
          size="sm"
          className="rounded-xl border-emerald-200 text-emerald-700 hover:bg-emerald-50 hover:text-emerald-800 font-bold px-4"
          onClick={(e) => e.stopPropagation()}
        >
          <Plus size={16} className="mr-1.5" />
          Tạo sân con
        </Button>
      </DialogTrigger>
      <DialogContent className="sm:max-w-[700px] p-0 overflow-hidden flex flex-col max-h-[90vh] rounded-2xl border-none shadow-2xl bg-white">
        <div className="bg-[#004E43] p-6 text-white flex-shrink-0">
          <DialogHeader>
            <DialogTitle className="text-2xl font-black flex items-center gap-3">
              <Layers className="text-emerald-400" />
              Quản lý sân con: {courtName}
            </DialogTitle>
            <p className="text-emerald-100/70 text-sm font-medium mt-1">
              Thêm và quản lý các sân con thuộc cơ sở này
            </p>
          </DialogHeader>
        </div>

        <div className="flex-1 overflow-y-auto p-6 custom-scrollbar">
          {/* Create Form */}
          <div className="bg-emerald-50/50 p-5 rounded-2xl border border-emerald-100 mb-8">
            <h3 className="text-sm font-black text-emerald-900 mb-4 flex items-center gap-2">
              <Plus size={16} />
              Thêm sân con mới
            </h3>
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4 items-end">
              <div className="space-y-2">
                <Label htmlFor="subCourtName" className="text-xs font-bold text-gray-700">Tên sân con (VD: Sân 1)</Label>
                <Input 
                  id="subCourtName"
                  placeholder="Nhập tên sân con..."
                  value={newSubCourtName}
                  onChange={(e) => setNewSubCourtName(e.target.value)}
                  className="rounded-xl border-emerald-100 focus:ring-emerald-500"
                />
              </div>
              <div className="space-y-2">
                <Label htmlFor="defaultPrice" className="text-xs font-bold text-gray-700">Giá mặc định (VNĐ/giờ)</Label>
                <Input 
                  id="defaultPrice"
                  type="number"
                  placeholder="Nhập giá..."
                  value={defaultPrice || ""}
                  onChange={(e) => setDefaultPrice(Number(e.target.value))}
                  className="rounded-xl border-emerald-100 focus:ring-emerald-500"
                />
              </div>
              <div className="md:col-span-2">
                <Button 
                  onClick={handleCreate} 
                  disabled={createSubCourt.isPending || !newSubCourtName.trim() || defaultPrice <= 0}
                  className="w-full bg-emerald-600 hover:bg-emerald-700 text-white rounded-xl font-bold h-11 shadow-sm"
                >
                  {createSubCourt.isPending ? (
                    <Loader2 className="animate-spin mr-2" size={18} />
                  ) : (
                    <Plus className="mr-2" size={18} />
                  )}
                  Tạo sân con
                </Button>
              </div>
            </div>
          </div>

          {/* List Section */}
          <div className="space-y-4">
            <h3 className="text-sm font-black text-gray-900 flex items-center gap-2">
              Danh sách sân con
            </h3>

            <div className="border rounded-2xl overflow-hidden border-gray-100 shadow-sm bg-white">
              {isLoading ? (
                <div className="py-12 flex flex-col items-center justify-center">
                  <Loader2 className="animate-spin text-emerald-600 mb-2" size={32} />
                  <p className="text-xs text-gray-500 font-medium">Đang tải danh sách...</p>
                </div>
              ) : data?.items && data.items.length > 0 ? (
                <Table>
                  <TableHeader className="bg-gray-50/50">
                    <TableRow>
                      <TableHead className="text-xs font-bold">Tên sân</TableHead>
                      <TableHead className="text-xs font-bold">ID Sân con</TableHead>
                      <TableHead className="text-right text-xs font-bold">Thao tác</TableHead>
                    </TableRow>
                  </TableHeader>
                  <TableBody>
                    {data.items.map((subCourt) => (
                      <TableRow key={subCourt.subCourtId} className="hover:bg-gray-50/30 transition-colors">
                        <TableCell className="font-bold text-gray-900">{subCourt.name}</TableCell>
                        <TableCell className="text-[10px] font-mono text-gray-400">{subCourt.subCourtId}</TableCell>
                        <TableCell className="text-right">
                          <Button variant="ghost" size="icon" className="h-8 w-8 rounded-full text-red-500 hover:bg-red-50 hover:text-red-600">
                            <Trash2 size={14} />
                          </Button>
                        </TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              ) : (
                <div className="py-12 text-center">
                  <p className="text-sm text-gray-400 font-medium italic">Chưa có sân con nào được tạo</p>
                </div>
              )}
            </div>
          </div>
        </div>
      </DialogContent>
    </Dialog>
  );
}
