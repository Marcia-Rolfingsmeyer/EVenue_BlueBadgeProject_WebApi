using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumProperties.RoomTypeEnum;

namespace EVenue.Models.RoomModels
{
    public class RoomListItem
    {
        public int RoomId { get; set; }

        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        [Display(Name = "Room Size")]
        public RoomType TypeOfRoom { get; set; }

        [Display(Name = "Maximum Capacity")]
        public int MaxCapacity { get; set; }
    }
}
