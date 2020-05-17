import React from 'react';

import TopMenu from 'components/molecules/TopMenu';
import LeftPanel from 'components/organisms/LeftPanel';
import PageContainer from 'components/atoms/PageContainer';
import PageMainPart from 'components/atoms/PageMainPart';
import ContentWrapper from 'components/atoms/PageContentWrapper';


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