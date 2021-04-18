using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Distribucion
    {
        public enum Tipo
        {
            discreta,
            continua
        }
        public int id { get; set; }
        public string descripcion { get; set; }

        public int parametrosEstimados { get; set; }

        public Tipo tipoDistribucion { get; set; }
    }
}
