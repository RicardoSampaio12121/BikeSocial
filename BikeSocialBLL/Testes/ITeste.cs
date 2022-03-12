using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialBLL.Testes
{
    public interface ITeste
    {
        Task<Task<bool>> Add(string user);
    }
}
