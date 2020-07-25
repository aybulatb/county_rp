import { Person } from 'AdminPanel/types';


type SearchResult = {
  items: Person[];
  allAmount: number;
  page: number;
  maxPage: number;
}

export async function getPersonFilterBy(page: number = 1, name: string = ''): Promise<SearchResult> {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}Person?page=${page}`;
  url += name ? `&name=${name}` : '';

  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  const items: Person[] = await response.json();
  const allAmount = Number(response.headers.get('X-Total-Count'));
  const maxPage = Math.ceil((allAmount || 1) / 10);

  if (!items)
    throw new Error(`Response is invalid`);

  return { items, allAmount, page, maxPage };
}