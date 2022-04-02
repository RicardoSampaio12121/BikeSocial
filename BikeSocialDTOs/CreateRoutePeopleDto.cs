using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record CreateRoutePeopleDto(int userId, bool Public, string Description, DateTime dateTime, float estimatedTime, float distance, int placeId, int routeTypeId, List<int> people);
}
