namespace BikeSocialDTOs
{
    public record GetUpdatedInformationDto(string currentPassword, string newPassword, string newEmail, string sex);
}
