using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases
{
    class Alumno
    {
        // public int numero_maquina { get; set; }
        public int numero { get; set; }
        public string estado { get; set; }
        public double? hora_regreso { get; set; }
        public Maquina maquina { get; set; }
        public Alumno(int numero)
        {
            this.numero = numero;
        }
    }
}
