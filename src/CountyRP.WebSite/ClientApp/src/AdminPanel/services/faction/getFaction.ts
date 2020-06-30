import { Faction } from 'AdminPanel/services/faction/Faction';


export async function getFaction(id: string = '') {
  const apiUrl = process.env.REACT_APP_API_URL;
  const url = `${apiUrl}api/Admin/Faction/${id}`;

  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  const json: Faction = await response.json();

  if (!json?.name || !json.ranks)
    throw new Error(`Response is invalid: ${json.toString()}`);

  return json;
}