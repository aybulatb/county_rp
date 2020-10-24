import React, { useEffect, useState, useCallback } from 'react';
import styled from 'styled-components';
import Portal from './Portal';
import { colors } from 'AdminPanel/variables';
import { eventEmitter } from 'AdminPanel/eventEmitter';


export type NotificationMsg = {
  header: string;
  content: string;
  type?: NotificationType
}

type NotificationType = 'info' | 'error';

export const notificationEvent = 'event-notification';

const NotificationTray = () => {
  const [messages, setMessages] = useState<NotificationMsg[]>([]);

  const closeNotification = useCallback((index: number) => {
    setMessages([...messages.slice(0, index), ...messages.slice(index + 1)]);
  }, [messages]);

  const onClick = (index: number) => {
    closeNotification(index);
  }

  useEffect(() => {
    const unsubscribe = eventEmitter.subscribe<NotificationMsg>(notificationEvent, (data) => {
      setMessages([...messages, data]);
    });

    return () => {
      unsubscribe();
    }
  });

  useEffect(() => { 
    const timer = setTimeout(() => { 
      closeNotification(0);
    }, 10000);

    return () => clearTimeout(timer);
  }, [closeNotification, messages]);

  return (
    <Portal>
      <TrayContainer>
        {
          messages.map((msg, index) => (
            <NotificationBlock
              {...msg}
              key={index}
              onClick={() => onClick(index)}
            />
          ))
        }
      </TrayContainer>  
    </Portal>
  )
}

const TrayContainer = styled.div`
  position: absolute;
  left: 50%;
  bottom: 0;
  display: flex;
  flex-direction: column;
  overflow: hidden;

  transform: translateX(-50%);
`;


const NotificationBlock = ({header, content, onClick, type}: NotificationMsg & {onClick: Function}) => {
  return (
    <NotificationContainer onClick={() => onClick()} type={type}>
      <h3>{header}</h3>
      {content}
    </NotificationContainer>
  );
}


const NotificationContainer = styled.div<{type?: NotificationType}>`
  min-width: 300px;

  margin-bottom: 10px;
  padding: 20px;
  border-radius: 10px;

  color: white;
  background: ${props => props.type === 'error' ? colors.redGradient : colors.blueGradient};

  text-align: center;
  user-select: none;
  cursor: pointer;

  animation: slide-up .4s ease;

  & > h3 {
    margin-bottom: 6px;
  }

  @keyframes move {
    0% {
      transform: translateY(50%);
    }

    100% {
      transform: translateY(0%);
    }
  }
`;


export default NotificationTray;