using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Description { get; set; }

        [Required]
        public string Amenities { get; set; }

        [Required]
        [Display(Name = "Room Type")]
        [Range(1, 2, ErrorMessage = "must select 1 (Indoors), 2 (Outdoors), or 3 (Both)")]
        public RoomType TypeOfRoom { get; set; }

        [Required]
        [Display(Name = "Price Per Hour")]
        [RegularExpression(@"^[0-9]*(\.[0-9]{1,2})?$")]
        public double PricePerHour { get; set; }

        [Required]
        [Display(Name = "Base Price Per Day")]
        [RegularExpression(@"^[0-9]*(\.[0-9]{1,2})?$")]
        public double BasePricePerDay { get; set; }

        [Required]
        [Display(Name = "Maximum Capacity")]
        [Range(0, int.MaxValue)]
        public int MaxCapacity { get; set; }
    }
}
