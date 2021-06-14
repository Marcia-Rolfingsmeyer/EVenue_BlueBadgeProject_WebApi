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

        public string VenuePhone { get; set; }

        public string VenueAddress { get; set; }

        public string VenueEmail { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
