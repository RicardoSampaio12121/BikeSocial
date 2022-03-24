using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record CreateRouteDto(int userId, string Description, DateTime dateTime, int placeId, int routeTypeId, float estimatedTime, float distance);
}
