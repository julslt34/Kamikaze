using Kamikaze.Models;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Kamikaze.Repositories;

namespace Kamikaze.Repositories
{
    public interface IDestinationRepository
    {
      List<Destination> GetAllDestinations();
        Destination GetDestinationById(int id);

        //Destination GetDestinationByCategory(int CategoryId);

        List<Destination> GetDestinationByCategory(int CategoryId);






        //List<Destination> GetDestinationByUser(int id);
        //Destination GetUserDestinationById(int userId, int id);
        //Destination GetByIdWithComments(int id);
        //void Add(Destination destination);
        //void Update(Destination destination);
        //bool GetDestinationCategoryId(int id);
        //void DeleteDestination(int id);
    }
}