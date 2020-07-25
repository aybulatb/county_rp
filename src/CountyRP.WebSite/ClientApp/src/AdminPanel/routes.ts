const root = '/admin';
const auth = `${root}/Auth`;
const profile = `${root}/profile/:login`;
const forum = `${root}/forum`;
const group = `${root}/group`;
const createGroup = `${group}/create`;
const editGroup = `${group}/edit`;
const players = `${root}/players`;
const createPlayer = `${players}/create`;
const editPlayer = `${players}/edit`;
const person = `${root}/person`;
const editPerson = `${person}/edit`;
const faction = `${root}/faction`;
const editFaction = `${faction}/editFaction`;
const createFaction = `${faction}/createFaction`;
const adminLevel = `${root}/adminLevel`;
const createAdminLevel = `${adminLevel}/create`;
const editAdminLevel = `${adminLevel}/edit`;

const testRoom = `${root}/testRoom`;


export const routes = {
  root,
  auth,
  profile,
  forum,
  group,
  createGroup,
  editGroup,
  players,
  createPlayer,
  editPlayer,
  person,
  editPerson,
  faction,
  editFaction,
  createFaction,
  adminLevel,
  createAdminLevel,
  editAdminLevel,
  testRoom
}