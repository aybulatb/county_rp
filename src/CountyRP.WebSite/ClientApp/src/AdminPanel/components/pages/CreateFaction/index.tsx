import React, { useState } from 'react';
import { useHistory, NavLink } from 'react-router-dom';
import styled from 'styled-components';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import EditPage from 'AdminPanel/components/templates/Edit';
import ColorPalette from 'AdminPanel/components/molecules/ColorPalette';
import { createFaction } from 'AdminPanel/services';
import { routes } from 'AdminPanel/routes';
import { handlerFactory } from 'AdminPanel/utils/handlerFactory';


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

  const handleCreate = handlerFactory(
    () => createFaction({
      id: factionId,
      name: factionName,
      color: factionColor,
      ranks: factionRanks.split(','),
      type: factionType
    }),
    () => history.push(prevLocation)
  );

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
          <BlueButtonWithMargin onClick={handleCreate}>
              Создать
          </BlueButtonWithMargin>
        </>
      }
    />
  )
}