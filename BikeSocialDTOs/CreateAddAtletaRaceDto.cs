using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Adicionar os atletas da equipa numa prova
/// </summary>

namespace BikeSocialDTOs
{
    public record CreateAddAtletaRaceDto(int id_atleta, int raceId);
}
