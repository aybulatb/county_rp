import React from 'react';
import Checkbox from './index';
import renderer from 'react-test-renderer';
import { mount } from 'enzyme';
import "jest-styled-components";
import { colors } from 'AdminPanel/variables';


describe('Testing <Checkbox />', () => {
  const checkedProps = {
    handleCheck: () => { },
    id: 'test',
    checked: true
  }

  const uncheckedProps = {
    handleCheck: () => { },
    id: 'test',
    checked: false
  }

  it('matches snapshot', () => {
    const component = <Checkbox {...checkedProps} />;
    const tree = renderer.create(component).toJSON();
    expect(tree).toMatchSnapshot();
  });

  it("has a blue mark when checked", () => {
    const checkbox = mount(<Checkbox {...checkedProps} />);
    const mark = checkbox.children().find('label').children();
    expect(mark).toHaveStyleRule('background', colors.blue);
  });

  it('has a white mark when not checked', () => {
    const checkbox = mount(<Checkbox {...uncheckedProps} />);
    const mark = checkbox.children().find('label').children();
    expect(mark).toHaveStyleRule('background', 'white');
  });
});