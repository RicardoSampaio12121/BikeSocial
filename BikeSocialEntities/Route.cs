using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Route
    {
        public int id { get; set; }
        public int userId { get; set; } //TODO: User Id, quando a tabela do user estiver completa tem que estar como chave estrangeira
        public string description { get; set; }
        public int placeId { get; set; }
        public int routeTypeId { get; set; }
        public DateTime dateTime { get; set; }
        public float estimatedTime { get; set; }
        public float distance { get; set; }
    }
}
