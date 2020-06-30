import React from 'react'
import { createPlayerInfoStore, TPlayerInfoStore } from './MiniPlayerInfoStore';
import { createProfileStore, TProfileStore } from './ProfileStore';
import { useLocalStore } from 'mobx-react';


const storeContext = React.createContext<{ profileStore: TProfileStore, playerInfoStore: TPlayerInfoStore } | null>(null)

export const StoreProvider = ({ children }: { children: React.ReactNode }) => {
  const playerInfoStore = useLocalStore(createPlayerInfoStore);
  const profileStore = useLocalStore(createProfileStore);

  return (
    <storeContext.Provider value={{ playerInfoStore, profileStore }}>
      {children}
    </storeContext.Provider>
  )
}

export const useStore = () => {
  const store = React.useContext(storeContext)
  if (!store) {
    // this is especially useful in TypeScript so you don't need to be checking for null all the time
    throw new Error('useStore must be used within a StoreProvider.')
  }
  return store
}