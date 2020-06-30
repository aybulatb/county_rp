import React from "react";
import RowContainer from './_RowContainer';
import Input from 'AdminPanel/components/atoms/Input';


type FilterInputProps = {
  value: string
  setValue: Function
  children: React.ReactNode
}

export default ({ children, value, setValue }: FilterInputProps) => (
  <RowContainer>
    {children}
    <Input
      value={value}
      setValue={setValue}
    />
  </RowContainer>
)