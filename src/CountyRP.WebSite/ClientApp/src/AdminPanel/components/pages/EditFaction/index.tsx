import React, { useState, useEffect } from 'react';
import { useHistory, NavLink, useParams } from 'react-router-dom';
import styled from 'styled-components';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import WhiteButton from 'AdminPanel/components/atoms/WhiteButton';
import Input from 'AdminPanel/components/atoms/Input';
import EditPage from 'AdminPanel/components/templates/Edit';
import ColorPalette from 'AdminPanel/components/molecules/ColorPalette';
import { getFaction } from 'AdminPanel/services';
import { editFaction } from 'AdminPanel/services';
import { deleteFaction } from 'AdminPanel/services';
import { routes } from 'AdminPanel/routes';
import { handlerFactory, handlerFetchError } from 'AdminPanel/utils/handlerFactory';


const BlueButtonWithMargin = styled(BlueButton)`
  margin-left: 10px;
`;

const StyledWhiteButton = styled(WhiteButton)`
  margin-left: 10px;
`;

export default () => {
  const { id } = useParams<{ id: string }>();

  const [factionId, setFactionId] = useState('');
  const [factionName, setFactionName] = useState('');
  const [factionRanks, setFactionRanks] = useState<string>('');
  const [factionColor, setFactionColor] = useState('');
  const [factionType, setFactionType] = useState(0);;

  const history = useHistory();
  const prevLocation = routes.faction;

  const handleEdit = handlerFactory(
    () => editFaction(id, {
      id: factionId,
      name: factionName,
      color: factionColor,
      ranks: factionRanks.split(','),
      type: factionType
    }),
    () => history.push(prevLocation)
  );

  const handleDelete = handlerFactory(
    () => deleteFaction(id),
    () => history.push(prevLocation)
  )

  useEffect(() => {
    (async () => {
      try {
        const faction = await getFaction(id);

        setFactionId(faction.id);
        setFactionName(faction.name);
        setFactionRanks(faction.ranks.join(','));
        setFactionColor('#' + (faction.color || 'ffffff'));

      } catch (error) {
        console.log(error);
        handlerFetchError(error);
        history.push(prevLocation);
      }
    })();
  }, [history, id, prevLocation]);

  return (
    <EditPage
      pageName='Редактировать'
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
            <Input value={factionColor} setValue={setFactionColor} color={factionColor} />
            <ColorPalette setColor={setFactionColor} />
          </>
        }
      ]}
      buttons={
        <>
          <BlueButton as={NavLink} to={prevLocation}>
            Отмена
          </BlueButton>

          <StyledWhiteButton onClick={handleDelete}>
            Удалить
          </StyledWhiteButton>
          
          <BlueButtonWithMargin onClick={handleEdit}>
            Сохранить
          </BlueButtonWithMargin>
        </>
      }
    />
  )
}