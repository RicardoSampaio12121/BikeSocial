using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnNeededInfoTrainInvUIDto(int athleteId, string username, string place, int concact, string clubName, int clubId);
}
