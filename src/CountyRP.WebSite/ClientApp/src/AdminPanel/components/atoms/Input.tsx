import React from 'react';
import styled from 'styled-components';
import { colors } from 'AdminPanel/variables';


const StyledInput = styled.input`
  height: 38px;
  width: 220px;
  border-radius: 6px;
  border: 1px solid ${colors.gray};
  outline: none;
  padding-left: 7px;
  box-sizing: border-box;
  display: block;
`;


type InputProps = {
  type?: 'text' | 'password'
  value: string
  setValue: Function
}

export default ({ value, setValue, type }: InputProps) => (
  <StyledInput
    type={type || 'text'}
    value={value}
    onChange={(event) => setValue(event.target.value)}
  />
);