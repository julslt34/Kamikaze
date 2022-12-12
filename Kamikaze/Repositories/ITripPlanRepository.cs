using Kamikaze.Models;
using System.Collections.Generic;

namespace Kamikaze.Repositories

{
    public interface ITripPlanRepository
    {
        List<TripPlan> GetAllTripPlans();
        TripPlan GetTripPlanById(int id);

        //List<TripPlan> GetDestinationByCategory(int CategoryId);

    }
}
