using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public class GetFriendDto
    {
        public int recieptientId { get; set; }
        public bool status { get; set; }
        public DateTime timeSent { get; set; }
    }
}
