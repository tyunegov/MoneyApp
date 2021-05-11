import './AddTransaction.scss'
import { Modal, Button, Row, Container, Dropdown, Form} from 'react-bootstrap';
import { Component, DOMFactory, HTMLAttributes, HtmlHTMLAttributes, useState } from 'react';
import { getAll, getTypes } from '../../Models/Transaction';

export class AddTransaction extends Component<{}, {types:any, useState:boolean}>{
  constructor(props:any) {
        super(props);
        this.state = {
          types: <div></div>,
          useState: false
        };
      }
  
    handleClose(){
      this.setState({useState:false})
    }

    handleShow(){
      this.setState({useState:true})
    }

    componentDidMount(){
      getTypes().then(
           result => {
               this.setState({
             types: result.map(item=>{
                 return (
                  <Form.Control as="select" multiple>
                  <option>{item.type}</option>
                </Form.Control>
                 );
             })
          })}
         );
        }
  
    render(){
    return (
      <>
        <Button variant="outline-primary" onClick={this.handleShow}>
          Добавить
        </Button>
  
        <Modal show={useState} onHide={this.handleClose}>
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
                {this.state.types}
              </Form.Group>
                </Row>
                </Container>                
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={this.handleClose}>
              Отмена
            </Button>
            <Button variant="primary" onClick={this.handleClose}>
              Сохранить
            </Button>
          </Modal.Footer>
        </Modal>
      </>
    );
  }}
  
  export default AddTransaction;
  