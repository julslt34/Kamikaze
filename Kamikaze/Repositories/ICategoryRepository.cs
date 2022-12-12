using Kamikaze.Models;
using System.Collections.Generic;


namespace Kamikaze.Repositories
{
    public interface ICategoryRepository
    {
        public List<Category> GetAllCategories();

        //void Add(Category category);
        //void Delete(int id);
        Category GetById(int id);

        //void Update(Category category);
    }
}