import React from 'react'
import { createPlayerInfoStore, TPlayerInfoStore } from './_MiniPlayerInfoStore';
import { createProfileStore, TProfileStore } from './_ProfileStore';
import { createGroupsSearchStore, TGroupsSearchStore } from './_GroupsSearchStore';
import { useLocalStore } from 'mobx-react';


const storeContext = React.createContext<{
  profileStore: TProfileStore,
  playerInfoStore: TPlayerInfoStore,
  groupsSearchStore: TGroupsSearchStore
} | null>(null);

export const StoreProvider = ({ children }: { children: React.ReactNode }) => {
  const playerInfoStore = useLocalStore(createPlayerInfoStore);
  const profileStore = useLocalStore(createProfileStore);
  const groupsSearchStore = useLocalStore(createGroupsSearchStore);

  return (
    <storeContext.Provider value={{
      playerInfoStore,
      profileStore,
      groupsSearchStore
    }}>
      {children}
    </storeContext.Provider>
  )
}

export const useStore = () => {
  const store = React.useContext(storeContext)
  if (!store) {
    throw new Error('useStore must be used within a StoreProvider.')
  }
  return store
}