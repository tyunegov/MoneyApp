import './Content.scss'
import {Table} from 'react-bootstrap';
import { getAll } from '../Models/Transaction';
import {TransactionsList} from './TransactionsList/TransactionsList'

function Content() {
  return (    
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>#</th>
          <th>Дата</th>
          <th>Категория</th>
          <th>Сумма</th>
          <th>Комментарий</th>            
        </tr>
      </thead>
      <TransactionsList />
    </Table>
  );
}

export default Content;