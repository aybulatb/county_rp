export async function editPlayer(id: string, login: string, password: string, groupId: string) {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}Player/${id}`;

  const response = await fetch(url, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({ id, login, password, groupId }),
  });

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  return 0;
}