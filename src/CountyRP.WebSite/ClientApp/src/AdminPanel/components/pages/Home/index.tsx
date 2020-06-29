import React from "react";
import styled from "styled-components";

import Base from 'AdminPanel/components/templates/Base';
import Tile from 'AdminPanel/components/molecules/Tile';

import { routes } from 'AdminPanel/routes';


const TilesGrid = styled.div`
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;

  padding: 25px;
`;


const Home = () => (
  <Base>
    <TilesGrid>
      <Tile name='Игроки' description='Описание' to={routes.players} />
      <Tile name='Группы' description='Описание' to={routes.group} />
      <Tile name='Форум' description='Описание' to={routes.forum} />
    </TilesGrid>
  </Base>
)

export default Home;