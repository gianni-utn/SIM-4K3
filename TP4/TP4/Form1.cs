using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP4.clases;

namespace TP4
{
    public partial class Form1 : Form
    {
        private int semanasASimular;
        private int iteraciones;
        private int iteracionesAPartirDe;
        private Random random;

        VectorEstado anterior;
        VectorEstado actual;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calcular();
        }
        private void calcular()
        {
            getValores();
        }
        private void getValores()
        {
            semanasASimular = int.Parse(txtSemanasASimular.Text);
            iteraciones = int.Parse(txtIteraciones.Text);
            iteracionesAPartirDe = int.Parse(txtIteracionesAPartirDe.Text);

            List<VectorEstado> semanasSimuladas = new List<VectorEstado>();
            
            // Configuro el dia 0
            actual = new VectorEstado();
            actual.nroSemana = 0;
            actual.ComAcumuladaV1 = 0;
            actual.ComAcumuladaV2 = 0;

            for (int nroSemanaSimulada = 1; nroSemanaSimulada <= semanasASimular; nroSemanaSimulada++)
            {
                simularSemana(nroSemanaSimulada);

                if(nroSemanaSimulada >= iteracionesAPartirDe && nroSemanaSimulada < (iteracionesAPartirDe + iteraciones) )
                    semanasSimuladas.Add(actual);

                if(nroSemanaSimulada == semanasASimular)
                    semanasSimuladas.Add(actual);
            }

            cargarEnTabla(semanasSimuladas);

        }

        private void simularSemana(int nroSemanaSimulada)
        {
            anterior = actual;
            actual = new VectorEstado();

            actual.nroSemana = nroSemanaSimulada;

            calcularVendedor1(actual);
            calcularVendedor2(actual);
            calcularVendedor3(actual);
            calcularVendedor4(actual);

            actual.ComPromTodos = (actual.TotalComV1 + actual.TotalComV2 + actual.TotalComV3 + actual.TotalComV4) / 4;
            actual.ComAcumuladaTodos = (actual.ComAcumuladaV1 + actual.ComAcumuladaV2 + actual.ComAcumuladaV3 + actual.ComAcumuladaV4) / 4;
        }

        private int obtenerVentas() {
            /*
                %	Cant Ventas
                20		0
                30		1
                30		2
                15		3
                5		4
             */

            double nro_random = random.NextDouble();

            if (nro_random < 0.2)
                return 0;
            else if(nro_random < 0.5)
                return 1;
            else if (nro_random < 0.8)
                return 2;
            else if (nro_random < 0.95)
                return 3;
            else
                return 4;
        }

        private string obtenerTipoAuto()
        {
            /*
                %	Tipo Auto
                50	Compacto 
                35	Mediano
                15	De Lujo
             */

            double nro_random = random.NextDouble();

            if (nro_random < 0.5)
                return "Compacto";
            else if (nro_random < 0.85)
                return "Mediano";
            else 
                return "De Lujo";
        }

        private int obtenerComisionAuto(string tipoAuto)
        {
            double nro_random = random.NextDouble();
            switch (tipoAuto)
            {
                case "Mediano":
                    /*
                         %	Com. Mediano
                        40		400
                        60		500
                     */

                    if (nro_random < 0.4)
                        return 400;
                    else
                        return 500;
                case "De Lujo":
                    /*
                        %	Com. De Lujo
                        35		1000
                        40		1500
                        25		2000                     
                     */

                    if (nro_random < 0.35)
                        return 1000;
                    else if (nro_random < 0.75)
                        return 1500;
                    else
                        return 2000;
                default:
                    // Compacto
                    return 250;
            }
        }

        private void calcularVendedor1(VectorEstado actual) {
            actual.nroVentasV1 = obtenerVentas();
            actual.TotalComV1 = 0;

            if (actual.nroVentasV1 > 0)
            {
                actual.TipoA1V1 = obtenerTipoAuto();
                actual.ComA1V1 = obtenerComisionAuto(actual.TipoA1V1);
                actual.TotalComV1 += actual.ComA1V1;
            }
            if (actual.nroVentasV1 > 1)
            {
                actual.TipoA2V1 = obtenerTipoAuto();
                actual.ComA2V1 = obtenerComisionAuto(actual.TipoA1V1);
                actual.TotalComV1 += actual.ComA2V1;
            }
            if (actual.nroVentasV1 > 2)
            {
                actual.TipoA3V1 = obtenerTipoAuto();
                actual.ComA3V1 = obtenerComisionAuto(actual.TipoA1V1);
                actual.TotalComV1 += actual.ComA3V1;
            }
            if (actual.nroVentasV1 > 3)
            {
                actual.TipoA4V1 = obtenerTipoAuto();
                actual.ComA4V1 = obtenerComisionAuto(actual.TipoA1V1);
                actual.TotalComV1 += actual.ComA4V1;
            }

            if (anterior.nroSemana > 0)
                // ((prom_anterior * cant_anterior) + valor_actual) / cant_actual
                actual.ComAcumuladaV1 = ((anterior.ComAcumuladaV1 * anterior.nroSemana) + actual.TotalComV1) / actual.nroSemana;
            else
                actual.ComAcumuladaV1 = actual.TotalComV1;
        }

