using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.VenueProfileModels
{
    public class VenueProlfieDetail
    {
        [Required]
        public int VenueProfileId { get; set; }

        public string VenueName { get; set; }

        public string VenueContactPerson { get; set; }

        [Required]
        public string VenuePhone { get; set; }

        [Required]
        public string VenueAddress { get; set; }

        public string VenueEmail { get; set; }
    }
}
