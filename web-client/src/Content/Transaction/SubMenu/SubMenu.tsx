import './SubMenu.scss'
import { Button, Nav} from 'react-bootstrap';
import { useState } from 'react';
import ModalTransaction from '../../../Components/ModalTransaction/ModalTransaction';
import { Title } from '../../../Components/ModalTransaction/ModalTransactionHelper';
import { postTransaction } from '../../../Requests/Transaction';
import { useEffect } from 'react';
import PushNotification from '../../../Components/PushNotification/PushNotification';


export default function SubMenu() {
  const [isShow, setIsShow] = useState(false);
  const[state, setState]=useState<string|null>(null);

  return (
    <>
    <PushNotification text={state} refState={setState}/>
    <Nav className="justify-content-end submenu">
          <Nav.Item>
          <Button variant="outline-primary" onClick={()=>setIsShow(true)}>
          Добавить
          </Button>         
          <ModalTransaction title={Title.Add} key={(new Date()).toString()} refIsHide={setIsShow} refTransaction={postTransaction} clickSave={setState} isShow={isShow}/>
          </Nav.Item>
    </Nav>
    </>
  );
}
