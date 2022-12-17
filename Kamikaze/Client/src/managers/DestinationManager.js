const apiUrl = "https://localhost:5001/api";

export const getAllDestinations = () => {
  return fetch(`${apiUrl}/Destination`)
    .then((res) => res.json())
};


// export const addCategory = (singleCategory) =>{
//     return fetch (`${baseURL}`, {
//         method: "POST",
//         headers: {
//             "Content-Type": "application/json",
//         },
//         body: JSON.stringify(singleCategory),
//     });
// };
