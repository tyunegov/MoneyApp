import React, { Component } from 'react'
import { getAll} from '../../Models/Transaction';


export class TransactionsList extends Component<{}, { transactions: any}>{
      constructor(props:any) {
        super(props);
        this.state = {
          transactions: <div></div>
        };
      }
     
      fillTable(){
        getAll().then(
             result => {
                 this.setState({
               transactions: result.map(item=>{
                   return (
                    <tr>
                     <td>{item.id}</td>
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
          this.fillTable()
          return (
              <tbody>{this.state.transactions}</tbody>
          );
        }
      }
    

export default TransactionsList
