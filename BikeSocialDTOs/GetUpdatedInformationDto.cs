using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record GetUpdatedInformationDto(string newPassword, string newEmail, DateTime newBirthDate);
}
