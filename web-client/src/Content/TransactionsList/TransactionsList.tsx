import React, { Component } from 'react'
import { Button, Table } from 'react-bootstrap';
import { ITransaction } from '../../Models/ITransaction';
import { IType } from '../../Models/IType';
import { deleteTransaction, getAll} from '../../Requests/Transaction';
import { useState } from 'react';
import { useEffect } from 'react';
import ModalTransaction from '../ModalTransaction/ModalTransaction';
import './TransactionList.scss'
import { Title } from '../ModalTransaction/ModalTransactionHelper';
import moment from 'moment';
import DeleteTransaction from '../DeleteTransaction/DeleteTransaction';


export default function TransactionsList(){
      const [transactions, setTransactions] = useState(<div></div>);
      const [isShowModalEdit, setIsShowModalEdit] = useState(false);
      const [editTransaction, handleEditTransaction] = useState<ITransaction>({});
      const [isShowModalDelete, setIsShowModalDelete] = useState(false);

      useEffect(() => {
        setImmediate(() => 
        {
        drawTransaction();
        }
        )        
      }, []);        

        function drawTransaction(){
            getAll().then(
              (resp)=>{
                const transactions = resp.map(
                    item=>{
                    return (
                     <tr key={item.id}>
                      <td>{moment(item.date).format('DD.MM.YYYY')}</td>
                      <td>{(item.type as IType).type}</td>
                      <td>{item.amount}</td>
                      <td>{item.description}</td>  
                      <td className="td-small"> 
                        <Button variant="link" size="sm" onClick={()=>{
                          handleEditTransaction(item);
                          setIsShowModalEdit(true);
                        }
                        }>{Title.Change}</Button>    
                      </td>
                      <td className="td-small"> 
                        <Button variant="link" size="sm" onClick={()=>{
                          handleEditTransaction(item);
                          setIsShowModalDelete(true);
                        }
                        }>{Title.Delete}</Button>    
                      </td>              
                     </tr>
                    );
                })
                setTransactions(<>{transactions}</>)
             })}                  

      return(
        <>
        {isShowModalEdit?<ModalTransaction transaction={editTransaction} title="Изменить" refIsHide={setIsShowModalEdit}/>:null}
        {isShowModalDelete?<DeleteTransaction id={editTransaction.id as number} refIsHide={setIsShowModalDelete}/>:null}
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
      
      
