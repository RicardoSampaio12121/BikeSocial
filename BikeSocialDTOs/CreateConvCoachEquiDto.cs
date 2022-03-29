using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Criar convites aos treinadores para as equipas
/// </summary>

namespace BikeSocialDTOs
{
    public record CreateConvCoachEquiDto(int idCoach, int idEquipa);

}
