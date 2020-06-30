export async function getGroup(id: string = '') {
  const apiUrl = process.env.REACT_APP_API_URL;
  const url = `${apiUrl}api/Admin/Group/${id}`;

  const response = await fetch(url);

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  const json = await response.json();

  if (!json?.id || !json?.name || !json?.color)
    throw new Error(`Response is invalid: ${json.toString()}`);

  return json;
}