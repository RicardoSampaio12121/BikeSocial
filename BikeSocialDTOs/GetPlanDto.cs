namespace BikeSocialDTOs
{
    public class GetPlanDto
    {
        public string description { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finishTime { get; set; }
        public float EstimatedTime { get; set; }
    }
}