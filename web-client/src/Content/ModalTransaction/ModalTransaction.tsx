import './ModalTransaction.scss';
import { getTypes, postTransaction } from '../../Models/Transaction';
import { Modal, Button, Row, Container, Form} from 'react-bootstrap';
import { useEffect, useState } from 'react';
import { ErrMessage} from './ModalTransactionHelper';
import { ITransaction } from '../../Models/ITransaction';

export default function ModalTransaction(props: {transaction:ITransaction|null, title:string, isShow:boolean, refIsHide:React.Dispatch<React.SetStateAction<boolean>>}){
    const[types, showSelectTypes] = useState(<></>);  
    const[amount, handleChangeAmount] = useState<number>();
    const[date, handleChangeDate] = useState<string>('');
    const[typeId, handleChangeTypeId] = useState(0);
    const[typeValue, handleChangeTypeValue] = useState('string');
    const [isError, setIsError] = useState(false);
    const [isShowSelect, setShowSelect] = useState(false);
    const [description, setDescription] = useState('');
    const [stansaction, setstansaction] = useState<ITransaction>();
    const [Show, setShow] = useState<boolean>(true);

      useEffect(() => {
        setImmediate(() => 
        drawTypes(),
        ()=>{
          if(props.transaction!==null){
            handleChangeAmount(props.transaction.amount as number);
            setDescription(props.transaction.description as string);
            handleChangeTypeId(props.transaction.type?.id as number);
            handleChangeDate(props.transaction.date as string);
          }
        }
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
       alert(stansaction?.amount);
       if (amount!==0 && typeId!==0 && date!=='')
        {
          postTransaction({amount:amount, date:date, type:{id:typeId, type:typeValue}, description:description});
          setIsError(false);
    //      setIsShowModalTransaction(false);         
        }
        setIsError(true);
     }

    return(
        <> 
        <Modal show={props.isShow} onHide={()=>props.refIsHide(false)}>
          <Modal.Header closeButton>
            <Modal.Title>{props.title}</Modal.Title>
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
                    <input type="number" className={isError?"":"form-group"} min="0" onChange={(e)=>setstansaction({amount: e.target.value as unknown as number})}/>                    
                </Row>
                  {stansaction?.amount? null:drawError(ErrMessage.AmountIsEmpty)}
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
            <Button variant="secondary" onClick={()=>false}>
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
