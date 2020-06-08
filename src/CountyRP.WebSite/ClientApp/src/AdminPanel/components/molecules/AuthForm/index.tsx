import React, { useState } from 'react';
import { observer } from 'mobx-react';
import { useHistory } from 'react-router-dom';
import InputField from './_InputField';
import FormContainer from './_FormContainer';
import Header from './_Header';
import Button from './_Button';
import { useStore } from 'AdminPanel/stores';


const AuthForm = observer(() => {
  const { playerInfoStore } = useStore();
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const history = useHistory();

  const handleLoginInput = (event: React.ChangeEvent<HTMLInputElement>) => {
    setUserName(event.target.value);
  }

  const handlePasswordInput = (event: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(event.target.value);
  }

  const handleLogin = () => {
    playerInfoStore.authorize(userName, password);
    history.push('/admin');
  }

  return (
    <FormContainer>
      <Header>Добро пожаловать!</Header>
      <InputField type="text" value={userName} onChange={handleLoginInput} />
      <InputField type="password" value={password} onChange={handlePasswordInput} />
      <Button onClick={handleLogin}>Войти</Button>
    </FormContainer>
  );
})


export default AuthForm;