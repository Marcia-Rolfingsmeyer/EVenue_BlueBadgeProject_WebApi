using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.OccasionModels
{
    public class OccasionEdit
    {
        public string OccasionName { get; set; }

        //public OccasionType TypeOfOccasion { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int VenueProfileId { get; set; }

        public int CustomerId { get; set; }

        public int RoomId { get; set; }

        public int VendorId { get; set; }
    }
}
