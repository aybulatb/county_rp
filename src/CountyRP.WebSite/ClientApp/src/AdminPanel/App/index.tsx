import React from 'react';
import {
  Switch,
  Route,
} from 'react-router-dom';

import GlobalStyle from './GlobalStyle';
import { StoreProvider } from 'AdminPanel/stores/index';

import Home from 'AdminPanel/components/pages/Home';
import AuthForm from 'AdminPanel/components/pages/Auth';
import Profile from 'AdminPanel/components/pages/Profile';
import Forum from 'AdminPanel/components/pages/Forum';
import Players from 'AdminPanel/components/pages/Players';
import Group from 'AdminPanel/components/pages/Group';
import CreateGroup from 'AdminPanel/components/pages/CreateGroup';
import EditGroup from 'AdminPanel/components/pages/EditGroup';


function App() {
  return <StoreProvider>
    <GlobalStyle />
    <Switch>
      <Route exact path='/admin' component={Home} />
      <Route path='/admin/Auth' component={AuthForm} />
      <Route path='/admin/profile/:login' component={Profile} />
      <Route path='/admin/players' component={Players} />
      <Route path='/admin/forum' component={Forum} />
      <Route exact path='/admin/group' component={Group} />
      <Route path='/admin/group/create'><CreateGroup /></Route>
      <Route path='/admin/group/edit/:id'><EditGroup /></Route>
    </Switch>
  </StoreProvider>;
}

export default App;
