import './ModalTransaction.scss';
import {getTypes} from '../../Requests/Transaction';
import { Modal, Button, Row, Container, Form} from 'react-bootstrap';
import React, {useEffect, useState } from 'react';
import { ErrMessage, Title} from './ModalTransactionHelper';
import { ITransaction } from '../../Models/ITransaction';
import moment from 'moment';
import { IType } from '../../Models/IType';
import Input from '../Input/Input';

export default function ModalTransaction(props: {transaction?:ITransaction, title:string, refIsHide:React.Dispatch<React.SetStateAction<boolean>>, refTransaction:Function, clickSave?:Function, isShow:boolean}){
    const[types, setTypes] = useState<IType[]>();
    const[isDisableSelect, setDisableSelect] = useState(false);

    const [errorAmount, setErrorAmount] = useState<string>("");
    const [errorDate, setErrorDate] = useState<string>("");
    const [errorType, setErrorType] = useState<string>("");
    const [errorDescription, setErrorDescription] = useState<string>("");


    const [amount, setAmount] = useState<number>();
    const [type, setTypeTransaction] = useState<IType>();
    const [date, setDate] = useState<Date>();
    const [description, setDescription] = useState<string>();

    const [isTouchAmount, setIsTouchAmount] = useState<boolean>(false);
    const [isTouchType, setIsTouchType] = useState<boolean>(false);
    const [isTouchDate, setIsTouchDate] = useState<boolean>(false);
    const [isTouchDescription, setIsTouchDescription] = useState<boolean>(false);
    const [isFirstTouch, setIsFirstTouch] = useState<boolean>(false);

    useEffect(() => {
      setImmediate(() =>
      getTypes().then(          
        (resp)=>{
          setTypes(resp);
        }
      ),
      ()=>{if(props.transaction && types){
        setHandleAmount(props.transaction.amount);
        setHandleType(props.transaction.type?.id);
        setHandleDescription(props.transaction.description);
        setHandleDate(props.transaction.date);
        }
      },        
      );          
    }, [],);

    useEffect(()=>{
        if(props.transaction && types){
          if(!isFirstTouch){
          setHandleAmount(props.transaction.amount);
          setHandleType(props.transaction.type?.id);
          setHandleDescription(props.transaction.description);
          setHandleDate(props.transaction.date);
          }      
        }
        }      
    );

    function setValue(value: any,error:string,setFuncValue:Function, setError: Function, setIsTouch:Function){
      setFuncValue(value);
      setError(error);
      setIsTouch(true);
      if(!isFirstTouch) setIsFirstTouch(true);
    }
  

    function setHandleAmount(value?:number|unknown){
      let error:string=""; 
      if (value===undefined || (value as number)<=0) error = ErrMessage.AmountIsEmpty;
      setValue(value, error, setAmount, setErrorAmount, setIsTouchAmount);
    }

    function setHandleDate(value?:Date|undefined){
      let error:string="";
      if (value===undefined) error = ErrMessage.DateIsEmpty;
      setValue(value, error, setDate, setErrorDate, setIsTouchDate);
    }

    function setHandleType(value?:number){
      let error:string="";
      let type;
      if((value as number)>0) setDisableSelect(true);
      if (value===undefined || value===0) error = ErrMessage.TypeIsEmpty;
      type=(types as IType[])[value as number -1];
      setValue(type, error, setTypeTransaction, setErrorType, setIsTouchType);
    }

    function setHandleDescription(value?:string|undefined){
      let error:string="";
      setValue(value, error, setDescription, setErrorDescription, setIsTouchDescription);
    }
      
     function save() {    
        if(!isError())
        {        
          props.refTransaction({amount:amount, type:type, description:description, date:date}).then(          
            (resp: React.SetStateAction<string | null>)=>{
              if(props.clickSave) props.clickSave(resp);
            });            
          closeModal();
        }
        if(!isTouchAmount) setHandleAmount();
        if(!isTouchDate) setHandleDate();
        if(!isTouchType) setHandleType();
        }

      function isError():boolean{
        if(errorAmount!==""||errorDate!==""||errorType!==""){
          return true;
        }    
        return false
      }

     function closeModal(){
      props.refIsHide(false);
     }

    return(
        <>
        <Modal show={props.isShow} onHide={()=>closeModal()}>
          <Modal.Header closeButton>
            <Modal.Title>{props.title}</Modal.Title>
          </Modal.Header>
          <Modal.Body>
              <Container>
                <Input label="Введите дату:" type="date" onChange={setHandleDate} value={date===undefined?'':moment(date).format('YYYY-MM-DD')} error={errorDate}/>
                <Input label="Введите сумму:" type="number" min="0" onChange={setHandleAmount} value={amount as number} error={errorAmount}/>
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
                {errorType?         
                <Row>
                    <label className="alertLabel">{errorType}</label>
                </Row>
                :null}
                <Row>
                  <Form.Label>Комментарий</Form.Label>
                  <Form.Control value={description} as="textarea" rows={3} onChange={(e)=>setHandleDescription(e.target.value)}/>
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
