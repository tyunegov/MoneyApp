import { FormControl, InputGroup, Row } from "react-bootstrap";

export default function Input(props:{label:string, type:string, onChange:Function, value:string|number|string[], error?:string|null, min?:string}) {
    return (
        <>
        <Row>
            <label>{props.label}</label>
        </Row>
        <Row>
            <InputGroup>
            <FormControl type={props.type} min={props.min} onChange={(e)=>{props.onChange(e.target.value)}} value={props.value}/>
        </InputGroup>  
        </Row>
        {props.error?         
        <Row>
            <label className="alertLabel">{props.error}</label>
        </Row>
        :null}
    </>
    );
  }