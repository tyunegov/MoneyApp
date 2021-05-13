import './AddTransaction.scss'
import { Modal, Button, Row, Container, Dropdown, Form} from 'react-bootstrap';
import { Component} from 'react';
import { getAll, getTypes } from '../../Models/Transaction';

export class AddTransaction extends Component<{}, {showModal:any, types:any}>{
  constructor(props:any) {
        super(props);
        this.state = {     
          showModal:false,
          types: <div></div>
        };
      }

    componentDidMount(){
      getTypes().then(
           result => {
               this.setState({
             types: result.map(item=>{
                 return (                  
                  <option>{item.type}</option>
                 );
             })
          })}
         );
        }

    showModal = () => this.setState((state) => ({ showModal: !state.showModal }));

    save = () => {
      this.showModal();
      if(this.state.showModal==true) window.location.reload();
    }
  
    render(){
    return (
      <>
        <Button variant="outline-primary" onClick={this.showModal}>
          Добавить
        </Button>
  
        <Modal show={this.state.showModal} onHide={this.showModal}>
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
                      {this.state.types}
                    </Form.Control>
                  </Form.Group>
                </Row>
                </Container>                
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={this.showModal}>
              Отмена
            </Button>
            <Button variant="primary" onClick={this.save}>
              Сохранить
            </Button>
          </Modal.Footer>
        </Modal>
      </>
    );
  }}
  
  export default AddTransaction;
  