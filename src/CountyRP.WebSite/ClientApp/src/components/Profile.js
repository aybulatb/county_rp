import React, { Component } from 'react';
import { observer, inject } from 'mobx-react';

class Profile extends Component {
  constructor(props) {
    super(props);

    var login = this.props.match.params.login;

    this.props.profileStore.getProfile(login);
  }



  render() {
    return (
      <div>
        {(this.props.profileStore.isLoading) ?
          <div>Загрузка</div>
          :
          <div>
            <div>Логин: {this.props.profileStore.player.login} ({this.props.profileStore.player.id})</div>
            <div>Персонажи:</div>
            {this.props.profileStore.persons.map(p => 
              <div>
                <div>Имя: {p.person.name} ({p.person.id})</div>
                <div>Фракция: {(p.person.factionId === null) ? 'Нет' : p.faction.name + ' (' + p.faction.id + ')'}</div>
                <div>Имущество:</div>
                {p.vehicles.map(v =>
                  <div>
                    <div>{v.id}</div>
                  </div>
                )}
                <br />
              </div>
            )}
          </div>
        }
      </div>  
    );
  }
}

export default inject('profileStore')(observer(Profile));