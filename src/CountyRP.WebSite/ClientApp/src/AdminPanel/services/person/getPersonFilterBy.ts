import { Person } from 'AdminPanel/services/person/Person';


type SearchResult = {
  items: Person[];

  allAmount: number;
  page: number;
  maxPage: number;
}

export async function getPersonFilterBy(page: number = 1, name: string = '') {
  let url = `https://www.county-rp.ru/api/Admin/Person/FilterBy?page=${page}`;
  url += name ? `&name=${name}` : '';

  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  const json: SearchResult = await response.json();

  if (!json.hasOwnProperty('items'))
    throw new Error(`Response is invalid: `+json);

  return json;
}