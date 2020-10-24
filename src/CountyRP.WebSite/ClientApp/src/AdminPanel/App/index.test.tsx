import React from 'react'
import { shallow } from 'enzyme';
import App from 'AdminPanel/App';


describe('testing <App />', () => {
  it("renders without crashing", () => {
    shallow(<App />);
  });
});