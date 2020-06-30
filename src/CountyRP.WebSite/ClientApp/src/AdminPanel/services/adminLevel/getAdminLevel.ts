import { AdminLevel } from 'AdminPanel/services/adminLevel/AdminLevel';


export async function getAdminLevel(id: string = '') {
  const apiUrl = process.env.REACT_APP_API_URL;
  const url = `${apiUrl}api/Admin/AdminLevel/${id}`;

  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  const json: AdminLevel = await response.json();

  if (!json?.name || !json.ban)
    throw new Error(`Response is invalid: ${json.toString()}`);

  return json;
}