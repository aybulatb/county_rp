import { Faction } from 'AdminPanel/types';


export async function editFaction(id: string, faction: Faction) {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}api/Admin/Faction/${id}`;

  const response = await fetch(url, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(faction),
  });

  if (!response.ok)
    throw new Error(`${response.status}: ${response.statusText}`);

  return 0;
}