using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    /// <summary>
    /// Para criar uma consulta de resultados de provas
    /// </summary>
    /// <param name="racesId"></param>
    /// <param name="athletesId"></param>
    /// <param name="position"></param>
    public record CreateConsultResultRaceDto(int racesId, int athletesId, int position);
}
