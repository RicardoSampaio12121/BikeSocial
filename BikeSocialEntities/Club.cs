using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Club
    {
        [ForeignKey("TeamDirector")]
        public int id { get; set; }
        public string name { get; set; }
        public int? Placeid { get; set; } // Corrigir este erro 
        public List<Equipa> Equipas { get; set; }
        public TeamDirector director { get; set; }
    }
}
