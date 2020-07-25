import React, { useState } from 'react';
import Input from 'AdminPanel/components/atoms/Input';
import CategoryPage from 'AdminPanel/components/templates/CategoryPage';
import { getPersonFilterBy } from 'AdminPanel/services';
import { routes } from 'AdminPanel/routes';
import { Person } from 'AdminPanel/types';


const PersonPage = () => {
  const [personName, setPersonName] = useState('');
  const [persons, setPersons] = useState<Person[]>([]);
  const [pageNumber, setPageNumber] = useState(1);
  const [maxPage, setMaxPage] = useState(1);

  const handleSearch = async (numberOfPage: number) => {
    try {
      const response = await getPersonFilterBy(numberOfPage, personName);

      setPersons(response.items);
      setMaxPage(response.maxPage);
      setPageNumber(response.page);
    } catch (error) {
      console.log(error);
    }
  }

  return (
    <CategoryPage
      inputRows={[
        {
          name: 'Имя',
          innerComponent: <Input value={personName} setValue={setPersonName} />
        }
      ]}
      handleSearch={(numberOfPage: number) => handleSearch(numberOfPage)}
      searchTableProps={{
        headers: ['ID', 'Имя', 'Фракция', 'Ранг', 'ID группы'],
        searchResultsItems: persons.map((person) => (
          [person.id.toString(), person.name, person.factionId, person.rank.toString(), person.groupId]
        )),
        editRoute: routes.editPerson,
        maxPage: maxPage,
        pageNumber: pageNumber
      }}
    />
  );
}


export default PersonPage;