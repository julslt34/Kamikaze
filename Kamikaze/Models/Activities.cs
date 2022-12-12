
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Kamikaze.Models
{
    public class Activities
    {
        public int Id { get; set; }


        [Required]
        public int DestinationId { get; set; }

        public string Content { get; set; }
        public string ImageLocation { get; set; }

        public string ActivityLink { get; set; }


        public List<Activities> AllActivities { get; set; }



    }
}