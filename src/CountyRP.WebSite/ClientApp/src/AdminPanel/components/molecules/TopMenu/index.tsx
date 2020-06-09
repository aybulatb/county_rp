import React from 'react';
import { observer } from 'mobx-react';
import { NavLink } from 'react-router-dom';
import Container from './_Container';
import Logo from './_Logo';
import TextRow from './_TextRow';
import { useStore } from 'AdminPanel/stores';


const TopMenu = observer(() => {
  const { playerInfoStore } = useStore();

  const login = playerInfoStore.profile.login || 'Null';


  const renderLoadingAuth = () => {
    return (
      playerInfoStore.isLoading ?
        <TextRow>loading...</TextRow>
        :
        renderMiniProfile()
    )
  }

  const renderMiniProfile = () => {
    return ((!playerInfoStore.isAuthorized) ?
      <TextRow as={NavLink} to="/admin/Auth">Войти</TextRow>
      :
      <>
        <TextRow as={NavLink} to={`/admin/profile/${login}`}>{playerInfoStore.profile.login}</TextRow>
        <Logo>{login[0].toUpperCase()}</Logo>
        <TextRow as={NavLink} to='/admin' onClick={() => playerInfoStore.logOut()}>
          Выйти
        </TextRow>
      </>
    );
  }


  return (
    <Container>
      <>{renderLoadingAuth()}</>
    </Container>
  );
})

export default TopMenu;