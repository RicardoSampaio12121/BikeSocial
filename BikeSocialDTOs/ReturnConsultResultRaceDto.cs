using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    /// <summary>
    /// função que returna os resultados da consulta de resultados de provas
    /// </summary>
    public record ReturnConsultResultRaceDto
    {
        public int racesId { get; set; }   
        public int athletesId { get; set; } 
        public int position { get; set; }

    }
}
