
const apiUrl = "https://localhost:5001/api";

export const getAllTripPlans = () => {
  return fetch(`${apiUrl}/TripPlan`)
    .then((res) => res.json())
};

// export const GetTripPlanById = () => {
//     return fetch('/api/TripPlan/GetTripPlanById')
//       .then((res) => res.json())
//   };


  export const getTripPlanById = (id) => {  //http GET by id parameter 
    return fetch(`https://localhost:5001/api/TripPlan/${id}`)
        .then((res) => res.json());
};


export const getTripPlan = (id) => {
  let tripPlan = fetch(`https://localhost:5001/api/TripPlan/${id}`)
      .then((res) => res.json());
return tripPlan};



export const addTripPlan = (singleTripPlan) => {
  return fetch(`${apiUrl}/TripPlan`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(singleTripPlan)
  });
};


export const editTripPlan = (tripPlan) => {
  return fetch(`${apiUrl}/TripPlan/${tripPlan.id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(tripPlan),
    });
};
  
export const deleteTripPlan = (id) => {
  return fetch(`${apiUrl}/TripPlan/${id}`, {
      method: "DELETE"
    })
};




















// import React from "react";




// const baseUrl = '/api/post';

// export const getAllPosts = () => {
//   return fetch(baseUrl)
//     .then((res) => res.json())
// };

// export const getAllPostsWithComments = () => {
//   return fetch('/api/post/GetWithComments')
//     .then((res) => res.json())
// };

// export const getPost = (id) => {
//   let post = fetch(`/api/Post/${id}`)
//       .then((res) => res.json());
// return post};


// export const getUserPostsById = (id) => {
//   return fetch(`/api/post/getUserPostsById?id=${id}`)
//     .then((res) => res.json());
// }

// export const addPost = (singlePost) => {
//   return fetch(baseUrl, {
//     method: "POST",
//     headers: {
//       "Content-Type": "application/json"
//     },
//     body: JSON.stringify(singlePost)
//   });
// };

// export const deletePost = (id) => {
//   return fetch(`/api/Post/${id}`, {
//       method: "DELETE"
//     })
// };

// export const editPost = (post) => {
//   return fetch(`/api/post/${post.id}`, {
//       method: "PUT",
//       headers: {
//         "Content-Type": "application/json",
//       },
//       body: JSON.stringify(post),
//     });
// };