import React from 'react';
import styled from 'styled-components';

import FormContainer from 'AdminPanel/components/atoms/FormContainer';
import FormRow from 'AdminPanel/components/atoms/FormRow'
import Header3 from 'AdminPanel/components/atoms/Header3';
import Base from 'AdminPanel/components/templates/Base';


const Container = styled.div`
  margin-top: 50px;
  padding: 1px 50px 20px 20px;
  width: 93%;
  margin-left: 3.5%;
  background: white;
  border-radius: 12px;
  animation: slide-down 0.4s ease;
`;

const ButtonsWrapper = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
`;


type EditPageProps = {
  pageName: string
  inputRows: {
    name: string
    innerElement: React.ReactNode
  }[]
  buttons: React.ReactNode
}

export default ({pageName, inputRows, buttons}: EditPageProps) => {
  return (
    <Base>
      <Container>
        <Header3>{pageName}</Header3>

        <FormContainer>
          {
            inputRows.map((row, key) => (
              <FormRow name={row.name} key={key}>
                {row.innerElement}
              </FormRow>    
            ))
          }
        </FormContainer>

        <ButtonsWrapper>
          {buttons}
        </ButtonsWrapper>
      </Container>
    </Base>
  )
}