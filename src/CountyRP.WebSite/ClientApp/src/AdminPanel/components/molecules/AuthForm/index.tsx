import React, { useState } from 'react';
import { observer } from 'mobx-react';
import { useHistory } from 'react-router-dom';
import Input from 'AdminPanel/components/atoms/Input';
import FormContainer from './_FormContainer';
import Header from 'AdminPanel/components/atoms/Header1';
import Button from 'AdminPanel/components/atoms/BlueButton';
import { useStore } from 'AdminPanel/stores';
import { routes } from 'AdminPanel/routes';
import { handlerFetchError } from 'AdminPanel/utils/handlerFactory';


const AuthForm = observer(() => {
  const { playerInfoStore } = useStore();
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const history = useHistory();

  const handleLogin = async (event: React.FormEvent) => {
    event.preventDefault();

    try {
      await playerInfoStore.authorize(userName, password);

      if (playerInfoStore.isAuthorized)
        history.push(routes.root);
    } catch (error) {
      handlerFetchError(error);
    }
  }

  return (
    <FormContainer onSubmit={handleLogin}>
      <Header>Добро пожаловать!</Header>
      <Input value={userName} setValue={setUserName} />
      <Input type="password" value={password} setValue={setPassword} />
      <Button as={'input'} type='submit' value='Войти'/>
    </FormContainer >
  );
})


export default AuthForm;