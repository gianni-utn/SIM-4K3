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
using SIM_4K3_TP1.Clases;

namespace SIM_4K3_TP1
{
    public partial class Form1 : Form
    {
        const String FRECUENCIA_OBSERVADA = "Frecuencia Observada";
        const String FRECUENCIA_ESPERADA = "Frecuencia Esperada";

        List<string> numeros = new List<string>();
        Generador generador = new Generador();
        List<Intervalo> intervalos = new List<Intervalo>();
        ValidadorCongruencialLineal validadorLineal = new ValidadorCongruencialLineal();
        ValidadorCongruencialMultiplicativo validadorMultiplicativo = new ValidadorCongruencialMultiplicativo();

        int Xn = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // validar formulario y metodos
            string mensajeError = "";

            if (validarCampos(ref mensajeError))
            {
                // generar listado de numeros pseudoaleatorios
                generarNumeros();
            }
            else {
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK);
            }
        }

        public void generarNumeros() {
            numeros = new List<string>();

            int cantidadPorPrimeraVez = int.Parse(txtCantidad.Text);
            
            int a= 0;
            int m = 0;
            int c = 0;

            if (!string.IsNullOrEmpty(txt_a.Text))
                a = int.Parse(txt_a.Text);

            if (!string.IsNullOrEmpty(txt_m.Text))
                m = int.Parse(txt_m.Text);
            
            int siguienteValor = 0;
            double numeroGenerado = 0;

            if (!string.IsNullOrEmpty(txt_c.Text))
                c = int.Parse(txt_c.Text);

            string metodoSeleccionado = cboMetodo.SelectedItem.ToString();
            Xn = int.Parse(txt_semilla.Text);
            Random aux = new Random(Xn);

            for (int i = 0; i < cantidadPorPrimeraVez; i++)
            {
                switch (metodoSeleccionado)
                {
                    case "Congruencial lineal":
                        siguienteValor = generador.generarLineal(Xn, a, m, c);
                        numeroGenerado = (double)siguienteValor / (m - 1);
                        break;
                    case "Congruencial multiplicativo":
                        siguienteValor = generador.generarMultiplicativo(Xn, a, m);
                        numeroGenerado = (double)siguienteValor / (m - 1);
                        break;
                    case "Función del lenguaje utilizado":
                        numeroGenerado = aux.NextDouble();
                        break;
                }

                Xn = (int)siguienteValor;

                numeroGenerado = Math.Truncate(numeroGenerado * 10000) / 10000;

                numeros.Add(numeroGenerado.ToString("0.0000"));
            }

            cargarGrilla(ref grdResultado);

            btnLimpiar.Enabled = true;
        }

        private void cargarGrilla(ref DataGridView grilla)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Indice");
            table.Columns.Add("Numeros Aleatorios");

            int indice = 1;

            foreach (var numero in numeros)
            {
                DataRow fila = table.NewRow();

                fila["Indice"] = indice;
                fila["Numeros Aleatorios"] = numero;

                table.Rows.Add(fila);

                indice++;
            }

            grilla.DataSource = table;
        }

        private void limpiarFormulario()
        {
            cboMetodo.SelectedIndex = -1;
            txt_semilla.Text = "";
            txt_a.Text = "";
            txt_m.Text = "";
            txt_c.Text = "";
            txtCantidad.Text = "";

            btnLimpiar.Enabled = false;
            grdResultado.DataSource = null;
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private bool validarCampos(ref string mensajeError) 
        {
            // validacion combo
            if (cboMetodo.SelectedIndex == -1)
            {
                cboMetodo.Focus();
                mensajeError = "Seleccione un método de generación aleatoria";
                return false;
            }

            string metodoSeleccionado = cboMetodo.SelectedItem.ToString();

            // validacion cantidad
            if (!validarEnteroYPositivo(ref mensajeError, txtCantidad.Text))
            {
                txtCantidad.Focus();
                mensajeError = "El valor de cantidad debe ser entero y positivo.";
                return false;
            }

            // validacion semilla
            if (!validarEnteroYPositivo(ref mensajeError, txt_semilla.Text))
            {
                txt_semilla.Focus();
                mensajeError = "El valor de semilla debe ser entero y positivo.";
                return false;
            }

            if (metodoSeleccionado != "Función del lenguaje utilizado")
            {
                // validacion a
                if (!validarEnteroYPositivo(ref mensajeError, txt_a.Text))
                {
                    txt_a.Focus();
                    mensajeError = "El valor de \"a\" debe ser entero y positivo.";
                    return false;
                }

                // validacion m
                if (!validarEnteroYPositivo(ref mensajeError, txt_m.Text))
                {
                    txt_m.Focus();
                    mensajeError = "El valor de \"m\" debe ser entero y positivo.";
                    return false;
                }

                // validacion c
                ResultadoDeValidacion resultadoValidacion = new ResultadoDeValidacion(true, "");
                if (metodoSeleccionado != "Congruencial multiplicativo")
                {
                    if (!validarEnteroYPositivo(ref mensajeError, txt_c.Text))
                    {
                        txt_c.Focus();
                        mensajeError = "El valor de \"c\" debe ser entero y positivo.";
                        return false;
                    }
                    /// validar lineal
                    resultadoValidacion = validadorLineal.validar(txt_m.Text, txt_a.Text, txt_c.Text);
                }
                else {
                    /// validar multiplicatitivo
                    resultadoValidacion = validadorMultiplicativo.validar(txt_semilla.Text, txt_a.Text, txt_m.Text);
                }

                if (!resultadoValidacion.esValido) {
                    mensajeError = resultadoValidacion.mensajeDeError;
                    return false;
                }
            }

            return true;
        }

        private bool validarEnteroYPositivo(ref string mensajeError, string numero)
        {
            if (string.IsNullOrEmpty(numero))
            {
                mensajeError = "Debe ingresar una cantidad de números a generar";
                return false;
            }
            else
            {
                int cantidad = 0;

                if (!int.TryParse(numero, out cantidad))
                {
                    mensajeError = "La cantidad debe ser un número entero";
                    return false;
                }

                if (cantidad % 1 != 0)
                {
                    mensajeError = "La cantidad debe ser un número entero";
                    return false;
                }

                if (cantidad < 0)
                {
                    mensajeError = "La cantidad debe ser un número mayor a cero";
                    return false;
                }
            }

            return true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRealizarTest_Click(object sender, EventArgs e)
        {
            intervalos = new List<Intervalo>();

            int numeroDeIntervalos = int.Parse(cboCantIntervalos.SelectedItem.ToString());
            int cantidadDeNumerosAGenerar = int.Parse(txtCantidad.Text);

            double tamanioIntervalo = Math.Round(1f / (double)numeroDeIntervalos, 4);

            double limiteInferior = 0;

            double frecuenciaEsperada = Math.Round((double)cantidadDeNumerosAGenerar / (double)numeroDeIntervalos, 5);

            // armado de intervalos
            for (int i = 0; i < numeroDeIntervalos; i++)
            {
                Intervalo intervalo = new Intervalo();

                intervalo.numero = i + 1;
                intervalo.limiteInferior = limiteInferior;
                intervalo.limiteSuperior = Math.Round(limiteInferior + tamanioIntervalo, 5);
                intervalo.frecuenciaEsperada = frecuenciaEsperada;

                limiteInferior = intervalo.limiteSuperior;

                if (i + 1 == numeroDeIntervalos) {
                    intervalo.limiteSuperior = 1;
                }

                intervalos.Add(intervalo);
            }

            foreach (var numeroGenerado in numeros)
            {
                float numero = float.Parse(numeroGenerado);
                for (int j = 0; j < intervalos.Count; j++)
                {
                    if (intervalos[j].limiteSuperior > numero)
                    {
                        intervalos[j].frecuenciaObservada++;
                        break;
                    }

                    if (j + 1 == intervalos.Count && intervalos[j].limiteSuperior >= numero) {
                        intervalos[j].frecuenciaObservada++;
                    }
                }
            }

            cargarGrillaIntervalos(intervalos);

            graficar();
        }

        private void cargarGrillaIntervalos(List<Intervalo> intervalos)
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("Intervalo");
            tabla.Columns.Add("FO");
            tabla.Columns.Add("FE");
            tabla.Columns.Add("DifFrec");
            tabla.Columns.Add("DifFrecCuadrado");
            tabla.Columns.Add("chiCuadrado");
            tabla.Columns.Add("chiCuadrado (A)");

            double acumulador = 0;

            DataRow fila;

            foreach (var intervalo in intervalos)
            {
                fila = tabla.NewRow();

                fila["Intervalo"] = "[" + intervalo.limiteInferior + " ; " + intervalo.limiteSuperior + ")";
                fila["FO"] = intervalo.frecuenciaObservada.ToString("0.0000");
                fila["FE"] = intervalo.frecuenciaEsperada.ToString("0.0000");
                fila["DifFrec"] = intervalo.diferenciaDeFrecuencias().ToString("0.0000");
                fila["DifFrecCuadrado"] = intervalo.diferenciaCuadradaDeFrecuencias().ToString("0.0000");
                fila["chiCuadrado"] = intervalo.chiCuadradoIntervalo().ToString("0.0000");

                acumulador += intervalo.chiCuadradoIntervalo();
                fila["chiCuadrado (A)"] = acumulador.ToString("0.0000");

                tabla.Rows.Add(fila);
            }

            grdPuntoB.DataSource = tabla;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void graficar()
        {
            generarPaleta();

            int maxValue = 0;
            var chart = grafico.ChartAreas[0];
            chart.AxisX.CustomLabels.Clear();
            chart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart.AxisX.Minimum = 0;
            chart.AxisY.Minimum = 0;
            chart.AxisX.Maximum = 1;

            foreach (Intervalo intervalo in intervalos)
            {
                if (intervalo.frecuenciaObservada > maxValue)
                {
                    maxValue = intervalo.frecuenciaObservada;
                }

                double media = Math.Round((intervalo.limiteInferior + intervalo.limiteSuperior) / 2, 2);
                media = Math.Truncate(media * 10000) / 10000;

                chart.AxisX.CustomLabels.Add(intervalo.limiteInferior, intervalo.limiteSuperior, intervalo.limiteInferior + " - " + intervalo.limiteSuperior);

                grafico.Series[FRECUENCIA_OBSERVADA].Points.AddXY(media, intervalo.frecuenciaObservada);
                grafico.Series[FRECUENCIA_ESPERADA].Points.AddXY(media, intervalo.frecuenciaEsperada);
            }

            chart.AxisY.Maximum = maxValue * 1.1;
        }


        private void generarPaleta()
        {
            grafico.Palette = ChartColorPalette.Excel;
            grafico.Titles.Clear();
            grafico.Titles.Add("FRECUENCIAS OBSERVADAS VS ESPERADAS");
            grafico.Series.Clear();

            Series serieFObservada = new Series();
            serieFObservada.Name = FRECUENCIA_OBSERVADA;
            grafico.Series.Add(serieFObservada);

            Series serieFEsperada = new Series();
            serieFEsperada.Name = FRECUENCIA_ESPERADA;
            grafico.Series.Add(serieFEsperada);
        }

    }
}
