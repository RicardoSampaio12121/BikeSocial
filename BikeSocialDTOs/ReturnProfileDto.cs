using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnProfileDto
    {
        public int userId {get; set;}
        public string description { get; set; }
    }
}
