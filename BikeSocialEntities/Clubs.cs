namespace BikeSocialEntities
{
    public class Clubs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlacesId { get; set; }

        public List<Teams> Teams { get; set; }
        public List<Directors> Directors { get; set; }
    }
}
