import React from "react";
import { Card, CardImg, CardBody } from "reactstrap";
import { Link } from "react-router-dom";




export const TripPlan = ({ tripPlan }) => {
  return (
    <Card className="m-4">
      <CardBody>
        {/* <Link to={`/destinations/${destination.id}`}>
            <strong>{destination.DestinationName}</strong>
        </Link> */}
        <Link to={`/tripPlan/${tripPlan.id}`}>
        <p>Destination:        {tripPlan.destination.destinationName}</p>   
            <p>Notes:        {tripPlan.notes}</p>  

         </Link> 
         <img src= {tripPlan.destination.imageLocation}/>
        

        </CardBody>

    </Card>
  );
};