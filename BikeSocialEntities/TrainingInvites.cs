namespace BikeSocialEntities
{
    public class TrainingInvites
    {
        public int Id { get; set; }
        public int TrainingsId { get; set; }
        public int AthletesId { get; set; }
        public bool Confirmation { get; set; }
    }
}