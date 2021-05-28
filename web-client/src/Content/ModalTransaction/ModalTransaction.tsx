import './ModalTransaction.scss';
import { editTransaction, getTypes, postTransaction } from '../../Models/Transaction';
import { Modal, Button, Row, Container, Form, InputGroup, FormControl} from 'react-bootstrap';
import React, {useEffect, useState } from 'react';
import { ErrMessage, Title} from './ModalTransactionHelper';
import { ITransaction } from '../../Models/ITransaction';
import moment from 'moment';
import { IType } from '../../Models/IType';

export default function ModalTransaction(props: {transaction:ITransaction|null, title:string, refIsHide:React.Dispatch<React.SetStateAction<boolean>>}){
    const[types, showSelectTypes] = useState(<></>);  
    const [isClickSave, setIsClickSave] = useState(false);
    const [isShowSelect, setShowSelect] = useState(false);
    const [_transaction, setTransaction] = useState<ITransaction>({});
    const [isErrorAmount, setIsErrorAmount] = useState(false);
    const [isErrorDate, setIsErrorDate] = useState(false);
    const [isErrorType, setIsErrorType] = useState(false);


    function setHandleTransaction(tr: ITransaction){
      setTransaction(
        {
          amount:tr.amount?tr.amount:_transaction?.amount,
          description:tr.description?tr.description:_transaction?.description,  
          type:tr.type?tr.type:_transaction?.type,
          date:tr.date?tr.date:_transaction?.date
        }
      );
    }

      useEffect(() => {
        setImmediate(() => 
          drawTypes(),
          setTransaction(props.transaction===null?{}:props.transaction as ITransaction)
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

      const setType=(i:number)=>{
        getTypes().then(
          (resp)=>{
            if(i>0){
              setHandleTransaction(
                {type: resp[i-1]}
              );
            }                            
          }                
        )
        }

      function drawError(errMessage: string) {  
        return isClickSave?
            (
            <Row>
              <label className="alertLabel">{errMessage}</label>
            </Row>)
            :null;
       }
      
     function save() {      
       validation();
       if (!isErrorAmount && isErrorDate && isErrorType)
        {
          if(props.title===Title.Add) postTransaction(_transaction);
          if(props.title===Title.Change) editTransaction(props.transaction?.id as number, _transaction);
          setIsClickSave(false);
          closeModal();       
        }
        setIsClickSave(true);
     }

     function validation() {
      console.log(_transaction);
      if(_transaction.amount as number <=0 || _transaction?.amount === undefined) setIsErrorAmount(true);
      if(_transaction?.date === undefined) setIsErrorDate(true);
      if(_transaction?.type === undefined || _transaction?.type.id as number <=0) setIsErrorType(true);
     }

     function closeModal(){
      props.refIsHide(false);
     }

    return(
        <> 
        <Modal show onHide={()=>closeModal()}>
          <Modal.Header closeButton>
            <Modal.Title>{props.title}</Modal.Title>
          </Modal.Header>
          <Modal.Body>
              <Container>
                <Row>
                    <label>Введите дату:</label>
                </Row>
                <Row>
                    <InputGroup>
                    <FormControl type="date" onChange={(e)=>{setHandleTransaction({date: e.target.value as unknown as Date})}} value={_transaction?.date===undefined?'':moment(_transaction?.date).format('YYYY-MM-DD')}/>
                  </InputGroup>  
                </Row>
                {isErrorDate?drawError(ErrMessage.DateIsEmpty):null}
                <Row>
                    <label>Введите сумму:</label>
                </Row>
                <Row>
                  <InputGroup>
                    <FormControl type="number" min="0" onChange={(e)=>setHandleTransaction({amount: e.target.value as unknown as number})} value={_transaction?.amount}/>
                  </InputGroup>            
                </Row>
                  {isErrorAmount?drawError(ErrMessage.AmountIsEmpty):null}
                <Row className={"row_displayBlock"} >
                <label>Тип операции</label>
                <Form.Control value={_transaction.type?.id} as="select" onChange={(e)=>{setType(e.target.value as unknown as number)}}>
                <option key='0' value='0' disabled={isShowSelect}>Выберите значение</option>
                {
                  types
                }             
                </Form.Control>
                </Row>
                {isErrorType?drawError(ErrMessage.TypeIsEmpty):null}
                <Row>
                  <Form.Label>Комментарий</Form.Label>
                  <Form.Control value={_transaction.description} as="textarea" rows={3} onChange={(e)=>setHandleTransaction({description: e.target.value})}/>
                </Row>
                </Container>                
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={()=>closeModal()}>
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
