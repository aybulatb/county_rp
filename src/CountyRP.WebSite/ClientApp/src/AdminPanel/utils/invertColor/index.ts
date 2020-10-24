export function invertColor(hexColor: string) {
  if (hexColor[0] !== '#')
    throw new Error('Wrong hex color string format (missing "#" at the start): '+ hexColor);
  
  const cuttedHex = hexColor.slice(1);

  return '#'+(Number(`0x1${cuttedHex}`) ^ 0xFFFFFF).toString(16).substr(1)
}