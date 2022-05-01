namespace BikeSocialDTOs;

public record ReturnAthleteDto
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public int? TeamId { get; set; }
    public int? ParentId { get; set; }
    public int AthleteTypeId { get; set; }
    public int? FederationId { get; set; }
    public int? PlanId { get; set; }
}