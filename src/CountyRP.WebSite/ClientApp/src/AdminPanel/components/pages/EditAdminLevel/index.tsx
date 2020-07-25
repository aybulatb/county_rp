import React, { useState, useEffect } from 'react';
import { useHistory, NavLink, useParams } from 'react-router-dom';
import styled from 'styled-components';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import EditPage from 'AdminPanel/components/templates/Edit';
import Checkbox from 'AdminPanel/components/molecules/Checkbox';
import { editAdminLevel } from 'AdminPanel/services';
import { getAdminLevel } from 'AdminPanel/services';
import { routes } from 'AdminPanel/routes';
import { handlerFactory, handlerFetchError } from 'AdminPanel/utils/handlerFactory';


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

  const handleEdit = handlerFactory(
    () => editAdminLevel(id, {
      id: adminLevelId,
      name: adminLevelName,
      ban
    }),
    () => history.push(prevLocation)
  );

  useEffect(() => {
    (async () => { 
      try {
        const level = await getAdminLevel(id);

        setAdminLevelName(level.id);
        setAdminLevelName(level.name);
        setBan(level.ban);

      } catch (error) {
        console.log(error);
        handlerFetchError(error);
        history.push(prevLocation)
      }
    })();
  }, [history, id, prevLocation])

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
          <BlueButtonWithMargin onClick={handleEdit}>
              Сохранить
          </BlueButtonWithMargin>
        </>
      }
    />
  )
}