import { editPerson as prodEditPerson } from './editPerson';
import { getPerson as prodGetPerson } from './getPerson';
import { getPersonFilterBy as prodGetPersonFilterBy } from './getPersonFilterBy';

import { editPerson as devEditPerson } from './fake/editPerson';
import { getPerson as devGetPerson } from './fake/getPerson';
import { getPersonFilterBy as devGetPersonFilterBy } from './fake/getPersonFilterBy';


export const {
  editPerson,
  getPerson,
  getPersonFilterBy
} = (() => {
  if (process.env.REACT_APP_DEV_MODE === 'true') {
    return {
      editPerson: devEditPerson,
      getPerson: devGetPerson,
      getPersonFilterBy: devGetPersonFilterBy
    }
  } else {
    return {
      editPerson: prodEditPerson,
      getPerson: prodGetPerson,
      getPersonFilterBy: prodGetPersonFilterBy
    }
  }
})();