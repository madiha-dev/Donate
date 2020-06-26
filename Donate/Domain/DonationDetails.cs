using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donate.Domain
{
    public class DonationDetails : BaseEntity
    {
        public DonationDetails()
        {
            IsAvailable = true;
            DonationCount = 0;
        }
        public bool IsAvailable { get; set; }
        public int DonationCount { get; set; }
    }
}
