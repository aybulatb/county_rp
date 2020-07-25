import React from 'react';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import { shallow } from 'enzyme';


it("renders without crashing", () => {
  shallow(<BlueButton />);
});