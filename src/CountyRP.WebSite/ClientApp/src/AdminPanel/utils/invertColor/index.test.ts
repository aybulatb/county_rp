import { invertColor } from 'AdminPanel/utils/invertColor';


describe('utils: test "invertColor"', () => {
  it('inverts HEX color successfully', () => {
    expect(invertColor('#000000')).toBe('#ffffff');
    expect(invertColor('#ffffff')).toBe('#000000');
    expect(invertColor('#7fffd4')).toBe('#80002b');
    expect(invertColor('#4b0082')).toBe('#b4ff7d');
  });
});