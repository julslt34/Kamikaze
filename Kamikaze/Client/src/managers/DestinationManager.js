const apiUrl = "https://localhost:5001/api";

export const getAllDestinations = () => {
  return fetch(`${apiUrl}/Destination`)
    .then((res) => res.json())
};