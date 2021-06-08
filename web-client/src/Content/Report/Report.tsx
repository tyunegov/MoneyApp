import moment from 'moment';
import { useEffect, useState } from 'react';
import { Col } from 'react-bootstrap';
import Row from 'react-bootstrap/esm/Row';
import { Report } from '../../Models/Report';
import { reportPeriod } from '../../Requests/Transaction';
import './Report.scss';

export default function Rest(){
    const [rest, setRest] = useState<Report>({});

    useEffect(() => {
        setImmediate(() => 
        {
        report();
        }
        )        
      }, []);  

      async function report(){        
         await reportPeriod().then(
          (resp)=>{
                setRest(
                  {
                    startDate:resp.startDate,
                    endDate:resp.endDate,
                    amountGroupType:resp.amountGroupType,
                    rest:resp.rest
                  }
                )
          }
        )
      }   
      
      function isVisible(): boolean {
        if(rest?.amountGroupType!==undefined){
          return true;
        }
        return false;
      }
      
    return(
        <>
        {isVisible()?
        <>
          <h5>Отчет за период c {moment(rest.startDate).format('DD.MM.YYYY')} по {moment(rest.endDate).format('DD.MM.YYYY')} </h5>  
        <Row>
          {
            rest.amountGroupType?.map((item)=>{
              console.log(item.amount);
              return( 
                <Col xs={3}>
                    <div>{item.type?.type}: {item.amount} рублей</div>
                </Col>
              )          
              })
          }
        </Row>
        <Row>
          <Col>
          <b> Остаток: {rest.rest} рублей </b>
          </Col>
        </Row>
        </>
        :null}
        </>
        
    );
}