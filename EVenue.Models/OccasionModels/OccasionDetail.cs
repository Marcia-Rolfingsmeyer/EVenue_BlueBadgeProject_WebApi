using EVenue.Models.CustomerModels;
using EVenue.Models.RoomModels;
using EVenue.Models.VendorModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumProperties.OccasionEnum;

namespace EVenue.Models.OccasionModels
{
    public class OccasionDetail
    {
        public int OccasionId { get; set; }

        public string OccasionName { get; set; }

        [Range(1, 9, ErrorMessage = "TypeOfOccasion requires a value from 1-9")]
        public OccasionType TypeOfOccasion { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int VenueProfileId { get; set; }

        //public int CustomerId { get; set; }
        public List<CustomerListItem> Customers { get; set; }

        //public int RoomId { get; set; }
        public List<RoomListItem> Rooms { get; set; }

        //public int VendorId { get; set; }
        public List<VendorListItem> Vendors { get; set; }

        public double TotalPrice { get; set; }
    }
}
