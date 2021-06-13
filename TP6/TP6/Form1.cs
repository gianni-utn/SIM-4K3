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
using TP5.clases;

namespace TP5
{
    public partial class Form1 : Form
    {
        private int filasASimular;
        private int iteraciones;
        private double iteracionesAPartirDe;
        private Random random;
        private double[] rnd_mantenimiento;

        private int insc_A;
        private int insc_B;
        private int llega_alum_media;
        private int llega_mant_A;
        private int llega_mant_B;
        private double h;

        private double demora_a1000;
        private double demora_a1500;
        private double demora_a2000;

        VectorEstado anterior;
        VectorEstado actual;
        DataTable tabla = new DataTable();

        Euler e1_anterior;
        Euler e1_actual;
        DataTable e1_tabla = new DataTable();

        Euler e2_anterior;
        Euler e2_actual;
        DataTable e2_tabla = new DataTable();

        Euler e3_anterior;
        Euler e3_actual;
        DataTable e3_tabla = new DataTable();


        public Form1()
        {
            InitializeComponent();
            cargarColumnas();
            cargarColumnasE(e1_tabla);
            cargarColumnasE(e2_tabla);
            cargarColumnasE(e3_tabla);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            random = new Random();
            grdSimulacion.DataSource = null;
            grdSimulacion.Rows.Clear();
            tabla.Clear();
            GC.Collect();
            grdSimulacion.ColumnHeadersVisible = false;
            filasASimular = int.Parse(txtFilasASimular.Text);
            iteraciones = int.Parse(txtIteraciones.Text);
            iteracionesAPartirDe = double.Parse(txtIteracionesAPartirDe.Text);

            insc_A = int.Parse(txt_insc_A.Text);
            insc_B = int.Parse(txt_insc_B.Text);
            llega_alum_media = int.Parse(txt_llega_alum_media.Text);
            llega_mant_A = int.Parse(txt_llega_mant_media.Text) - int.Parse(txt_llega_mant_mm.Text);
            llega_mant_B = int.Parse(txt_llega_mant_media.Text) + int.Parse(txt_llega_mant_mm.Text);
            h = double.Parse(txt_h.Text); //.Parse(txt_h.Text);


            // armar tablas
            
            armarE1();
            armarE2();
            armarE3();
            
            getValores();

            grdSimulacion.ColumnHeadersVisible = true;

            txt_prom_uso.Text = formatearDouble(actual.prom_insc_por_hora_y_maq);
            prom_alumnos_regresan.Text = Math.Round(actual.porcentaje_de_alumnos_regresan, 2).ToString("0.00") + " %";
        }


        private void armarE1()
        {
            e1_actual = new Euler();
            e1_actual.A_prox = 1000;
            e1_actual.t_prox = 0;

            do
            {
                DataRow fila = e1_tabla.NewRow();
                e1_anterior = e1_actual;
                e1_actual = new Euler();

                e1_actual.A = e1_anterior.A_prox;
                e1_actual.t = e1_anterior.t_prox;

                e1_actual.dA_dt = -68 - (Math.Pow(e1_actual.A, 2) / 1000);
                e1_actual.t_prox = e1_actual.t + h;
                e1_actual.A_prox = e1_actual.A + h * e1_actual.dA_dt;

                fila["t"] = Math.Round((double)e1_actual.t, 3).ToString("0.000");
                fila["A"] = formatearDouble(e1_actual.A);
                fila["dA / dt"] = formatearDouble(e1_actual.dA_dt);
                fila["t (i+1)"] = formatearDouble(e1_actual.t_prox);
                fila["A (i+1)"] = formatearDouble(e1_actual.A_prox);

                e1_tabla.Rows.Add(fila);

            } while (e1_actual.A > 0);

            demora_a1000 = e1_actual.t;
            grdE1.DataSource = e1_tabla;

            grdE1.Columns["t"].Width = 70;
            grdE1.Columns["A"].Width = 70;
            grdE1.Columns["dA / dt"].Width = 70;
            grdE1.Columns["t (i+1)"].Width = 70;
            grdE1.Columns["A (i+1)"].Width = 70;
        }

