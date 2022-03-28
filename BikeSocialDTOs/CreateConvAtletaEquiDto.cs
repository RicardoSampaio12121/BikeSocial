using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Criar convites a atletas para equipas
/// </summary>

namespace BikeSocialDTOs
{
    public record CreateConvAtletaEquiDto(bool resposta, int id_athelete, int id_equipa);
    
}

