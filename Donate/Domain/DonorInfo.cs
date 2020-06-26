using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donate.Domain
{
    public class DonorInfo : BaseEntity
    {
        public DonorInfo()
        {
            DonationDetails = new List<DonationDetails>();
        }
        public string Name { get; set; }
        public string City { get; set; }
        public int ContactNumber { get; set; }
        public string BloodGroup { get; set; }
        public DateTime DischargeDate { get; set; }
        public ICollection<DonationDetails> DonationDetails { get; set; }
    }
}
