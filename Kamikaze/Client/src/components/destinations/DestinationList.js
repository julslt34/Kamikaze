import React, { useState, useEffect, useContext } from "react";
import { Destination } from './Destination';
import { getAllDestinations } from "../../managers/DestinationManager";
import { Link } from "react-router-dom";

const DestinationList = () => {
  const [destinations, setDestinations] = useState([]);

  const localUser = localStorage.getItem("user")
  const userObject = JSON.parse(localUser)

  const getDestinations = () => {
    getAllDestinations().then(allDestinations => setDestinations(allDestinations));
  };


  useEffect(() => {
    getDestinations();
  }, []);

  return (
    <>
    {/* <Link to={`/createPost`}>
      New Post
    </Link> */}
    <h1>All Desetinations</h1>
    <div className="container">
      <div className="row justify-content-center">
        <div className="cards-column">
          {destinations?.map((destination) => (
            <>
              <Destination key={destination.id} destination={destination} />
            </>
          ))}
        </div>
      </div>
    </div>
    </>
  );
};

export default DestinationList;