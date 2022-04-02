using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Profile
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string description { get; set; }
    }
}
