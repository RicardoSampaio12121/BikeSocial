namespace BikeSocialDTOs
{
    public record CreatePlanDto(string description, DateTime startTime, DateTime finishTime, float estimatedTime);
}