import React, {useState, useEffect} from "react";
import { useNavigate } from "react-router-dom";
import {Category} from "./Category";
import { getAllCategories, getById } from "../../managers/CategoryManager";

const CategoryList = () => {
    const [categories, setCategories] = useState([]);

    const localUser = localStorage.getItem("user")
    const userObject = JSON.parse(localUser)

    // const navigate = useNavigate();

    const getCategories = () => {
        getAllCategories().then( allCategories => setCategories(allCategories))
    };
    useEffect(() => {
        getCategories();
    }, []);

//     const handleDeleteClick = (id) => {
//       getById(id).then((e) => {navigate(`/deleteCategory/${id}`)})
//   }

//     const handleEditClick = (id) => {
//       getById(id).then((e) => {navigate(`/editCategory/${id}`)})
//   }


    
    // return (
    //   <div className="container">
    //     <div className="row justify-content-center" style={{display: 'flex', flexDirection: 'column'}}>
    //       <h4 style={{marginTop: '20px', marginBottom: '15px'}}>Categories</h4>
         
{/*          
          <button onClick={(e) => {
            navigate('/createCategory')
          }} style={{width: '120px', marginBottom: '25px'}}
          >New Category</button>
            <div className="cards-column">
                {categories.map((c) => (
                  <div style={{display: 'flex'}}>
                    <Category key={c.id} category={c} />
                    <button onClick={(e) => {
                      handleDeleteClick(c.id)
                    }} style={{width: '60px', height: '30px', margin: '5px'}}>Delete</button>
                    <button onClick={(e) => {
                      handleEditClick(c.id)
                    }} style={{width: '43px', height: '30px', margin: '5px'}}> Edit </button>
                    </div>
                    ))}

        </div>
//       */}
     
//       </div>
//     </div>
//     )
// }


return (
    <>
    {/* <Link to={`/createPost`}>
      New Post
    </Link> */}
    <h1>Categories</h1>
    <div className="container">
      <div className="row justify-content-center">
        <div className="cards-column">
          {categories?.map((category) => (
            <>
              <Category key={category.id} category={category} />
            </>
          ))}
        </div>
      </div>
    </div>
    </>
  );
};

export default CategoryList;