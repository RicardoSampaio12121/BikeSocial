using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class AthleteService : IAthleteService
    {
        private readonly IAthleteRepository _athleteRepository;
        
        public AthleteService(IAthleteRepository athleteRepository)
        {
            _athleteRepository = athleteRepository;
        }
        
        // Criar um atleta novo
        public async Task<bool> Create(CreateAthleteDto athlete)
        {
            // É igual quando tem o mesmo nome e a mesma data de nascimento
            // Verificar se já existe um atleta com o mesmo nome e a mesma data de nascimento ("iguais")
            Athlete ath = await _athleteRepository.Get(athleteQuery => athleteQuery.name == athlete.name.ToString() && 
                                                            athleteQuery.birthdate.ToString() == athlete.birthdate.ToString());
            // Não podem existir 2 atletas "iguais"
            if (ath != null) return false;
            else await _athleteRepository.Add(athlete.AsAthlete());
            return true;
        }
    }
}