using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class UserTypes
    {
        public int Id { get; set; }
        public string name { get; set; }

        public List<Users> Users { get; set; }
    }
}
