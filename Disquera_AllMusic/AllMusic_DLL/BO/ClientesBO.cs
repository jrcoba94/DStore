using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMusic_DLL.BO
{
    public class ClientesBO
    {
        public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string CorreoElectronico { get; set; }
        public string Password { get; set; }
    }
}
