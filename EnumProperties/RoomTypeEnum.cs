using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumProperties
{
    public class RoomTypeEnum
    {
        public enum RoomType
        {
            SmallHall = 1,
            MediumHall,
            LargeHall
        }

        public RoomType TypeOfRoom { get; set; }
    }
}
