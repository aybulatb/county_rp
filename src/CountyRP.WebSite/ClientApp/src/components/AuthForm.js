import React, { Component } from 'react';
import { observer, inject } from 'mobx-react';

class AuthForm extends Component {
  constructor(props) {
    super(props);

    this.state = {
      login: '',
      password: ''
    };

    this.changeLoginInput = this.changeLoginInput.bind(this);
    this.changePasswordInput = this.changePasswordInput.bind(this);
    this.authorize = this.authorize.bind(this);
  }

  changeLoginInput(e) {
    this.setState({
      login: e.target.value
    });
  }

  changePasswordInput(e) {
    this.setState({
      password: e.target.value
    });
  }

  authorize = () => this.props.miniPlayerInfoStore.authorize(this.state.login, this.state.password);

  render() {
    return (
      <div>
        <input type="text" value={this.state.login} onChange={this.changeLoginInput} />
        <input type="password" value={this.state.password} onChange={this.changePasswordInput} />
        <button onClick={this.authorize}>Авторизоваться</button>
      </div>
    );
  }
}

export default inject('miniPlayerInfoStore')(observer(AuthForm));