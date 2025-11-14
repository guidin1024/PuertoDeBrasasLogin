using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuertoDeBrasas.Modelos
{
    public class Reserva
    {
        public int ReservaID { get; set; }
        public int ClienteID { get; set; }
        public DateTime Dia { get; set; }
        public string Lugar { get; set; } = "";
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
