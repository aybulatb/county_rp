import styled from 'styled-components';
import { colors } from 'AdminPanel/variables';


const BlueButton = styled.button`
  padding: 13px 26px;
  
  border: none;
  border-radius: 7px;

  background: ${colors.blue};  
  color: white;
  font-size: 15px;
  font-weight: bold;
  text-decoration: none;
  cursor: pointer;
  outline: none;

  &:hover {
    background: ${colors.blueGradient};
  }
`;


export default BlueButton;