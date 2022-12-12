const baseURL = `https://localhost:5001/api/Category`;

export const getAllCategories = () => {
    return fetch(`${baseURL}`)
    .then((res)=> res.json())
};

export const getById = (id) => {
    return fetch(`${baseURL}/${id}`)
        .then((res) => res.json())
}


// export const addCategory = (singleCategory) =>{
//     return fetch (`${baseURL}`, {
//         method: "POST",
//         headers: {
//             "Content-Type": "application/json",
//         },
//         body: JSON.stringify(singleCategory),
//     });
// };


// export const deleteCat = (id) => {
//     return fetch(`${baseURL}/${id}`, {
//         method: "DELETE"
//     })
// }

// export const editCat = (category) => {
//     return fetch(`${baseURL}/${category.id}`, {
//         method: "PUT",
//         headers: {
//             "Content-Type": "application/json"
//         },
//         body: JSON.stringify(category)
//     })
//     .then(getAllCategories)
// }





// import React from 'react';

// const baseUrl = '/api/Category';

// export const getAllCategories = () => {
//     return fetch(`${baseURL}`)
//         .then((res) => res.json())
// };

// export const getById = (id) => {  //http GET by id parameter 
//     return fetch(`https://localhost:5001/api/Category/${id}`)
//         .then((res) => res.json());
// };


