namespace BikeSocialDTOs;

public record ReturnAthleteDto
{
    public int Id { get; set; }
    public string name { get; set; }
    public DateTime birthdate { get; set; }
    public int contact { get; set; }
    public int ParentId { get; set; }
    public int AthleteTypeId { get; set; }
    public int PlaceId { get; set; }
    public int UserId { get; set; }
    public int CoachId { get; set; }
    public int FederationId { get; set; }
    public int PlanId { get; set; }
}