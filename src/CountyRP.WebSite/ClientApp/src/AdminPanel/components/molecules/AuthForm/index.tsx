import React, { useState } from 'react';
import { observer } from 'mobx-react';
import { useHistory } from 'react-router-dom';
import Input from 'AdminPanel/components/atoms/Input';
import FormContainer from './_FormContainer';
import Header from 'AdminPanel/components/atoms/Header1';
import Button from 'AdminPanel/components/atoms/BlueButton';
import { useStore } from 'AdminPanel/stores';


const AuthForm = observer(() => {
  const { playerInfoStore } = useStore();
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const history = useHistory();

  const handleLogin = async () => {
    const result = await playerInfoStore.authorize(userName, password);

    if (result === 0 && playerInfoStore.isAuthorized) {
      history.push('/admin');
    }
  }

  return (
    <FormContainer>
      <Header>Добро пожаловать!</Header>
      <Input value={userName} setValue={setUserName} />
      <Input type="password" value={password} setValue={setPassword} />
      <Button onClick={handleLogin}>Войти</Button>
    </FormContainer >
  );
})


export default AuthForm;