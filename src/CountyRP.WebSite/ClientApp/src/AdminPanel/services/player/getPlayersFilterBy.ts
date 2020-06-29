type SearchPlayersResult = {
  items: {
    id: number;
    login: string;
    password: string;
    groupId: string;
  }[];

  allAmount: number;
  page: number;
  maxPage: number;
}

export async function getPlayersFilterBy(page: number = 1, name: string = '') {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}api/Admin/Player/FilterBy?page=${page}`;
  url += name ? `&name=${name}` : '';

  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  const json: SearchPlayersResult = await response.json();

  if (!json.hasOwnProperty('items'))
    throw new Error(`Response is invalid: ${json.toString()}`);

  return json;
}