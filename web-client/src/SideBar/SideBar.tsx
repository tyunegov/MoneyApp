import './SideBar.scss'
import { Navbar, Nav} from 'react-bootstrap';

function SideBar() {
  return (      
        <Navbar variant='dark' className='sidebar'>
          <Navbar.Brand>MoneyApp</Navbar.Brand>
            <Nav defaultActiveKey="/home" className="flex-column">
            <Nav.Link eventKey="link-1" href="/home">История</Nav.Link>
            <Nav.Link eventKey="link-2" href="/stock">Инвестиции</Nav.Link>
            </Nav>
        </Navbar>
  );
}

export default SideBar;
