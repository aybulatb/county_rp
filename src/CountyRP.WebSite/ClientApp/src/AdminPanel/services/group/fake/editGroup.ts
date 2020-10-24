export async function editGroup(oldId: string, id: string, name: string, color: string) {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}Group/${oldId}`;

  const response = await fetch(url, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({ id, name, color }),
  });

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  return 0;
}