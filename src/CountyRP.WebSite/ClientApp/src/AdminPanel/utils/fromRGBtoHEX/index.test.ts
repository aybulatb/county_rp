import { fromRGBtoHEX } from 'AdminPanel/utils/fromRGBtoHEX';


describe('utils: test "fromRGBtoHEX"', () => {
  it('convert from RGB to HEX successfully', () => {
    expect(fromRGBtoHEX(127, 255, 212)).toBe('#7fffd4');
    expect(fromRGBtoHEX(75, 0, 130)).toBe('#4b0082');
    expect(fromRGBtoHEX(0, 0, 0)).toBe('#000000');
    expect(fromRGBtoHEX(255, 255, 255)).toBe('#ffffff');
  });
});