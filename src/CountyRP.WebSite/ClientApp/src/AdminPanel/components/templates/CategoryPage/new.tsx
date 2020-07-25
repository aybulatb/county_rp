import React from 'react';
import Container from './__styled/Container';
import SearchButton from './__styled/SearchButton';
import ButtonsContainer from './__styled/ButtonsContainer';
import ArrowButton from './__styled/ArrowButton';
import Header3 from 'AdminPanel/components/atoms/Header3';
import FormContainer from 'AdminPanel/components/atoms/FormContainer';
import FormRow from 'AdminPanel/components/atoms/FormRow';
import HorizontalRule from 'AdminPanel/components/atoms/HorizontalRule';
import SearchResultsTable from 'AdminPanel/components/molecules/SearchResultsTable';
import Base from 'AdminPanel/components/templates/Base';


type CategoryPageProps = {
  topButtons?: React.ReactNode;
  inputRows: {
    name: string;
    innerComponent: React.ReactNode; 
  }[];
  searchTableProps: {
    headers: string[];
    searchResultsItems: string[][];
    editRoute: string;
    maxPage: number;
    currentPage: number;
    goToNextPage: () => void;
    goToPrevPage: () => void;
    search: () => void;
  }
}

function CategoryPage(props: CategoryPageProps) {
  const {
    topButtons,
    inputRows,
    searchTableProps
  } = props;

  return (
    <Base>
      <Container>
        {topButtons}
        <Header3>Фильтр</Header3>
        <FormContainer>
          {
            inputRows.map(({name, innerComponent}, key) => (
              <FormRow name={name} key={key}>
                {innerComponent}
              </FormRow>
            ))
          }
        </FormContainer>
        <SearchButton onClick={() => searchTableProps.search()}>
          Найти
        </SearchButton>
        <HorizontalRule />
        <SearchResultsTable
          {...searchTableProps}
        />
        <ButtonsContainer>
          <ArrowButton direction='back' onClick={searchTableProps.goToPrevPage} />
          <span>{searchTableProps.currentPage}..{searchTableProps.maxPage}</span>
          <ArrowButton direction='forward' onClick={searchTableProps.goToNextPage} />
        </ButtonsContainer>
      </Container>
    </Base>
  );
}


export default CategoryPage;