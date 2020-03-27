import React, { Component } from 'react';

export default class AuthForm extends Component {
  constructor(props) {
    super(props);

    this.state = {
      login: '',
      password: ''
    };

    this.changeLoginInput = this.changeLoginInput.bind(this);
    this.changePasswordInput = this.changePasswordInput.bind(this);
  }

  changeLoginInput(e) {
    this.setState({
      login: e.value
    });
  }

  changePasswordInput(e) {
    this.setState({
      password: e.value
    });
  }

  render() {
    return (
      <div>
        <input type="text" value={this.state.login} onChange={this.changeLoginInput} />
        <input type="password" value={this.state.password} onChange={this.ChangePasswordInput} />
      </div>
    );
  }
}