namespace BikeSocialDTOs
{
    public record ReturnRaceInviteDto
    {
        public int Id { get; set; }
        public int? RacesId { get; set; }
        public int AthletesId { get; set; }
        public bool Confirmation { get; set; }
    }
}