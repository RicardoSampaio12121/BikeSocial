namespace BikeSocialEntities
{
    public class Plans
    {
        public int Id { get; set; }
        public string description { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finishTime { get; set; }
        public float EstimatedTime { get; set; }
        
        public List<Trainings> Trainings { get; set; }
        public List<Athletes> Athletes { get; set; }
    }
}