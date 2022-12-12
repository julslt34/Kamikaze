using Kamikaze.Models;
using System.Collections.Generic;


namespace Kamikaze.Repositories
{
    public interface IActivitiesRepository
    {
        List<Activities> GetAllActivities();

        //public void AddActivities(Activities newActivities);
        //public void DeleteActivities(int activitiesId);
        //public void EditActivities(Activities activities);
        Activities GetActivitiesById(int id);
    }
}
