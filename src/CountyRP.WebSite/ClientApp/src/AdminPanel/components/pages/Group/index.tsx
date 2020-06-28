import React, { useState } from "react";
import styled from 'styled-components';
import { NavLink } from 'react-router-dom';
import Base from 'AdminPanel/components/templates/Base';
import Input from 'AdminPanel/components/atoms/Input';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import SearchResultsTable from './SearchResultsTable';
import HorizontalRule from 'AdminPanel/components/atoms/HorizontalRule';
import Header3 from 'AdminPanel/components/atoms/Header3';
import FormContainer from 'AdminPanel/components/atoms/FormContainer';
import FormRow from 'AdminPanel/components/atoms/FormRow'
import { getGroupsFilterBy } from 'AdminPanel/services/group/getGroupsFilterBy';


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


type Group = {
  id: string
  name: string
  color?: string
}

export default () => {
  const [groups, setGroups] = useState<Group[]>([]);
  const [pageNumber, setPageNumber] = useState(1);
  // const [groupsAmout, setGroupsAmount] = useState(0);
  const [maxPage, setMaxPage] = useState(1);
  const [groupId, setGroupId] = useState('');
  const [groupName, setGroupName] = useState('');


  const handleSearch = async (numberOfPage: number, idOfGroup: string, nameOfGroup: string) => {
    try {
      const response = await getGroupsFilterBy(numberOfPage, idOfGroup, nameOfGroup);

      setGroups(response.groups);
      // setGroupsAmount(response.allAmount);
      setMaxPage(response.maxPage);
      setPageNumber(response.page);
    } catch (error) {
      console.log(error);
    }
  }

  const handleForwardButton = () => {
    const nextPageNumber = pageNumber < maxPage ? pageNumber + 1 : pageNumber;
    handleSearch(nextPageNumber, groupId, groupName);
  }

  const handleBackButtton = () => {
    const previousPageNumber = pageNumber > 1 ? pageNumber - 1 : pageNumber;
    handleSearch(previousPageNumber, groupId, groupName);
  }

  return <Base>
    <Container>
      <BlueButton as={NavLink} to='/admin/group/create' >Создать</BlueButton>
      <Header3>Фильтр</Header3>

      <FormContainer>
        <FormRow name='ID'>
          <Input value={groupId} setValue={setGroupId} />
        </FormRow>

        <FormRow name='Имя группы'>
          <Input value={groupName} setValue={setGroupName} />
        </FormRow>
      </FormContainer>

      <SearchButton onClick={() => handleSearch(pageNumber, groupId, groupName)}>
        Найти
      </SearchButton>
      <HorizontalRule />
      <SearchResultsTable
        searchResultsItems={groups}
      />
      <ButtonsContainer>
        <BackButton onClick={handleBackButtton} />
        <span>{pageNumber}..{maxPage}</span>
        <ForwardButton onClick={handleForwardButton} />
      </ButtonsContainer>
    </Container>
  </Base>
}