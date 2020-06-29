import React, { useState, useEffect } from 'react';
import { useHistory, NavLink, useParams } from 'react-router-dom';
import styled from 'styled-components';

import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import EditPage from 'AdminPanel/components/templates/Edit';

import { getPlayer } from 'AdminPanel/services/player/getPlayer';
import { editPlayer } from 'AdminPanel/services/player/editPlayer';
import { getGroupsFilterBy } from 'AdminPanel/services/group/getGroupsFilterBy';

import { routes } from 'AdminPanel/routes';

import { Group } from 'AdminPanel/services/group/Group';


const BlueButtonWithMargin = styled(BlueButton)`
  margin-left: 10px;
`;


export default () => {
  const { id } = useParams<{ id: string }>();
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [groups, setGroups] = useState([] as Group[]);
  const [groupId, setGroupId] = useState('');
  const history = useHistory();
  const prevLocation = routes.players;

  const editHandler = async () => {
    try {
      const fetchResult = await editPlayer(id, username, password, groupId);

      if (fetchResult === 0) {
        history.push(prevLocation)
      }
    } catch (error) {
      console.dir(error);
    }
  }

  const fetchGroups = async () => {
    try {
      const fetchResult = await getGroupsFilterBy();

      if (fetchResult.items.length !== 0) {
        setGroups(fetchResult.items);
        setGroupId(fetchResult.items[0].id);
      }
    } catch (error) {
      console.dir(error);
    }
  }

  useEffect(() => {
    fetchGroups();

    (async () => {
      try {
        const fetchResult = await getPlayer(id);

        setUsername(fetchResult.login);
        setPassword(fetchResult.password);
        setGroupId(fetchResult.groupId);
      } catch (error) {
        console.log(error);
      }
    })();
  }, [id]);


  return (
    <EditPage
      pageName='Создать'
      inputRows={[
        {
          name: 'Логин  ',
          innerElement: <Input value={username} setValue={setUsername} />
        },
        {
          name: 'Пароль',
          innerElement: <Input value={password} setValue={setPassword} />
        },
        {
          name: 'Группа',
          innerElement: <select onBlur={(event) => {setGroupId(event.target.value)}}>
            {
              groups.map((group, key) => <option key={key} value={group.id}>{group.name}</option>)
            }
          </select>
          
        },
      ]}
      buttons={
        <>
          <BlueButton as={NavLink} to={routes.players}>
            Отмена
          </BlueButton>

          <BlueButtonWithMargin onClick={editHandler}>
            Сохранить
          </BlueButtonWithMargin>
        </>
      }
    />
  )
}