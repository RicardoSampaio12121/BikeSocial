using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IEquipaService
    {
        Task<ReturnEquipaDto> Get(int teamId);
        Task<Teams> Create(int userId, CreateEquipaDto equipaDto);
        Task<bool> ConviteAE(int userId, CreateConvAtletaEquiDto convite);
        Task<bool> ConviteCE(int userId, CreateConvCoachEquiDto convite);
        Task<bool> FederationRequest(int userId, GetTeamFederationRequestDto dto);

        Task<ReturnDirectorDto> GetDirector(int directorId);
        Task<Directors> CreateDirector(CreateDirectorDto directorDto);

    }
}


