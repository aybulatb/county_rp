import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';
import { observer, inject } from 'mobx-react';
import { IMiniPlayerInfoStore } from 'stores/MiniPlayerInfoStore';
import InputField from './_InputField';
import FormContainer from './_FormContainer';
import Header from './_Header';
import Button from './_Button';


type AuthFormProps = {
  miniPlayerInfoStore?: IMiniPlayerInfoStore
}

const AuthForm = (props: AuthFormProps) => {
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
    props.miniPlayerInfoStore?.authorize(userName, password);
    history.push('/');
  }

  return (
    <FormContainer>
      <Header>Добро пожаловать!</Header>
      <InputField type="text" value={userName} onChange={handleLoginInput} />
      <InputField type="password" value={password} onChange={handlePasswordInput} />
      <Button onClick={handleLogin}>Войти</Button>
    </FormContainer>
  );
}


export default inject('miniPlayerInfoStore')(observer(AuthForm));