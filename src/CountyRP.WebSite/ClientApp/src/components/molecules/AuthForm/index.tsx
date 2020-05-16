import React, { useState } from 'react';
import { observer, inject } from 'mobx-react';
import { MiniPlayerInfoStore } from 'store/MiniPlayerInfoStore';


type AuthFormProps = {
  miniPlayerInfoStore?: MiniPlayerInfoStore
}

const AuthForm = (props: AuthFormProps) => {
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');

  const handleLoginInput = (event: React.ChangeEvent<HTMLInputElement>) => {
    setUserName(event.target.value);
  }

  const handlePasswordInput = (event: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(event.target.value);
  }

  const authorize = () => props.miniPlayerInfoStore?.authorize(userName, password);

  return (
    <div>
      <input type="text" value={userName} onChange={handleLoginInput} />
      <input type="password" value={password} onChange={handlePasswordInput} />
      <button onClick={authorize}>Авторизоваться</button>
    </div>
  );
}


export default inject('miniPlayerInfoStore')(observer(AuthForm));