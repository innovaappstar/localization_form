using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_G.dto
{
    internal class DeviceLocation
    {
        public DeviceLocation(string device, string fecha, string coordenadas, string estado, string velocidad, string ver)
        {
            Device = device;
            Fecha = fecha;
            Coordenadas = coordenadas;
            Estado = estado;
            Velocidad = velocidad;
            Ver = ver;
        }

        public string Device { get; set; }
        public string Fecha { get; set; }
        public string Coordenadas { get; set; }
        public string Estado { get; set; }

        public string Velocidad { get; set; }

        public string Ver { get; set; }
    }
}
