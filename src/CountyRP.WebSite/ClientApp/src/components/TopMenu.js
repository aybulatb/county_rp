import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { observer, inject } from 'mobx-react';

import './TopMenu.css';

class TopMenu extends Component {
  constructor(props) {
    super(props);

    this.renderLoadingAuth = this.renderLoadingAuth.bind(this);
    this.renderMiniProfile = this.renderMiniProfile.bind(this);

    this.props.miniPlayerInfoStore.getMiniProfile();
  }

  renderLoadingAuth() {
    return ((this.props.miniPlayerInfoStore.isLoading) ?
      "loading" :
      this.renderMiniProfile()
    );
  }

  renderMiniProfile() {
    return ((!this.props.miniPlayerInfoStore.isAuthorized) ?
      <Link to="/Auth">Авторизация</Link> :
      <div>
        <div>{this.props.miniPlayerInfoStore.profile.login}</div>
        <button onClick={() => this.props.miniPlayerInfoStore.logOut()}>Выйти</button>
      </div>
    );
  }

  render() {
    return (
      <div className="topMenu__wrap">
        <div className="topMenu">
          <div className="topMenu__logo">так1</div>
          <div>{this.renderLoadingAuth()}</div>
          <div className="topMenu__navPanel">
            <ul>
              <li><Link to="/">Главная</Link></li>
              <li>Форум</li>
              <li>Тест</li>
            </ul>
          </div>
        </div>
      </div>  
    );
  }
}

export default inject('miniPlayerInfoStore')(observer(TopMenu));