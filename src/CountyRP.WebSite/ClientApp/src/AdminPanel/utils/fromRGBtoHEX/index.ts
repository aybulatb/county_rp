export function fromRGBtoHEX(R: number, G: number, B: number) {
  let hexColor = '';

  [R, G, B].forEach(num => {
    const hexNum = num.toString(16)

    hexColor += hexNum.length > 1 ? hexNum : `0${hexNum}`;
  })

  return '#'+hexColor;
}