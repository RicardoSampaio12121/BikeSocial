using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Places
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string PlaceName { get; set; }

        public List<Users> Users{ get; set; }
        public List<Teams> Teams { get; set; }
        public List<Clubs> Clubs { get; set; }
        public List<Races> Races { get; set; }
        public List<Trainings> Trainings { get; set; }
        public List<Routes> Routes { get; set; }
        public List<Achievements> Achievements { get; set; }
    }
}
