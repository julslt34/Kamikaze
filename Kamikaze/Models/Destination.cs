
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Kamikaze.Models
{
    public class Destination
    {
        public int Id { get; set; }

        [Required]
        public string DestinationName { get; set; }


        [Required]
        public int CategoryId { get; set; }

        public string ImageLocation { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }
        public List<Destination> Destinations { get; set; }



    }
}