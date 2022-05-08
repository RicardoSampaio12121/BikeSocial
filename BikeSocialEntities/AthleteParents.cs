namespace BikeSocialEntities
{
    public class AthleteParents
    {
        public int Id { get; set; }
        public int UsersId { get; set; }

        public List<Athletes> Athletes { get; set; }
    }
}
