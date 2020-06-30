import React, { useState, useEffect } from 'react';
import { useHistory, NavLink, useParams } from 'react-router-dom';
import styled from 'styled-components';

import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import EditPage from 'AdminPanel/components/templates/Edit';
import Checkbox from 'AdminPanel/components/molecules/Checkbox';

import { editAdminLevel } from 'AdminPanel/services/adminLevel/editAdminLevel';
import { getAdminLevel } from 'AdminPanel/services/adminLevel/getAdminLevel';

import { routes } from 'AdminPanel/routes';

import { AdminLevel } from 'AdminPanel/services/adminLevel/AdminLevel';


const BlueButtonWithMargin = styled(BlueButton)`
  margin-left: 10px;
`;


export default () => {
  const { id } = useParams<{ id: string }>();

  const [adminLevelId, setAdminLevelId] = useState('');
  const [adminLevelName, setAdminLevelName] = useState('');
  const [ban, setBan] = useState(false);

  const history = useHistory();
  const prevLocation = routes.adminLevel;

  const editHandler = async () => {
    try {
      const newFaction: AdminLevel = {
        id: adminLevelId,
        name: adminLevelName,
        ban
      }

      const fetchResult = await editAdminLevel(id, newFaction);

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
        const level = await getAdminLevel(id);

        setAdminLevelName(level.id);
        setAdminLevelName(level.name);
        setBan(level.ban);

      } catch (error) {
        console.log(error);
      }
    })();
  }, [id])


  return (
    <EditPage
      pageName='Редактировать'
      inputRows={[
        {
          name: 'ID',
          innerElement: <Input value={adminLevelId} setValue={setAdminLevelId} />
        },
        {
          name: 'Название',
          innerElement: <Input value={adminLevelName} setValue={setAdminLevelName} />
        },
        {
          name: 'Бан',
          innerElement: <Checkbox checked={ban} id='rights' handleCheck={() => setBan(!ban)} />
        },
      ]}
      buttons={
        <>
          <BlueButton as={NavLink} to={prevLocation}>
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