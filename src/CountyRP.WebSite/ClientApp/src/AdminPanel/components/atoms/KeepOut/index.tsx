import React from 'react';
import styled from 'styled-components';
import Sign from './KeepOut.jpg';

const Img = styled.div`
  width: 100%;
  height: 98%;

  background: url(${Sign});
  background-size: contain;
  background-repeat: no-repeat;
  background-position-x: center;

  animation: slide-up .4s ease;
`;


export default () => <Img />