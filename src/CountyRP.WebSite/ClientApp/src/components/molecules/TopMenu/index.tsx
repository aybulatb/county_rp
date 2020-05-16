import React, { useEffect } from 'react';
import { NavLink } from 'react-router-dom';
import { observer, inject } from 'mobx-react';

import Container from './_Container';
import Logo from './_Logo';
import TextRow from './_TextRow';

import { MiniPlayerInfoStore } from 'store/MiniPlayerInfoStore';


type TopMenuProps = {
  miniPlayerInfoStore?: MiniPlayerInfoStore
}

const TopMenu = (props: TopMenuProps) => {
  const renderLoadingAuth = () => {
    return (
      props.miniPlayerInfoStore?.isLoading ?
        <TextRow>loading...</TextRow>
        :
        renderMiniProfile()
    )
  }

  const renderMiniProfile = () => {
    return ((!props?.miniPlayerInfoStore?.isAuthorized) ?
      <TextRow as={NavLink} to="/Auth">Войти</TextRow>
      :
      <>
        <TextRow>{props.miniPlayerInfoStore.profile.login}</TextRow>
        <Logo>{props.miniPlayerInfoStore.profile.login[0].toUpperCase()}</Logo>
        <TextRow as={'button'} onClick={() => props.miniPlayerInfoStore?.logOut()}>
          Выйти
        </TextRow>
      </>
    );
  }

  const getMiniProfile = props.miniPlayerInfoStore?.getMiniProfile;

  useEffect(() => {
    getMiniProfile && getMiniProfile();
  }, [getMiniProfile]);


  return (
    <Container>
      <>{renderLoadingAuth()}</>
    </Container>
  );
}

export default inject('miniPlayerInfoStore')(observer(TopMenu));