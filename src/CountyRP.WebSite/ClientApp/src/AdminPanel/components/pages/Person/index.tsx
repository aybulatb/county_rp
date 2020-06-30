import React, { useState } from "react";
import styled from 'styled-components';
import Base from 'AdminPanel/components/templates/Base';
import Input from 'AdminPanel/components/atoms/Input';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import SearchResultsTable from 'AdminPanel/components/molecules/SearchResultsTable';
import HorizontalRule from 'AdminPanel/components/atoms/HorizontalRule';
import Header3 from 'AdminPanel/components/atoms/Header3';
import FormContainer from 'AdminPanel/components/atoms/FormContainer';
import FormRow from 'AdminPanel/components/atoms/FormRow'
import { getPersonFilterBy } from 'AdminPanel/services/person/getPersonFilterBy';
import { routes } from 'AdminPanel/routes';
import { Person } from 'AdminPanel/services/person/Person';


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
  const [personName, setPersonName] = useState('');

  const [persons, setPersons] = useState<Person[]>([]);
  const [pageNumber, setPageNumber] = useState(1);
  const [maxPage, setMaxPage] = useState(1);

  const handleSearch = async (numberOfPage: number, name: string) => {
    try {
      const response = await getPersonFilterBy(numberOfPage, name);

      setPersons(response.items);
      setMaxPage(response.maxPage);
      setPageNumber(response.page);
    } catch (error) {
      console.log(error);
    }
  }

  const handleForwardButton = () => {
    const nextPageNumber = pageNumber < maxPage ? pageNumber + 1 : pageNumber;
    handleSearch(nextPageNumber, personName);
  }

  const handleBackButtton = () => {
    const previousPageNumber = pageNumber > 1 ? pageNumber - 1 : pageNumber;
    handleSearch(previousPageNumber, personName);
  }

  return <Base>
    <Container>
      <Header3>Фильтр</Header3>

      <FormContainer>
        <FormRow name='Имя'>
          <Input value={personName} setValue={setPersonName} />
        </FormRow>
      </FormContainer>

      <SearchButton onClick={() => handleSearch(pageNumber, personName)}>
        Найти
      </SearchButton>
      <HorizontalRule />
      <SearchResultsTable
        headers={['ID', 'Имя', 'Фракция', 'Ранг', 'ID группы']}
        searchResultsItems={persons.map((person) => (
          [person.id.toString(), person.name, person.factionId, person.rank.toString(), person.groupId]
        ))}
        editRoute={routes.editPerson}
      />
      <ButtonsContainer>
        <BackButton onClick={handleBackButtton} />
        <span>{pageNumber}..{maxPage}</span>
        <ForwardButton onClick={handleForwardButton} />
      </ButtonsContainer>
    </Container>
  </Base>
}