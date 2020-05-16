import styled from 'styled-components';
import { NavLink } from 'react-router-dom';


const activeClassName = 'nav-item-active';

const SidePanelRow = styled(NavLink).attrs({
  activeClassName
})`
  display: flex;
  align-items: center;
  padding-left: 21px;
  border-left: 5px solid transparent;

  color: white;
  height: 45px;

  font-family: 'Roboto', sans-serif;
  font-style: normal;
  font-weight: normal;
  font-size: 14px;
  line-height: 18px;

  text-decoration: none;

  cursor: pointer;

  &.${activeClassName} {
    border-left: 5px solid #FFFFFF;
    background:  rgb(73, 92, 172);
  }
`;


// type SidePanelRowProps = {
//   path: string
//   children: React.ReactText
// }

// export default ({ children, path }: SidePanelRowProps) => {
//   return (
//     <SidePanelRow to={path}>
//       {children}
//     </SidePanelRow>
//   )
// }

export default SidePanelRow;