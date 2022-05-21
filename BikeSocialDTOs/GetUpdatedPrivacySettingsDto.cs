namespace BikeSocialDTOs
{
    public record GetUpdatedPrivacySettingsDto(int profileVisibility, int commentsPermission, bool unfriendContactPermission, bool unfriendTrodyVisualization, bool privateTrainings, bool privateRaces, bool privateRoutes);
}
