﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class TeamInviteAthletes
    {
        public int Id { get; set; }
        public int? TeamsId { get; set; }
        public int AthletesId { get; set; }
        public int? TrainingsId { get; set; }
    }
}
