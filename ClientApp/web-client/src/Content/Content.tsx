import './Content.scss'
import {Table} from 'react-bootstrap';
import { getAll } from '../Models/Transaction';
import {TransactionsList} from './TransactionsList/TransactionsList'

function Content() {
  return (    
      <TransactionsList />
  );
}

export default Content;