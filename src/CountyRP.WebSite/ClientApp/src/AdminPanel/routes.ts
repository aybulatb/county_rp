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
}