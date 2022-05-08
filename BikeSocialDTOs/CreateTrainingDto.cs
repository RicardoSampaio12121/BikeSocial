namespace BikeSocialDTOs
{
    public record CreateTrainingDto(string name, DateTime dateTime, 
        float estimatedTime, float distance, int placeId, int trainingTypeId);
    public record CreateTrainingWithInvitesDto(string name, DateTime dateTime, 
        float estimatedTime, float distance, int placeId, int trainingTypeId, 
        List<int> athleteId);
}
