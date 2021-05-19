import './SubMenu.scss'
import { Nav} from 'react-bootstrap';
import AddTransaction from '../AddTransaction/AddTransaction';

function SubMenu() {
  return (
    <Nav className="justify-content-end submenu" activeKey="/home">
          <Nav.Item>
          <AddTransaction/>
          </Nav.Item>
    </Nav>
  );
}

export default SubMenu;
