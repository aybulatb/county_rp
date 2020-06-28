import styled from 'styled-components';
import { colors } from 'AdminPanel/variables';


export type CheckBoxMarkProps = {
  checked: boolean
}

const CheckBoxMark = styled.div<CheckBoxMarkProps>`
  width: 100%;
  height: 100%;
  border-radius: 2px;

  background: ${props => props.checked ? colors.blue : 'white'};

  transition: all .3s ease;
`;


export default CheckBoxMark;
