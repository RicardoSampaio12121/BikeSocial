namespace BikeSocialDTOs
{
    public record ReturnRaceDto
    {
        public int Id { get; set; }
        public string Description { get; set; }       
        public float Distance { get; set; }
        public float EstimatedTime{ get; set; }
        public DateTime dateTime{ get; set; }
        public int FederationId { get; set; }
        public int RaceTypeId { get; set; }
        public int PlaceId { get; set; }
        public string State { get; set; }
    }
}