import styled from 'styled-components';


const TableRow = styled.tr`
  height: 65px;

  & > td {
    color: blue;
  }

  animation: slide-down 0.4s ease;
`;


export default TableRow;