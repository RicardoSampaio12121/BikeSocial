using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnConAtletaEqui
    {
        public int id_atleta { get; set; }
        public int id_equipa { get; set; }
    }
}
