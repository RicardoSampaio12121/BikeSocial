using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class DirectorTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Directors> Directors { get; set; }
    }
}
