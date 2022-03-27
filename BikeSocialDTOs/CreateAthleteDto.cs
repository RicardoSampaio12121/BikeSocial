namespace BikeSocialDTOs
{
    public record CreateAthleteDto(string name, DateTime birthdate, int contact, int parentId, int athleteTypeId,
        int placeId, int userId, int coachId, int federationId, int planId);
}