export async function deleteGroup(oldId: string) {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}api/Admin/Group/${oldId}`;

  const response = await fetch(url, {
    method: 'DELETE',
    mode: 'cors'
  });

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  return 0;
}