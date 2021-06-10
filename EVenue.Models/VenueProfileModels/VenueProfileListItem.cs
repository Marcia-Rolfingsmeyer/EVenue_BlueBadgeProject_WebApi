using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.VenueProfileModels
{
    public class VenueProfileListItem
    {
        public int VenueProfileId { get; set; }

        public string VenueName { get; set; }

        public string VenueContactPerson { get; set; }

        public string VenuePhone { get; set; }

        public string VenueAddress { get; set; }

        public string VenueEmail { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
