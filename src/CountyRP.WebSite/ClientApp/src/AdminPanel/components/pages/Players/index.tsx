import React, {useState} from 'react';
import { NavLink } from 'react-router-dom';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import CategoryPage from 'AdminPanel/components/templates/CategoryPage';
import { getPlayersFilterBy } from 'AdminPanel/services';
import { routes } from 'AdminPanel/routes';
import { Player } from 'AdminPanel/types';


const PlayersPage = () => {
  const [username, setUsername] = useState('');
  const [players, setPlayers] = useState<Player[]>([]);
  const [pageNumber, setPageNumber] = useState(1);
  const [maxPage, setMaxPage] = useState(1);

  const handleSearch = async (numberOfPage: number) => {
    try {
      const response = await getPlayersFilterBy(numberOfPage, username);

      setPlayers(response.items);
      setMaxPage(response.maxPage);
      setPageNumber(response.page);
    } catch (error) {
      console.log(error);
    }
  }

  return (
    <CategoryPage
      topButtons={
        <BlueButton as={NavLink} to={routes.createPlayer}>Создать</BlueButton>
      }
      inputRows={[
        {
          name: 'Логин',
          innerComponent: <Input value={username} setValue={setUsername} />
        }
      ]}
      handleSearch={handleSearch}
      searchTableProps={{
        headers: ['ID', 'Логин', 'Группа'],
        searchResultsItems: players.map((player) => [player.id.toString(), player.login, player.groupId]),
        editRoute: routes.editPlayer,
        maxPage,
        pageNumber
      }}
    />
  );
}


export default PlayersPage;