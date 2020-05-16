import React from 'react';
import {
  BrowserRouter,
  Switch,
  Route,
} from 'react-router-dom';
import { Provider } from 'mobx-react';

import GlobalStyle from './GlobalStyle';

import Home from 'components/pages/Home';
import AuthForm from 'components/pages/Auth';
import Profile from 'components/pages/Profile';
import Forum from 'components/pages/Forum';
import Players from 'components/pages/Players';


import { miniPlayerInfoStore } from 'store/MiniPlayerInfoStore';
import { profileStore } from 'store/ProfileStore';


const stores = { miniPlayerInfoStore, profileStore };

function App() {
  return <Provider {...stores}>
    <GlobalStyle />
    <BrowserRouter>
      <Switch>
        <Route exact path='/' component={Home} />
        <Route path='/Auth' component={AuthForm} />
        <Route path='/profile/:login' component={Profile} />
        <Route path='/players' component={Players} />
        <Route path='/forum' component={Forum} />
      </Switch>
    </BrowserRouter>
  </Provider>;
}

export default App;
