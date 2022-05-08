using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IConsultResultRaceService
    {
        
        Task<List<ReturnConsultResultRaceDto>> ConsultResult(int athletesId);
       
    }
}
