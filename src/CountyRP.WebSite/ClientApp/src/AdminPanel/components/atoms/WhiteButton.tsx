import styled from 'styled-components';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import { colors as Colors } from 'AdminPanel/variables';

const WhiteButton = styled(BlueButton)`
  border: 2px ${Colors.gray} solid;
  color: ${Colors.gray};
  background: white;

  &:hover {
    color: ${Colors.blue};
    background: white;
    border: 2px ${Colors.blue} solid;
  }
`;

export default WhiteButton;