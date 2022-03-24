namespace BikeSocialEntities
{
    public class RaceType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Race> Races { get; set; }
    }
}