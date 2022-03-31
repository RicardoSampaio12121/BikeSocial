using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnFriendDto
    {
        public int solicitorId { get; set; }
        public int receiptientId { get; set; }
        public bool status { get; set; }
        public DateTime timeSent { get; set; }
    }
}
