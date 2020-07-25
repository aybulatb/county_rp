import { Person } from 'AdminPanel/types';


type SearchResult = {
  items: Person[];

  allAmount: number;
  page: number;
  maxPage: number;
}

export async function getPersonFilterBy(page: number = 1, name: string = '') {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}Admin/Person/FilterBy?page=${page}`;
  url += name ? `&name=${name}` : '';

  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  const json: SearchResult = await response.json();

  if (!json.hasOwnProperty('items'))
    throw new Error(`Response is invalid: `+json);

  return json;
}