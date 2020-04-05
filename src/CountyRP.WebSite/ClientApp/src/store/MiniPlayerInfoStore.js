import { decorate, observable, action } from 'mobx';

class MiniPlayerInfoStore {
  isLoading = true;
  isAuthorized = false;

  profile = {
    login: ''
  };

  getMiniProfile() {
    var request = new XMLHttpRequest();
    request.open('GET', 'api/PlayerProfile/MiniInfo');
    request.onload = () => {
      if (request.readyState === XMLHttpRequest.DONE) {
        if (request.status === 200) {
          var miniProfile = JSON.parse(request.responseText);
          this.profile = {
            login: miniProfile.login
          };

          this.isAuthorized = true;
        }

        this.isLoading = false;
      }
    };
    request.send();
  }

  authorize(login, password) {
    var formData = new FormData();
    formData.append('login', login);
    formData.append('password', password);

    var query = 'login=' + login + '&password=' + password;

    var request = new XMLHttpRequest();
    request.open('POST', 'api/PlayerAuthorization/TryAuthorize?' + query);
    request.onreadystatechange = () => {
      if (request.readyState !== XMLHttpRequest.DONE)
        return;

      if (request.status === 200) {
        var player = JSON.parse(request.responseText);
        console.log(player.login);
        console.log(player.password);
        this.profile.login = player.login;
        this.isAuthorized = true;
        //this.props.history.push('/');
      }
    };

    request.send(formData);
  }

  logOut() {
    var request = new XMLHttpRequest();
    request.open('GET', 'api/PlayerAuthorization/Logout');
    request.onload = () => {
      if (request.readyState === XMLHttpRequest.DONE) {
        if (request.status === 200) {
          this.profile = {
            login: ''
          };
          this.isAuthorized = false;
        }
      }
    };
    request.send();
  }
}

MiniPlayerInfoStore = decorate(MiniPlayerInfoStore, {
  isLoading: observable,
  isAuthorized: observable,
  profile: observable,
  getMiniProfile: action,
  authorize: action,
  logOut: action
});

export default new MiniPlayerInfoStore();