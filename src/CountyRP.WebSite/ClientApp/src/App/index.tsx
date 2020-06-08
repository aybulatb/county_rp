import React from 'react';
import {
  BrowserRouter,
  Switch,
  Route,
} from 'react-router-dom';

import GlobalStyle from './GlobalStyle';

import Home from 'components/pages/Home';
import AuthForm from 'components/pages/Auth';
import Profile from 'components/pages/Profile';
import Forum from 'components/pages/Forum';
import Players from 'components/pages/Players';

import { StoreProvider } from 'stores/index';


function App() {
  return <StoreProvider>
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
  </StoreProvider>;
}

export default App;
