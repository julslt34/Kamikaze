import React from "react";
import { Card, CardImg, CardBody } from "reactstrap";
import { Link } from "react-router-dom";


export const Destination = ({ destination }) => {
  return (
    <Card className="m-4">
      <CardBody>
        <Link to={`/destinations/${destination.id}`}>
            <strong>{destination.DestinationName}</strong>
        </Link>
        {/* <Link to={`/posts/${post.id}`}>
            <p>Author: {destination.userProfile.displayName}</p>
        {/* </Link> */}
        {/* <p>Category: {destination.category.name}</p> */}
        
        {/* {post?.comments.length ? post?.comments?.map(comment => 
            <p key={comment?.id} className="text-left px-2">Comment: {comment?.message}</p>) : ""} */}
       {/* */} 
        </CardBody>

    </Card>
  );
};