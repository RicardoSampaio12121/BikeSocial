using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnFriendDto
    {
        int solicitorId { get; set; }
        int receiptientId { get; set; }
        bool status { get; set; }
        DateTime timeSent { get; set; }
    }
}
