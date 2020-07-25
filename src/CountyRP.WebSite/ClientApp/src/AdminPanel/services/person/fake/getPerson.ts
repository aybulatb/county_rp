import { Person } from 'AdminPanel/types';


export async function getPerson(id: string = '') {
  const apiUrl = process.env.REACT_APP_API_URL;
  const url = `${apiUrl}Person/${id}`;
  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  const json: Person = await response.json();

  if (!json?.playerId)
    throw new Error(`Response is invalid: ${json.toString()}`);

  return json;
}