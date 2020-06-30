import { Person } from 'AdminPanel/services/person/Person';


export async function editPerson(person: Person) {
  const apiUrl = process.env.REACT_APP_API_URL;
  let url = `${apiUrl}api/Admin/Person/${person.id}`;

  const response = await fetch(url, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(person),
  });

  if (!response.ok)
    throw new Error(`${response.statusText}`);

  return 0;
}