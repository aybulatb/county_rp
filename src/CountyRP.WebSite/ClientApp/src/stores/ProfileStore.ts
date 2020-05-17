import { decorate, observable, action } from 'mobx';


type Person = {
  person: {
    id: number
    name: string
    playerId: number
    factionId: string
  },
  faction: {
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
    id: NaN,
    login: ''
  }
  persons: Person[] = [];

  getProfile(login: string) {
    this.isLoading = true;
    this.player = {
      id: NaN,
      login: '',
    }
    this.persons = [];

    const request = new XMLHttpRequest();
    const url = process.env.REACT_APP_API_URL;
    request.open('GET', url + 'api/Profile?login=' + login);
    request.onload = () => {
      if (request.readyState === XMLHttpRequest.DONE) {
        if (request.status === 200) {
          const profile = JSON.parse(request.responseText);

          this.player.id = profile.player.id;
          this.player.login = profile.player.login;

          profile.persons.map((personItem: Person) => this.persons.push({
            person: personItem.person,
            faction: personItem.faction,
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