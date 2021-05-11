import './AddTransaction.scss'
import { Modal, Button} from 'react-bootstrap';
import { useState } from 'react';

function AddTransaction() {
    const [show, setShow] = useState(false);
  
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
  
    return (
      <>
        <Button variant="outline-primary" onClick={handleShow}>
          Добавить
        </Button>
  
        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Добавить</Modal.Title>
          </Modal.Header>
          <Modal.Body>Woohoo, you're reading this text in a modal!</Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose}>
              Отмена
            </Button>
            <Button variant="primary" onClick={handleClose}>
              Сохранить
            </Button>
          </Modal.Footer>
        </Modal>
      </>
    );
  }
  
  export default AddTransaction;