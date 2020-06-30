import styled from 'styled-components';


const CheckboxContainer = styled.div`
  display: flex;
  flex-direction: row;
  align-items: center;

  & input[type='checkbox'] {
    display: none;
    outline: none;
  }
`;


export default CheckboxContainer;