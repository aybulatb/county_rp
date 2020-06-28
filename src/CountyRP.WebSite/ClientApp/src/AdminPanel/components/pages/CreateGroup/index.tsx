import React, { useState } from 'react';
import { useHistory, NavLink } from 'react-router-dom';
import styled from 'styled-components';

import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import ColorPalette from 'AdminPanel/components/molecules/ColorPalette';
import Checkbox from 'AdminPanel/components/molecules/Checkbox';
import EditPage from 'AdminPanel/components/templates/Edit';

import { createGroup } from 'AdminPanel/services/group/createGroup';


const BlueButtonWithMargin = styled(BlueButton)`
  margin-left: 10px;
`;


export default () => {
  const [groupId, setGroupId] = useState('');
  const [groupName, setGroupName] = useState('');
  const [color, setColor] = useState('');
  const [rights, setRights] = useState(false);
  const history = useHistory();
  const prevLocation = '/admin/group';

  const createHandler = async () => {
    try {
      const fetchResult = await createGroup(groupId, groupName, color);

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
          <BlueButtonWithMargin onClick={createHandler}>
              Создать
          </BlueButtonWithMargin>
        </>
      }
    />
  )
}