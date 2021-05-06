import React, { Component } from 'react';
import './MainContainer.scss'
import {Container, Row} from 'react-bootstrap';
import SubMenu from '../SubMenu/SubMenu';
import Content from '../Content/Content';

function MainContainer() {
  return (
    <div className='wrapper'>      
    <Container>
      <Row><SubMenu/></Row>
      <Row><Content/></Row>  
    </Container>
    </div>
  );
}

export default MainContainer;
