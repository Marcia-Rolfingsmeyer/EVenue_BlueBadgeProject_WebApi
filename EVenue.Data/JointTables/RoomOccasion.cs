using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Data.JointTables
{
    public class RoomOccasion
    {
        [Key]
        public int Id { get; set; }
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        [ForeignKey(nameof(Occasion))]
        public int OccasionId { get; set; }
        public virtual Occasion Occasion { get; set; }
    }
}
