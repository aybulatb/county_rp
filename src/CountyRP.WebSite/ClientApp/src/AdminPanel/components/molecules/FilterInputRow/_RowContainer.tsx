import styled from 'styled-components';


const RowContainer = styled.label`
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;

  width: 320px;
  margin-right: 80px;
  
  color: #4a4a4a;

  &:last-child {
    margin-bottom: 0;
  }

  & + & {
    margin-top: 25px;
  }
`;

export default RowContainer;