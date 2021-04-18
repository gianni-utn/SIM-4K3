using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Intervalo
    {
        public int numero { get; set; }
        public string etiqueta { get; set; }
        public double limiteInferior { get; set; }
        public double limiteSuperior { get; set; }
        public int frecuenciaObservada { get; set; }
        public double frecuenciaEsperada { get; set; }
        public double diferenciaDeFrecuencias()
        {
            return frecuenciaEsperada - frecuenciaObservada;
        }

        public double diferenciaCuadradaDeFrecuencias()
        {
            return diferenciaDeFrecuencias() * diferenciaDeFrecuencias();
        }

        public double chiCuadradoIntervalo()
        {
            if (frecuenciaEsperada > 0)
                return diferenciaCuadradaDeFrecuencias() / frecuenciaEsperada;
            else
            {
                throw new Exception("Calcule la frecuencia esperada");
            }
        }

        public double getValorMedia()
        {
            return this.limiteInferior + this.limiteSuperior / 2;
        }
    }
}
