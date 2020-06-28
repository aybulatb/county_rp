import React, { useEffect } from 'react';
import { observer } from 'mobx-react';
import { useHistory } from 'react-router-dom';
import TopMenu from 'AdminPanel/components/molecules/TopMenu';
import LeftPanel from 'AdminPanel/components/organisms/LeftPanel';
import PageContainer from 'AdminPanel/components/atoms/PageContainer';
import PageMainPart from 'AdminPanel/components/atoms/PageMainPart';
import ContentWrapper from 'AdminPanel/components/atoms/PageContentWrapper';

import { useStore } from 'AdminPanel/stores';


type PageProps = {
  children: React.ReactNode;
}

const Page = observer((props: PageProps) => {
  const { playerInfoStore } = useStore();
  const history = useHistory();
  const isAuthorized = playerInfoStore.isAuthorized;

  useEffect(() => {
    if (!isAuthorized) {
      history.push('/admin/Auth');
    }
  }, [history, isAuthorized]);

  return (
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
})


export default Page;