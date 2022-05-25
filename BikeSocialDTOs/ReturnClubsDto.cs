using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnClubsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlacesId { get; set; }
    }
}
