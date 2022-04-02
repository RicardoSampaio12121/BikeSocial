using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Users
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime birthDate { get; set; }
        public int contact { get; set; }
        public int PlacesId { get; set; }
        public int UserTypesId { get; set; }

        public List<Athletes> Athletes { get; set; }
        public List<AthleteParents> AthleteParents { get; set; }
        public List<Coaches> Coaches { get; set; }
        public List<Directors> Directors { get; set; }
        public List<Routes> Routes { get; set; }
        public List<RouteInvites> RouteInvites { get; set; }
        public List<Profile> Profiles { get; set; }

        [InverseProperty("Solicitor")]
        public ICollection<Friend> solicitor { get; set; }
        [InverseProperty("Recieptient")]
        public ICollection<Friend> recieptient { get; set; }

    }
}
