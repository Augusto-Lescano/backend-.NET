using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class UsuarioRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }
    }
}
