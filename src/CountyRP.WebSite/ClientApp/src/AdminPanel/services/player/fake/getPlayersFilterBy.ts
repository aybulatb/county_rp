import { Player } from 'AdminPanel/types';


type SearchPlayersResult = {
  items: Player[];
  allAmount: number;
  page: number;
  maxPage: number;
}

export async function getPlayersFilterBy(page: number = 1, name: string = ''): Promise<SearchPlayersResult> {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}Player?page=${page}`;
  url += name ? `&name=${name}` : '';

  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  const items: Player[] = await response.json();
  const allAmount = Number(response.headers.get('X-Total-Count'));
  const maxPage = Math.ceil((allAmount || 1) / 10);

  if (!items)
    throw new Error(`Response is invalid`);

  return { items, page, allAmount, maxPage };
}