using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIM_4K3_TP1.Clases
{
    public class Generador
    {
        public int generarMultiplicativo(int Xn, int a, int m)
        {
            //Congruencial Multiplicativo
            //Xn+1 = (a * Xn) mod m (%)

            int resultado = (a * Xn) % m;

            return resultado;
        }

        public int generarLineal(int Xn, int a, int m, int c)
        {
            //Congruencial Lineal
            //Xn+1 = (a*Xn + c) mod m (%)
            int resultado = (a * Xn + c) % m;

            return resultado;
        }
    }
}
