import React, {useState} from 'react';
import { NavLink } from 'react-router-dom';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import CategoryPage from 'AdminPanel/components/templates/CategoryPage';
import { getFactionFilterBy } from 'AdminPanel/services';
import { routes } from 'AdminPanel/routes';
import { Faction } from 'AdminPanel/types';
import { handlerFetchError } from 'AdminPanel/utils/handlerFactory';


const FactionPage = () => {
  const [factionId, setFactionId] = useState('');
  const [factionName, setFactionName] = useState('');
  const [factions, setFactions] = useState<Faction[]>([]);
  const [pageNumber, setPageNumber] = useState(1);
  const [maxPage, setMaxPage] = useState(1);

  const handleSearch = async (numberOfPage: number) => {
    try {
      const response = await getFactionFilterBy(numberOfPage, factionId, factionName);

      setFactions(response.items);
      setMaxPage(response.maxPage);
      setPageNumber(response.page);
    } catch (error) {
      handlerFetchError(error);
    }
  }

  return (
    <CategoryPage
      topButtons={
        <BlueButton as={NavLink} to={routes.createFaction}>Создать</BlueButton>
      }
      inputRows={[
        {
          name: 'ID',
          innerComponent: <Input value={factionId} setValue={setFactionId} />
        },
        {
          name: 'Имя',
          innerComponent: <Input value={factionName} setValue={setFactionName} />
        }
      ]}
      handleSearch={handleSearch}
      searchTableProps={{
        headers: ['ID', 'Имя','Тип'],
        searchResultsItems: factions.map((faction) => (
          [faction.id, faction.name, faction.type.toString()]
        )),
        editRoute: routes.editFaction,
        maxPage,
        pageNumber
      }}
    />
  );
}


export default FactionPage;