using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record CreateEquipaDto(int clubI, 
        string name, int placeId, int federationId);
  
}