        private void calcularVendedor2(VectorEstado actual)
        {
            actual.nroVentasV2 = obtenerVentas();
            actual.TotalComV2 = 0;

            if (actual.nroVentasV2 > 0)
            {
                actual.TipoA1V2 = obtenerTipoAuto();
                actual.ComA1V2 = obtenerComisionAuto(actual.TipoA1V2);
                actual.TotalComV2 += actual.ComA1V2;
            }
            if (actual.nroVentasV2 > 1)
            {
                actual.TipoA2V2 = obtenerTipoAuto();
                actual.ComA2V2 = obtenerComisionAuto(actual.TipoA1V2);
                actual.TotalComV2 += actual.ComA2V2;
            }
            if (actual.nroVentasV2 > 2)
            {
                actual.TipoA3V2 = obtenerTipoAuto();
                actual.ComA3V2 = obtenerComisionAuto(actual.TipoA1V2);
                actual.TotalComV2 += actual.ComA3V2;
            }
            if (actual.nroVentasV2 > 3)
            {
                actual.TipoA4V2 = obtenerTipoAuto();
                actual.ComA4V2 = obtenerComisionAuto(actual.TipoA1V2);
                actual.TotalComV2 += actual.ComA4V2;
            }

            if (anterior.nroSemana > 0)
                // ((prom_anterior * cant_anterior) + valor_actual) / cant_actual
                actual.ComAcumuladaV2 = ((anterior.ComAcumuladaV2 * anterior.nroSemana) + actual.TotalComV2) / actual.nroSemana;
            else
                actual.ComAcumuladaV2 = actual.TotalComV2;
        }

        private void calcularVendedor3(VectorEstado actual)
        {
            actual.nroVentasV3 = obtenerVentas();
            actual.TotalComV3 = 0;

            if (actual.nroVentasV3 > 0)
            {
                actual.TipoA1V3 = obtenerTipoAuto();
                actual.ComA1V3 = obtenerComisionAuto(actual.TipoA1V3);
                actual.TotalComV3 += actual.ComA1V3;
            }
            if (actual.nroVentasV3 > 1)
            {
                actual.TipoA2V3 = obtenerTipoAuto();
                actual.ComA2V3 = obtenerComisionAuto(actual.TipoA1V3);
                actual.TotalComV3 += actual.ComA2V3;
            }
            if (actual.nroVentasV3 > 2)
            {
                actual.TipoA3V3 = obtenerTipoAuto();
                actual.ComA3V3 = obtenerComisionAuto(actual.TipoA1V3);
                actual.TotalComV3 += actual.ComA3V3;
            }
            if (actual.nroVentasV3 > 3)
            {
                actual.TipoA4V3 = obtenerTipoAuto();
                actual.ComA4V3 = obtenerComisionAuto(actual.TipoA1V3);
                actual.TotalComV3 += actual.ComA4V3;
            }

            if (anterior.nroSemana > 0)
                // ((prom_anterior * cant_anterior) + valor_actual) / cant_actual
                actual.ComAcumuladaV3 = ((anterior.ComAcumuladaV3 * anterior.nroSemana) + actual.TotalComV3) / actual.nroSemana;
            else
                actual.ComAcumuladaV3 = actual.TotalComV3;
        }

