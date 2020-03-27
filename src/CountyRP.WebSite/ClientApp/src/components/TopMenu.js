import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import './TopMenu.css';

export default class TopMenu extends Component {
  render() {
    return (
      <div className="topMenu__wrap">
        <div className="topMenu">
          <div className="topMenu__logo">так1</div>
          <div><Link to="/Auth">Авторизация</Link></div>
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