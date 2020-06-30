export async function deleteFaction(id: string) {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}api/Admin/Faction/${id}`;

  const response = await fetch(url, {
    method: 'DELETE',
  });

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  return 0;
}