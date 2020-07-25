import React from 'react';
import styled from 'styled-components';
import { colors } from 'AdminPanel/variables';
import { invertColor } from 'AdminPanel/utils/invertColor';


const StyledInput = styled.input<{color?: string}>`
  height: 38px;
  width: 220px;
  border-radius: 6px;
  border: 1px solid ${colors.gray};
  outline: none;
  padding-left: 7px;
  box-sizing: border-box;
  display: block;
  color: ${props => invertColor(props.color || '#ffffff')};
  background: ${props => props.color || 'white'};
`;


export type InputProps = {
  type?: 'text' | 'password'
  value: string | number
  setValue: Function
  color?: string
}

export default ({ value, setValue, type, color }: InputProps) => (
  <StyledInput
    color={color}
    type={type || 'text'}
    value={value}
    onChange={(event) => setValue(event.target.value)}
  />
);