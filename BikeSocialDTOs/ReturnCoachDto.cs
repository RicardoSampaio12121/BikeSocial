namespace BikeSocialDTOs;

public record ReturnCoachDto
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public int? TeamId { get; set; }
}