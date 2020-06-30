import { AdminLevel } from 'AdminPanel/services/adminLevel/AdminLevel';


export async function createAdminLevel(adminLevel: AdminLevel) {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}api/Admin/AdminLevel`;
  const response = await fetch(url, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(adminLevel),
  });

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  return 0;
}