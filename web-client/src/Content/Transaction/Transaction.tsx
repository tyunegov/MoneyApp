import {Row} from 'react-bootstrap';
import SubMenu from './SubMenu/SubMenu';
import Rest from './Report/Report';
import History from './History/History';

function Transaction() {
  return (
    <>
        <Row><h1>Финансы</h1></Row>
        <Row><Rest/></Row>
        <Row><SubMenu/></Row>
        <Row><History/></Row> 
    </>
  );
}

export default Transaction;
