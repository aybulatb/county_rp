import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { observer, inject } from 'mobx-react';

import './TopMenu.css';

class TopMenu extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isAuthLoading: true
    };

    this.logOut = this.logOut.bind(this);
    this.renderLoadingAuth = this.renderLoadingAuth.bind(this);
    this.renderMiniProfile = this.renderMiniProfile.bind(this);

    this.props.miniPlayerInfoStore.getMiniProfile();
  }

  logOut() {
    var request = new XMLHttpRequest();
    request.open('GET', 'PlayerAuthorization/Logout');
    request.onload = () => {
      if (request.readyState === XMLHttpRequest.DONE) {
        if (request.status === 200) {
          this.setState({
            miniProfile: null
          });
        }
      }
    };
    request.send();
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
        <button onClick={this.logOut}>Выйти</button>
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