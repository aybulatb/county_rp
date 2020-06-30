import React, { useEffect } from 'react';
import {
  Switch,
  Route,
  Redirect,
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
import Person from 'AdminPanel/components/pages/Person';
import EditPerson from 'AdminPanel/components/pages/EditPerson';
import Faction from 'AdminPanel/components/pages/Faction';
import CreateFaction from 'AdminPanel/components/pages/CreateFaction';
import EditFaction from 'AdminPanel/components/pages/EditFaction';
import AdminLevel from 'AdminPanel/components/pages/AdminLevel';
import EditAdminLevel from 'AdminPanel/components/pages/EditAdminLevel';
import CreateAdminLevel from 'AdminPanel/components/pages/EditAdminLevel'

import { routes } from 'AdminPanel/routes';


const App = observer(() => {
  
  useAuthCheck();

  return <>
    <GlobalStyle />
    <Switch>
      <Route exact path={routes.root}><Home /></Route>
      <Route path={routes.auth} component={AuthForm} />
      <Route path={routes.profile} component={Profile} />
      <Route path={routes.forum} component={Forum} />
      
      <Route exact path={routes.group} component={Group} />
      <Route path={routes.createGroup}><CreateGroup /></Route>
      <Route path={routes.editGroup + '/:id'}><EditGroup /></Route>
      
      <Route exact path={routes.players} component={Players} />
      <Route path={routes.editPlayer + '/:id'}><EditPlayer /></Route>
      <Route path={routes.createPlayer}><CreatePlayer /></Route>

      <Route exact path={routes.person} component={Person} />
      <Route path={routes.editPerson + '/:id'}><EditPerson /></Route>

      <Route exact path={routes.faction} ><Faction /></Route>
      <Route path={routes.createFaction}><CreateFaction /></Route>
      <Route path={routes.editFaction + '/:id'}><EditFaction /></Route>

      <Route exact path={routes.adminLevel} ><AdminLevel /></Route>
      <Route path={routes.createAdminLevel}><CreateAdminLevel /></Route>
      <Route path={routes.editAdminLevel + '/:id'}><EditAdminLevel /></Route>

      <Redirect to={routes.root} />
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


export default () => <StoreProvider><App /></StoreProvider>;