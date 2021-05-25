using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clases;

namespace TP5
{
    public partial class Form1 : Form
    {
        private int filasASimular;
        private int iteraciones;
        private double iteracionesAPartirDe;
        private Random random;

        VectorEstado anterior;
        VectorEstado actual;
        DataTable tabla = new DataTable();

        public Form1()
        {
            InitializeComponent();
            cargarColumnas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            random = new Random();
            tabla.Clear();
            getValores();
        }
        private void getValores()
        {
            filasASimular = int.Parse(txtFilasASimular.Text);
            iteraciones = int.Parse(txtIteraciones.Text);
            iteracionesAPartirDe = double.Parse(txtIteracionesAPartirDe.Text);

            // Configuro el dia 0
            actual = new VectorEstado();
            simularFilaInicial();
            DataRow fila = null;
            
            
            for (int nroFilaSimulada = 1; nroFilaSimulada <= filasASimular; nroFilaSimulada++)
            {
                simularFila(nroFilaSimulada);

                if (nroFilaSimulada >= iteracionesAPartirDe && nroFilaSimulada < (iteracionesAPartirDe + iteraciones)) {
                    imprimirFila();

                }

                if (nroFilaSimulada == filasASimular)
                    imprimirFila();
            }

            grdSimulacion.DataSource = tabla;
        }

        private void simularFilaInicial() {
            actual.nro_fila = 0;
            actual.reloj = 0;

            // servidores
            actual.maquinas = new List<Maquina>();
            actual.maquinas.Add(new Maquina(1));
            actual.maquinas.Add(new Maquina(2));
            actual.maquinas.Add(new Maquina(3));
            actual.maquinas.Add(new Maquina(4));
            actual.maquinas.Add(new Maquina(5));

            // clientes
            actual.alumnos = new List<Alumno>();

            // clientes
            actual.prox_eventos = new List<Evento>();

            // llegada alumno
            proxLlegadaAlumno();

            // llegada mantenimiento
            // proxLlegadaMantenimiento();

            // contadores y acumuladores
            actual.cant_alumnos_inscriptos = 0;
            actual.cant_alumnos_no_ingresan = 0;
            actual.cant_alumnos_que_llegan = 0;
            actual.cant_horas = 0;
            actual.prom_insc_por_hora_y_maq = 0;
            actual.cola_alumnos = 0;
        }

        private void proxLlegadaMantenimiento()
        {
            actual.rnd_llegada_mantenimiento = random.NextDouble();
            actual.tiempo_llegada_mantenimiento = DistribucionesContinuas.generarUniforme(57, 63, actual.rnd_llegada_mantenimiento);
            actual.prox_llegada_mantenimiento = actual.tiempo_llegada_mantenimiento + actual.reloj;
            actual.prox_eventos.Add(new Evento("Llegada Mantenimiento", actual.prox_llegada_mantenimiento));
        }

        private void proxLlegadaAlumno()
        {
            actual.rnd_llegada_alumno = random.NextDouble();
            actual.tiempo_llegada_alumno = DistribucionesContinuas.generarExponencial(2, actual.rnd_llegada_alumno);
            actual.prox_llegada_alumno = actual.tiempo_llegada_alumno + actual.reloj;
            actual.prox_eventos.Add(new Evento("Llegada Alumno", actual.prox_llegada_alumno));
        }

        private void simularFila(int nroFilaSimulada)
        {
            anterior = actual;
            actual = new VectorEstado();
            nuevoVector();

            actual.nro_fila = nroFilaSimulada;
            Evento evento = actual.getProximoEvento();
            actual.evento = evento.nombre;
            actual.reloj = evento.tiempo;

            switch (actual.evento)
            {
                case "Llegada Alumno":
                    llegadaAlumno();
                    break;

                case "Fin Inscripcion":
                    finInscripcion(evento.nro_referencia);
                    break;

                case "Regreso Alumno":
                    regresoAlumno(evento.nro_referencia);
                    break;

                case "Llegada Mantenimiento":
                    llegadaMantenimiento();
                    break;

                default:
                    break;
            }

            actual.prox_eventos.Remove(evento);

        }

