import React from "react";
import { Route, Routes, Navigate } from "react-router-dom";

import CategoryList from "./categories/CategoryList";

import Hello from "./Hello";
// import UserProfileDetails from "./userProfiles/UserProfileDetail";
// import UserProfileList from "./userProfiles/UserProfileList";


export default function ApplicationViews() {

 return(
      <Routes>
        <Route path="/" element={<Hello />} />
        {/* <Route path="/categories" element={<CategoryList />} />
        
        <Route path="/users" element={<UserList />} />
         */}
        
        
      </Routes>
   );
 

}
