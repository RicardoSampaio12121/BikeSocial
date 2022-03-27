namespace BikeSocialEntities
{
    public class AthleteType
    {
        public int Id { get; set; }
        public string Description { get; set; } 
        public List<Athlete> Athletes { get; set; }
    }
}