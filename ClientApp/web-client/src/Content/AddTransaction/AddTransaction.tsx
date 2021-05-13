import React, { useCallback, useState } from 'react'
import { Button, Container, Form, Modal, Row } from 'react-bootstrap'
import { getTTFB } from 'web-vitals'
import { IType } from '../../Models/IType'
import { getTypes } from '../../Models/Transaction'
import './AddTransaction.scss'

export default function AddTransaction() {
    const [showModal, setShowModal] = useState(true);
    const [types] = useState(getTypes().then(
      result => {
          result.map(item=>{
            return (
             <option>{item.type}</option>
            );
          })}));
    const handleMembersCount = useCallback(() => {
        setShowModal(true)
      }, []);



    return(
        <>
        <Button variant="outline-primary" onClick={handleMembersCount}>
          Добавить
        </Button>
        <Modal show={showModal} onHide={handleMembersCount}>
        <Modal.Header closeButton>
            <Modal.Title>Добавить</Modal.Title>
          </Modal.Header>
          <Modal.Body>
              <Container>
                <Row>
                    <label>Введите дату:</label>
                </Row>
                <Row>
                    <input type="date" className={"form-group"}/>
                </Row>
                <Row>
                    <label>Введите сумму:</label>
                </Row>
                <Row>
                    <input type="number" className={"form-group"}/>
                </Row>
                <Row className={"row_displayBlock"} >
                  <Form.Group controlId="exampleForm.ControlSelect2">
                    <Form.Label>Тип транзакции</Form.Label>
                    <Form.Control as="select" multiple>
                      {types}
                    </Form.Control>
                  </Form.Group>
                </Row>
                </Container>                
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleMembersCount}>
              Отмена
            </Button>
            <Button variant="primary" onClick={handleMembersCount}>
              Сохранить
            </Button>
          </Modal.Footer>
        </Modal>
      </>
    )
}
