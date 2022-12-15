import React from "react";
import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";

const User = ({user, get}) => {

    const navigate = useNavigate();

    //Perform a patch to update isActive state when button is clicked
console.log(user)
    const handleActive = () => {

        //object to be updated
        const updatedUser = {
            id: user.id,
            userName: user.userName,            
            email: user.email,
            yearEstablished: user.yearEstablished
              }


        return fetch(`https://localhost:5001/api/User/${user.id}`, {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(updatedUser),
        })
          .then((response) => response.json())
          .then((users) =>
           get(users)
          );
      };

    const handleNotActive = () => {

        //object to be updated
        const updatedUser = {
            id: user.id,
            userName: user.userName,            
            email: user.email,
            earEstablished: user.yearEstablished

        }


        return fetch(`https://localhost:5001/api/User/${user.id}`, {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(updatedUser), })
        .then((response) => response.json())
        .then((users) => {
            get(users)
        })
      }

    return (
        <div style={{ width: '20%', borderBottom: 'solid 1px blue'}}>
            <Link to={`/users/${user.id}`}>
    <strong>{user.userName}</strong></Link>
            <h6>User Name: {user.userName}</h6>
            
            {/* {user.isActive ?
            <button onClick={(e) => {
                handleActive()
            }} style={{marginBottom: '15px', marginTop: '15px'}}
            >DEACTIVATE</button>
            :
            <button onClick={(e) => {
                handleNotActive();
            }} style={{marginBottom: '15px', marginTop: '15px'}}>ACTIVATE</button>} */}
        </div>
)}

export default User;