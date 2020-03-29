import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import './TopMenu.css';

export default class TopMenu extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isAuthLoading: true,
      miniProfile: null
    };

    this.logOut = this.logOut.bind(this);
    this.renderLoadingAuth = this.renderLoadingAuth.bind(this);
    this.renderMiniProfile = this.renderMiniProfile.bind(this);

    this.getMiniProfile();
  }

  getMiniProfile() {
    var request = new XMLHttpRequest();
    request.open('GET', 'PlayerProfile/MiniInfo');
    request.onload = () => {
      if (request.readyState === XMLHttpRequest.DONE) {
        if (request.status === 200) {
          var miniProfile = JSON.parse(request.responseText);
          this.setState({
            miniProfile: {
              login: miniProfile.login
            }
          });
        }

        this.setState({
          isAuthLoading: false
        });
      }
    };
    request.send();
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
    return ((this.state.isAuthLoading) ?
      "loading" :
      this.renderMiniProfile()
    );
  }

  renderMiniProfile() {
    return ((this.state.miniProfile === null) ?
      <Link to="/Auth">Авторизация</Link> :
      <div>
        <div>{this.state.miniProfile.login}</div>
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