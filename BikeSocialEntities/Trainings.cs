namespace BikeSocialEntities
{
    public class Trainings
    {
        public int Id { get; set; }
        public int? TeamsId { get; set; }
        public string Name { get; set; }
        public DateTime dateTime { get; set; }
        public float EstimatedTime { get; set; }
        public float Distance { get; set; }
        public int PlacesId { get; set; }
        public int TrainingTypesId { get; set; }

        public List<TrainingInvites> TrainingInvites { get; set; }
    }
}