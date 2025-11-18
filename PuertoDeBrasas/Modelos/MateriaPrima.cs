using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuertoDeBrasas.Modelos
{
    public class MateriaPrima
    {
        public int MateriaPrimaID { get; set; }
        public string Nombre { get; set; } = "";
        public int Stock { get; set; }
        public string UnidadMedida { get; set; } = "";
        public int ProveedorID { get; set; }
    }
}
