import './MainContainer.scss'
import {Container, Row} from 'react-bootstrap';
import SubMenu from '../Content/SubMenu/SubMenu';
import Content from '../Content/Content';

function MainContainer() {
  return (
    <Container className='wrapper'>
      <Row><h1>Финансы</h1></Row>
      <Row><SubMenu/></Row>
      <Row><Content/></Row>  
    </Container>
  );
}

export default MainContainer;
