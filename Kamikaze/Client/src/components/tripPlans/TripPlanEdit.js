import React from "react";
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import { getTripPlan, editTripPlan } from "../../managers/TripPlanManager";



const TripPlanEdit = () => {
    const [tripPlan, update] = useState({
        Notes: "",
        TripDate: ""
    });

    const navigate = useNavigate();
    const { id } = useParams();  
    
    // const localUser = localStorage.getItem("user")
    // const userObject = JSON.parse(localUser)

    // const [categories, setCategories] = useState([])

    // useEffect(() => {
    //     getAllCategories().then(setCategories);
    // }, []);

    useEffect(() => {
        getTripPlan(id).then(update)        
    }, [])
    

     function Edit(e) {

        e.preventDefault();

        const editedTripPlan = {
            id: tripPlan.id,                  
            userId: tripPlan.userId,            
            destinationId: tripPlan.destinationId,
            notes: tripPlan.notes,
            tripDate: tripPlan.tripDate
        }

        editTripPlan(editedTripPlan).then(() => {
            console.log("here?");
            navigate(`/tripPlans/${editedTripPlan.id}`)});        
    }

    const Cancel = () => {
        navigate(`/TripPLans/${id}`)
    }

    return (
        <form className="tripPlanForm">
            <h2 className="tripPlanForm__Title">Edit Trip Plan</h2>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="Notes">Notes:</label>
                    <input
                        required autoFocus
                        type="text"
                        className="form-control"
                        placeholder="TripPlan notes"
                        value={tripPLan.notes}
                        onChange={(changeEvent) => {
                            const copy = {...tripPlan}
                            copy.notes = changeEvent.target.value
                            update(copy)
                        }} />
                </div>
            </fieldset>
           
                      
            <button className="btn btn-primary" style={{marginRight: '10px'}} onClick={ e => Edit(e) }>Edit</button>
            <button onClick={ e => Cancel() }>Cancel</button>
        </form>
    )
}

export default TripPlanEdit;