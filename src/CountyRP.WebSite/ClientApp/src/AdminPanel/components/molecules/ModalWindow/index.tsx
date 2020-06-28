import React from "react";
import { useHistory } from 'react-router-dom';
import styled from 'styled-components';


const Wrapper = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  height: 100vh;
`;


const Background = styled.div`
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: 25;
  height: 100vh;

  background: #0000006e;
  cursor: pointer;
`;

const Window = styled.div`
  z-index: 26;

  background: white;
  border-radius: 7px;
  animation: slide-up 0.4s ease;
`;


type ModalProps = {
  children: React.ReactNode
  prevLocation: string
}

export default ({ children, prevLocation }: ModalProps) => {
  const body = document.getElementsByTagName("BODY")[0] as HTMLElement;
  body.style.overflowY = "hidden";
  const history = useHistory();

  const closeHandler = () => {
    history.push(prevLocation);
    body.style.overflowY = "auto";
  }

  return (
    <Wrapper>
      <Background onClick={closeHandler}>
      </Background>
      <Window>
        {children}
      </Window>
    </Wrapper>
  )
}