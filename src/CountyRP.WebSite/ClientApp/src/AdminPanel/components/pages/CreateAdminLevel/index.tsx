import React, { useState } from 'react';
import { useHistory, NavLink } from 'react-router-dom';
import styled from 'styled-components';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import EditPage from 'AdminPanel/components/templates/Edit';
import Checkbox from 'AdminPanel/components/molecules/Checkbox';
import { createAdminLevel } from 'AdminPanel/services';
import { routes } from 'AdminPanel/routes';
import { handlerFactory } from 'AdminPanel/utils/handlerFactory';


const BlueButtonWithMargin = styled(BlueButton)`
  margin-left: 10px;
`;

export default () => {
  const [adminLevelId, setAdminLevelId] = useState('');
  const [adminLevelName, setAdminLevel] = useState('');
  const [ban, setBan] = useState(false);

  const history = useHistory();
  const prevLocation = routes.adminLevel;

  const handleCreate = handlerFactory(
    () => createAdminLevel({
      id: adminLevelId,
      name: adminLevelName,
      ban
    }),
    () => {history.push(prevLocation)}
  );


  return (
    <EditPage
      pageName='Создать'
      inputRows={[
        {
          name: 'ID',
          innerElement: <Input value={adminLevelId} setValue={setAdminLevelId} />
        },
        {
          name: 'Название',
          innerElement: <Input value={adminLevelName} setValue={setAdminLevel} />
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
          <BlueButtonWithMargin onClick={handleCreate}>
              Создать
          </BlueButtonWithMargin>
        </>
      }
    />
  )
}