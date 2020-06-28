type SearchResult = {
  groups: {
    id: string;
    name: string;
    color: string;
  }[];

  allAmount: number;
  page: number;
  maxPage: number;
}

export async function getGroupsFilterBy(page: number = 1, id: string = '', name: string = '') {
  let url = `https://www.county-rp.ru/api/Admin/Group/FilterBy?page=${page}`;
  url += id ? `&id=${id}` : '';
  url += name ? `&name=${name}` : '';

  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  const json: SearchResult = await response.json();

  if (!json.hasOwnProperty('groups'))
    throw new Error(`Response is invalid: ${json.toString()}`);

  return json;
}