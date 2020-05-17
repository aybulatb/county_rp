import React, { useEffect } from 'react';
import { NavLink } from 'react-router-dom';
import 'mobx-react-lite/batchingForReactDom';
import { observer, inject } from 'mobx-react';

import Container from './_Container';
import Logo from './_Logo';
import TextRow from './_TextRow';

import { IMiniPlayerInfoStore } from 'stores/MiniPlayerInfoStore';


type TopMenuProps = {
  miniPlayerInfoStore?: IMiniPlayerInfoStore
}

const TopMenu = ({ miniPlayerInfoStore }: TopMenuProps) => {
  const login = miniPlayerInfoStore?.profile.login || 'Null';

  const renderLoadingAuth = () => {
    return (
      miniPlayerInfoStore?.isLoading ?
        <TextRow>loading...</TextRow>
        :
        renderMiniProfile()
    )
  }

  const renderMiniProfile = () => {
    return ((!miniPlayerInfoStore?.isAuthorized) ?
      <TextRow as={NavLink} to="/Auth">Войти</TextRow>
      :
      <>
        <TextRow>{miniPlayerInfoStore.profile.login}</TextRow>
        <Logo>{login[0].toUpperCase()}</Logo>
        <TextRow as={'button'} onClick={() => miniPlayerInfoStore?.logOut()}>
          Выйти
        </TextRow>
      </>
    );
  }

  useEffect(() => {
    miniPlayerInfoStore?.getMiniProfile()
  }, [miniPlayerInfoStore]);


  return (
    <Container>
      <>{renderLoadingAuth()}</>
    </Container>
  );
}

export default inject('miniPlayerInfoStore')(observer(TopMenu));