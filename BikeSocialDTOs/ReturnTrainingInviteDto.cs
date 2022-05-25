namespace BikeSocialDTOs
{
    public record ReturnTrainingInviteDto()
    {
        public int Id { get; set; }
        public int? TrainingsId { get; set; }
        public int AthletesId { get; set; }
        public bool Confirmation { get; set; }
    }
}