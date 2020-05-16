import React from 'react';
import styled from 'styled-components';
import { NavLink } from 'react-router-dom';

import Row from './_Row';


const Header = styled(NavLink)`
  display: block;

  width: 100%;
  height: 58px;

  padding-top: 30px;

  font-weight: bold;
  font-size: 24px;
  line-height: 18px;
  text-decoration: none;
  text-align: center;

  color: #FFFFFF;
`;

const RowsContainer = styled.div`
  width: 100%;
`;

const PanelContainer = styled.div`
  width: 350px;
  height: 100vh;

  background: linear-gradient(180deg, #2A3799 0%, #298ACF 100%);
`


const SidePanel = () => (
  <PanelContainer>
    <Header to='/'>ADMIN PANEL</Header>

    <RowsContainer>
      <Row to='/' exact>Главная</Row>
      <Row to='/players' exact>Игроки</Row>
      <Row to='/forum' exact>Форум</Row>
    </RowsContainer>
  </PanelContainer>
)

export default SidePanel;