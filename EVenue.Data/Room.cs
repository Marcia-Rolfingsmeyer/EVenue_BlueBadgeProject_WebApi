using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Data
{
    public enum RoomType
    {
        SmallHall = 1,
        MediumHall = 2,
        LargeHall =3
    }

    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public string RoomName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Amenities { get; set; }

        [Required]
        public RoomType TypeOfRoom { get; set; }


        [Required]
        public double PricePerHour { get; set; }

        [Required]
        public double BasePricePerDay { get; set; }

        //public virtual ICollection<OccasionItemList> Occasions = new ICollection<OccasionItemList>();
    }
}
