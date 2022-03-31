using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnFriendDto
    {
        int Id { get; set; }
        int solicitor { get; set; }
        int receiptient { get; set; }
        bool status { get; set; }
        DateTime timeSent { get; set; }
    }
}
