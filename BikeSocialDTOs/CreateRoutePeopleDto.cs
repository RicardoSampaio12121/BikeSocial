namespace BikeSocialDTOs
{
    public record CreateRoutePeopleDto(bool Public, string Description, 
        DateTime dateTime, float estimatedTime, float distance, int placeId, 
        int routeTypeId, List<int> people);
}
