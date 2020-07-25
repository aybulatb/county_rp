import { createPlayer as prodCreatePlayer } from './createPlayer';
import { editPlayer as prodEditPlayer } from './editPlayer';
import { getPlayer as prodGetPlayer } from './getPlayer';
import { getPlayersFilterBy as prodGetPlayersFilterBy } from './getPlayersFilterBy';

import { createPlayer as devCreatePlayer } from './fake/createPlayer';
import { editPlayer as devEditPlayer } from './fake/editPlayer';
import { getPlayer as devGetPlayer } from './fake/getPlayer';
import { getPlayersFilterBy as devGetPlayersFilterBy } from './fake/getPlayersFilterBy';


export const {
  createPlayer,
  editPlayer,
  getPlayer,
  getPlayersFilterBy
} = (() => {
  if (process.env.REACT_APP_DEV_MODE === 'true') {
    return {
      createPlayer: devCreatePlayer,
      editPlayer: devEditPlayer,
      getPlayer: devGetPlayer,
      getPlayersFilterBy: devGetPlayersFilterBy
    }
  } else {
    return {
      createPlayer: prodCreatePlayer,
      editPlayer: prodEditPlayer,
      getPlayer: prodGetPlayer,
      getPlayersFilterBy: prodGetPlayersFilterBy
    }
  }
})();