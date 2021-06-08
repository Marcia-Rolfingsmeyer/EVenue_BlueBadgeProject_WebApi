using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Data
{
    //public enum OccasionType {Other, Wedding, Retirement, Birthday, Corporate, Club, Funeral}
    public class Occasion
    {
        [Key]
        public int OccasionId { get; set; }
        public Guid OwnerId { get; set; }
        public string OccasionName { get; set; }
        //public OccasionType TypeOfOccasion { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey(nameof(VenueProfile))]
        public int VenueProfileId { get; set; }
        public virtual VenueProfile VenueProfile { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
