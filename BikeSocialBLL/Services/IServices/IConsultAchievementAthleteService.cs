using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IConsultAchievementAthleteService
    {
        Task<List<ReturnConsultAchievementAthleteDto>> ConsultAchievementAthlete(int athteleId);
    }
}
