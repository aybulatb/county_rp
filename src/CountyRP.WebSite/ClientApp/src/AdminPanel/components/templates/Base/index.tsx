import React from 'react';
import TopMenu from 'AdminPanel/components/molecules/TopMenu';
import LeftPanel from 'AdminPanel/components/organisms/LeftPanel';
import PageContainer from 'AdminPanel/components/atoms/PageContainer';
import PageMainPart from 'AdminPanel/components/atoms/PageMainPart';
import ContentWrapper from 'AdminPanel/components/atoms/PageContentWrapper';


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