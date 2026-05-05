import { create } from 'zustand';

interface OwnerRegistrationStore {
  isDialogOpen: boolean;
  setDialogOpen: (open: boolean) => void;
}

export const useOwnerRegistrationStore = create<OwnerRegistrationStore>()(
  (set) => ({
    isDialogOpen: false,
    setDialogOpen: (open) => set({ isDialogOpen: open }),
  })
);
