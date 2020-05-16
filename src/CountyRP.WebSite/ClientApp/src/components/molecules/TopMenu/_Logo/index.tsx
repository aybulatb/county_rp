import styled from 'styled-components';
import { makeColorFromString } from './makeColorFromString';
import { invertColor } from './invertColor'


type AvatarProps = {
  children: React.ReactText
}

const TopMenuLogo = styled.div<AvatarProps>`
  min-height: 50px;
  max-height: 50px;
  min-width: 50px;
  max-width: 50px;

  border-radius: 50%;

  background: ${props => makeColorFromString(String(props.children))};
  color: ${props => invertColor(makeColorFromString(String(props.children)))}
`;


export default TopMenuLogo;