using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuertoDeBrasas.Models
{
  
        public class Cliente
        {
        public int ClienteID { get; set; }
        public string TipoCliente { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string CorreoElectronico { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Clave { get; set; } = "";
    }
    

}
