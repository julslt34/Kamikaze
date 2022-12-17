import React from "react";
import { Route, Routes, Navigate } from "react-router-dom";

import CategoryList from "./categories/CategoryList";
import {TripPlanForm} from "./tripPlans/TripPlanForm";
import Hello from "./Hello";
import UserDetail from "./user/UserDetail";
 import UserList from "./user/UserList";
 import DestinationList from "./destinations/DestinationList";
 import TripPlanList from "./tripPlans/TripPlanList";
 import TripPlanDelete from "./tripPlans/TripPlanDelete";
  import TripPlanEdit from "./tripPlans/TripPlanEdit";


export default function ApplicationViews() {

 return(
      <Routes>
        <Route path="/" element={<Hello />} />
      
        <Route path="/users" element={<UserList />} />
        <Route path="/user/:id" element={<UserDetail />} /> 
        <Route path="/categories" element={<CategoryList />} />
        <Route path="/destinations" element={<DestinationList />} />
         <Route path="/destinations/:id" element={<TripPlanForm />} /> 
         <Route path="/deleteTripPlan/:id" element={<TripPlanDelete />} />
        {/* <Route path="posts/:id/addComment" element={<CommentNew />} /> */}
         {/* <Route path ="/post/details/:postId" element={<PostDetails />} /> */}
         
        <Route path="/tripPlans" element={<TripPlanList />} />
        <Route path="/editTripPlan/:id" element={ <TripPlanEdit /> } /> 

       
        {/* <Route path="tripPlans/:id/addComment" element={<CommentNew />} />
    </Routes> */}
      </Routes>
   );
 

}
