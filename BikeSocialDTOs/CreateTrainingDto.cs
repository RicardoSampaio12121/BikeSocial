namespace BikeSocialDTOs
{
    public record CreateTrainingDto(string Name, DateTime dateTime, 
        float estimatedTime, float distance, string cidade, 
        string localidade, string lugar, int trainingTypeId);
    public record CreateTrainingWithInvitesDto(string name, DateTime dateTime, 
        float estimatedTime, float distance, int placeId, int trainingTypeId, 
        List<int> athleteId);
}
