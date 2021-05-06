import React from 'react';
import './SubMenu.scss'
import { Nav, Button} from 'react-bootstrap';

function SubMenu() {
  return (
    <Nav className="justify-content-end submenu" activeKey="/home">
          <Nav.Item>
          <Button variant="outline-primary">Добавить</Button>
          </Nav.Item>
    </Nav>
  );
}

export default SubMenu;
