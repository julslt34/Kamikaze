using System.Collections.Generic;
using Kamikaze.Models;

namespace Kamikaze.Repositories
{
    public interface IUserRepository
    {
        //void Add(User user);
        User GetUserByEmail(string email);
        User GetUserById(int id);
        List<User> GetAllUsers();


        //void Update(User singleUser);
        //****Do I nee this?
        //void UpdateActive(User user);

    }
}

