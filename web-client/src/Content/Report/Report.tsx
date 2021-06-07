import moment from 'moment';
import { useEffect, useState } from 'react';
import { Col } from 'react-bootstrap';
import Row from 'react-bootstrap/esm/Row';
import { Report } from '../../Models/Report';
import { reportPeriod } from '../../Requests/Transaction';
import './Report.scss';

export default function Rest(){
    const [rest, setRest] = useState<Report>({});
    const [aGroupT, setAGroupT] = useState(<></>);

    useEffect(() => {
        setImmediate(() => 
        {
        report();
        displayByType();
        }
        )        
      }, []);  

      function report(){
        reportPeriod().then(
          (resp)=>{
                setRest(
                  {
                    startDate:resp.startDate,
                    endDate:resp.endDate,
                    amountGroupType:resp.amountGroupType,
                    rest:resp.rest
                  }
                )
            
            console.log(rest);
          }
        )
      }          

      function displayByType(){
        const result = rest.amountGroupType?.map((item)=>{
          return( 
            <Col xs={3}>
                <div>{item.type?.type}: {item.amount} рублей</div>
            </Col>
          )          
        })
        setAGroupT(
          <>
            {result}
          </>
        )
      }
      
    return(
        <>
          <h5>Отчет за период c {moment(rest.startDate).format('DD.MM.YYYY')} по {moment(rest.endDate).format('DD.MM.YYYY')} </h5>  
        <Row>
          {aGroupT}
        </Row>
        <Row>
          <Col>
          <b> Остаток: {rest.rest} рублей </b>
          </Col>
        </Row>
        </>
    );
}