using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;

namespace BikeSocialBLL.Services
{
    public class EquipaService : IEquipaService
    {
        private readonly IEquipaRepository _equipaRepository;

        public EquipaService(IEquipaRepository equipaRepository)
        {
            _equipaRepository = equipaRepository;
        }

        public async Task<bool> Equipa(GetEquipaDto equipa)
        {
            //throw new NotImplementedException();

            Equipa eq = await _equipaRepository.Get(equipaQuery => equipaQuery.name == equipa.name.ToString() &&
            equipaQuery.local == equipa.local.ToString());

            //verifica se existe alguma equipa com os dados que recebe de cima
            if (eq == null) return false;
            else return true;
        }
    }
}
