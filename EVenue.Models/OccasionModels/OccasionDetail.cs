using EVenue.Models.RoomModels;
using EVenue.Models.VendorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.OccasionModels
{
    public class OccasionDetail
    {
        public int OccasionId { get; set; }

        public string OccasionName { get; set; }

        //public OccasionType TypeOfOccasion { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int VenueProfileId { get; set; }

        public int CustomerId { get; set; }

        //public virtual ICollection<RentalListItem> Rentals { get; set; }
        
        public virtual ICollection<RoomListItem> Rooms { get; set; }
        
        public virtual ICollection<VendorListItem> Vendors { get; set; }
    }
}
