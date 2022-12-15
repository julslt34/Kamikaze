
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Kamikaze.Models
{ 
    public class TripPlan
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int DestinationId { get; set; }

        public Destination Destination { get; set; }

        public string Notes { get; set; }

        public string TripDate { get; set; }


        public List<TripPlan> TripPlans { get; set; }



    }
}