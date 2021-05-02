using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class DistribucionesContinuas
    {
        private static Random RND = new Random();
        
        public static double[] generarUniforme(int tamanioMuestra, double a, double b)
        {
            double[] v = new double[tamanioMuestra];

            for (int i = 0; i < v.Length; i++)
            {
                v[i] = Math.Round(RND.NextDouble() * (b - a) + a, 4);
            }

            return v;
        }

        public static double[] generarExponencial(int tamanioMuestra, double lambda)
        {
            double[] v = new double[tamanioMuestra];

            for (int i = 0; i < v.Length; i++)
            {
                v[i] = Math.Round(-(1 / lambda) * Math.Log(1 - RND.NextDouble()), 4);
            }

            return v;
        }

        public static double[] generarNormal(int tamanioMuestra, double media, double desviacion)
        {
            double pi = Math.PI;
            //RND = new Random();

            double[] v = new double[tamanioMuestra];

            int i = 0;

            while (i < v.Length)
            {
                double rnd1 = RND.NextDouble() * 1;
                double rnd2 = RND.NextDouble() * 1;

                double z1 = Math.Sqrt(-2 * Math.Log(rnd1)) * (Math.Sin(2 * pi * rnd2));
                double z2 = Math.Sqrt(-2 * Math.Log(rnd1)) * (Math.Cos(2 * pi * rnd2));

                double n1 = z1 * media + desviacion;
                double n2= z2 * media + desviacion;

                v[i] = Math.Round(n1, 4);
                v[i + 1] = Math.Round(n2, 4);
                
                i = i + 2;
            }

            return v;
        }
    }
}
