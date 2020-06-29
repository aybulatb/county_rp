import React, { useState } from "react";
import styled from 'styled-components';
import { NavLink } from 'react-router-dom';
import Base from 'AdminPanel/components/templates/Base';
import Input from 'AdminPanel/components/atoms/Input';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import SearchResultsTable from 'AdminPanel/components/molecules/SearchResultsTable';
import HorizontalRule from 'AdminPanel/components/atoms/HorizontalRule';
import Header3 from 'AdminPanel/components/atoms/Header3';
import FormContainer from 'AdminPanel/components/atoms/FormContainer';
import FormRow from 'AdminPanel/components/atoms/FormRow'
import { getPlayersFilterBy } from 'AdminPanel/services/player/getPlayersFilterBy';
import { routes } from 'AdminPanel/routes';


const Container = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: flex-start;

  box-sizing: border-box;
  padding: 50px;
`;

const SearchButton = styled(BlueButton)`
  margin-left: auto;
  margin-right: 40px;
`;

const ForwardButton = styled.button`
  width: 15px;
  height: 15px;

  border: none;
  border-top: 2px blue solid;
  border-right: 2px blue solid;
  outline: none;

  background: none;

  transform: rotate(45deg);

  cursor: pointer;
`;

const BackButton = styled(ForwardButton)`
  transform: rotate(-135deg);
`;

const ButtonsContainer = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
  width: 100%;
  margin-top: 25px;
  padding-right: 29px;
  color: blue;
`;


type Player = {
  id: number
  login: string
  groupId: string
}

export default () => {
  const [username, setUsername] = useState('');
  const [characterName, setCharacterName] = useState('');
  const [players, setPlayers] = useState<Player[]>([]);
  const [pageNumber, setPageNumber] = useState(1);
  const [maxPage, setMaxPage] = useState(1);


  const handleSearch = async (numberOfPage: number, name: string) => {
    try {
      const response = await getPlayersFilterBy(numberOfPage, name);

      setPlayers(response.items);
      setMaxPage(response.maxPage);
      setPageNumber(response.page);
    } catch (error) {
      console.log(error);
    }
  }

  const handleForwardButton = () => {
    const nextPageNumber = pageNumber < maxPage ? pageNumber + 1 : pageNumber;
    handleSearch(nextPageNumber, username);
  }

  const handleBackButtton = () => {
    const previousPageNumber = pageNumber > 1 ? pageNumber - 1 : pageNumber;
    handleSearch(previousPageNumber, username);
  }

  return <Base>
    <Container>
      <BlueButton as={NavLink} to={routes.createPlayer}>Создать</BlueButton>
      <Header3>Фильтр</Header3>

      <FormContainer>
        <FormRow name='Логин'>
          <Input value={username} setValue={setUsername} />
        </FormRow>

        <FormRow name='Имя персонажа'>
          <Input value={characterName} setValue={setCharacterName} />
        </FormRow>
      </FormContainer>

      <SearchButton onClick={() => handleSearch(pageNumber, username)}>
        Найти
      </SearchButton>
      <HorizontalRule />
      <SearchResultsTable
        headers={['ID', 'Логин', 'Группа']}
        searchResultsItems={players.map((player) => [player.id.toString(), player.login, player.groupId])}
        editRoute={routes.editPlayer}
      />
      <ButtonsContainer>
        <BackButton onClick={handleBackButtton} />
        <span>{pageNumber}..{maxPage}</span>
        <ForwardButton onClick={handleForwardButton} />
      </ButtonsContainer>
    </Container>
  </Base>
}