        private void armarE2()
        {
            e2_actual = new Euler();
            e2_actual.A_prox = 1500;
            e2_actual.t_prox = 0;

            do
            {
                DataRow fila = e2_tabla.NewRow();
                e2_anterior = e2_actual;
                e2_actual = new Euler();

                e2_actual.A = e2_anterior.A_prox;
                e2_actual.t = e2_anterior.t_prox;

                e2_actual.dA_dt = -68 - (Math.Pow(e2_actual.A, 2) / 1500);
                e2_actual.t_prox = e2_actual.t + h;
                e2_actual.A_prox = e2_actual.A + h * e2_actual.dA_dt;

                fila["t"] = Math.Round((double)e2_actual.t, 3).ToString("0.000");
                fila["A"] = formatearDouble(e2_actual.A);
                fila["dA / dt"] = formatearDouble(e2_actual.dA_dt);
                fila["t (i+1)"] = formatearDouble(e2_actual.t_prox);
                fila["A (i+1)"] = formatearDouble(e2_actual.A_prox);

                e2_tabla.Rows.Add(fila);

            } while (e2_actual.A > 0);

            demora_a1500 = e2_actual.t;
            grdE2.DataSource = e2_tabla;
            
            grdE2.Columns["t"].Width = 70;
            grdE2.Columns["A"].Width = 70;
            grdE2.Columns["dA / dt"].Width = 70;
            grdE2.Columns["t (i+1)"].Width = 70;
            grdE2.Columns["A (i+1)"].Width = 70;

        }

        private void armarE3()
        {
            e3_actual = new Euler();
            e3_actual.A_prox = 2000;
            e3_actual.t_prox = 0;

            do
            {
                DataRow fila = e3_tabla.NewRow();
                e3_anterior = e3_actual;
                e3_actual = new Euler();

                e3_actual.A = e3_anterior.A_prox;
                e3_actual.t = e3_anterior.t_prox;

                e3_actual.dA_dt = -68 - (Math.Pow(e3_actual.A, 2) / 2000);
                e3_actual.t_prox = e3_actual.t + h;
                e3_actual.A_prox = e3_actual.A + h * e3_actual.dA_dt;

                fila["t"] = Math.Round((double)e3_actual.t, 3).ToString("0.000");
                fila["A"] = formatearDouble(e3_actual.A);
                fila["dA / dt"] = formatearDouble(e3_actual.dA_dt);
                fila["t (i+1)"] = formatearDouble(e3_actual.t_prox);
                fila["A (i+1)"] = formatearDouble(e3_actual.A_prox);

                e3_tabla.Rows.Add(fila);

            } while (e3_actual.A > 0);

            demora_a2000 = e3_actual.t;
            grdE3.DataSource = e3_tabla;

            grdE3.Columns["t"].Width = 70;
            grdE3.Columns["A"].Width = 70;
            grdE3.Columns["dA / dt"].Width = 70;
            grdE3.Columns["t (i+1)"].Width = 70;
            grdE3.Columns["A (i+1)"].Width = 70;

        }
        private void cargarColumnasE(DataTable e_tabla)
        {
            e_tabla.Columns.Add("t");
            e_tabla.Columns.Add("A");
            e_tabla.Columns.Add("dA / dt");
            e_tabla.Columns.Add("t (i+1)");
            e_tabla.Columns.Add("A (i+1)");
        }

        private void getValores()
        {
            // Configuro el dia 0
            actual = new VectorEstado();
            simularFilaInicial();
            if(iteracionesAPartirDe == 0)
                imprimirFila();

            int aux_fila = 0;

            for (int nroFilaSimulada = 1; nroFilaSimulada <= filasASimular; nroFilaSimulada++)
            {
                simularFila(nroFilaSimulada);

                if (actual.reloj >= iteracionesAPartirDe && nroFilaSimulada < (aux_fila + iteraciones)) {
                    imprimirFila();
                    if (aux_fila == 0)
                        aux_fila = actual.nro_fila;
                }
            }

            grdSimulacion.DataSource = tabla;
            grdSimulacion.Columns["# Fila"].Frozen = true;
            grdSimulacion.Columns["Evento"].Frozen = true;
            grdSimulacion.Columns["Reloj"].Frozen = true;
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
            reiniciarMantenimiento();

            // contadores y acumuladores
            actual.cant_alumnos_inscriptos = 0;
            actual.cant_alumnos_no_ingresan = 0;
            actual.cant_alumnos_que_llegan = 0;
            actual.cant_horas = 0;
            actual.prom_insc_por_hora_y_maq = 0;
            actual.cola_alumnos = 0;
        }

