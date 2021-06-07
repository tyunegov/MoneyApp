import './MainContainer.scss'
import {Container, Row} from 'react-bootstrap';
import SubMenu from '../Content/SubMenu/SubMenu';
import Content from '../Content/Content';
import React from 'react';
import Rest from '../Content/Report/Report';

function MainContainer() {
  return (
    <Container className='wrapper'>
      <Row><h1>Финансы</h1></Row>
      <Row><Rest/></Row>
      <Row><SubMenu/></Row>
      <Row><Content/></Row>  
    </Container>
  );
}

export default MainContainer;
