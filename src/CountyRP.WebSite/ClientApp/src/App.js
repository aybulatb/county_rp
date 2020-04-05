import React, { Component } from 'react';
import { Route } from 'react-router';
import { Provider } from 'mobx-react';

import { Layout } from './components/Layout';
import { Home } from './components/Home';
import AuthForm from './components/AuthForm';
import Profile from './components/Profile';

import miniPlayerInfoStore from './store/MiniPlayerInfoStore';
import profileStore from './store/ProfileStore';

const stores = { miniPlayerInfoStore, profileStore };

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Provider {...stores }>
        <Layout>
          <Route exact path='/' component={Home} />
          <Route path='/Auth' component={AuthForm} />
          <Route path='/profile' component={Profile} />
        </Layout>
      </Provider>
    );
  }
}