        private void reiniciarMantenimiento()
        {
            this.rnd_mantenimiento = new double[6];
            actual.personal_mantenimiento = new Mantenimiento("");
            actual.maquinas_mantenidas = 0;
            actual.reiniciarMantenimientoMaquinas();
            proxLlegadaMantenimiento();
        }

        private void proxLlegadaMantenimiento()
        {
            actual.rnd_llegada_mantenimiento = random.NextDouble();
            actual.tiempo_llegada_mantenimiento = DistribucionesContinuas.generarUniforme(llega_mant_A, llega_mant_B, actual.rnd_llegada_mantenimiento);
            actual.prox_llegada_mantenimiento = actual.tiempo_llegada_mantenimiento + actual.reloj;
            actual.prox_eventos.Add(new Evento("Llegada Mantenimiento", actual.prox_llegada_mantenimiento));
        }

        private void proxLlegadaAlumno()
        {
            actual.rnd_llegada_alumno = random.NextDouble();
            actual.tiempo_llegada_alumno = DistribucionesContinuas.generarExponencial(llega_alum_media, actual.rnd_llegada_alumno);
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
            actual.cant_horas = actual.reloj / 60;

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

                case "Fin Mantenimiento":
                    finMantenimiento(evento.nro_referencia);
                    break;

                default:
                    break;
            }

            actual.prox_eventos.Remove(evento);

            actual.prom_insc_por_hora_y_maq = actual.cant_alumnos_inscriptos / (actual.cant_horas * 5);
            actual.porcentaje_de_alumnos_regresan = (double) ((double)actual.cant_alumnos_no_ingresan / (double) actual.cant_alumnos_que_llegan) * (double) 100;
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

            ocuparMaquinaOLiberar(maquina);
        }

