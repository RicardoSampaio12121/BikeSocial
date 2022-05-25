using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnPlacesDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string PlaceName { get; set; }

    }
}
