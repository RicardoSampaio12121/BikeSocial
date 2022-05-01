using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnRouteDto
    {
        public int Id { get; set; }
        public int? UsersId { get; set; }
        public bool Public { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public float EstimatedTime { get; set; }
        public float Distance { get; set; }
        public int PlacesId { get; set; }
        public int RouteTypesId { get; set; }
    }
}
