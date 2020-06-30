import React, { useState } from "react";
import styled from 'styled-components';
import { NavLink } from "react-router-dom";

import Base from 'AdminPanel/components/templates/Base';
import Input from 'AdminPanel/components/atoms/Input';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import SearchResultsTable from 'AdminPanel/components/molecules/SearchResultsTable';
import HorizontalRule from 'AdminPanel/components/atoms/HorizontalRule';
import Header3 from 'AdminPanel/components/atoms/Header3';
import FormContainer from 'AdminPanel/components/atoms/FormContainer';
import FormRow from 'AdminPanel/components/atoms/FormRow'
import { getFactionFilterBy } from 'AdminPanel/services/faction/getFactionFilterBy';
import { routes } from 'AdminPanel/routes';
import { Faction } from 'AdminPanel/services/faction/Faction';


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


export default () => {
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
      console.log(error);
    }
  }

  const handleForwardButton = () => {
    const nextPageNumber = pageNumber < maxPage ? pageNumber + 1 : pageNumber;
    handleSearch(nextPageNumber);
  }

  const handleBackButtton = () => {
    const previousPageNumber = pageNumber > 1 ? pageNumber - 1 : pageNumber;
    handleSearch(previousPageNumber);
  }

  return <Base>
    <Container>
      <BlueButton as={NavLink} to={routes.createFaction}>Создать</BlueButton>
      <Header3>Фильтр</Header3>

      <FormContainer>
        <FormRow name='ID'>
          <Input value={factionId} setValue={setFactionId} />
        </FormRow>

        <FormRow name='Имя'>
          <Input value={factionName} setValue={setFactionName} />
        </FormRow>
      </FormContainer>

      <SearchButton onClick={() => handleSearch(pageNumber)}>
        Найти
      </SearchButton>
      <HorizontalRule />
      <SearchResultsTable
        headers={['ID', 'Имя','Тип']}
        searchResultsItems={factions.map((faction) => (
          [faction.id, faction.name, faction.type.toString()]
        ))}
        editRoute={routes.editFaction}
      />
      <ButtonsContainer>
        <BackButton onClick={handleBackButtton} />
        <span>{pageNumber}..{maxPage}</span>
        <ForwardButton onClick={handleForwardButton} />
      </ButtonsContainer>
    </Container>
  </Base>
}