using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases
{
    class Maquina
    {
        public int nro { get; set; }
        public string estado { get; set; }
        public double? fin_inscripcion { get; set; }
        public bool mantenimiento { get; set; }
        public double fin_mantenimiento { get; set; }

        public Maquina(int nro)
        {
            this.nro = nro;
            this.estado = "Libre";
            this.mantenimiento = false;
        }
    }
}
