import React from "react";
import { Toast } from "react-bootstrap";
import './PushNotification.scss';

export default function PushNotification(props: {text:string}) {

    return (
      <>
      <div className='positionToast'>
          <Toast show delay={3000} autohide>
            <Toast.Body>{props.text}</Toast.Body>
          </Toast>
      </div>
      </>
    );
  }