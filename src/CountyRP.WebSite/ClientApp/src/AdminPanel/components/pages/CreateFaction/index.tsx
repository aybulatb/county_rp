import React, { useState } from 'react';
import { useHistory, NavLink } from 'react-router-dom';
import styled from 'styled-components';

import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import EditPage from 'AdminPanel/components/templates/Edit';
import ColorPalette from 'AdminPanel/components/molecules/ColorPalette';

import { createFaction } from 'AdminPanel/services/faction/createFaction';

import { routes } from 'AdminPanel/routes';

import { Faction } from 'AdminPanel/services/faction/Faction';


const BlueButtonWithMargin = styled(BlueButton)`
  margin-left: 10px;
`;


export default () => {
  const [factionId, setFactionId] = useState('');
  const [factionName, setFactionName] = useState('');
  const [factionRanks, setFactionRanks] = useState<string>('');
  const [factionColor, setFactionColor] = useState('');
  const [factionType, setFactionType] = useState(0);;

  const history = useHistory();
  const prevLocation = routes.faction;

  const createHandler = async () => {
    try {
      const newFaction: Faction = {
        id: factionId,
        name: factionName,
        color: factionColor,
        ranks: factionRanks.split(','),
        type: factionType
      }

      const fetchResult = await createFaction(newFaction);

      if (fetchResult === 0) {
        history.push(prevLocation)
      }

    } catch (error) {
      console.dir(error);
    }
  }


  return (
    <EditPage
      pageName='Создать'
      inputRows={[
        {
          name: 'ID',
          innerElement: <Input value={factionId} setValue={setFactionId} />
        },
        {
          name: 'Название',
          innerElement: <Input value={factionName} setValue={setFactionName} />
        },
        {
          name: 'Ранги',
          innerElement: <Input value={factionRanks} setValue={setFactionRanks} />
        },
        {
          name: 'Тип',
          innerElement: <Input value={factionType} setValue={setFactionType} />
        },
        {
          name: 'Цвет',
          innerElement: <>
            <Input value={factionColor} setValue={setFactionColor} />
            <ColorPalette setColor={setFactionColor} />
          </>
        }
      ]}
      buttons={
        <>
          <BlueButton as={NavLink} to={prevLocation}>
              Отмена
          </BlueButton>
          <BlueButtonWithMargin onClick={createHandler}>
              Создать
          </BlueButtonWithMargin>
        </>
      }
    />
  )
}