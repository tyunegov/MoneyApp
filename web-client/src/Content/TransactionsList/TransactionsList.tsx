import React, { Component } from 'react'
import { Button, Table } from 'react-bootstrap';
import { ITransaction } from '../../Models/ITransaction';
import { IType } from '../../Models/IType';
import { getAll} from '../../Models/Transaction';
import { useState } from 'react';
import { useEffect } from 'react';
import ModalTransaction from '../ModalTransaction/ModalTransaction';


export default function TransactionsList(){
      const [transactions, setTransactions] = useState(<div></div>);
      const [isShow, setIsShow] = useState(true)

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
                      <td>{item.date}</td>
                      <td>{(item.type as IType).type}</td>
                      <td>{item.amount}</td>
                      <td>{item.description}</td>   
                      <Button onClick={()=>changeTransaction(item)}>Изменить</Button>                  
                     </tr>
                    );
                })
                setTransactions(<>{transactions}</>)
             })}            

      function changeTransaction(_transaction:ITransaction){
          return(
            isShow==true?
            <ModalTransaction transaction={null} title="Изменить" isShow={isShow} refIsHide={setIsShow}/>
            :null
          )
      }
      

      return(
        <>
            <Table striped bordered hover>
              <thead>
                <tr>
                  <th>Дата</th>
                  <th>Категория</th>
                  <th>Сумма</th>
                  <th>Комментарий</th>            
                </tr>
              </thead>    
              <tbody>{transactions}</tbody>
              </Table>
        </>
          );
      }
      
      
