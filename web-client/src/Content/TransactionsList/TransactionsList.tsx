import { Component } from 'react'
import { Table } from 'react-bootstrap';
import { ITransaction } from '../../Models/ITransaction';
import { IType } from '../../Models/IType';
import { getAll} from '../../Models/Transaction';


export class TransactionsList extends Component<{}, { transactions: any}>{
      constructor(props:any) {
        super(props);
        this.state = {
          transactions: <div></div>
        };
      }
     
      componentDidMount(){
        this.drawTransaction();
        setInterval(()=>this.drawTransaction(),30000);
        }

          drawTransaction(){
            getAll().then(
              result => {
                  this.setState({
                transactions: result.map(item=>{
                    return (
                     <tr key={item.id}>
                      <td>{item.date}</td>
                      <td>{(item.type as IType).type}</td>
                      <td>{item.amount}</td>
                      <td>{item.description}</td>   
                      <td onClick={()=>this.changeTransaction(item)}>Изменить</td>                  
                     </tr>
                    );
                })
             })}
            );
          }

      changeTransaction(_transaction:ITransaction){
   //     return <ModalTransaction transaction={_transaction as ITransaction} title="Изменить"  isShow={true}></ModalTransaction>
      }

      render() {
          return (
            <Table striped bordered hover>
              <thead>
                <tr>
                  <th>Дата</th>
                  <th>Категория</th>
                  <th>Сумма</th>
                  <th>Комментарий</th>            
                </tr>
              </thead>    
              <tbody>{this.state.transactions}</tbody>
              </Table>
          );
        }
      }
    

export default TransactionsList
