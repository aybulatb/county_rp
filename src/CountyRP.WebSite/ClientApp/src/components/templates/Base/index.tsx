import React from 'react';
import styled from 'styled-components';

import TopMenu from 'components/molecules/TopMenu';
import LeftPanel from 'components/organisms/LeftPanel';


const PageContainer = styled.div`
  display: flex;
  flex-direction: row;
  
  width: 100vw;
  min-height: 100vh; 

  background: #ccc;
`;

const PageMainPart = styled.div`
  display: flex;
  flex-direction: column;

  width: 100%;
  min-height: 100vh;
`;

const ContentWrapper = styled.div`
  width: 100%;
  height: 100%;

  overflow: auto;
`;


type PageProps = {
  children: React.ReactNode;
}

const Page = (props: PageProps) => (
  <PageContainer>
    <LeftPanel />
    <PageMainPart>
      <TopMenu />
      <ContentWrapper>
        {props.children}
      </ContentWrapper>
    </PageMainPart>
  </PageContainer>
)


export default Page;