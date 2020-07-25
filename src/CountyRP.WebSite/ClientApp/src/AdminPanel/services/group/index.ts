import { createGroup as prodCreateGroup } from './createGroup';
import { deleteGroup as prodDeleteGroup } from './deleteGroup';
import { getGroupsFilterBy as prodGetGroupsFilterBy } from './getGroupsFilterBy';
import { editGroup as prodEditGroup } from './editGroup';
import { getGroup as prodGetGroup } from './getGroup';

import { createGroup as devCreateGroup } from './fake/createGroup';
import { deleteGroup as devDeleteGroup } from './fake/deleteGroup';
import { getGroupsFilterBy as devGetGroupsFilterBy } from './fake/getGroupsFilterBy';
import { editGroup as devEditGroup } from './fake/editGroup';
import { getGroup as devGetGroup } from './fake/getGroup';


export const {
  createGroup,
  deleteGroup,
  getGroupsFilterBy,
  getGroup,
  editGroup
} = (() => {
  if (process.env.REACT_APP_DEV_MODE === 'true') {
    return {
      createGroup: devCreateGroup,
      deleteGroup: devDeleteGroup,
      getGroupsFilterBy: devGetGroupsFilterBy,
      getGroup: devGetGroup,
      editGroup: devEditGroup
    }
  } else {
    return {
      createGroup: prodCreateGroup,
      deleteGroup: prodDeleteGroup,
      getGroupsFilterBy: prodGetGroupsFilterBy,
      getGroup: prodGetGroup,
      editGroup: prodEditGroup,
    }
  }
})();