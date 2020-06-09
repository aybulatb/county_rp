import React from 'react';
import PageContainer from './_PageContainer';


const BaseTemplate: React.FC = ({ children }) => (
  <PageContainer>
    {children}
  </PageContainer>
)


export default BaseTemplate;