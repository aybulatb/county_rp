import React, { Component } from 'react';
import { observer, inject } from 'mobx-react';

class Profile extends Component {
  constructor(props) {
    super(props);

    this.props.profileStore.getProfile('Nigger');
  }

  render() {
    return (
      <div>
        {this.props.profileStore.isLoading &&
          <div>Загрузка</div>
        }
        {!this.props.profileStore.isLoading &&
          <div>
            <div>Логин: {this.props.profileStore.player.login} ({this.props.profileStore.player.id})</div>
            <div>Персонажи:</div>
            <div></div>
          </div>
        }
      </div>  
    );
  }
}

export default inject('profileStore')(observer(Profile));