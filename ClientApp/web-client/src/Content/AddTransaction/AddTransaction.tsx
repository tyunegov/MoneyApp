import { useState } from 'react'
import { Button, Container, Form, Modal, Row } from 'react-bootstrap'
import { getTypes } from '../../Models/Transaction'
import './AddTransaction.scss'
import { Modal, Button, Row, Container, Form} from 'react-bootstrap';
import { useEffect, useState } from 'react';
import { getTypes } from '../../Models/Transaction';
import { ErrMessage } from './AddTransactionHelper';

export default function AddTransaction(){
    const[types, setTypes] = useState(<></>);  
    const[showModal, handleShowModal] = useState(true);
    const[amount, setAmount] = useState('');
    const[date, setDate] = useState('');
    const[type, setType] = useState(0);
    const [isError, setIsError] = useState(false)

      useEffect(() => {
        setImmediate(() => 
          drawTypes()
        )
      }, []);

     const drawTypes=()=>{
      getTypes().then(
        (resp)=>{
          const types = resp.map(
              item=>{
                return(
                  <option key={item.id} onChange={()=>setType(item.id)}>{item.type}</option>
                )
              }
          )
          setTypes(
            <Form.Control as="select" multiple>
              {types}
            </Form.Control>
          );
        }
      )
      }

      function drawError(errMessage: string) {  
        return isError?
            (
            <Row>
              <label className="alertLabel">{errMessage}</label>
            </Row>)
            :null;
       }
      
     function save() {
       if (amount || date==='')
        {
            setIsError(true);
        }
     }

    return(
        <>
        <Button variant="outline-primary" onClick={()=>handleShowModal(true)}>
          Добавить
        </Button>
  
        <Modal show={showModal} onHide={()=>handleShowModal(false)}>
          <Modal.Header closeButton>
            <Modal.Title>Добавить</Modal.Title>
          </Modal.Header>
          <Modal.Body>
              <Container>
                <Row>
                    <label>Введите дату:</label>
                </Row>
                <Row>
                    <input type="date" className={"form-group"} value={date} onChange={(e)=>setDate(e.target.value)}/>    
                </Row>
                  {date===''?drawError(ErrMessage.DataIsEmpty):null}
                <Row>
                    <label>Введите сумму:</label>
                </Row>
                <Row>
                    <input type="number" className={"form-group"} min="0" value={amount} onChange={(e)=>setAmount(e.target.value)}/>                    
                </Row>
                  {amount===''?drawError(ErrMessage.AmountIsEmpty):null}
                <Row className={"row_displayBlock"} >
                <Form.Group controlId="exampleForm.ControlSelect2">
                <Form.Label>Тип операции</Form.Label>
                {
                  types
                }
                {type===0?drawError(ErrMessage.TypeIsEmpty):null}
              </Form.Group>
                </Row>
                </Container>                
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={()=>handleShowModal(false)}>
              Отмена
            </Button>
            <Button variant="primary" onClick={save}>
              Сохранить
            </Button>
          </Modal.Footer>
        </Modal>
      </>
    )
}
