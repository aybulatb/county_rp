import { Faction } from 'AdminPanel/types';


type SearchResult = {
  items: Faction[];

  allAmount: number;
  page: number;
  maxPage: number;
}

export async function getFactionFilterBy(page: number = 1, id: string = '', name: string = '') {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}Faction/FilterBy?page=${page}`;
  url += id ? `&id=${id}` : '';
  url += name ? `&name=${name}` : '';

  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.status}: ${response.statusText}`);

  const json: SearchResult = await response.json();

  if (!json.hasOwnProperty('items'))
    throw new Error(`Response is invalid: `+json);

  return json;
}