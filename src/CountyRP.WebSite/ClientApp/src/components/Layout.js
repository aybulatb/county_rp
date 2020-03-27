import React, { Component } from 'react';

import TopMenu from './TopMenu';

import './Layout.css';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <TopMenu />
        {this.props.children}
      </div>
    );
  }
}
