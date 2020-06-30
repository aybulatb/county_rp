import React from 'react';
import styled from 'styled-components';


type TDprops = {
  verticalAlign?: string
}

const TD = styled.td<TDprops>`
  vertical-align: ${props => props.verticalAlign || 'middle'};
  padding-bottom: 15px;
  padding-right: 15px;
`;


type FormRowProps = {
  name: string
  children: React.ReactNode
}

export default ({ name, children, verticalAlign }: FormRowProps & TDprops) => (
  <tr>
    <TD {...{ verticalAlign }}>{name}</TD>
    <TD {...{ verticalAlign }}>{children}</TD>
  </tr>
)