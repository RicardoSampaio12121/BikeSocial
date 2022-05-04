namespace BikeSocialDTOs
{
    public record CreateRaceDto(string description, float distance, float estimatedTime, 
        DateTime dateTime, int FederationId, int RaceTypeId, int placeId, string state);
}