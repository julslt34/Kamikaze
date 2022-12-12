const apiUrl = "https://localhost:5001";

  export const login = (userObject) => {
    return fetch(`${apiUrl}/api/user/getuserbyemail?email=${userObject.email}`)
    .then((r) => r.json())
      .then((user) => {
        if(user.id){
          localStorage.setItem("user", JSON.stringify(user));
          return user
        }
        else{
          return undefined
        }
      });
  };

  export const logout = () => {
        localStorage.clear()
  };

  export const register = (userObject, password) => {
    return  fetch(`${apiUrl}/api/user`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(userObject),
    })
    .then((response) => response.json())
      .then((savedUser) => {
        localStorage.setItem("user", JSON.stringify(savedUser))
      });
  };





  // return (
  //   <UserProfileContext.Provider value={{ isLoggedIn, login, logout, register,  }}>
  //      {props.children}
  //   </UserProfileContext.Provider>
  // );






// import React from 'react';

// const baseUrl = '/api/User';

// export const GetAllUsers = () => {
//     return fetch(`${baseURL}`)
//         .then((res) => res.json())
// };
