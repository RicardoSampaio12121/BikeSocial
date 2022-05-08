namespace BikeSocialEntities
{
    public class Races
    {
        public int Id { get; set; }
        public string description { get; set; }
        public float distance { get; set; }
        public float estimateTime { get; set; }
        public DateTime dateTime { get; set; }
        public int FederationsId { get; set; }
        public int RaceTypesId { get; set; }
        public int PlacesId { get; set; }
        public string State { get; set; }

        public List<RaceInvites> RaceInvites { get; set; }
        public List<RaceResults> RaceResults { get; set; }
    }
}
