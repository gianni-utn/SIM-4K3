using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TP3
{
    public partial class Form1 : Form
    {
        enum TipoDistribucion
        {
            continuaExponencial,
            continuaUniforme,
            continuaNormal
        }

        private TipoDistribucion distribucionElegida;
        private List<Distribucion> distribucionesContinuas = new List<Distribucion>();
        private List<double> datos = new List<double>();
        private List<Intervalo> intervalos = new List<Intervalo>();

        public Form1()
        {
            InitializeComponent();
            popularComboDistribucion();
            grafico.Visible = false;
        }

        private void popularComboDistribucion() {
            distribucionesContinuas.Add(new Distribucion { id = 1, descripcion = "Exponencial Negativa", tipoDistribucion = Distribucion.Tipo.continua, parametrosEstimados = 1 });
            distribucionesContinuas.Add(new Distribucion { id = 2, descripcion = "Normal", tipoDistribucion = Distribucion.Tipo.continua, parametrosEstimados = 2 });
            distribucionesContinuas.Add(new Distribucion { id = 3, descripcion = "Uniforme", tipoDistribucion = Distribucion.Tipo.continua, parametrosEstimados = 2 });

            cboDistribucion.DataSource = distribucionesContinuas;
            cboDistribucion.DisplayMember = "descripcion";
            cboDistribucion.ValueMember = "id";
        }

        private void cboDistribucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarGeneracion();
            configurarInputs();
        }

        private void deshabilitarInputs()
        {
            txtMedia.Enabled = false;
            txtDesvEstandar.Enabled = false;
            txtLambda.Enabled = false;
            txtA.Enabled = false;
            txtB.Enabled = false;
        }
        private void configurarInputs()
        {
            deshabilitarInputs();
            switch (((Distribucion)cboDistribucion.SelectedItem).id)
            {
                case 1:
                    distribucionElegida = TipoDistribucion.continuaExponencial;
                    txtLambda.Enabled = true;

                    break;

                case 2:

                    distribucionElegida = TipoDistribucion.continuaNormal;

                    txtDesvEstandar.Enabled = true;
                    txtMedia.Enabled = true;

                    break;

                case 3:
                    distribucionElegida = TipoDistribucion.continuaUniforme;
                    txtA.Enabled = true;
                    txtB.Enabled = true;
                    break;

                default:
                    break;
            }

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (esValido())
            {
                datos.Clear();
                generarDatos();
                cargarGrilla(ref grdResultado);
            }
        }

        private bool esValido() {
            if (txtCantNumeros.Text == "")
            {
                MessageBox.Show("Debe ingresar la cantidad de numeros a generar.", "Error", MessageBoxButtons.OK);
                return false;
            }

            switch (((Distribucion)cboDistribucion.SelectedItem).id)
            {
                case 1:
                    if(txtLambda.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el valor Lambda.", "Error", MessageBoxButtons.OK);
                        return false;
                    }
                    break;

                case 2:
                    if (txtMedia.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el valor Media.", "Error", MessageBoxButtons.OK);
                        return false;
                    }

                    if (txtDesvEstandar.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el valor Desviacion Estandar.", "Error", MessageBoxButtons.OK);
                        return false;
                    }

                    break;

                case 3:

                    if (txtA.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el valor A.", "Error", MessageBoxButtons.OK);
                        return false;
                    }

                    if (txtB.Text == "")
                    {
                        MessageBox.Show("Debe ingresar el valor B.", "Error", MessageBoxButtons.OK);
                        return false;
                    }
                    break;

                default:
                    MessageBox.Show("Debe seleccionar una distribucion.", "Error", MessageBoxButtons.OK);
                    return false;
                    break;
            }

            return true;


        }

        private void generarDatos() {
            int cantidadDeNumeros = int.Parse(txtCantNumeros.Text);
            switch (distribucionElegida)
            {
                case TipoDistribucion.continuaExponencial:

                    double lambda = double.Parse(txtLambda.Text);
                    double[] muestraExponencial = DistribucionesContinuas.generarExponencial(cantidadDeNumeros, lambda);

                    datos.AddRange(muestraExponencial.ToList());

                    break;
                case TipoDistribucion.continuaUniforme:

                    double a = double.Parse(txtA.Text);
                    double b = double.Parse(txtB.Text);

                    double[] muestraUniforme = DistribucionesContinuas.generarUniforme(cantidadDeNumeros, a, b);
                    datos.AddRange(muestraUniforme.ToList());

                    break;

                case TipoDistribucion.continuaNormal:

                    double media = double.Parse(txtMedia.Text);
                    double desviacion = double.Parse(txtDesvEstandar.Text);

                    double[] muestraNormal = DistribucionesContinuas.generarNormal(cantidadDeNumeros, media, desviacion);

                    datos.AddRange(muestraNormal.ToList());

                    break;
            }
        }

        private void cargarGrilla(ref DataGridView grilla)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Indice");
            table.Columns.Add("Numeros Aleatorios");

            int indice = 1;

            foreach (var numero in datos)
            {
                DataRow fila = table.NewRow();
                double num = Math.Truncate(numero * 10000) / 10000;
                fila["Indice"] = indice;
                fila["Numeros Aleatorios"] = num.ToString("0.0000");

                table.Rows.Add(fila);

                indice++;
            }

            grilla.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            intervalos.Clear();
            if (datos.Count() <= 0)
            {
                MessageBox.Show("Debe generar datos primero.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (cboIntervalo.SelectedIndex == -1)
            {

                MessageBox.Show("Debe seleccionar la cantidad de intervalos.", "Error", MessageBoxButtons.OK);
                return;
            }
            grafico.Visible = true;

            int numeroDeIntervalos = int.Parse(cboIntervalo.SelectedItem.ToString());

            double min = datos.Min();
            double max = datos.Max() + 0.001d;

            double paso = (max - min) / (double)numeroDeIntervalos;

            paso = Math.Round(paso, 4);

            double limiteInferior = min;
            double limiteSuperior = min + paso;

            Intervalo intervalo = null;

            for (int i = 0; i < numeroDeIntervalos; i++)
            {
                intervalo = new Intervalo();

                intervalo.numero = i + 1;
                intervalo.limiteInferior = Math.Round(limiteInferior, 4);
                intervalo.limiteSuperior = Math.Round(limiteSuperior, 4);

                intervalos.Add(intervalo);

                limiteInferior = limiteSuperior;
                limiteSuperior = limiteInferior + paso;
            }

            for (int i = 0; i < datos.Count; i++)
            {
                for (int j = 0; j < intervalos.Count; j++)
                {
                    if (intervalos[j].limiteSuperior > datos[i])
                    {
                        intervalos[j].frecuenciaObservada++;
                        break;
                    }
                }
            }

            cargarGrillaFrecuencias();
            graficar();
        }

        private void cargarGrillaFrecuencias()
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("Intervalo");
            tabla.Columns.Add("FO");

            DataRow fila;

            foreach (var intervalo in intervalos)
            {
                fila = tabla.NewRow();
                fila["Intervalo"] = "[" + intervalo.limiteInferior.ToString("0.0000") + " ; " + intervalo.limiteSuperior.ToString("0.0000") + ")";
                fila["FO"] = intervalo.frecuenciaObservada.ToString("0");

                tabla.Rows.Add(fila);
            }

            grillaIntervalos.DataSource = tabla;
        }

        private void graficar()
        {
            generarPaleta();

            int maxValue = 0;
            var chart = grafico.ChartAreas[0];
            chart.AxisX.CustomLabels.Clear();
            chart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart.AxisX.Minimum = datos.Min();
            chart.AxisY.Minimum = 0;
            chart.AxisX.Maximum = datos.Max();
            float size = 0;
            
            foreach (Intervalo intervalo in intervalos)
            {
                if (intervalo.frecuenciaObservada > maxValue)
                {
                    maxValue = intervalo.frecuenciaObservada;
                }

                double media = Math.Round((intervalo.limiteInferior + intervalo.limiteSuperior) / 2, 4);
                media = Math.Truncate(media * 10000) / 10000;
                grafico.Series["Frecuencia Observada"].Points.AddXY(media, intervalo.frecuenciaObservada);
                size = (float)(intervalo.limiteSuperior - intervalo.limiteInferior);
            }

            grafico.Series["Frecuencia Observada"]["PointWidth"] = "1";
            grafico.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            grafico.ChartAreas[0].AxisX.Interval = Math.Round(size, 4);
            chart.AxisY.Maximum = maxValue * 1.1;
        }


        private void generarPaleta()
        {
            grafico.Palette = ChartColorPalette.Excel;
            grafico.Titles.Clear();
            grafico.Series.Clear();

            Series serieFObservada = new Series();
            serieFObservada.Name = "Frecuencia Observada";
            grafico.Series.Add(serieFObservada);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiarGeneracion();
        }

        private void limpiarGeneracion() {
            txtMedia.Text = "";
            txtDesvEstandar.Text = "";
            txtLambda.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtCantNumeros.Text = "";

            grdResultado.DataSource = null;

            limpiarHistograma();
        }

        private void limpiarHistograma() {
            grillaIntervalos.DataSource = null;
            grafico.Visible = false;
        }

        private void cboIntervalo_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarHistograma();
        }
    }
}

