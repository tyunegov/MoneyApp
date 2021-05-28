import { deleteTransaction} from '../../Models/Transaction';
import { Modal, Button} from 'react-bootstrap';
import React from 'react';
import { Title } from '../ModalTransaction/ModalTransactionHelper';

export default function DeleteTransaction(props: {id:number, refIsHide:React.Dispatch<React.SetStateAction<boolean>>}){
    function closeModal(){
        props.refIsHide(false);
       }

    return(
        <> 
        <Modal show onHide={()=>closeModal()}>
          <Modal.Header closeButton>
            <Modal.Title>{Title.Delete}</Modal.Title>
          </Modal.Header>
          <Modal.Body>
                Вы уверены что хотите удалить?               
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={()=>closeModal()}>
              Отмена
            </Button>
            <Button variant="danger" onClick={()=>{deleteTransaction(props.id);}}>
              Удалить
            </Button>
          </Modal.Footer>
        </Modal>
      </>
    )
}
