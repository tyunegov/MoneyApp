import { Component } from 'react'
import { Table } from 'react-bootstrap';
import { getAll} from '../../Models/Transaction';


export class TransactionsList extends Component<{}, { transactions: any}>{
      constructor(props:any) {
        super(props);
        this.state = {
          transactions: <div></div>
        };
      }
     
      componentDidMount(){
        getAll().then(
             result => {
                 this.setState({
               transactions: result.map(item=>{
                   return (
                    <tr>
                     <td>{new Date(item.date).toLocaleDateString()}</td>
                     <td>{item.type.type}</td>
                     <td>{item.amount}</td>
                     <td>{item.description}</td>                     
                    </tr>
                   );
               })
            })}
           );
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
