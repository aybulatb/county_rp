import { decorate, observable, action } from 'mobx';

class Profile {
  isLoading = true;
  player = {
    login: ''
  }
  persons = [];

  getProfile(login) {
    this.isLoading = true;
    this.player = {
      login: ''
    };
    this.persons = [];

    var request = new XMLHttpRequest();
    request.open('GET', 'api/Profile?login=' + login);
    request.onload = () => {
      if (request.readyState === XMLHttpRequest.DONE) {
        if (request.status === 200) {
          var profile = JSON.parse(request.responseText);
          this.player.id = profile.player.id;
          this.player.login = profile.player.login;
          profile.persons.map(p => this.persons.push({
            name: p.name
          }));
        }

        this.isLoading = false;
      }
    };
    request.send();
  }
}

Profile = decorate(Profile, {
  isLoading: observable,
  login: observable,
  persons: observable,
  getProfile: action
});

export default new Profile();