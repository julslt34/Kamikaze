import React from "react";
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import { getTripPlan, editTripPlan } from "../../managers/TripPlanManager";




const TripPlanEdit = () => {   
    const [tripPlan, setTripPlan] = useState({});

    const navigate = useNavigate();
    const {id} = useParams();



    useEffect(
    () => {
        getTripPlan(id).then((t) => {setTripPlan(t)})        
    },
    []
    )    

    console.log(tripPlan);

    const saveEdit = (e) => {
        e.preventDefault()
        const newTripPlan = {
            id: tripPlan.id,                  
            userId: tripPlan.userId,            
            destinationId: tripPlan.destinationId,
            notes: tripPlan.notes,
            tripDate: tripPlan.tripDate
        }
        console.log(newTripPlan)
        editTripPlan(newTripPlan).then((e) => {
            navigate('/tripPlans')
        })
    }

    const handleCancel = (e) => {
        navigate('/tripPlans')
    }

    return (
        <div style={{display:'flex', flexDirection: 'column', letterSpacing: '.5px', alignItems: 'center', margin: '45px', height: '30px', width: '500px', justifyContent: 'space-between'}}>
            <h5 style={{marginBottom: '45px'}}>Edit Trip Plan</h5>
            <div style={{display: 'flex'}}>
            <fieldset>
            <input
             style={{marginRight: '10px'}}
             type="text" name="title"  value={tripPlan.notes}
              onChange={(e) => {
                const copy = {...tripPlan}
                copy.notes = e.target.value
                setTripPlan(copy);}
              }
            />
          </fieldset>
          <fieldset>
            <input
             style={{marginRight: '10px'}}
              type="text"
              placeholder={tripPlan.tripDate}
              value={tripPlan.tripDate}
              onChange={(e) => {
                const copy = {...tripPlan}
                copy.tripDate = e.target.value
                setTripPlan(copy);}
              }
            />
          </fieldset>
            <button style={{marginRight: '10px'}} onClick={(e) => {
                saveEdit(e)
            }}>Save</button>
            <button onClick={(e) => {
                handleCancel()
            }}>Cancel</button>
            </div>
        </div>
    )
}

export default TripPlanEdit;