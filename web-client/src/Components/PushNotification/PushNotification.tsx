import React from "react";
import { useEffect } from "react";
import { useState } from "react";
import { Toast } from "react-bootstrap";
import './PushNotification.scss';

export default function PushNotification(props:{text:string|null, refState:Function}) {
    return (
      <Toast onClose={() => props.refState(null)} show={props.text!==null} delay={3000} autohide className='positionToast'>
            <Toast.Body>{props.text}</Toast.Body>
      </Toast>
    );
  }