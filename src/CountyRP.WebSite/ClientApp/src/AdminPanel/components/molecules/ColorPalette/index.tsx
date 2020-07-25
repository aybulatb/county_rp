import React from 'react';
import styled from 'styled-components';
import { invertColor } from 'AdminPanel/utils/invertColor';
import { fromRGBtoHEX } from 'AdminPanel/utils/fromRGBtoHEX';


const Container = styled.div`
  border: 1px solid #a0a0a0;
  border-radius: 4px;
  display: inline-flex;
`;

const ColorBlock = styled.button<{ hexColor: string }>`
  display: block;
  width: 21px;
  height: 21px;
  margin: 4.5px 3px;
  border: none;

  &:focus {
    outline: 2px solid ${props => invertColor(props.hexColor)};
  }

  background: ${props => props.hexColor};
  cursor: pointer;
`;

const Column = styled.div`
  display: inline-block;
`;


export default ({ setColor, className }: { setColor: Function; className?: string }) => {
  const baseColors = [
    [0, 0, 0],
    [255, 0, 0],
    [255, 165, 0],
    [255, 255, 0],
    [0, 128, 0],
    [0, 0, 255],
    [75, 0, 130],
    [238, 130, 238]
  ];

  const getGradation = (R: number, G: number, B: number) => {
    const gradations = [{ R, G, B }];
    const rStep = Math.round((255 - R) / 7);
    const gStep = Math.round((255 - G) / 7);
    const bStep = Math.round((255 - B) / 7);

    for (let i = 0; i < 6; i++) {
      R += rStep;
      G += gStep;
      B += bStep;

      gradations.push({ R, G, B });
    }

    return gradations;
  }


  const handleClick = (R: number, G: number, B: number) => {
    setColor("#" + fromRGBtoHEX(R, G, B));
  }


  return (
    <Container className={className}>
      {
        baseColors.map((item, columnKey) => (
          <Column key={columnKey}>
            {
              getGradation(item[0], item[1], item[2]).map((color, key) => (
                <ColorBlock
                  key={key}
                  hexColor={fromRGBtoHEX(color.R, color.G, color.B)}
                  onClick={() => handleClick(color.R, color.G, color.B)}
                />
              ))
            }
          </Column>
        ))
      }
    </Container>
  )
}

