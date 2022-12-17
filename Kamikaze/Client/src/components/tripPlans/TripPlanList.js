import React, { useState, useEffect, useContext } from "react";
import { TripPlan } from './TripPlan';
import { getAllTripPlans, getTripPlan, getTripPlanById } from "../../managers/TripPlanManager";
import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";


const TripPlanList = () => {
  const [tripPlans, setTripPlans] = useState([]);

  const localUser = localStorage.getItem("user")
  const userObject = JSON.parse(localUser)

const navigate = useNavigate();

  const getTripPlans = () => {
    getAllTripPlans().then(allTripPlans => setTripPlans(allTripPlans));
  };


  useEffect(() => {
    getTripPlans();
  }, []);

  const handleDeleteClick = (id) => {
    getTripPlan(id).then((c) => { navigate(`/deleteTripPlan/${id}`) })
}

const handleEditClick = (id) => {
  getTripPlan(id).then((e) => { navigate(`/editTripPlan/${id}`) })
}



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
            // <>
            //   <TripPlan key={tripPlan.id} tripPlan={tripPlan} />
            // </>

<div style={{ display: 'flex' }}>
<TripPlan key={tripPlan.id} tripPlan={tripPlan} />
<button onClick={(e) => {
    handleDeleteClick(tripPlan.id)
}} style={{ width: '60px', height: '30px', margin: '5px' }}>Delete</button>
<button onClick={(e) => {
    handleEditClick(tripPlan.id)
}} style={{ width: '43px', height: '30px', margin: '5px' }}> Edit </button>
</div>


          ))}
        </div>
      </div>
    </div>
    </>
  );
};

export default TripPlanList;