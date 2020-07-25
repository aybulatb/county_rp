export const createPlayerInfoStore = () => ({
  isLoading: false,
  isAuthorized: false,
  profile: {
    login: ''
  },

  getMiniProfile() {
    if (!this.isAuthorized) {
      console.log('sadasda');
      return;
    }

    const request = new XMLHttpRequest();
    const apiUrl = process.env.REACT_APP_API_URL;
    request.open('GET', apiUrl + 'api/PlayerProfile/MiniInfo');
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
  },

  async authorize(login: string, password: string) {
    const formData = new FormData();
    formData.append('login', login);
    formData.append('password', password);

    const query = `login=${login}&password=${password}`;
    const apiUrl = process.env.REACT_APP_API_URL;
    const url = apiUrl + 'api/Authorization/TryAuthorize?' + query;

    const response = await fetch(url, {
      method: 'POST',
      body: formData
    });

    if (!response.ok) {
      const errorText = await response.text();
      throw new Error(errorText);
    }

    const player = await response.json();
    
    this.profile.login = player.login;
    this.isAuthorized = true;

    if (process.env.REACT_APP_DEV_MODE === 'true') {
      console.log('login: ', this.profile.login);
      console.log('password: ', player.password);
    }
  },

  logOut() {
    console.log('log out...');

    const apiUrl = process.env.REACT_APP_API_URL;

    const request = new XMLHttpRequest();
    request.open('GET', apiUrl + 'api/Authorization/Logout');
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
});


export type TPlayerInfoStore = ReturnType<typeof createPlayerInfoStore>