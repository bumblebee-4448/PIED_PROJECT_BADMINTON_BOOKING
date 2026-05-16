import React from "react";
import { Bell, CheckCheck, Loader2, Info, AlertTriangle, CheckCircle, BellOff, ShieldAlert, Flag, X } from "lucide-react";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuTrigger,
} from "@/shared/components/ui/dropdown-menu";
import { Button } from "@/shared/components/ui/button";
import { Badge } from "@/shared/components/ui/badge";
import { useNotifications, useUnreadCount, useNotificationActions } from "../hooks/useNotifications";
import { formatDistanceToNow } from "date-fns";
import { vi } from "date-fns/locale";
import { cn } from "@/lib/utils";

export const NotificationBell: React.FC = () => {
  const { data: notifications, isLoading: isListLoading } = useNotifications();
  const { data: unreadCount = 0 } = useUnreadCount();
  const { 
    readNotification, 
    markAllRead, 
    deleteNotification, 
    deleteAllRead 
  } = useNotificationActions();

  const sortedNotifications = React.useMemo(() => {
    if (!notifications?.items) return [];
    return [...notifications.items].sort((a, b) => {
      if (a.isRead === b.isRead) {
        return new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime();
      }
      return a.isRead ? 1 : -1;
    });
  }, [notifications?.items]);

  const getTypeStyles = (type: string, isRead: boolean) => {
    const t = type?.toLowerCase();
    
    // Important / Emergency / High Priority -> Red
    if (t === "important" || t === "error" || t === "emergency") return {
      icon: <ShieldAlert className="w-4 h-4 text-rose-600" />,
      bg: isRead ? "bg-rose-50/20" : "bg-rose-50",
      iconBg: "bg-rose-100",
      dot: "bg-rose-500",
      textColor: "text-rose-900",
      descColor: "text-rose-700/70"
    };

    // Report / Feedback / Issue -> Yellow
    if (t === "report" || t === "warning" || t === "issue") return {
      icon: <Flag className="w-4 h-4 text-amber-600" />,
      bg: isRead ? "bg-amber-50/20" : "bg-amber-50",
      iconBg: "bg-amber-100",
      dot: "bg-amber-500",
      textColor: "text-amber-900",
      descColor: "text-amber-700/70"
    };

    // Success / Finished / OK -> Green (User called it 'Normal')
    if (t === "success" || t === "normal" || t === "finished") return {
      icon: <CheckCircle className="w-4 h-4 text-emerald-600" />,
      bg: isRead ? "bg-emerald-50/20" : "bg-emerald-50",
      iconBg: "bg-emerald-100",
      dot: "bg-emerald-500",
      textColor: "text-emerald-900",
      descColor: "text-emerald-700/70"
    };

    // Default / Info -> Blue
    return {
      icon: <Info className="w-4 h-4 text-blue-600" />,
      bg: isRead ? "bg-blue-50/20" : "bg-blue-50",
      iconBg: "bg-blue-100",
      dot: "bg-blue-500",
      textColor: "text-blue-900",
      descColor: "text-blue-700/70"
    };
  };

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button
          variant="ghost"
          size="icon"
          className="relative rounded-2xl text-gray-400 hover:bg-gray-100 h-11 w-11 transition-all"
        >
          <Bell size={20} className={cn(unreadCount > 0 && "animate-tada")} />
          {unreadCount > 0 && (
            <Badge 
              className="absolute top-2 right-2 min-w-[18px] h-[18px] p-0 flex items-center justify-center bg-red-500 border-2 border-white text-[10px] font-bold text-white hover:bg-red-600"
            >
              {unreadCount > 99 ? "99+" : unreadCount}
            </Badge>
          )}
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent 
        align="end" 
        sideOffset={8}
        className="w-[420px] p-0 rounded-2xl overflow-hidden border-gray-100 shadow-2xl z-[100]"
      >
        <div className="bg-white p-4 border-b border-gray-100 space-y-3">
          <div className="flex items-center justify-between">
            <DropdownMenuLabel className="p-0 font-bold text-lg text-slate-800">
              Thông báo
            </DropdownMenuLabel>
            <div className="flex items-center gap-1">
              <Button
                variant="ghost"
                size="sm"
                onClick={() => markAllRead()}
                title="Đánh dấu tất cả đã đọc"
                className="h-8 w-8 p-0 text-emerald-600 hover:text-emerald-700 hover:bg-emerald-50 rounded-lg"
              >
                <CheckCheck className="w-4 h-4" />
              </Button>
              <Button
                variant="ghost"
                size="sm"
                title="Xóa tất cả đã đọc"
                onClick={(e) => {
                  e.stopPropagation();
                  deleteAllRead();
                }}
                className="h-8 w-8 p-0 text-rose-600 hover:text-rose-700 hover:bg-rose-50 rounded-lg"
              >
                <X className="w-4 h-4" />
              </Button>
            </div>
          </div>
        </div>

        <div className="max-h-[500px] overflow-y-auto custom-scrollbar">
          {isListLoading ? (
            <div className="py-12 flex flex-col items-center justify-center gap-3">
              <Loader2 className="w-8 h-8 animate-spin text-emerald-500 opacity-20" />
              <p className="text-xs text-slate-400 font-medium">Đang tải thông báo...</p>
            </div>
          ) : sortedNotifications.length > 0 ? (
            <div className="flex flex-col">
              {sortedNotifications.map((item) => {
                const styles = getTypeStyles(item.type, item.isRead);
                return (
                  <DropdownMenuItem
                    key={item.id}
                    onClick={() => !item.isRead && readNotification(item.id)}
                    className={cn(
                      "group flex flex-col items-start gap-1 p-4 cursor-pointer transition-all border-b border-gray-50 last:border-0 focus:bg-slate-50 outline-none relative",
                      styles.bg
                    )}
                  >
                    <div className="flex w-full gap-3">
                      <div className={cn(
                        "mt-0.5 p-2.5 rounded-xl shrink-0 flex items-center justify-center h-10 w-10 transition-transform group-hover:scale-110",
                        styles.iconBg
                      )}>
                        {styles.icon}
                      </div>
                      <div className="flex-1 space-y-1 pr-6">
                        <div className="flex items-center justify-between gap-2">
                          <p className={cn(
                            "text-sm tracking-tight",
                            !item.isRead ? cn("font-bold", styles.textColor) : "font-medium text-slate-500"
                          )}>
                            {item.title}
                          </p>
                          {!item.isRead && (
                            <div className={cn("w-2 h-2 rounded-full", styles.dot)} />
                          )}
                        </div>
                        <p className={cn(
                          "text-xs leading-relaxed line-clamp-2",
                          !item.isRead ? styles.descColor : "text-slate-400"
                        )}>
                          {item.content}
                        </p>
                        <p className="text-[10px] font-medium text-slate-400 mt-2 flex items-center gap-2">
                          <span className="w-1 h-1 rounded-full bg-slate-300" />
                          {formatDistanceToNow(new Date(item.createdAt), { addSuffix: true, locale: vi })}
                        </p>
                      </div>

                      {/* Delete button (UI only for now as backend lacks endpoint) */}
                      <Button
                        variant="ghost"
                        size="icon"
                        className="absolute top-4 right-2 h-7 w-7 rounded-lg opacity-0 group-hover:opacity-100 hover:bg-rose-50 hover:text-rose-500 transition-all"
                        onClick={(e) => {
                          e.stopPropagation();
                          deleteNotification(item.id);
                        }}
                      >
                        <X className="w-3.5 h-3.5" />
                      </Button>
                    </div>
                  </DropdownMenuItem>
                );
              })}
            </div>
          ) : (
            <div className="py-16 flex flex-col items-center justify-center text-center px-8">
              <div className="w-16 h-16 bg-slate-50 rounded-full flex items-center justify-center mb-4">
                <BellOff className="w-8 h-8 text-slate-200" />
              </div>
              <p className="text-sm font-semibold text-slate-800 mb-1">Không có thông báo nào</p>
              <p className="text-xs text-slate-400">Chúng tôi sẽ cập nhật khi có tin mới dành cho bạn.</p>
            </div>
          )}
        </div>

        <div className="p-3 bg-white border-t border-gray-100">
          <Button 
            variant="ghost" 
            className="w-full text-xs font-semibold text-slate-500 hover:text-emerald-600 hover:bg-emerald-50 transition-all rounded-xl h-10"
          >
            Xem tất cả thông báo
          </Button>
        </div>
      </DropdownMenuContent>
    </DropdownMenu>
  );
};
