using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumProperties.RoomTypeEnum;

namespace EVenue.Models.RoomModels
{
    public class RoomCreate
    {
        [Required]
        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Amenities")]
        public string Amenities { get; set; }

        [Required]
        [Display(Name = "Room Size")]
        public RoomType TypeOfRoom { get; set; }

        [Required]
        [Display(Name = "Price Per Hour")]
        [Range(0, double.MaxValue, ErrorMessage = "The price must be greater than 0.")]
        public double PricePerHour { get; set; }

        [Required]
        [Display(Name = "Base Price Per Day")]
        [Range(0, double.MaxValue, ErrorMessage = "The price must be greater than 0.")]
        public double BasePricePerDay { get; set; }
    }
}
