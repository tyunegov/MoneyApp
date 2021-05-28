import './SubMenu.scss'
import { Button, Nav} from 'react-bootstrap';
import { useState } from 'react';
import ModalTransaction from '../ModalTransaction/ModalTransaction';


export default function SubMenu() {
  const [isShow, setIsShow] = useState(false)

  function Modal(){
    return(
      isShow==true?
      <ModalTransaction transaction={null} title="Изменить" refIsHide={setIsShow}/>
      :null
    )
  }

  return (
    <Nav className="justify-content-end submenu" activeKey="/home">
          <Nav.Item>
          <Button variant="outline-primary" onClick={()=>setIsShow(true)}>
          Добавить
          </Button>         
          {Modal()}
          </Nav.Item>
    </Nav>
  );
}
