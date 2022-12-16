import React from "react";
import { useState, useEffect } from "react";
import { addTripPlan } from "../../managers/TripPlanManager";
import { CardLink } from "reactstrap";
import { useNavigate, useParams } from "react-router-dom";
import { getCurrentUser } from "../../managers/UserManager";

export const TripPlanForm = () => {
  const navigate = useNavigate();
  const currentUser = getCurrentUser();
  const { id } = useParams();

  const [newTripPlan, setNewTripPlan] = useState({
    notes: "",
    tripDate: "",
    userId: currentUser.id,
    destinationId: id,
  });

  const handleNewTripPlan = (e) => {
    e.preventDefault();
    const tripPlanToSend = {
      notes: newTripPlan.notes,
      tripDate: newTripPlan.tripDate,
      userId: currentUser.id,
      destinationId: id,
    };
    debugger;
    addTripPlan(tripPlanToSend).then((t) => {
      navigate(`/tripPlans/${id}`);
    });
  };

  const saveNewTripPlan = (e) => {
    const copy = { ...newTripPlan };
    copy[e.target.id] = e.target.value;
    setNewTripPlan(copy);
  };

  return (
    <>
      <form onSubmit={handleNewTripPlan}>
        <div className="col-md-3">
          <input
            type="text"
            placeholder="Notes"
            onChange={saveNewTripPlan}
            className="form-control"
            id="notes"
          />
          <input
            type="text"
            placeholder="Trip Date"
            onChange={saveNewTripPlan}
            className="form-control"
            id="tripDate"
          />
          <button type="submit" className="btn btn-primary mt-2">
            Save Trip
          </button>
          <CardLink href={`/tripPlans/`}>Back to Trip Plans</CardLink>
          {/* <CardLink href={`/tripPlans/${id}`}>Back to Trip Plans</CardLink> */}
          <CardLink href={`/destinations/`}>Back to Destinations</CardLink>
          {/* <CardLink href={`/destinations/${id}`}>Back to Destinations</CardLink> */}
        </div>
      </form>
    </>
  );
};