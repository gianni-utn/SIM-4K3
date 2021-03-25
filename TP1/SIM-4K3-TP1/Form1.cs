using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIM_4K3_TP1.Clases;

namespace SIM_4K3_TP1
{
    public partial class Form1 : Form
    {
        List<string> numeros = new List<string>();
        List<double> numerosDouble = new List<double>();
        Generador generador = new Generador();
        Validador validador = new Validador();
        List<Intervalo> intervalos = new List<Intervalo>();

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
                if (metodoSeleccionado != "Congruencial multiplicativo")
                {
                    if (!validarEnteroYPositivo(ref mensajeError, txt_c.Text))
                    {
                        txt_c.Focus();
                        mensajeError = "El valor de \"c\" debe ser entero y positivo.";
                        return false;
                    }
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

                if (cantidad <= 0)
                {
                    mensajeError = "La cantidad debe ser un número mayor a cero";
                    return false;
                }
            }

            return true;
        }
    }
}
