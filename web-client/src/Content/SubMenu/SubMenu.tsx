import './SubMenu.scss'
import { Button, Nav} from 'react-bootstrap';
import { useState } from 'react';
import ModalTransaction from '../../Components/ModalTransaction/ModalTransaction';
import { Title } from '../../Components/ModalTransaction/ModalTransactionHelper';
import { postTransaction } from '../../Requests/Transaction';
import { ITransaction } from '../../Models/ITransaction';


export default function SubMenu() {
  const [isShow, setIsShow] = useState(false);

  function Modal(){
    return(
      isShow===true?
      <ModalTransaction transaction={null} title={Title.Add} refIsHide={setIsShow} refTransaction={postTransaction}/>
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