        private void ocuparMaquinaOLiberar(Maquina maquina)
        {
            // Verificar si mantenimiento esta esperando
            if (actual.personal_mantenimiento.estado == "Esperando maquina" && !maquina.mantenimiento)
            {
                mantenerMaquina(maquina);
            }
            // verificar si hay gente en cola
            else if (actual.cola_alumnos > 0) 
            {
                Alumno alumno_esperando = actual.getAlumnoEsperando();

                calcularInscripcion();
                maquina.fin_inscripcion = actual.fin_incripcion;
                maquina.estado = "Ocupada";
                alumno_esperando.estado = "Inscribiendo";
                alumno_esperando.maquina = maquina;
                actual.prox_eventos.Add(new Evento("Fin Inscripcion", actual.fin_incripcion, maquina.nro));
                actual.cola_alumnos--;
            }
            else
            {
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
            actual.personal_mantenimiento = anterior.personal_mantenimiento;
            actual.maquinas_mantenidas = anterior.maquinas_mantenidas;
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
            actual.tiempo_incripcion = DistribucionesContinuas.generarUniforme(insc_A, insc_B, actual.rnd_incripcion);
            actual.fin_incripcion = actual.tiempo_incripcion + actual.reloj;
        }

        /*
        private void calcularTiemposMantenimiento()
        {
            for (int i = 0; i < 6; i++)
            {
                this.rnd_mantenimiento[i] = random.NextDouble();
            }
            actual.tiempos_mantenimiento = DistribucionesContinuas.generarNormal(this.rnd_mantenimiento, 3, 0.17);
        }
        */
        private void llegadaMantenimiento()
        {
          //  calcularTiemposMantenimiento();
            mantenerOEsperar();
            actual.prox_llegada_mantenimiento = 0;
        }

        private void mantenerOEsperar()
        {
            Maquina maquina = actual.getMaquinaParaMantener();
            if (!(maquina is null))
            {
                mantenerMaquina(maquina);
            }
            else
            {
                actual.personal_mantenimiento.estado = "Esperando maquina";
            }
        }


        private void mantenerMaquina(Maquina maquina)
        {
            maquina.estado = "Mantenimiento";
            actual.personal_mantenimiento.estado = "Manteniendo maquina";
            actual.rnd_cant_archivos = random.NextDouble();

            if (actual.rnd_cant_archivos < 0.33)
            {
                actual.cant_archivos = 1000;
                actual.tiempo_mantenimiento = demora_a1000;
            }
            else if (actual.rnd_cant_archivos < 0.66)
            {
                actual.cant_archivos = 1500;
                actual.tiempo_mantenimiento = demora_a1500;
            }
            else {
                actual.cant_archivos = 2000;
                actual.tiempo_mantenimiento = demora_a2000;
            }

            actual.fin_mantenimiento = actual.tiempo_mantenimiento + actual.reloj;
            
            maquina.fin_mantenimiento = actual.tiempo_mantenimiento + actual.reloj;
            maquina.fin_inscripcion = null;
            actual.prox_eventos.Add(new Evento("Fin Mantenimiento", actual.tiempo_mantenimiento + actual.reloj, maquina.nro));
        }

        private void finMantenimiento(int nro_maquina)
        {
            actual.maquinas_mantenidas++;
            
            // obtener maquina mantenida
            Maquina maquina = actual.getMaquinaPorNro(nro_maquina);
            maquina.fin_mantenimiento = 0;
            maquina.mantenimiento = true;
            // ocupar maquina mantenida para inscripcion o liberar
            ocuparMaquinaOLiberar(maquina);

            // Validar si termino el mantenimiento
            if (actual.mantenimientoTermino())
            {
                // Fin del mantenimiento
                reiniciarMantenimiento();
            } else
            {

                // iniciar nuevo mantenimiento o esperar
                mantenerOEsperar();
 
            }
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

            tabla.Columns.Add("RND lleg mant");
            tabla.Columns.Add("Tiem lleg mant");
            tabla.Columns.Add("Prox lleg mant");
               
            tabla.Columns.Add("RND Cant Archivos");
            tabla.Columns.Add("Cant Archivos");
            tabla.Columns.Add("Tiempo Man");
            tabla.Columns.Add("Fin Man");

            tabla.Columns.Add("Estado Mantenimiento");
            tabla.Columns.Add("Maquinas Mantenidas");

            tabla.Columns.Add("M1 - Estado");
            tabla.Columns.Add("M1 - Fin inscripcion");
            tabla.Columns.Add("M1 - Mantenimiento");
            tabla.Columns.Add("M1 - Fin Mantenimiento");

            tabla.Columns.Add("M2 - Estado");
            tabla.Columns.Add("M2 - Fin inscripcion");
            tabla.Columns.Add("M2 - Mantenimiento");
            tabla.Columns.Add("M2 - Fin Mantenimiento");

            tabla.Columns.Add("M3 - Estado");
            tabla.Columns.Add("M3 - Fin inscripcion");
            tabla.Columns.Add("M3 - Mantenimiento");
            tabla.Columns.Add("M3 - Fin Mantenimiento");

            tabla.Columns.Add("M4 - Estado");
            tabla.Columns.Add("M4 - Fin inscripcion");
            tabla.Columns.Add("M4 - Mantenimiento");
            tabla.Columns.Add("M4 - Fin Mantenimiento");

            tabla.Columns.Add("M5 - Estado");
            tabla.Columns.Add("M5 - Fin inscripcion");
            tabla.Columns.Add("M5 - Mantenimiento");
            tabla.Columns.Add("M5 - Fin Mantenimiento");

            tabla.Columns.Add("Cola alumnos espera");
            tabla.Columns.Add("Cantidad alumnos inscriptos");
            tabla.Columns.Add("Cantidad alumnos no ingresan");
            tabla.Columns.Add("Cantidad alumnos que llegan");
            tabla.Columns.Add("Porcentaje de alumnos que regresan");
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
            
            TimeSpan r = TimeSpan.FromMinutes(actual.reloj);
            fila["Reloj"] = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", r.Hours, r.Minutes, r.Seconds);
            
            fila["RND lleg alumn"] = formatearDouble(actual.rnd_llegada_alumno);
            fila["Tiem lleg alumn"] = formatearHora(actual.tiempo_llegada_alumno);
            fila["Prox llegada alumn"] = formatearHora(actual.prox_llegada_alumno);
            fila["RND Insc"] = formatearDouble(actual.rnd_incripcion);
            fila["Tiempo insc"] = formatearHora(actual.tiempo_incripcion);
            fila["Fin inscripcion"] = formatearHora(actual.fin_incripcion);

            fila["RND lleg mant"] = formatearDouble(actual.rnd_llegada_mantenimiento);
            fila["Tiem lleg mant"] = formatearHora(actual.tiempo_llegada_mantenimiento);
            fila["Prox lleg mant"] = formatearHora(actual.prox_llegada_mantenimiento);

            fila["RND Cant Archivos"] = formatearDouble(actual.rnd_cant_archivos);
            fila["Cant Archivos"] = formatearDouble(actual.cant_archivos);
            fila["Tiempo Man"] = formatearHora(actual.tiempo_mantenimiento);
            fila["Fin Man"] = formatearHora(actual.fin_mantenimiento);


            fila["Estado Mantenimiento"] = actual.personal_mantenimiento.estado;
            fila["Maquinas Mantenidas"] = actual.maquinas_mantenidas;

            fila["M1 - Estado"] = maquina1.estado;
            fila["M1 - Fin inscripcion"] = formatearHora(maquina1.fin_inscripcion);
            fila["M1 - Mantenimiento"] = maquina1.mantenimiento;
            fila["M1 - Fin Mantenimiento"] = formatearHora(maquina1.fin_mantenimiento);

            fila["M2 - Estado"] = maquina2.estado;
            fila["M2 - Fin inscripcion"] = formatearHora(maquina2.fin_inscripcion);
            fila["M2 - Mantenimiento"] = maquina2.mantenimiento;
            fila["M2 - Fin Mantenimiento"] = formatearHora(maquina2.fin_mantenimiento);

            fila["M3 - Estado"] = maquina3.estado;
            fila["M3 - Fin inscripcion"] = formatearHora(maquina3.fin_inscripcion);
            fila["M3 - Mantenimiento"] = maquina3.mantenimiento;
            fila["M3 - Fin Mantenimiento"] = formatearHora(maquina3.fin_mantenimiento);

            fila["M4 - Estado"] = maquina4.estado;
            fila["M4 - Fin inscripcion"] = formatearHora(maquina4.fin_inscripcion);
            fila["M4 - Mantenimiento"] = maquina4.mantenimiento;
            fila["M4 - Fin Mantenimiento"] = formatearHora(maquina4.fin_mantenimiento);

            fila["M5 - Estado"] = maquina5.estado;
            fila["M5 - Fin inscripcion"] = formatearHora(maquina5.fin_inscripcion);
            fila["M5 - Mantenimiento"] = maquina5.mantenimiento;
            fila["M5 - Fin Mantenimiento"] = formatearHora(maquina5.fin_mantenimiento);


            fila["Cola alumnos espera"] = actual.cola_alumnos;
            fila["Cantidad alumnos inscriptos"] = actual.cant_alumnos_inscriptos;
            fila["Cantidad alumnos no ingresan"] = actual.cant_alumnos_no_ingresan;
            fila["Cantidad alumnos que llegan"] = actual.cant_alumnos_que_llegan;
            fila["Promedio insc por hora y maq"] = Math.Round(actual.prom_insc_por_hora_y_maq, 3).ToString("0.000");
            fila["Porcentaje de alumnos que regresan"] = Math.Round(actual.porcentaje_de_alumnos_regresan, 2).ToString("0.00") + " %";
            
            fila["Cnt horas"] = formatearDouble(actual.cant_horas);

            foreach (var alumno in actual.alumnos)
            {
                if (!tabla.Columns.Contains("A" + alumno.numero + " - Estado")) {
                    tabla.Columns.Add("A" + alumno.numero + " - Estado");
                    tabla.Columns.Add("A" + alumno.numero + " - Hora Regreso");
                }

                fila["A" + alumno.numero + " - Estado"] = alumno.estado;
                fila["A" + alumno.numero + " - Hora Regreso"] = formatearHora(alumno.hora_regreso);
            }

            tabla.Rows.Add(fila);
        }

        public string formatearDouble(double? numero)
        {
            if (numero == 0 || numero is null )
                return "";

            return Math.Round((double)numero, 3).ToString("0.000");
        }
        public string formatearHora(double? minutos)
        {
            if (minutos is null || minutos == 0)
                return "";

            TimeSpan t = TimeSpan.FromMinutes((double) minutos);
            return string.Format("{0:D2}h:{1:D2}m:{2:D2}s", t.Hours, t.Minutes, t.Seconds);
        }
    }
}
