using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Data
{
    public class VenueProfile
    {
        [Key]
        public int VenueProfileId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string VenueName { get; set; }

        public string VenueContactPerson { get; set; }

        [Required]
        public string VenuePhone { get; set; }

        [Required]
        public string VenueAddress { get; set; }

        public string VenueEmail { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
