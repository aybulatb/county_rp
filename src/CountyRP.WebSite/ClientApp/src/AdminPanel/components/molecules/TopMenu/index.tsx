import React from 'react';
import styled from 'styled-components';
import { observer } from 'mobx-react';
import { NavLink, matchPath, useLocation } from 'react-router-dom';
import Container from './_Container';
import Avatar from 'AdminPanel/components/atoms/Avatar';
import TextRow from './_TextRow';
import { useStore } from 'AdminPanel/stores';
import { locations } from 'AdminPanel/locations';


const LocationTag = styled(TextRow)`
  margin-right: auto;
  margin-left: 50px;
`;


const TopMenu = observer(() => {
  const { playerInfoStore } = useStore();
  const currentLocation = useLocation().pathname;
  const login = playerInfoStore.profile.login || 'Null';

// Вынеси в отдельную компоненту
  const getLocationTagText = () => {
    let tagText = '';

    locations.forEach(location => {
      const match = matchPath(currentLocation, {
        path: location.route,
      });

      if (match)
        tagText = location.name
    })

    return tagText;
  }

  const renderLoadingAuth = () => {
    return (
      playerInfoStore.isLoading ?
        <TextRow>loading...</TextRow>
        :
        renderMiniProfile()
    )
  }

// Вынеси в отдельную компоненты и убери нахуй конпку "Войти"
  const renderMiniProfile = () => {
    return ((!playerInfoStore.isAuthorized) ?
      <TextRow as={NavLink} to="/admin/Auth">Войти</TextRow>
      :
      <>
        <TextRow as={NavLink} to={`/admin/profile/${login}`}>{playerInfoStore.profile.login}</TextRow>
        <Avatar>{login}</Avatar>
        <TextRow as={NavLink} to='/admin' onClick={() => playerInfoStore.logOut()}>
          Выйти
        </TextRow>
      </>
    );
  }
  
  return (
    <Container>
      <LocationTag>{getLocationTagText()}</LocationTag>
      <>{renderLoadingAuth()}</>
    </Container>
  );
})

export default TopMenu;
