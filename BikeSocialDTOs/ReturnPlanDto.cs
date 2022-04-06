namespace BikeSocialDTOs
{
    public record ReturnPlanDto
    {
        public int Id { get; set; }
        public string description { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finishTime { get; set; }
        public float EstimatedTime { get; set; }
    }
}