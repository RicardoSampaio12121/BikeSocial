using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record CreateEquipa(int coachId, int clubeId, 
        string name, string local);
  
}