        private void finInscripcion(int nro_maquina)
        {
            // obtener maquina
            Maquina maquina = actual.getMaquinaPorNro(nro_maquina);

            // destruir alumno
            Alumno alumno = actual.getAlumnoPorMaquina(nro_maquina);
            actual.alumnos.Remove(alumno);

            // incrementar cant inscriptos
            actual.cant_alumnos_inscriptos++;

            // verificar si hay gente en cola
            if (actual.cola_alumnos > 0)
            {
                Alumno alumno_esperando = actual.getAlumnoEsperando();

                calcularInscripcion();
                maquina.fin_inscripcion = actual.fin_incripcion;
                alumno_esperando.estado = "Inscribiendo";
                alumno_esperando.maquina = maquina;
                actual.prox_eventos.Add(new Evento("Fin Inscripcion", actual.fin_incripcion, maquina.nro));
                actual.cola_alumnos--;
            }
            else {
                maquina.estado = "Libre";
                maquina.fin_inscripcion = null;
            }
        }

        private void regresoAlumno(int nro_alumno)
        {
            Alumno alumno = actual.getAlumnoPorNro(nro_alumno);
            alumno.hora_regreso = null;

            // Buscar Maquina
            Maquina maquina = actual.getMaquinaLibre();

            if (!(maquina is null))
            {
                maquina.estado = "Ocupada";
                calcularInscripcion();
                maquina.fin_inscripcion = actual.fin_incripcion;
                alumno.estado = "Inscribiendo";
                alumno.maquina = maquina;
                actual.prox_eventos.Add(new Evento("Fin Inscripcion", actual.fin_incripcion, maquina.nro));
            }
            else
            {
                if (actual.cola_alumnos == 4)
                {
                    alumno.estado = "Ausente";
                    alumno.hora_regreso = actual.reloj + 30;
                    actual.prox_eventos.Add(new Evento("Regreso Alumno", (double) alumno.hora_regreso, alumno.numero));
                    actual.cant_alumnos_no_ingresan++;
                }
                else
                {
                    alumno.estado = "Esperando Maquina";
                    actual.cola_alumnos++;
                }
            }
        }

        private void nuevoVector()
        {
            actual.maquinas = anterior.maquinas;
            actual.alumnos = anterior.alumnos;
            actual.personal_mantenimiento = anterior.personal_mantenimiento;
            actual.prox_eventos = anterior.prox_eventos;
            actual.cant_alumnos_inscriptos = anterior.cant_alumnos_inscriptos;
            actual.cant_alumnos_no_ingresan = anterior.cant_alumnos_no_ingresan;
            actual.cant_alumnos_que_llegan = anterior.cant_alumnos_que_llegan;
            actual.cant_horas = anterior.cant_horas;
            actual.prom_insc_por_hora_y_maq = anterior.prom_insc_por_hora_y_maq;
            actual.cola_alumnos = anterior.cola_alumnos;
            actual.prox_llegada_alumno = anterior.prox_llegada_alumno;
            actual.prox_llegada_mantenimiento = anterior.prox_llegada_mantenimiento;
        }

        private void llegadaAlumno() {
            proxLlegadaAlumno(); // ALUMNO FUTURO
            actual.cant_alumnos_que_llegan++;

            Alumno alumno = new Alumno(actual.cant_alumnos_que_llegan);
            actual.alumnos.Add(alumno);

            // Buscar Maquina
            Maquina maquina = actual.getMaquinaLibre();

            if (!(maquina is null))
            {
                maquina.estado = "Ocupada";
                calcularInscripcion();
                maquina.fin_inscripcion = actual.fin_incripcion;
                alumno.estado = "Inscribiendo";
                alumno.maquina = maquina;
                actual.prox_eventos.Add(new Evento("Fin Inscripcion", actual.fin_incripcion, maquina.nro));
            }
            else {
                if (actual.cola_alumnos == 4)
                {
                    alumno.estado = "Ausente";
                    alumno.hora_regreso = actual.reloj + 30;
                    actual.prox_eventos.Add(new Evento("Regreso Alumno", (double) alumno.hora_regreso, alumno.numero));
                    actual.cant_alumnos_no_ingresan++;
                }
                else {
                    alumno.estado = "Esperando Maquina";
                    actual.cola_alumnos++;
                }
            }
        }

        private void calcularInscripcion()
        {
            actual.rnd_incripcion = random.NextDouble();
            actual.tiempo_incripcion = DistribucionesContinuas.generarUniforme(5, 8, actual.rnd_incripcion);
            actual.fin_incripcion = actual.tiempo_incripcion + actual.reloj;
        }

