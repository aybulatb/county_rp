import styled from 'styled-components';


const TableWrapper = styled.div`
  border-radius: 10px;
  width: 100%;
  height: 100%;
  padding: 10px 40px;
  box-sizing: border-box;
  background: white;

  & > table {
    width: 100%;
    border-collapse: collapse;
  }
`;

export default TableWrapper;