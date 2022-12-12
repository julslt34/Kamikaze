using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Kamikaze.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


       public List<Category> Categorys { get; set; }

    }
}