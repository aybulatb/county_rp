import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';

export default class AuthForm extends Component {
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

  authorize() {
    var formData = new FormData();
    formData.append('login', this.state.login);
    formData.append('password', this.state.password);

    var query = 'login=' + this.state.login + '&password=' + this.state.password;

    var request = new XMLHttpRequest();
    request.open('POST', 'PlayerAuthorization/TryAuthorize?' + query);
    request.onreadystatechange = () => {
      if (request.readyState !== XMLHttpRequest.DONE)
        return;

      if (request.status === 200) {
        var player = JSON.parse(request.responseText);
        console.log(player.login);
        console.log(player.password);
        //this.props.history.push('/');
      }
    };

    request.send(formData);
  }

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