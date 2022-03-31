namespace BikeSocialDTOs
{
    public record CreateAthleteDto(string name, int teamId, DateTime birthdate, int contact, int parentId, int athleteTypeId,
        int placeId, int userId, int coachId, int federationId, int planId);
}