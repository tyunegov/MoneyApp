import './AddTransaction.scss';
import { getTypes, postTransaction } from '../../Models/Transaction';
import { Modal, Button, Row, Container, Form} from 'react-bootstrap';
import { useEffect, useState } from 'react';
import { ErrMessage } from './AddTransactionHelper';
import { IType } from '../../Models/IType';

export default function AddTransaction(){
    const[types, showSelectTypes] = useState(<></>);  
    const[isShowModal, handleShowModal] = useState(true);
    const[amount, handleChangeAmount] = useState(0);
    const[date, handleChangeDate] = useState('');
    const[typeId, handleChangeTypeId] = useState(0);
    const[typeValue, handleChangeTypeValue] = useState('string');
    const [isError, setIsError] = useState(false);
    const [isShowSelect, setShowSelect] = useState(false);
    const [description, setDescription] = useState('');

      useEffect(() => {
        setImmediate(() => 
        drawTypes(),
        ()=>{if (isShowModal==false) setIsError(false)}       
        )        
      }, []);

     const drawTypes=()=>{
      getTypes().then(
        (resp)=>{
          const types = resp.map(
              item=>{
                return(
                  <option key={item.id} value={item.id}>{item.type}</option>
                )
              }
          )

          showSelectTypes(
            <>
              {types}
            </>
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
       alert(date);
       if (amount!==0 && typeId!==0 && date!=='')
        {
          postTransaction({amount:amount, date:date, type:{id:typeId, type:typeValue}, description:description});
          setIsError(false);
          handleShowModal(false);          

        }
        setIsError(true);
     }

    return(
        <>
        <Button variant="outline-primary" onClick={()=>handleShowModal(true)}>
          Добавить
        </Button>
  
        <Modal show={isShowModal} onHide={()=>handleShowModal(false)}>
          <Modal.Header closeButton>
            <Modal.Title>Добавить</Modal.Title>
          </Modal.Header>
          <Modal.Body>
              <Container>
                <Row>
                    <label>Введите дату:</label>
                </Row>
                <Row>
                    <input type="date" className={isError?"":"form-group"} onChange={(e)=>handleChangeDate(e.target.value)}/>   
                </Row>
                {date===''?drawError(ErrMessage.DateIsEmpty):null}
                <Row>
                    <label>Введите сумму:</label>
                </Row>
                <Row>
                    <input type="number" className={isError?"":"form-group"} min="0" onChange={(e)=>handleChangeAmount(e.target.value as unknown as number)}/>                    
                </Row>
                  {amount===0?drawError(ErrMessage.AmountIsEmpty):null}
                <Row className={"row_displayBlock"} >
                <label>Тип операции</label>
                <Form.Control as="select" onChange={(e)=> [handleChangeTypeId(e.target.value as unknown as number), setShowSelect(true)]}>
                <option key='0' value='0' disabled={isShowSelect}>Выберите значение</option>
                {
                  types
                }             
                </Form.Control>
                </Row>
                {typeId===0?drawError(ErrMessage.TypeIsEmpty):null}
                <Row>
                  <Form.Label>Комментарий</Form.Label>
                  <Form.Control as="textarea" rows={3} onChange={(e)=>setDescription(e.target.value)}/>
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
