using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }

        public int solicitor { get; set; }

        public int recieptient { get; set; }

        public bool status { get; set; }

        public DateTime timeSent { get; set; }
    }
}
