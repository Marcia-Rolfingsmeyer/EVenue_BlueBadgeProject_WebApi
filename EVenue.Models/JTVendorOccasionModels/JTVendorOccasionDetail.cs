using EVenue.Models.OccasionModels;
using EVenue.Models.VendorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVenue.Models.JTVendorOccasionModels
{
    public class JTVendorOccasionDetail
    {
        public int VendorId { get; set; }
        public VendorListItem Vendor { get; set; }
        public int OccasionId { get; set; }
        public OccasionListItem Occasion { get; set; }
    }
}
