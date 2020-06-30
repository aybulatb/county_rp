import React from "react";
import styled from "styled-components";

import Base from 'AdminPanel/components/templates/Base';
import Tile from 'AdminPanel/components/molecules/Tile';
import { locations } from 'AdminPanel/locations';


const TilesGrid = styled.div`
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;

  padding: 25px;
`;


const Home = () => (
  <Base>
    <TilesGrid>
      {
        locations.map((location, key) => (
          <Tile
            key={key}
            name={location.name}
            description={location.description}
            to={location.route}
          />
        ))
      }
    </TilesGrid>
  </Base>
)

export default Home;