import { createFaction as prodCreateFaction } from './createFaction';
import { deleteFaction as prodDeleteFaction } from './deleteFaction';
import { getFactionFilterBy as prodGetFactionFilterBy } from './getFactionFilterBy';
import { editFaction as prodEditFaction } from './editFaction';
import { getFaction as prodGetFaction } from './getFaction';

import { createFaction as devCreateFaction } from './fake/createFaction';
import { deleteFaction as devDeleteFaction } from './fake/deleteFaction';
import { getFactionFilterBy as devGetFactionFilterBy } from './fake/getFactionFilterBy';
import { editFaction as devEditFaction } from './fake/editFaction';
import { getFaction as devGetFaction } from './fake/getFaction';


export const {
  createFaction,
  deleteFaction,
  getFactionFilterBy,
  editFaction,
  getFaction
} = (() => {
  let createFaction;
  let deleteFaction;
  let getFactionFilterBy;
  let editFaction;
  let getFaction;

  if (process.env.REACT_APP_DEV_MODE === 'true') {
    createFaction = devCreateFaction;
    deleteFaction = devDeleteFaction;
    getFactionFilterBy = devGetFactionFilterBy;
    editFaction = devEditFaction;
    getFaction = devGetFaction;
  } else {
    createFaction = prodCreateFaction;
    deleteFaction = prodDeleteFaction;
    getFactionFilterBy = prodGetFactionFilterBy;
    editFaction = prodEditFaction;
    getFaction = prodGetFaction;
  }

  return {
    createFaction,
    deleteFaction,
    getFactionFilterBy,
    editFaction,
    getFaction
  }
})();