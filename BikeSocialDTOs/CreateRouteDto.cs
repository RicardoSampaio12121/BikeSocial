using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record CreateRouteDto(bool Public, string Description, DateTime dateTime, float estimatedTime, float distance, int placeId, int routeTypeId);
}
