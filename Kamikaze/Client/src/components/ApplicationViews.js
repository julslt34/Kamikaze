import React from "react";
import { Route, Routes, Navigate } from "react-router-dom";

import CategoryList from "./categories/CategoryList";

import Hello from "./Hello";
import UserDetail from "./user/UserDetail";
 import UserList from "./user/UserList";
 import DestinationList from "./destinations/DestinationList";

export default function ApplicationViews() {

 return(
      <Routes>
        <Route path="/" element={<Hello />} />
        {/* <Route path="/categories" element={<CategoryList />} /> */}
        
        <Route path="/users" element={<UserList />} />
        <Route path="/user/:id" element={<UserDetail />} /> 
        <Route path="/categories" element={<CategoryList />} />
        <Route path="/destinations" element={<DestinationList />} />
      </Routes>
   );
 

}
