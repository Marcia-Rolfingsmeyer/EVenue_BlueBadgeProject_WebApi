using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.RoomOccasionModels
{
    public class RoomOccasionCreate
    {
        [Required]
        public int RoomId { get; set; }

        [Required]
        public int OccasionId { get; set; }
    }
}
