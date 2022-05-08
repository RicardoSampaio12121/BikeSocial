namespace BikeSocialDTOs
{
    public record GetPublishResultsDto(int raceId, Dictionary<int, int> placements);
}
