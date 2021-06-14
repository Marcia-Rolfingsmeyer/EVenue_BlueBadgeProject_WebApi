using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumProperties.RoomTypeEnum;

namespace EVenue.Models.RoomModels
{
    public class RoomDetail
    {
        public int RoomId { get; set; }

        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        public string Description { get; set; }

        public string Amenities { get; set; }

        [Display(Name = "Room Type")]
        public RoomType TypeOfRoom { get; set; }

        [Display(Name = "Price Per Hour")]
        public double PricePerHour { get; set; }

        [Display(Name = "Base Price Per Day")]
        public double BasePricePerDay { get; set; }

        [Required]
        [Display(Name = "Maximum Capacity")]
        public int MaxCapacity { get; set; }
    }
}
