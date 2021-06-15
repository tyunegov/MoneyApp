import './ModalTransaction.scss';
import { editTransaction, getTypes, postTransaction, reportPeriod } from '../../Requests/Transaction';
import { Modal, Button, Row, Container, Form, InputGroup, FormControl} from 'react-bootstrap';
import React, {useEffect, useState } from 'react';
import { ErrMessage, Title} from './ModalTransactionHelper';
import { ITransaction } from '../../Models/ITransaction';
import moment from 'moment';
import { IType } from '../../Models/IType';

export default function ModalTransaction(props: {transaction:ITransaction|null, title:string, refIsHide:React.Dispatch<React.SetStateAction<boolean>>, refTransaction:Function}){
    const[types, setTypes] = useState<IType[]>();
    const [isDisableSelect, setDisableSelect] = useState(false);
    const [_transaction, setTransaction] = useState<ITransaction>({});

    const [errorAmount, setErrorAmount] = useState<JSX.Element|null>();
    const [errorDate, setErrorDate] = useState<JSX.Element|null>();
    const [errorType, setErrorType] = useState<JSX.Element|null>();
    const [errorDescription, setErrorDescription] = useState<JSX.Element|null>();


    const [amount, setAmount] = useState<number>();
    const [type, setTypeTransaction] = useState<IType>();
    const [date, setDate] = useState<Date>();
    const [description, setDescription] = useState<string>();

    const [isTouchAmount, setIsTouchAmount] = useState<boolean>();
    const [isTouchType, setIsTouchType] = useState<boolean>();
    const [isTouchDate, setIsTouchDate] = useState<boolean>();
    const [isTouchDescription, setIsTouchDescription] = useState<boolean>();

    useEffect(() => {
      setImmediate(() => 
      getTypes().then(          
        (resp)=>{
          setTypes(resp);
        }
      ),
      ()=>{if(props.transaction){
        setHandleAmount(props.transaction.amount);
        setHandleType(props.transaction.type?.id);
        setHandleDescription(props.transaction.description);
        setHandleDate(props.transaction.date);
        }
      }
      )        
    }, []);

    function setValue(value: any,error:string|null,setFuncValue:Function, setError: Function, setIsTouch:Function){
      setFuncValue(value);
         setError(  
          error?         
            <Row>
              <label className="alertLabel">{error}</label>
            </Row>
            :null
        );
      setIsTouch(true);
    }
  

    function setHandleAmount(value?:number|undefined){
      let error:string|null=null;
      if (value===undefined || (value as number)<=0) error = ErrMessage.AmountIsEmpty;
      setValue(value, error, setAmount, setErrorAmount, setIsTouchAmount);
    }

    function setHandleDate(value?:Date|undefined){
      let error:string|null=null;
      if (value===undefined) error = ErrMessage.DateIsEmpty;
      setValue(value, error, setDate, setErrorDate, setIsTouchDate);
    }

    function setHandleType(value?:number){
      let error:string|null=null;      
      let type;
      if((value as number)>0) setDisableSelect(true);
      if (value===undefined || value===0) error = ErrMessage.TypeIsEmpty;
      type=(types as IType[])[value as number -1];
      console.log(type);
      setValue(type, error, setTypeTransaction, setErrorType, setIsTouchType);
    }

    function setHandleDescription(value?:string|undefined){
      let error:string|null=null;
      setValue(value, error, setDescription, setErrorDescription, setIsTouchDescription);
    }
      
     function save() {    
       console.log(errorAmount);
        if(!errorAmount&&!errorDate&&!errorType) 
        {
          props.refTransaction({amount:amount, type:type, description:description, date:date});
          closeModal();
        }
        if(!isTouchAmount) setHandleAmount();
        if(!isTouchDate) setHandleDate();
        if(!isTouchType) setHandleType();
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
                    <FormControl type="date" onChange={(e)=>{setHandleDate(e.target.value as unknown as Date)}} value={_transaction?.date===undefined?'':moment(_transaction?.date).format('YYYY-MM-DD')}/>
                  </InputGroup>  
                </Row>
                {errorDate}
                <Row>
                    <label>Введите сумму:</label>
                </Row>
                <Row>
                  <InputGroup>
                    <FormControl type="number" min="0" onChange={(e)=>setHandleAmount(e.target.value as unknown as number)} value={amount}/>
                  </InputGroup>            
                </Row>
                  {errorAmount}
                <Row className={"row_displayBlock"} >
                <label>Тип операции</label>
                <Form.Control value={type?.id} as="select" onChange={(e)=>{setHandleType(e.target.value as unknown as number)}}>
                <option key='0' value='0' disabled={isDisableSelect}>Выберите значение</option>
                {
                  types?.map(
                    item=>
                        <option key={item.id} value={item.id}>{item.type}</option> 
                  )    
                }             
                </Form.Control>
                </Row>
                {errorType}
                <Row>
                  <Form.Label>Комментарий</Form.Label>
                  <Form.Control value={_transaction.description} as="textarea" rows={3} onChange={(e)=>setHandleDescription(e.target.value)}/>
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
