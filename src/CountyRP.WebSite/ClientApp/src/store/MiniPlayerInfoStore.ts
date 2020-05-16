import { decorate, observable, action } from 'mobx';


export class MiniPlayerInfoStore {
  isLoading = false;
  isAuthorized = false;

  profile = {
    login: ''
  };

  getMiniProfile() {
    const request = new XMLHttpRequest();
    request.open('GET', 'api/PlayerProfile/MiniInfo');
    request.onload = () => {
      if (request.readyState === XMLHttpRequest.DONE) {
        if (request.status === 200) {
          const miniProfile = JSON.parse(request.responseText);
          this.profile = {
            login: miniProfile.login
          };

          this.isAuthorized = true;
        }

        this.isLoading = false;
      }
    }

    request.send();
  }

  authorize(login: string, password: string) {
    const formData = new FormData();
    formData.append('login', login);
    formData.append('password', password);

    const query = `login=${login}&password=${password}`;

    const request = new XMLHttpRequest();
    request.open('POST', 'api/PlayerAuthorization/TryAuthorize?' + query);
    request.onreadystatechange = () => {
      if (request.readyState !== XMLHttpRequest.DONE)
        return;

      if (request.status === 200) {
        const player = JSON.parse(request.responseText);
        this.profile.login = player.login;
        this.isAuthorized = true;

        if (process.env.REACT_APP_DEV_MODE === 'true') {
          console.log(player.login);
          console.log(player.password);
        }
      }
    }

    request.send(formData);
  }

  logOut() {
    const request = new XMLHttpRequest();
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


decorate(MiniPlayerInfoStore, {
  isLoading: observable,
  isAuthorized: observable,
  profile: observable,
  getMiniProfile: action,
  authorize: action,
  logOut: action
});


export const miniPlayerInfoStore = new MiniPlayerInfoStore();