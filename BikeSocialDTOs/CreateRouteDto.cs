namespace BikeSocialDTOs
{
    public record CreateRouteDto(bool Public, string Description, 
        DateTime dateTime, float estimatedTime, float distance, 
        int placeId, int routeTypeId);
}
