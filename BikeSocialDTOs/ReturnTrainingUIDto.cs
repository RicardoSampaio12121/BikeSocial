using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnTrainingUIDto(int trainId, string type, int typeId, string place, int placeId, DateTime dateTime, float estimatedTime, float distance);
}
