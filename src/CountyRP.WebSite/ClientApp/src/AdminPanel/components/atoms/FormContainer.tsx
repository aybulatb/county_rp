import React from 'react';


const FormContainer = ({ children }: { children: React.ReactNode }) => (
  <table>
    <tbody>
      {children}
    </tbody>
  </table>
)


export default FormContainer;