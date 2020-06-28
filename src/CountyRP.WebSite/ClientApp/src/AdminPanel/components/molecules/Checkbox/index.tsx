import React from 'react';
import CheckboxContainer from './CheckboxContainer';
import CheckboxMarkContainer from './CheckboxMarkContainer';
import CheckboxMark, { CheckBoxMarkProps } from './CheckboxMark';


type CheckboxProps = {
  className?: string
  children?: React.ReactNode
  handleCheck: (event: React.ChangeEvent<HTMLInputElement>) => void
  id: string
}

const Checkbox = (props: CheckboxProps & CheckBoxMarkProps) => {

  return <CheckboxContainer className={props.className}>
    {props.children}

    <input
      type='checkbox'
      id={props.id}
      checked={props.checked}
      onChange={props.handleCheck}
    />

    <CheckboxMarkContainer htmlFor={props.id}>
      <CheckboxMark checked={props.checked} />
    </CheckboxMarkContainer>

  </CheckboxContainer>
}


export default Checkbox;
