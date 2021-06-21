import { Button, Table } from 'react-bootstrap';
import { ITransaction } from '../../../Models/ITransaction';
import { IType } from '../../../Models/IType';
import { getAll, editTransaction} from '../../../Requests/Transaction';
import { useState } from 'react';
import { useEffect } from 'react';
import ModalTransaction from '../../../Components/ModalTransaction/ModalTransaction';
import './History.scss'
import { Title } from '../../../Components/ModalTransaction/ModalTransactionHelper';
import moment from 'moment';
import DeleteTransaction from '../DeleteTransaction/DeleteTransaction';
import PushNotification from '../../../Components/PushNotification/PushNotification';


export default function History(){
      const [transactions, setTransactions] = useState(<div></div>);
      const [isShowModalEdit, setIsShowModalEdit] = useState(false);
      const [selectedTransaction, handleSelectedTransaction] = useState<ITransaction>({});
      const [isShowModalDelete, setIsShowModalDelete] = useState(false);
      const[state, setState]=useState<string|null>(null);

      useEffect(() => {
        setImmediate(() => 
        {
        drawTransaction();
        }
        )        
      }, []);  
      
      useEffect(()=>{
        setTimeout(drawTransaction, 7000);
      });

        function drawTransaction(){
            getAll().then(
              (resp)=>{
                const transactions = resp.map(
                    item=>{
                    return (
                     <tr key={item.id} className={item.type?.id===1?'isIncome':''}>
                      <td>{moment(item.date).format('DD.MM.YYYY')}</td>
                      <td>{(item.type as IType).type}</td>
                      <td>{item.amount}</td>
                      <td>{item.description}</td>  
                      <td className="td-small"> 
                        <Button variant="link" size="sm" onClick={()=>{
                          handleSelectedTransaction(item);
                          setIsShowModalEdit(true);
                        }
                        }>{Title.Change}</Button>    
                      </td>
                      <td className="td-small"> 
                        <Button variant="link" size="sm" onClick={()=>{
                          handleSelectedTransaction(item);
                          setIsShowModalDelete(true);
                        }
                        }>{Title.Delete}</Button>    
                      </td>              
                     </tr>
                    );
                })
                setTransactions(<>{transactions}</>)
             })}
             
      function editSelectTransaction(transaction:ITransaction){
        return editTransaction(selectedTransaction.id as number, transaction);
      }

      return(
        <>
        <ModalTransaction key={selectedTransaction.id} isShow={isShowModalEdit} transaction={selectedTransaction} title={Title.Change} refIsHide={setIsShowModalEdit} refTransaction={editSelectTransaction} clickSave={setState}/>
        {isShowModalDelete?<DeleteTransaction id={selectedTransaction.id as number} refIsHide={setIsShowModalDelete}/>:null}
        <PushNotification text={state} refState={setState}/>
            <Table hover>
              <thead>
                <tr>
                  <th>Дата</th>
                  <th>Категория</th>
                  <th>Сумма</th>
                  <th>Комментарий</th>      
                  <th></th>
                  <th></th>   
                </tr>
              </thead>    
              <tbody>{transactions}</tbody>
              </Table>
        </>
          );
      }
      
      
