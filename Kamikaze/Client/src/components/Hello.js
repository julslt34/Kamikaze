// import React from "react";

import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useNavigate, Link } from "react-router-dom";


export default function Hello() {
  return (
    <span style={{
      position: "fixed",
      left: 0,
      right: 0,
      top: "50%",
      marginTop: "-0.5rem",
      textAlign: "center",
    }}>FIND A JOURNEY THAT INSPIRES YOU!
   
   
        <em>
          <Link to="/destinations"><FormGroup>
          <Button>Start Here!</Button>
        </FormGroup></Link>
        </em>
   
        {/* <FormGroup>
          <Button>Login</Button>
        </FormGroup> */}

    </span>
  );
}