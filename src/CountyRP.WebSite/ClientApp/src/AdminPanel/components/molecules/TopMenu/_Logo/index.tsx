import styled from 'styled-components';
import { makeColorFromString } from './makeColorFromString';
import { invertColor } from 'AdminPanel/utils/invertColor'


type AvatarProps = {
  children: React.ReactText
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

  background: #${props => makeColorFromString(String(props.children))};
  color: #${props => invertColor(makeColorFromString(String(props.children)))}
`;


export default TopMenuLogo;