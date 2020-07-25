import React from 'react';
import styled from 'styled-components';
import { makeColorFromString } from 'AdminPanel/utils/makeColorFromString';
import { invertColor } from 'AdminPanel/utils/invertColor';


type AvatarProps = {
  textColor: string;
  backgroundColor: string;
  children: React.ReactText;
}

const TopMenuLogo = styled.div<AvatarProps>`
  display: flex;
  justify-content: center;
  align-items: center;
  
  min-width: 50px;
  min-height: 50px;
  max-width: 50px;
  max-height: 50px;
  border-radius: 50%;
  margin: 0 15px;
  font-weight: bold;
  font-size: 24px;

  background: ${props => props.backgroundColor};
  color: ${props => props.textColor};
`;

export default ({ className, children }: {
  className?: string;
  children: React.ReactText;
}) => {
  const text = children.toString();
  const backgroundColor = makeColorFromString(text);
  const textColor = invertColor(backgroundColor);

  return (
    <TopMenuLogo className={className} textColor={textColor} backgroundColor={backgroundColor}>
      {text.slice(0, 2).toUpperCase()}
    </TopMenuLogo>
  )
};