using EVenue.Models.OccasionModels;
using EVenue.Models.RoomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.RoomOccasionModels
{
    public class RoomOccasionDetail
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public RoomListItem Room { get; set; }
        public int OccasionId { get; set; }
        public OccasionListItem Occasion { get; set; }
    }
}
