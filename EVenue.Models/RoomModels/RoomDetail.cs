using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.RoomModels
{
    public class RoomDetail
    {
        public int RoomId { get; set; }

        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        public string Description { get; set; }

        public string Amenities { get; set; }

        //[Display(Name = "Room Size")]
        //public RoomType TypeOfRoom { get; set; }

        [Display(Name = "Price Per Hour")]
        [Range(0, double.MaxValue, ErrorMessage = "The price must be greater than 0.")]
        public double PricePerHour { get; set; }

        [Display(Name = "Base Price Per Day")]
        [Range(0, double.MaxValue, ErrorMessage = "The price must be greater than 0.")]
        public double BasePricePerDay { get; set; }

    }
}
