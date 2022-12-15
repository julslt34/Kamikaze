import React, { useState, useEffect, useContext } from "react";
import { TripPlan } from './TripPlan';
import { getAllTripPlans } from "../../managers/TripPlanManager";
import { Link } from "react-router-dom";

const TripPlanList = () => {
  const [tripPlans, setTripPlans] = useState([]);

//   const localUser = localStorage.getItem("user")
//   const userObject = JSON.parse(localUser)

  const getTripPlans = () => {
    getAllTripPlans().then(allTripPlans => setTripPlans(allTripPlans));
  };


  useEffect(() => {
    getTripPlans();
  }, []);

  return (
    <>
    {/* <Link to={`/createPost`}>
      New Post
    </Link> */}
    <h1>My Trip Plans</h1>
    <div className="container">
      <div className="row justify-content-center">
        <div className="cards-column">
          {tripPlans?.map((tripPlan) => (
            <>
              <TripPlan key={tripPlan.id} tripPlan={tripPlan} />
            </>
          ))}
        </div>
      </div>
    </div>
    </>
  );
};

export default TripPlanList;