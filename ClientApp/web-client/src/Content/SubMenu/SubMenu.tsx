import React from 'react';
import './SubMenu.scss'
import { Nav, Button} from 'react-bootstrap';
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
