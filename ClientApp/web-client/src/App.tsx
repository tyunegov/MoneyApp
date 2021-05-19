import './App.scss';
import 'bootstrap/dist/css/bootstrap.min.css';
import SideBar from './SideBar/SideBar'
import MainContainer from './MainContainer/MainContainer'
import { Col, Row } from 'react-bootstrap';

function App() {
  return (
    <div>
      <div className='app-side'>
        <Row>
          <Col xs={2} className='side'/>
          <Col/>
        </Row>
      </div>
      <div className='app-main'>
        <Row>
          <Col xs={2}>
            <SideBar/>
          </Col>
          <Col>
            <MainContainer/>
        </Col>
        </Row>
      </div>
    </div>
  );
}


export default App;
