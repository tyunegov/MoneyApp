import './MainContainer.scss'
import {Container} from 'react-bootstrap';
import Transaction from '../Content/Transaction/Transaction';
import { Switch, Route, Redirect, BrowserRouter } from 'react-router-dom';
import Stock from '../Content/Stock/Stock';

function MainContainer() {
  return (
    <Container className='wrapper'>
      <BrowserRouter>
            <Switch>
              <Route  path='/home' component={Transaction} />
              <Route path='/stock' component={Stock} />
              <Redirect from='/' to='/stock'/>
            </Switch>
      </BrowserRouter>
    </Container>
  );
}

export default MainContainer;
