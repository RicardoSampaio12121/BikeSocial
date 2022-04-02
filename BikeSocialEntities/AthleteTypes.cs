using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class AthleteTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Athletes> Athletes { get; set; }
    }
}