        private void llegadaMantenimiento()
        {
            actual.cant_alumnos_que_llegan = anterior.cant_alumnos_que_llegan;
        }
        private void cargarColumnas()
        {
            tabla.Columns.Add("# Fila");

            tabla.Columns.Add("Evento");
            tabla.Columns.Add("Reloj");
            tabla.Columns.Add("RND lleg alumn");
            tabla.Columns.Add("Tiem lleg alumn");
            tabla.Columns.Add("Prox llegada alumn");
            tabla.Columns.Add("RND Insc");
            tabla.Columns.Add("Tiempo insc");
            tabla.Columns.Add("Fin inscripcion");
            
            tabla.Columns.Add("M1 - Estado");
            tabla.Columns.Add("M1 - Fin inscripcion");
            tabla.Columns.Add("M2 - Estado");
            tabla.Columns.Add("M2 - Fin inscripcion");
            tabla.Columns.Add("M3 - Estado");
            tabla.Columns.Add("M3 - Fin inscripcion");
            tabla.Columns.Add("M4 - Estado");
            tabla.Columns.Add("M4 - Fin inscripcion");
            tabla.Columns.Add("M5 - Estado");
            tabla.Columns.Add("M5 - Fin inscripcion");

            tabla.Columns.Add("Cola alumnos espera");
            tabla.Columns.Add("Cantidad alumnos inscriptos");
            tabla.Columns.Add("Cantidad alumnos no ingresan");
            tabla.Columns.Add("Cantidad alumnos que llegan");
            tabla.Columns.Add("Promedio insc por hora y maq");
            tabla.Columns.Add("Cnt horas");

        }

        public void imprimirFila() {
            DataRow fila = tabla.NewRow();

            Maquina maquina1 = actual.getMaquinaPorNro(1);
            Maquina maquina2 = actual.getMaquinaPorNro(2);
            Maquina maquina3 = actual.getMaquinaPorNro(3);
            Maquina maquina4 = actual.getMaquinaPorNro(4);
            Maquina maquina5 = actual.getMaquinaPorNro(5);


            fila["# Fila"] = actual.nro_fila;
            fila["Evento"] = actual.evento;
            fila["Reloj"] = actual.reloj;
            fila["RND lleg alumn"] = actual.rnd_llegada_alumno.ToString("0.000");
            fila["Tiem lleg alumn"] = actual.tiempo_llegada_alumno;
            fila["Prox llegada alumn"] = actual.prox_llegada_alumno;
            fila["RND Insc"] = actual.rnd_incripcion.ToString("0.000");
            fila["Tiempo insc"] = actual.tiempo_incripcion;
            fila["Fin inscripcion"] = actual.fin_incripcion;

            fila["M1 - Estado"] = maquina1.estado;
            fila["M1 - Fin inscripcion"] = maquina1.fin_inscripcion;
            fila["M2 - Estado"] = maquina2.estado;
            fila["M2 - Fin inscripcion"] = maquina2.fin_inscripcion;
            fila["M3 - Estado"] = maquina3.estado;
            fila["M3 - Fin inscripcion"] = maquina3.fin_inscripcion;
            fila["M4 - Estado"] = maquina4.estado;
            fila["M4 - Fin inscripcion"] = maquina4.fin_inscripcion;
            fila["M5 - Estado"] = maquina5.estado;
            fila["M5 - Fin inscripcion"] = maquina5.fin_inscripcion;

            fila["Cola alumnos espera"] = actual.cola_alumnos;
            fila["Cantidad alumnos inscriptos"] = actual.cant_alumnos_inscriptos;
            fila["Cantidad alumnos no ingresan"] = actual.cant_alumnos_no_ingresan;
            fila["Cantidad alumnos que llegan"] = actual.cant_alumnos_que_llegan;
            fila["Promedio insc por hora y maq"] = actual.prom_insc_por_hora_y_maq;
            fila["Cnt horas"] = actual.cant_horas;

            foreach (var alumno in actual.alumnos)
            {
                if (!tabla.Columns.Contains("A" + alumno.numero + " - Estado")) {
                    tabla.Columns.Add("A" + alumno.numero + " - Estado");
                    tabla.Columns.Add("A" + alumno.numero + " - Hora Regreso");
                }

                fila["A" + alumno.numero + " - Estado"] = alumno.estado;
                fila["A" + alumno.numero + " - Hora Regreso"] = alumno.hora_regreso;
            }

            tabla.Rows.Add(fila);
        }
    }
}
