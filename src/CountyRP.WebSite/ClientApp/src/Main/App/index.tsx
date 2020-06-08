import React from 'react';
import {
  Route,
} from 'react-router-dom';

import Home from 'Main/components/pages/Home';
import GlobalStyle from './GlobalStyle';


function App() {
  return <>
    <GlobalStyle />
    <Route exact path='/' component={Home} />
  </>;
}

export default App;
