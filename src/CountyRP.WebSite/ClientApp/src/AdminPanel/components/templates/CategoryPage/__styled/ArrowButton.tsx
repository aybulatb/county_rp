import styled from "styled-components";


const ArrowButton = styled.button<{direction: 'forward' | 'back'}>`
  width: 15px;
  height: 15px;

  border: none;
  border-top: 2px blue solid;
  border-right: 2px blue solid;
  outline: none;

  background: none;

  transform: rotate(${props => props.direction === 'forward' ? '45' : '-135'}deg);

  cursor: pointer;
`;


export default ArrowButton;