        private void calcularVendedor4(VectorEstado actual)
        {
            actual.nroVentasV4 = obtenerVentas();
            actual.TotalComV4 = 0;

            if (actual.nroVentasV4 > 0)
            {
                actual.TipoA1V4 = obtenerTipoAuto();
                actual.ComA1V4 = obtenerComisionAuto(actual.TipoA1V4);
                actual.TotalComV4 += actual.ComA1V4;
            }
            if (actual.nroVentasV4 > 1)
            {
                actual.TipoA2V4 = obtenerTipoAuto();
                actual.ComA2V4 = obtenerComisionAuto(actual.TipoA1V4);
                actual.TotalComV4 += actual.ComA2V4;
            }
            if (actual.nroVentasV4 > 2)
            {
                actual.TipoA3V4 = obtenerTipoAuto();
                actual.ComA3V4 = obtenerComisionAuto(actual.TipoA1V4);
                actual.TotalComV4 += actual.ComA3V4;
            }
            if (actual.nroVentasV4 > 3)
            {
                actual.TipoA4V4 = obtenerTipoAuto();
                actual.ComA4V4 = obtenerComisionAuto(actual.TipoA1V4);
                actual.TotalComV4 += actual.ComA4V4;
            }

            if (anterior.nroSemana > 0)
                // ((prom_anterior * cant_anterior) + valor_actual) / cant_actual
                actual.ComAcumuladaV4 = ((anterior.ComAcumuladaV4 * anterior.nroSemana) + actual.TotalComV4) / actual.nroSemana;
            else
                actual.ComAcumuladaV4 = actual.TotalComV4;
        }

        private void cargarEnTabla(List<VectorEstado> listSemanasSimuladas)
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("# Semana");

            // Vendedor 1
            tabla.Columns.Add("# Ventas (V1)");

            tabla.Columns.Add("Tipo A1 (V1)");
            tabla.Columns.Add("Com. A1 (V1)");

            tabla.Columns.Add("Tipo A2 (V1)");
            tabla.Columns.Add("Com. A2 (V1)");

            tabla.Columns.Add("Tipo A3 (V1)");
            tabla.Columns.Add("Com. A3 (V1)");

            tabla.Columns.Add("Tipo A4 (V1)");
            tabla.Columns.Add("Com. A4 (V1)");

            tabla.Columns.Add("Com. Total (V1)");
            tabla.Columns.Add("Com. Prom. Acumulada (V1)");

            // Vendedor 2
            tabla.Columns.Add("# Ventas (V2)");

            tabla.Columns.Add("Tipo A1 (V2)");
            tabla.Columns.Add("Com. A1 (V2)");

            tabla.Columns.Add("Tipo A2 (V2)");
            tabla.Columns.Add("Com. A2 (V2)");

            tabla.Columns.Add("Tipo A3 (V2)");
            tabla.Columns.Add("Com. A3 (V2)");

            tabla.Columns.Add("Tipo A4 (V2)");
            tabla.Columns.Add("Com. A4 (V2)");

            tabla.Columns.Add("Com. Total (V2)");
            tabla.Columns.Add("Com. Prom. Acumulada (V2)");

            // Vendedor 3
            tabla.Columns.Add("# Ventas (V3)");

            tabla.Columns.Add("Tipo A1 (V3)");
            tabla.Columns.Add("Com. A1 (V3)");

            tabla.Columns.Add("Tipo A2 (V3)");
            tabla.Columns.Add("Com. A2 (V3)");

            tabla.Columns.Add("Tipo A3 (V3)");
            tabla.Columns.Add("Com. A3 (V3)");

            tabla.Columns.Add("Tipo A4 (V3)");
            tabla.Columns.Add("Com. A4 (V3)");

            tabla.Columns.Add("Com. Total (V3)");
            tabla.Columns.Add("Com. Prom. Acumulada (V3)");

            // Vendedor 4
            tabla.Columns.Add("# Ventas (V4)");

            tabla.Columns.Add("Tipo A1 (V4)");
            tabla.Columns.Add("Com. A1 (V4)");

            tabla.Columns.Add("Tipo A2 (V4)");
            tabla.Columns.Add("Com. A2 (V4)");

            tabla.Columns.Add("Tipo A3 (V4)");
            tabla.Columns.Add("Com. A3 (V4)");

            tabla.Columns.Add("Tipo A4 (V4)");
            tabla.Columns.Add("Com. A4 (V4)");

            tabla.Columns.Add("Com. Total (V4)");
            tabla.Columns.Add("Com. Prom. Acumulada (V4)");


            tabla.Columns.Add("Com. Promedio");
            tabla.Columns.Add("Com. Prom. Acumulada");

            DataRow fila = null;

