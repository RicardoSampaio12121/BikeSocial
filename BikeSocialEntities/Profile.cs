using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int userId { get; set; }
        public User user { get; set; }
        public string description { get; set; }
    }
}
