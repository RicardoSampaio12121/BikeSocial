namespace BikeSocialDTOs
{
    public record ReturnFormattedRaceDto()
    {
        public string Description { get; set; }       
        public float Distance { get; set; }
        public float EstimatedTime{ get; set; }
        public String date { get; set; }
        public String time { get; set; }
        public string Federation { get; set; }
        public string RaceType { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string PlaceName { get; set; }
    }
}