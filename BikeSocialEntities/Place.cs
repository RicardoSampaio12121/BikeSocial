﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Place
    {
        public int id { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string PlaceName { get; set; }
        public List<Trainings> Trainings { get; set; }
        public List<Race> Races { get; set; }
        public List<Route> Routes { get; set; }
        public List<Athlete> Athletes { get; set; }
        public List<Club> Clubs { get; set; }
        public List<TeamDirector> Directors { get; set; }
    }
}
