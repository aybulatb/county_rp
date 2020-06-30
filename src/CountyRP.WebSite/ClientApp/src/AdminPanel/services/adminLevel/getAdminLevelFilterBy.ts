import {AdminLevel} from 'AdminPanel/services/adminLevel/AdminLevel';


type SearchResult = {
  items: AdminLevel[];

  allAmount: number;
  page: number;
  maxPage: number;
}

export async function getAdminLevelFilterBy(page: number = 1, id: string = '', name: string = '') {
  let url = `https://www.county-rp.ru/api/Admin/AdminLevel/FilterBy?page=${page}`;
  url += id ? `&id=${id}` : '';
  url += name ? `&name=${name}` : '';

  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  const json: SearchResult = await response.json();

  if (!json.hasOwnProperty('items'))
    throw new Error(`Response is invalid: `+json);

  return json;
}