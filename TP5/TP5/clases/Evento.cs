using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases
{
    class Evento
    {
        public string nombre { get; set; }
        public double tiempo { get; set; }
        public int nro_referencia { get; set; }

        public Evento(string nombre, double tiempo)
        {
            this.nombre = nombre;
            this.tiempo = tiempo;
        }

        public Evento(string nombre, double tiempo, int nro_referencia)
        {
            this.nombre = nombre;
            this.tiempo = tiempo;
            this.nro_referencia = nro_referencia;
        }
    }

}
