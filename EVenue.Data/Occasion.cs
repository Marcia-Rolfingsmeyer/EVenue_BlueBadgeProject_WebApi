using EVenue.Data.JointTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumProperties.OccasionEnum;

namespace EVenue.Data
{

    public class Occasion
    {
        [Key]
        public int OccasionId { get; set; }
        public Guid OwnerId { get; set; }
        public string OccasionName { get; set; }
        public OccasionType TypeOfOccasion { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey(nameof(VenueProfile))]
        public int VenueProfileId { get; set; }
        public virtual VenueProfile VenueProfile { get; set; }

        //Joining Tables
        public virtual List<CustomerOccasion> CustomerOccasions { get; set; } = new List<CustomerOccasion>();
        public virtual List<RoomOccasion> RoomOccasions { get; set; } = new List<RoomOccasion>();
        public virtual List<VendorOccasion> VendorOccasions { get; set; } = new List<VendorOccasion>();

        //TotalPrice Method
        public double TotalPrice()
        {
            TimeSpan duration = EndTime - StartTime;
            double numOfHours = duration.TotalHours;
            double price = 0;
            foreach (RoomOccasion roomOccasion in RoomOccasions)
            {
                price += roomOccasion.Room.BasePricePerDay;
                price += numOfHours * roomOccasion.Room.PricePerHour;
            }
            foreach (VendorOccasion vendorOccasion in VendorOccasions)
            {
                price += vendorOccasion.Vendor.VendorFee;
            }
            return price;
        }
    }
}
