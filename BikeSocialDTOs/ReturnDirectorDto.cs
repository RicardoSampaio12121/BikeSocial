﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnDirectorDto
    {
        public int Id { get; set; }
        public int? UsersId { get; set; }
        public int DirectorTypesId { get; set; }
        public int ClubsId { get; set; }
    }
}