            foreach (var semanaSimulada in listSemanasSimuladas)
            {
                fila = tabla.NewRow();

                fila["# Semana"] = semanaSimulada.nroSemana;

                // Vendedor 1
                fila["# Ventas (V1)"] = semanaSimulada.nroVentasV1;

                fila["Tipo A1 (V1)"] = semanaSimulada.TipoA1V1;
                fila["Com. A1 (V1)"] = semanaSimulada.ComA1V1;

                fila["Tipo A2 (V1)"] = semanaSimulada.TipoA2V1;
                fila["Com. A2 (V1)"] = semanaSimulada.ComA2V1;

                fila["Tipo A3 (V1)"] = semanaSimulada.TipoA3V1;
                fila["Com. A3 (V1)"] = semanaSimulada.ComA3V1;

                fila["Tipo A4 (V1)"] = semanaSimulada.TipoA4V1;
                fila["Com. A4 (V1)"] = semanaSimulada.ComA4V1;

                fila["Com. Total (V1)"] = semanaSimulada.TotalComV1.ToString("0.000");
                fila["Com. Prom. Acumulada (V1)"] = semanaSimulada.ComAcumuladaV1.ToString("0.000");

                // Vendedor 2
                fila["# Ventas (V2)"] = semanaSimulada.nroVentasV2;

                fila["Tipo A1 (V2)"] = semanaSimulada.TipoA1V2;
                fila["Com. A1 (V2)"] = semanaSimulada.ComA1V2;

                fila["Tipo A2 (V2)"] = semanaSimulada.TipoA2V2;
                fila["Com. A2 (V2)"] = semanaSimulada.ComA2V2;

                fila["Tipo A3 (V2)"] = semanaSimulada.TipoA3V2;
                fila["Com. A3 (V2)"] = semanaSimulada.ComA3V2;

                fila["Tipo A4 (V2)"] = semanaSimulada.TipoA4V2;
                fila["Com. A4 (V2)"] = semanaSimulada.ComA4V2;

                fila["Com. Total (V2)"] = semanaSimulada.TotalComV2.ToString("0.000");
                fila["Com. Prom. Acumulada (V2)"] = semanaSimulada.ComAcumuladaV2.ToString("0.000");

                // Vendedor 3
                fila["# Ventas (V3)"] = semanaSimulada.nroVentasV3;

                fila["Tipo A1 (V3)"] = semanaSimulada.TipoA1V3;
                fila["Com. A1 (V3)"] = semanaSimulada.ComA1V3;

                fila["Tipo A2 (V3)"] = semanaSimulada.TipoA2V3;
                fila["Com. A2 (V3)"] = semanaSimulada.ComA2V3;

                fila["Tipo A3 (V3)"] = semanaSimulada.TipoA3V3;
                fila["Com. A3 (V3)"] = semanaSimulada.ComA3V3;

                fila["Tipo A4 (V3)"] = semanaSimulada.TipoA4V3;
                fila["Com. A4 (V3)"] = semanaSimulada.ComA4V3;

                fila["Com. Total (V3)"] = semanaSimulada.TotalComV3.ToString("0.000");
                fila["Com. Prom. Acumulada (V3)"] = semanaSimulada.ComAcumuladaV3.ToString("0.000");

                // Vendedor 4
                fila["# Ventas (V4)"] = semanaSimulada.nroVentasV4;

                fila["Tipo A1 (V4)"] = semanaSimulada.TipoA1V4;
                fila["Com. A1 (V4)"] = semanaSimulada.ComA1V4;

                fila["Tipo A2 (V4)"] = semanaSimulada.TipoA2V4;
                fila["Com. A2 (V4)"] = semanaSimulada.ComA2V4;

                fila["Tipo A3 (V4)"] = semanaSimulada.TipoA3V4;
                fila["Com. A3 (V4)"] = semanaSimulada.ComA3V4;

                fila["Tipo A4 (V4)"] = semanaSimulada.TipoA4V4;
                fila["Com. A4 (V4)"] = semanaSimulada.ComA4V4;

                fila["Com. Total (V4)"] = semanaSimulada.TotalComV4.ToString("0.000");
                fila["Com. Prom. Acumulada (V4)"] = semanaSimulada.ComAcumuladaV4.ToString("0.000");

                fila["Com. Promedio"] = semanaSimulada.ComPromTodos.ToString("0.000");
                fila["Com. Prom. Acumulada"] = semanaSimulada.ComAcumuladaTodos.ToString("0.000");

                tabla.Rows.Add(fila);
            }

            grdSimulacion.DataSource = tabla;
        }
    }
}