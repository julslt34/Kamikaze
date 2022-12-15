import React from "react";
import { getUserById } from "../../managers/UserManager";
import { useParams } from "react-router-dom";
import { useState } from "react";
import { useEffect } from "react";
import { Link } from "react-router-dom";

const UserDetail = () => {
    const [user, setUser] = useState({})
    const {id} = useParams();

    useEffect(
    () => {
        getUserById(id).then((u) => {setUser(u)})
    }, []);

    if (!user){
        return null;
    }
console.log(user)

    return (
        <>
        <div style={{width: '1300px', display: 'flex', justifyContent: 'left', marginLeft: '50px', marginTop: '50px', alignContent: 'center'}}>
            <div style={{borderBottom: '1px solid blue', width: '20%'}}>
            <h4>{user.userName}</h4>            
            <h6 style={{marginTop: '15px'}}>Name: {user.userName} </h6>
            <h6>Email: {user.email}</h6>
            <p>
            User Since: {user.yearEstablished}</p>
        </div>
        
        </div>
        <div style={{marginLeft: '50px'}}>
         <Link to="/users">Go Back</Link>
         </div>
         </>
    )
}

export default UserDetail;