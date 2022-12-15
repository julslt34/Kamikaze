using Kamikaze.Models;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Kamikaze.Repositories

{
    public interface ITripPlanRepository
    {
        List<TripPlan> GetAllTripPlans();
        TripPlan GetTripPlanById(int id);

        //List<TripPlan> GetDestinationByCategory(int CategoryId);

        public void Insert(TripPlan tripPlan);
        public void Update(TripPlan tripPlan);
        public void Delete(int id);



    }
}
