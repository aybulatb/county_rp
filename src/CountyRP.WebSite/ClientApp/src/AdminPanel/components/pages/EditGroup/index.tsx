import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import { useHistory, NavLink, useParams } from 'react-router-dom';

import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import WhiteButton from 'AdminPanel/components/atoms/WhiteButton';
import Input from 'AdminPanel/components/atoms/Input';
import ColorPalette from 'AdminPanel/components/molecules/ColorPalette';
import Checkbox from 'AdminPanel/components/molecules/Checkbox';
import EditPage from 'AdminPanel/components/templates/Edit';

import { editGroup } from 'AdminPanel/services/group/editGroup';
import { getGroup } from 'AdminPanel/services/group/getGroup';
import { deleteGroup } from 'AdminPanel/services/group/deleteGroup';

import { routes } from 'AdminPanel/routes';


const StyledBlueButton = styled(BlueButton)`
  margin-left: 10px;
`;

const StyledWhiteButton = styled(WhiteButton)`
  margin-left: 10px;
`;


export default () => {
  const { id: oldId } = useParams<{ id: string }>();
  const [groupId, setGroupId] = useState(oldId);
  const [groupName, setGroupName] = useState('');
  const [color, setColor] = useState('');
  const [rights, setRights] = useState(false);
  const history = useHistory();
  const prevLocation = routes.group;

  const editHandler = async () => {
    try {
      const fetchResult = await editGroup(oldId, groupId, groupName, color);

      if (fetchResult === 0) {
        history.push(prevLocation)
      }
    } catch (error) {
      console.dir(error);
    }
  }

  const deleteHandler = async () => {
    try {
      const fetchResult = await deleteGroup(oldId);

      if (fetchResult === 0) {
        history.push(prevLocation)
      }
    } catch (error) {
      console.dir(error);
    }
  }

  useEffect(() => {
    (async () => {
      try {
        const fetchResult = await getGroup(oldId);
  
        setGroupId(fetchResult.id);
        setGroupName(fetchResult.name);
        setColor('#'+fetchResult.color);
      } catch (error) {
        console.log(error);
      }
    })();
  }, [oldId]);

  return (
    <EditPage
      pageName='Редактировать'
      inputRows={[
        {
          name: 'ID',
          innerElement: <Input value={groupId} setValue={setGroupId} />
        },
        {
          name: 'Имя Группы',
          innerElement: <Input value={groupName} setValue={setGroupName} />
        },
        {
          name: 'Цвет',
          innerElement: <>
            <Input value={color} setValue={setColor} />
            <ColorPalette setColor={setColor} />
          </>
        },
        {
          name: 'Права На АдминПанель',
          innerElement: <Checkbox checked={rights} id='rights' handleCheck={() => setRights(!rights)} />
        },
      ]}
      buttons={
        <>
          <BlueButton as={NavLink} to='/admin/group'>
            Отмена
          </BlueButton>

          <StyledWhiteButton onClick={deleteHandler}>
            Удалить
          </StyledWhiteButton>

          <StyledBlueButton onClick={editHandler}>
            Сохранить
          </StyledBlueButton>
        </>
      }
    />
  )
}