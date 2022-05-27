namespace BikeSocialDTOs
{
    public record CreateRaceDto(string description, float distance, float estimatedTime, 
        DateTime dateTime, int FederationId, int RaceTypeId, 
        string cidade, string localidade, string lugar, string state);
}