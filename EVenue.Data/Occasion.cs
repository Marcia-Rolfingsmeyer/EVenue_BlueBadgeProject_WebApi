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

        //[ForeignKey(nameof(Customer))]
        //public int CustomerId { get; set; }
        //public virtual Customer Customer { get; set; }

        //[ForeignKey(nameof(Room))]
        //public int RoomId { get; set; }
        //public virtual Room Room { get; set; }

        //[ForeignKey(nameof(Vendor))]
        //public int VendorId { get; set; }
        //public virtual Vendor Vendor { get; set; }

        public virtual IEnumerable<CustomerOccasion> CustomerOccasions { get; set; }
        public virtual List<RoomOccasion> RoomOccasions { get; set; } = new List<RoomOccasion>();
        public virtual IEnumerable<VendorOccasion> VendorOccasions { get; set; }

        //public virtual ICollection<Rental> Rentals { get; set; }
        //public virtual ICollection<Room> Rooms { get; set; }
        //public virtual ICollection<Vendor> Vendors { get; set; }



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
