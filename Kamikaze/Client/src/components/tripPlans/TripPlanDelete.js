import React from "react";
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import { getTripPlan, deleteTripPlan, getTripPlanById } from "../../managers/TripPlanManager";
import { CardLink } from "reactstrap";

const TripPlanDelete = () => {
    const [chosenTripPlan, setChosenTripPlan] = useState({});

    const navigate = useNavigate();
    const {id} = useParams();    

    // useEffect(() => {
    //     getTripPlan(id).then(setChosenTripPlan)        
    // }, [])
    

    useEffect(
        () => {
            getTripPlan(id).then((c) => {setChosenTripPlan(c)}).then(console.log(chosenTripPlan))
            
        },
        []
        )
    
        console.log(chosenTripPlan)


    const Delete = () => {
        deleteTripPlan(chosenTripPlan.id).then((c) => {
            navigate(`/TripPlans`)
        })
    }

    const Cancel = () => {
        navigate(`/TripPlans/${id}`)
    }

    return (
        <div style={{display:'flex', flexDirection: 'column', letterSpacing: '.5px', alignItems: 'center', margin: '45px', height: '30px', width: '500px', justifyContent: 'space-between'}}>
            <h5 style={{marginBottom: '45px'}}>Are you sure you wish to delete this Trip Plan?</h5>
            <div style={{display: 'flex'}}>
            <h5 style={{ marginRight: '30px' }}>{chosenTripPlan.id}</h5>
            <button style={{marginRight: '10px'}} onClick={(c) => {
                Delete()
            }}>Delete</button>
            <button onClick={(c) => {
                Cancel()
            }}>Cancel</button>
            </div>
        </div>
    )




    // return (
    //     <div style={{display:'flex', flexDirection: 'column', letterSpacing: '.5px', alignItems: 'center', margin: '45px', height: '30px', width: '500px', justifyContent: 'space-between'}}>
    //         <h5 style={{marginBottom: '45px'}}>Are you sure you wish to delete this Trip Plan?</h5>
    //         <div style={{display: 'flex'}}>
    //             <button style={{marginRight: '10px'}} onClick={ e => Delete() }>Delete</button>
    //             <button onClick={ e => Cancel() }>Cancel</button>
    //         </div>
    //     </div>
    // )
}

export default TripPlanDelete;