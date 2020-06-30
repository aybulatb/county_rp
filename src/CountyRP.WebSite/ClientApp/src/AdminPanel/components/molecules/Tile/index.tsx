import React from 'react';
import { NavLink } from 'react-router-dom';
import styled from 'styled-components';
import { colors } from 'AdminPanel/variables';


const TileContainer = styled.div`
  display: flex;
  flex-direction: column;
  
  width: 435px;
  height: 221px;

  padding: 20px;
  margin-left: 25px;
  margin-top: 25px;
  border-radius: 18px;

  color: ${colors.blue};
  background: white;
  font-weight: bold;

  animation: slide-right 0.4s ease;
`;

const TileHeader = styled.h3`
  margin-bottom: 10px;
`;

const TileDescription = styled.span`

`;

const TileButton = styled(NavLink)`
  margin-top: auto;
  margin-left: auto;
  text-decoration: none;
  color: ${colors.blue};
`;


type TileProps = {
  name: string
  description: string
  to: string
}

export default ({name, description, to}: TileProps) => (
  <TileContainer>
    <TileHeader>{name}</TileHeader>
    <TileDescription>{description}</TileDescription>
    <TileButton to={to}>Далее</TileButton>
  </TileContainer>
)