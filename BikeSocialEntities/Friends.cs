using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Solicitor")]
        public int? solicitorId { get; set; }
        public virtual Users solicitor { get; set; }

        [ForeignKey("Recieptient")]
        public int? recieptientId { get; set; }
        public virtual Users recieptient { get; set; }

        public bool status { get; set; }

        public DateTime timeSent { get; set; }
    }
}
