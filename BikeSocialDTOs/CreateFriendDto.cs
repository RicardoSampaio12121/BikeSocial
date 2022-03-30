using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record CreateFriendDto(int solicitor, int recieptient, bool status, DateTime timeSent);
}
