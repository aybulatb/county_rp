import React from 'react';
import Input, {InputProps} from 'AdminPanel/components/atoms/Input';
import { mount } from 'enzyme';


const inputProps: InputProps = {
  type: "text",
  value: 'test',
  setValue: (value:  string) => {
    inputProps.value = value
  },
  color: '#000000'
}


describe("Input", () => {
  it("accepts input props", () => {
    const wrapper = mount<InputProps>(<Input {...inputProps} />);
    expect(wrapper.props().type).toEqual(inputProps.type);
    expect(wrapper.props().value).toEqual(inputProps.value);
    expect(wrapper.props().color).toEqual(inputProps.color);
  });

  it.skip("reacts to setValue", () => {
    const wrapper = mount<InputProps>(<Input {...inputProps} />);
    inputProps.setValue('test2')
    expect(wrapper.props().value).toEqual("test2");
  });
});