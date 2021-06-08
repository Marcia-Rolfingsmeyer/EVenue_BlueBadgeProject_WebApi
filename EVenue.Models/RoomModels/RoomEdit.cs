using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.RoomModels
{
    public class RoomEdit
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public string Amenities { get; set; }
        //public RoomType TypeOfRoom { get; set; }
        public double PricePerHour { get; set; }
        public double BasePricePerDay { get; set; }
    }
}
