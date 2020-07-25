import { createAdminLevel as prodCreateAdminLevel } from './createAdminLevel';
import { deleteAdminLevel as prodDeleteAdminLevel } from './deleteAdminLevel';
import { editAdminLevel as prodEditAdminLevel } from './editAdminLevel';
import { getAdminLevel as prodGetAdminLevel } from './getAdminLevel';
import { getAdminLevelFilterBy as prodGetAdminLevelFilterBy } from './getAdminLevelFilterBy';

import { createAdminLevel as devCreateAdminLevel } from './fake/createAdminLevel';
import { deleteAdminLevel as devDeleteAdminLevel } from './fake/deleteAdminLevel';
import { editAdminLevel as devEditAdminLevel } from './fake/editAdminLevel';
import { getAdminLevel as devGetAdminLevel } from './fake/getAdminLevel';
import { getAdminLevelFilterBy as devGetAdminLevelFilterBy } from './fake/getAdminLevelFilterBy';


export const {
  createAdminLevel,
  deleteAdminLevel,
  editAdminLevel,
  getAdminLevel,
  getAdminLevelFilterBy
} = (() => {
  if (process.env.REACT_APP_DEV_MODE === 'true') {
    return {
      createAdminLevel: devCreateAdminLevel,
      deleteAdminLevel: devDeleteAdminLevel,
      editAdminLevel: devEditAdminLevel,
      getAdminLevel: devGetAdminLevel,
      getAdminLevelFilterBy: devGetAdminLevelFilterBy
    }
  } else {
    return {
      createAdminLevel: prodCreateAdminLevel,
      deleteAdminLevel: prodDeleteAdminLevel,
      editAdminLevel: prodEditAdminLevel,
      getAdminLevel: prodGetAdminLevel,
      getAdminLevelFilterBy: prodGetAdminLevelFilterBy
    }
  }
})();