using EVenue.Data.JointTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumProperties.RoomTypeEnum;

namespace EVenue.Data
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string RoomName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Amenities { get; set; }

        [Required]      
        public RoomType TypeOfRoom { get; set; }

        [Range(0, 200000)]
        [Required]
        public double PricePerHour { get; set; }

        [Range(0, 200000)]
        [Required]
        public double BasePricePerDay { get; set; }

        [Required]
        public int MaxCapacity { get; set; }

        public virtual List<RoomOccasion> RoomOccasions { get; set; } = new List<RoomOccasion>();
    }
}
