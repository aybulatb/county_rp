import { AdminLevel } from 'AdminPanel/services/adminLevel/AdminLevel';


export async function editAdminLevel(id: string, adminLevel: AdminLevel) {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}api/Admin/AdminLevel/${id}`;

  const response = await fetch(url, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(adminLevel),
  });

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  return 0;
}