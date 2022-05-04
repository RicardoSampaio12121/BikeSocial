using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
   
    public record ReturnEquipaDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? placeId { get; set; }
        public int clubeId { get; set; }
    }
}
