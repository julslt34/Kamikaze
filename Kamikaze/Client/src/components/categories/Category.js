// import React from "react";
// import { useNavigate } from "react-router-dom";
// import { useParams } from "react-router-dom";
// import { Link } from "react-router-dom";

// const Category = ({category}) => {
//     const {id} = useParams();
//     const navigate = useNavigate();


//     return (
//         <div style={{display:'flex', letterSpacing: '.5px', alignItems: 'center', margin: '15px', borderBottom: '1px solid gray', height: '30px', width: '500px', justifyContent: 'space-between'}}>
//             <h5 style={{ marginRight: '15px' }}>{category.name}</h5>
//         </div>
//     )
// }


// export default Category;



import React from "react";
import { Card, CardImg, CardBody } from "reactstrap";
import { Link } from "react-router-dom";


export const Category = ({ category }) => {
  return (
    <Card className="m-4">
      <CardBody>
        {/* <Link to={`/destinations/${destination.id}`}>
            <strong>{destination.DestinationName}</strong>
        </Link> */}


         <Link to={`/categorys/${category.id}`}>
            <p>Where:        {category.name}</p>            
         </Link> 




          {/* <img src= {destination.imageLocation}/>
         <p>Description: {category.description}</p>  */}

         
{/*         
        {destination?.comments.length ? post?.comments?.map(comment => 
            <p key={comment?.id} className="text-left px-2">Comment: {comment?.message}</p>) : ""}  */}
       
        </CardBody>

    </Card>
  );
};