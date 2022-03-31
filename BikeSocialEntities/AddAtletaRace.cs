using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class AddAtletaRace
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int IdAtleta { get; set; }
        public bool Confirmation { get; set; }
    }
}
