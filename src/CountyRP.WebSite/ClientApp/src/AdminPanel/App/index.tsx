import React, { useEffect } from 'react';
import {
  Switch,
  Route,
} from 'react-router-dom';
import { useHistory } from 'react-router-dom';
import { observer } from 'mobx-react';

import GlobalStyle from './GlobalStyle';
import { StoreProvider } from 'AdminPanel/stores/index';
import { useStore } from 'AdminPanel/stores';

import Home from 'AdminPanel/components/pages/Home';
import AuthForm from 'AdminPanel/components/pages/Auth';
import Profile from 'AdminPanel/components/pages/Profile';
import Forum from 'AdminPanel/components/pages/Forum';
import Group from 'AdminPanel/components/pages/Group';
import CreateGroup from 'AdminPanel/components/pages/CreateGroup';
import EditGroup from 'AdminPanel/components/pages/EditGroup';
import Players from 'AdminPanel/components/pages/Players';
import EditPlayer from 'AdminPanel/components/pages/EditPlayer';
import CreatePlayer from 'AdminPanel/components/pages/CreatePlayer';

import { routes } from 'AdminPanel/routes';


const App = observer(() => {
  useAuthCheck();

  return <>
    <GlobalStyle />
    <Switch>
      <Route exact path={routes.root} component={Home} />
      <Route path={routes.auth} component={AuthForm} />
      <Route path={routes.profile} component={Profile} />
      <Route path={routes.forum} component={Forum} />
      <Route exact path={routes.group} component={Group} />
      <Route path={routes.createGroup}><CreateGroup /></Route>
      <Route path={routes.editGroup + '/:id'}><EditGroup /></Route>
      <Route exact path={routes.players} component={Players} />
      <Route path={routes.editPlayer + '/:id'}><EditPlayer /></Route>
      <Route path={routes.createPlayer}><CreatePlayer /></Route>
    </Switch>
  </>;
})


function useAuthCheck() {
  const { playerInfoStore } = useStore();
  const history = useHistory();
  const isAuthorized = playerInfoStore.isAuthorized;

  useEffect(() => {
    if (!isAuthorized && process.env.REACT_APP_AUTH === 'ON') {
      history.push('/admin/Auth');
    }
  }, [history, isAuthorized]);
}


export default () => <StoreProvider><App/></StoreProvider>;