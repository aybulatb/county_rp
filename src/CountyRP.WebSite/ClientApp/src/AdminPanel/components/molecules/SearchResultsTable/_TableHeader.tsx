import styled from 'styled-components';


const TableHeader = styled.th<{ width?: string }>`
  width: ${props => props.width ? props.width : ''};
  text-align: left;
  color: #9a9b9e;
`;


export default TableHeader;