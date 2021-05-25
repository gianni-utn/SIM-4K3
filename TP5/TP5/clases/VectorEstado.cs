using System;
using System.Collections.Generic;

namespace clases
{
    class VectorEstado
    {
        public int nro_fila { get; set; }
        public double reloj { get; set; }
        public string evento { get; set; }
        public double rnd_llegada_alumno { get; set; }
        public double tiempo_llegada_alumno { get; set; }
        public double prox_llegada_alumno { get; set; }
        public double rnd_incripcion { get; set; }
        public double tiempo_incripcion { get; set; }
        public double fin_incripcion { get; set; }
        public double rnd_llegada_mantenimiento { get; set; }
        public double tiempo_llegada_mantenimiento { get; set; }
        public double prox_llegada_mantenimiento { get; set; }
        public double[] rnd_mantenimiento { get; set; }
        public double rnd1_mantenimiento { get; set; }
        public double rnd2_mantenimiento { get; set; }
        public double[] tiempo_mantenimiento { get; set; }
        public int maquinas_mantenidas { get; set; }
        public double[] fin_mantenimiento { get; set; }
        public int cola_alumnos { get; set; }
        public int cant_alumnos_inscriptos { get; set; }
        public int cant_alumnos_no_ingresan { get; set; }
        public int cant_alumnos_que_llegan { get; set; }
        public double prom_insc_por_hora_y_maq { get; set; }
        public int cant_horas { get; set; }
        public List<Maquina> maquinas { get; set; }
        public List<Alumno> alumnos { get; set; }
        public Mantenimiento personal_mantenimiento { get; set; }
        public List<Evento> prox_eventos { get; set; }

        public VectorEstado()
        {

        }
        public Evento getProximoEvento() {
            // contemplar prioridad de mantenimiento
            this.prox_eventos.Sort(delegate (Evento x, Evento y) { return x.tiempo.CompareTo(y.tiempo); });
            return prox_eventos[0];
        }

        public Maquina getMaquinaLibre() {
            foreach (var maquina in this.maquinas)
            {
                if (maquina.estado == "Libre")
                    return maquina;
            }

            return null;
        }

        public Maquina getMaquinaParaMantener()
        {
            foreach (var maquina in this.maquinas)
            {
                if (maquina.estado == "Libre" && !maquina.mantenimiento)
                    return maquina;
            }

            return null;
        }

        public Boolean mantenimientoTermino()
        {
            foreach (var maquina in this.maquinas)
            {
                if (!maquina.mantenimiento)
                    return false;
            }

            return true;
        }

        public Alumno getAlumnoEsperando()
        {
            foreach (var alumno in this.alumnos)
            {
                if (alumno.estado == "Esperando Maquina")
                    return alumno;
            }

            return null;
        }

        public void reiniciarMantenimientoMaquinas()
        {
            foreach (var maquina in this.maquinas)
            {
                maquina.mantenimiento = false;
                maquina.fin_mantenimiento = 0;
            }
        }

        internal Maquina getMaquinaPorNro(int nro_maquina)
        {
            return this.maquinas.Find(delegate (Maquina maquina) { return maquina.nro == nro_maquina; });
        }
        internal Alumno getAlumnoPorNro(int nro_alumno)
        {
            return this.alumnos.Find(delegate (Alumno alumno) { return alumno.numero == nro_alumno; });
        }
        internal Alumno getAlumnoPorMaquina(int nro_maquina)
        {
            return this.alumnos.Find(delegate (Alumno alumno) {
                if (alumno.maquina is null)
                    return false;
                return alumno.maquina.nro == nro_maquina; 
            });
        }
    }
}
