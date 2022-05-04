namespace BikeSocialDTOs
{
    public record CreateAthleteDto(int userId, 
        int? teamId, int? parentId, 
        int athleteTypeId, int? federationId, int? trainingsId, int? plansId);
}