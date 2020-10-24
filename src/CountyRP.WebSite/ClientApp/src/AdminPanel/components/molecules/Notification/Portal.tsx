import React, { useEffect } from 'react';
import ReactDOM from 'react-dom';


const Portal = ({ children }: { children: React.ReactNode }) => {
  const container = document.createElement('div');

  useEffect(() => {
    const portalNode = document.getElementById('portal');
    portalNode?.appendChild(container);

    return () => {
      portalNode?.removeChild(container);
    }
  }, [container]);
  
  return ReactDOM.createPortal(
    children,
    container
  );
}


export default Portal;