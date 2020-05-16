import { decorate, observable, action } from 'mobx';


type Person = {
  person: {
    id: number
    name: string
    playerId: number
    fractionId: string
  },
  fraction: {
    id: string
    name: string
    ranks: string[]
  }
  vehicles: {
    id: number
    personId: number
  }[]
}

export class ProfileStore {
  isLoading = false;
  player = {
    id: '',
    login: ''
  }
  persons: Person[] = [];

  getProfile(login: string) {
    this.isLoading = true;
    this.player = {
      login: '',
      id: ''
    }
    this.persons = [];

    const request = new XMLHttpRequest();
    request.open('GET', 'api/Profile?login=' + login);
    request.onload = () => {
      if (request.readyState === XMLHttpRequest.DONE) {
        if (request.status === 200) {
          const profile = JSON.parse(request.responseText);
          this.player.id = profile.player.id;
          this.player.login = profile.player.login;
          profile.persons.map((personItem: Person) => this.persons.push({
            person: personItem.person,
            fraction: personItem.fraction,
            vehicles: personItem.vehicles
          }));
        }

        this.isLoading = false;
      }
    }

    request.send();
  }
}

decorate(ProfileStore, {
  isLoading: observable,
  player: observable,
  persons: observable,
  getProfile: action
});


export const profileStore = new ProfileStore();