import styled from 'styled-components';
import { colors } from 'AdminPanel/variables';


const CheckboxMarkContainer = styled.label`
  display: inline-block;

  width: 20px;
  height: 20px;

  padding: 2px;
  margin-right: 10px;
  border: 1px solid ${colors.gray};
  border-radius: 5px;
  background-color: white;
  box-sizing: border-box;

  outline: none;

  cursor: pointer;
`;


export default CheckboxMarkContainer;