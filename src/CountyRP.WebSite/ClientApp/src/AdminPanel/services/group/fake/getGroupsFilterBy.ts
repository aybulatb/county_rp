import { Group } from 'AdminPanel/types';


type SearchResult = {
  items: Group[];
  allAmount: number;
  page: number;
  maxPage: number;
}

export async function getGroupsFilterBy(page: number = 1, id: string = '', name: string = ''): Promise<SearchResult> {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}Group?page=${page}`;
  url += id ? `&id=${id}` : '';
  url += name ? `&name=${name}` : '';

  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  const items: Group[] = await response.json();
  const allAmount = Number(response.headers.get('X-Total-Count'));
  const maxPage = Math.ceil((allAmount || 1) / 10);

  if (!items)
    throw new Error(`Response is invalid`);

  return { items, page, allAmount, maxPage};
}